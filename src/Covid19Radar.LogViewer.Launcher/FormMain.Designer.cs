/****
 * CocoaLogViewer
 * Copyright (C) 2020-2021 Yigty.ORG; all rights reserved.
 * Copyright (C) 2020-2021 Takym.
 *
 * distributed under the MIT License.
****/

namespace Covid19Radar.LogViewer.Launcher
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnOpen = new System.Windows.Forms.Button();
			this.viewers = new System.Windows.Forms.ListBox();
			this.labelVersion = new System.Windows.Forms.Label();
			this.cboxAllowEscape = new System.Windows.Forms.CheckBox();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.ContextMenuStrip = this.contextMenuStrip;
			this.btnOpen.Location = new System.Drawing.Point(8, 8);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(160, 23);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "btnOpen";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// viewers
			// 
			this.viewers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.viewers.FormattingEnabled = true;
			this.viewers.ItemHeight = 15;
			this.viewers.Location = new System.Drawing.Point(8, 56);
			this.viewers.Name = "viewers";
			this.viewers.Size = new System.Drawing.Size(480, 379);
			this.viewers.TabIndex = 3;
			this.viewers.SelectedIndexChanged += new System.EventHandler(this.viewers_SelectedIndexChanged);
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(176, 12);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(70, 15);
			this.labelVersion.TabIndex = 1;
			this.labelVersion.Text = "labelVersion";
			// 
			// cboxAllowEscape
			// 
			this.cboxAllowEscape.AutoSize = true;
			this.cboxAllowEscape.Location = new System.Drawing.Point(8, 32);
			this.cboxAllowEscape.Name = "cboxAllowEscape";
			this.cboxAllowEscape.Size = new System.Drawing.Size(118, 19);
			this.cboxAllowEscape.TabIndex = 2;
			this.cboxAllowEscape.Text = "cboxAllowEscape";
			this.cboxAllowEscape.UseVisualStyleBackColor = true;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
			// 
			// FormMain
			// 
			this.AcceptButton = this.btnOpen;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 441);
			this.Controls.Add(this.cboxAllowEscape);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.viewers);
			this.Controls.Add(this.btnOpen);
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ListBox viewers;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.CheckBox cboxAllowEscape;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
	}
}

