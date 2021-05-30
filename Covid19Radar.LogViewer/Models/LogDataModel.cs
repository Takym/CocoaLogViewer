/****
 * CocoaLogViewer
 * Copyright (C) 2020-2021 Yigty.ORG; all rights reserved.
 * Copyright (C) 2020-2021 Takym.
 *
 * distributed under the MIT License.
****/

using System;
using System.Globalization;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;
using Covid19Radar.LogViewer.Globalization;

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

		public string GetDateTimeAsString(bool wrap = true)
		{
			if (this.TryGetDateTime(out var dt)) {
				return dt.ToString(
					wrap ? LanguageData.Current.LogDataModel_DateTime_Format_WithWordWrap
					     : LanguageData.Current.LogDataModel_DateTime_Format_WithNoWrap
				);
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

		public string CreateDetails()
		{
			var sb = StringBuilderCache<LogDataModel>.Get();
			this.CreateDetails(sb);
			return sb.ToString();
		}

		public void CreateDetails(StringBuilder sb)
		{
			sb.AppendFormat(
				LanguageData.Current.LogDataModel_DateTime,
				this.GetDateTimeAsString()
			).AppendLine();
			sb.AppendFormat(
				LanguageData.Current.LogDataModel_LogLevel,
				this.GetLogLevel().Text
			).AppendLine();
			sb.AppendFormat(
				LanguageData.Current.LogDataModel_Location,
				this.GetLocation()
			).AppendLine();
			if (this.OriginalMessage == this.TransformedMessage) {
				sb.AppendFormat(
					LanguageData.Current.LogDataModel_Message,
					this.OriginalMessage
				).AppendLine();
			} else {
				sb.AppendFormat(
					LanguageData.Current.LogDataModel_Message_Transformed,
					this.TransformedMessage
				).AppendLine();
				sb.AppendFormat(
					LanguageData.Current.LogDataModel_Message_Original,
					this.OriginalMessage
				).AppendLine();
			}
			sb.AppendFormat(
				LanguageData.Current.LogDataModel_Platform,
				this.Platform,
				this.PlatformVersion
			).AppendLine();
			sb.AppendFormat(
				LanguageData.Current.LogDataModel_Device,
				this.DeviceModel,
				this.DeviceType
			).AppendLine();
			sb.AppendFormat(
				LanguageData.Current.LogDataModel_Version,
				this.Version,
				this.BuildNumber
			).AppendLine();
		}

		public static void CreateMarkdownHeader(StringBuilder sb)
		{
			sb
				.AppendLine("***")
				.AppendLine()
				.AppendFormat(
					"|{0}|{1}|{2}|{3}|",
					LanguageData.Current.LogHeaderView_Timestamp,
					LanguageData.Current.LogHeaderView_Level,
					LanguageData.Current.LogHeaderView_Location,
					LanguageData.Current.LogHeaderView_Message
				)
				.AppendLine()
				.AppendLine("|:--|:-:|:--|:--|");
		}

		public void CreateDetailsAsMarkdown(StringBuilder sb)
		{
			sb
				.Append('|')
				.Append(this.GetDateTimeAsString(false))
				.Append('|')
				.Append(this.GetLogLevel().Text)
				.Append('|')
				.Append(this.GetLocation())
				.Append('|')
				.Append(this.TransformedMessage)
				.Append('|');
		}

		public static void CreateMarkdownFooter(StringBuilder sb)
		{
			sb
				.AppendLine()
				.AppendLine("Generated by [CocoaLogViewer](https://github.com/YigtyORG/CocoaLogViewer).")
				.AppendLine("***")
				.AppendLine();
		}
	}
}
