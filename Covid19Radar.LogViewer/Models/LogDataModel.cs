﻿using System;
using System.Globalization;
using System.Windows.Documents;
using System.Windows.Media;

namespace Covid19Radar.LogViewer.Models
{
	public record LogDataModel(
		string Timestamp,
		string Level,
		string OriginalMessage,
		string TransformedMessage,
		string Method,
		string FilePath,
		string LineNumber,
		string Platform,
		string PlatformVersion,
		string DeviceModel,
		string DeviceType,
		string Version,
		string BuildNumber)
	{
		private static readonly SolidColorBrush _method_color    = new(Color.FromRgb(0x00, 0x80, 0xFF));
		private static readonly SolidColorBrush _file_path_color = new(Color.FromRgb(0x80, 0x40, 0x00));
		private static readonly SolidColorBrush _line_num_color  = new(Color.FromRgb(0x80, 0xFF, 0x80));

		public bool TryGetDateTime(out DateTime result)
		{
			return DateTime.TryParseExact(this.Timestamp, "yyyy/MM/dd HH:mm:ss",         null, DateTimeStyles.None, out result)
				|| DateTime.TryParseExact(this.Timestamp, "yyyy/MM/dd HH:mm:ss.fff",     null, DateTimeStyles.None, out result)
				|| DateTime.TryParseExact(this.Timestamp, "yyyy/MM/dd HH:mm:ss.fffffff", null, DateTimeStyles.None, out result)
				|| DateTime.TryParse(this.Timestamp, out result);
		}

		public string GetDateTimeAsString()
		{
			if (this.TryGetDateTime(out var dt)) {
				return dt.ToString("yyyy\'年\'MM\'月\'dd\'日\'\r\nHH\'時\'mm\'分\'ss.fffffff\'秒\'");
			} else {
				return this.Timestamp;
			}
		}

		public LogLevel GetLogLevel()
		{
			return LogLevel.Parse(this.Level);
		}

		public string GetLocation()
		{
			return $"{this.Method} \"{this.FilePath}\"({this.LineNumber})";
		}

		public FlowDocument GetLocationAsFlowDocument()
		{
			return new(new Paragraph() {
				Inlines = {
					new Bold(new Run(this.Method) { Foreground = _method_color }),
					new Run(" \""),
					new Italic(new Run(this.FilePath) { Foreground = _file_path_color }),
					new Run("\"("),
					new Run(this.LineNumber) { Foreground = _line_num_color },
					new Run(")"),
				}
			});
		}
	}
}
