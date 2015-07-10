using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace FeedBuilder
{
	partial class frmMain
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstFiles = new System.Windows.Forms.ListView();
            this.colFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgFiles = new System.Windows.Forms.ImageList(this.components);
            this.fbdOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdFeedXML = new System.Windows.Forms.SaveFileDialog();
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panFiles = new System.Windows.Forms.Panel();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOssSourceRoot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOssAccessKeySecret = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOssAccessKeyID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOssBucketName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOssEndPoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAsServerConfig = new System.Windows.Forms.Button();
            this.btnSaveServerConfig = new System.Windows.Forms.Button();
            this.labelServerConfigPath = new System.Windows.Forms.Label();
            this.btnLoadServerConfig = new System.Windows.Forms.Button();
            this.chkCleanUp = new System.Windows.Forms.CheckBox();
            this.chkCopyFiles = new System.Windows.Forms.CheckBox();
            this.lblIgnore = new System.Windows.Forms.Label();
            this.lblMisc = new System.Windows.Forms.Label();
            this.lblCompare = new System.Windows.Forms.Label();
            this.chkHash = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkSize = new System.Windows.Forms.CheckBox();
            this.chkVersion = new System.Windows.Forms.CheckBox();
            this.chkIgnoreVsHost = new System.Windows.Forms.CheckBox();
            this.chkIgnoreSymbols = new System.Windows.Forms.CheckBox();
            this.cmdFeedXML = new System.Windows.Forms.Button();
            this.lblFeedXML = new System.Windows.Forms.Label();
            this.cmdOutputFolder = new System.Windows.Forms.Button();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnOpenOutputs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPublish = new System.Windows.Forms.ToolStripButton();
            this.btnDeploy = new System.Windows.Forms.ToolStripButton();
            this.btnBuild = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.txtFeedXML = new FeedBuilder.HelpfulTextBox(this.components);
            this.txtOutputFolder = new FeedBuilder.HelpfulTextBox(this.components);
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.panFiles.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.CheckBoxes = true;
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilename,
            this.colVersion,
            this.colSize,
            this.colDate,
            this.colHash});
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.Location = new System.Drawing.Point(0, 15);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(0);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(1091, 194);
            this.lstFiles.SmallImageList = this.imgFiles;
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            // 
            // colFilename
            // 
            this.colFilename.Text = "Filename";
            this.colFilename.Width = 200;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 80;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 80;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDate.Width = 120;
            // 
            // colHash
            // 
            this.colHash.Text = "Hash";
            this.colHash.Width = 300;
            // 
            // imgFiles
            // 
            this.imgFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFiles.ImageStream")));
            this.imgFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFiles.Images.SetKeyName(0, "file_extension_other.png");
            this.imgFiles.Images.SetKeyName(1, "file_extension_bmp.png");
            this.imgFiles.Images.SetKeyName(2, "file_extension_dll.png");
            this.imgFiles.Images.SetKeyName(3, "file_extension_doc.png");
            this.imgFiles.Images.SetKeyName(4, "file_extension_exe.png");
            this.imgFiles.Images.SetKeyName(5, "file_extension_htm.png");
            this.imgFiles.Images.SetKeyName(6, "file_extension_jpg.png");
            this.imgFiles.Images.SetKeyName(7, "file_extension_pdf.png");
            this.imgFiles.Images.SetKeyName(8, "file_extension_png.png");
            this.imgFiles.Images.SetKeyName(9, "file_extension_txt.png");
            this.imgFiles.Images.SetKeyName(10, "file_extension_wav.png");
            this.imgFiles.Images.SetKeyName(11, "file_extension_wmv.png");
            this.imgFiles.Images.SetKeyName(12, "file_extension_zip.png");
            // 
            // fbdOutputFolder
            // 
            this.fbdOutputFolder.Description = "Select your projects output folder:";
            // 
            // sfdFeedXML
            // 
            this.sfdFeedXML.DefaultExt = "xml";
            this.sfdFeedXML.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            this.sfdFeedXML.Title = "Select the location to save your NauXML file:";
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.panFiles);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.grpSettings);
            this.ToolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ToolStripContainer1.ContentPanel.Padding = new System.Windows.Forms.Padding(16, 10, 16, 15);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1123, 586);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(1123, 613);
            this.ToolStripContainer1.TabIndex = 3;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // ToolStripContainer1.TopToolStripPanel
            // 
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.tsMain);
            // 
            // panFiles
            // 
            this.panFiles.Controls.Add(this.lstFiles);
            this.panFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panFiles.Location = new System.Drawing.Point(16, 362);
            this.panFiles.Margin = new System.Windows.Forms.Padding(4);
            this.panFiles.Name = "panFiles";
            this.panFiles.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panFiles.Size = new System.Drawing.Size(1091, 209);
            this.panFiles.TabIndex = 2;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.groupBox1);
            this.grpSettings.Controls.Add(this.chkCleanUp);
            this.grpSettings.Controls.Add(this.chkCopyFiles);
            this.grpSettings.Controls.Add(this.lblIgnore);
            this.grpSettings.Controls.Add(this.lblMisc);
            this.grpSettings.Controls.Add(this.lblCompare);
            this.grpSettings.Controls.Add(this.chkHash);
            this.grpSettings.Controls.Add(this.chkDate);
            this.grpSettings.Controls.Add(this.chkSize);
            this.grpSettings.Controls.Add(this.chkVersion);
            this.grpSettings.Controls.Add(this.chkIgnoreVsHost);
            this.grpSettings.Controls.Add(this.chkIgnoreSymbols);
            this.grpSettings.Controls.Add(this.cmdFeedXML);
            this.grpSettings.Controls.Add(this.txtFeedXML);
            this.grpSettings.Controls.Add(this.lblFeedXML);
            this.grpSettings.Controls.Add(this.cmdOutputFolder);
            this.grpSettings.Controls.Add(this.txtOutputFolder);
            this.grpSettings.Controls.Add(this.lblOutputFolder);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSettings.Location = new System.Drawing.Point(16, 10);
            this.grpSettings.Margin = new System.Windows.Forms.Padding(4);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.grpSettings.Size = new System.Drawing.Size(1091, 352);
            this.grpSettings.TabIndex = 1;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOssSourceRoot);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtOssAccessKeySecret);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOssAccessKeyID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOssBucketName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOssEndPoint);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSaveAsServerConfig);
            this.groupBox1.Controls.Add(this.btnSaveServerConfig);
            this.groupBox1.Controls.Add(this.labelServerConfigPath);
            this.groupBox1.Controls.Add(this.btnLoadServerConfig);
            this.groupBox1.Location = new System.Drawing.Point(23, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 152);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "远程服务器";
            // 
            // txtOssSourceRoot
            // 
            this.txtOssSourceRoot.Location = new System.Drawing.Point(128, 110);
            this.txtOssSourceRoot.Name = "txtOssSourceRoot";
            this.txtOssSourceRoot.Size = new System.Drawing.Size(501, 22);
            this.txtOssSourceRoot.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "OssSourceRoot";
            // 
            // txtOssAccessKeySecret
            // 
            this.txtOssAccessKeySecret.Location = new System.Drawing.Point(783, 79);
            this.txtOssAccessKeySecret.Name = "txtOssAccessKeySecret";
            this.txtOssAccessKeySecret.Size = new System.Drawing.Size(259, 22);
            this.txtOssAccessKeySecret.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "OssAccessKeySecret";
            // 
            // txtOssAccessKeyID
            // 
            this.txtOssAccessKeyID.Location = new System.Drawing.Point(402, 79);
            this.txtOssAccessKeyID.Name = "txtOssAccessKeyID";
            this.txtOssAccessKeyID.Size = new System.Drawing.Size(210, 22);
            this.txtOssAccessKeyID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "OssAccessKeyID";
            // 
            // txtOssBucketName
            // 
            this.txtOssBucketName.Location = new System.Drawing.Point(128, 79);
            this.txtOssBucketName.Name = "txtOssBucketName";
            this.txtOssBucketName.Size = new System.Drawing.Size(139, 22);
            this.txtOssBucketName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "OssBucketName";
            // 
            // txtOssEndPoint
            // 
            this.txtOssEndPoint.Location = new System.Drawing.Point(128, 49);
            this.txtOssEndPoint.Name = "txtOssEndPoint";
            this.txtOssEndPoint.Size = new System.Drawing.Size(501, 22);
            this.txtOssEndPoint.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "OssEndPoint";
            // 
            // btnSaveAsServerConfig
            // 
            this.btnSaveAsServerConfig.Location = new System.Drawing.Point(654, 11);
            this.btnSaveAsServerConfig.Name = "btnSaveAsServerConfig";
            this.btnSaveAsServerConfig.Size = new System.Drawing.Size(78, 29);
            this.btnSaveAsServerConfig.TabIndex = 3;
            this.btnSaveAsServerConfig.Text = "另存为...";
            this.btnSaveAsServerConfig.UseVisualStyleBackColor = true;
            this.btnSaveAsServerConfig.Click += new System.EventHandler(this.btnSaveAsServerConfig_Click);
            // 
            // btnSaveServerConfig
            // 
            this.btnSaveServerConfig.Location = new System.Drawing.Point(565, 11);
            this.btnSaveServerConfig.Name = "btnSaveServerConfig";
            this.btnSaveServerConfig.Size = new System.Drawing.Size(78, 29);
            this.btnSaveServerConfig.TabIndex = 2;
            this.btnSaveServerConfig.Text = "保存";
            this.btnSaveServerConfig.UseVisualStyleBackColor = true;
            this.btnSaveServerConfig.Click += new System.EventHandler(this.btnSaveServerConfig_Click);
            // 
            // labelServerConfigPath
            // 
            this.labelServerConfigPath.AutoSize = true;
            this.labelServerConfigPath.Location = new System.Drawing.Point(180, 17);
            this.labelServerConfigPath.Name = "labelServerConfigPath";
            this.labelServerConfigPath.Size = new System.Drawing.Size(204, 17);
            this.labelServerConfigPath.TabIndex = 1;
            this.labelServerConfigPath.Text = "请点击加载按钮选择服务器文件";
            // 
            // btnLoadServerConfig
            // 
            this.btnLoadServerConfig.Location = new System.Drawing.Point(96, 11);
            this.btnLoadServerConfig.Name = "btnLoadServerConfig";
            this.btnLoadServerConfig.Size = new System.Drawing.Size(78, 29);
            this.btnLoadServerConfig.TabIndex = 0;
            this.btnLoadServerConfig.Text = "加载...";
            this.btnLoadServerConfig.UseVisualStyleBackColor = true;
            this.btnLoadServerConfig.Click += new System.EventHandler(this.btnLoadServerConfig_Click);
            // 
            // chkCleanUp
            // 
            this.chkCleanUp.AutoSize = true;
            this.chkCleanUp.Checked = true;
            this.chkCleanUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCleanUp.Location = new System.Drawing.Point(391, 286);
            this.chkCleanUp.Margin = new System.Windows.Forms.Padding(4);
            this.chkCleanUp.Name = "chkCleanUp";
            this.chkCleanUp.Size = new System.Drawing.Size(174, 21);
            this.chkCleanUp.TabIndex = 17;
            this.chkCleanUp.Text = "Clean Unselected Files";
            this.chkCleanUp.UseVisualStyleBackColor = true;
            // 
            // chkCopyFiles
            // 
            this.chkCopyFiles.AutoSize = true;
            this.chkCopyFiles.Checked = true;
            this.chkCopyFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyFiles.Location = new System.Drawing.Point(195, 286);
            this.chkCopyFiles.Margin = new System.Windows.Forms.Padding(4);
            this.chkCopyFiles.Name = "chkCopyFiles";
            this.chkCopyFiles.Size = new System.Drawing.Size(181, 21);
            this.chkCopyFiles.TabIndex = 16;
            this.chkCopyFiles.Text = "Copy Files with NauXML";
            this.chkCopyFiles.UseVisualStyleBackColor = true;
            this.chkCopyFiles.CheckedChanged += new System.EventHandler(this.chkCopyFiles_CheckedChanged);
            // 
            // lblIgnore
            // 
            this.lblIgnore.AutoSize = true;
            this.lblIgnore.Location = new System.Drawing.Point(20, 322);
            this.lblIgnore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIgnore.Name = "lblIgnore";
            this.lblIgnore.Size = new System.Drawing.Size(52, 17);
            this.lblIgnore.TabIndex = 15;
            this.lblIgnore.Text = "Ignore:";
            // 
            // lblMisc
            // 
            this.lblMisc.AutoSize = true;
            this.lblMisc.Location = new System.Drawing.Point(20, 288);
            this.lblMisc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(40, 17);
            this.lblMisc.TabIndex = 15;
            this.lblMisc.Text = "Misc:";
            // 
            // lblCompare
            // 
            this.lblCompare.AutoSize = true;
            this.lblCompare.Location = new System.Drawing.Point(20, 253);
            this.lblCompare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(69, 17);
            this.lblCompare.TabIndex = 14;
            this.lblCompare.Text = "Compare:";
            // 
            // chkHash
            // 
            this.chkHash.AutoSize = true;
            this.chkHash.Checked = true;
            this.chkHash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHash.Location = new System.Drawing.Point(427, 252);
            this.chkHash.Margin = new System.Windows.Forms.Padding(4);
            this.chkHash.Name = "chkHash";
            this.chkHash.Size = new System.Drawing.Size(63, 21);
            this.chkHash.TabIndex = 13;
            this.chkHash.Text = "Hash";
            this.chkHash.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(353, 252);
            this.chkDate.Margin = new System.Windows.Forms.Padding(4);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(60, 21);
            this.chkDate.TabIndex = 12;
            this.chkDate.Text = "Date";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // chkSize
            // 
            this.chkSize.AutoSize = true;
            this.chkSize.Location = new System.Drawing.Point(284, 252);
            this.chkSize.Margin = new System.Windows.Forms.Padding(4);
            this.chkSize.Name = "chkSize";
            this.chkSize.Size = new System.Drawing.Size(57, 21);
            this.chkSize.TabIndex = 11;
            this.chkSize.Text = "Size";
            this.chkSize.UseVisualStyleBackColor = true;
            // 
            // chkVersion
            // 
            this.chkVersion.AutoSize = true;
            this.chkVersion.Checked = true;
            this.chkVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVersion.Location = new System.Drawing.Point(195, 252);
            this.chkVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.chkVersion.Name = "chkVersion";
            this.chkVersion.Size = new System.Drawing.Size(78, 21);
            this.chkVersion.TabIndex = 10;
            this.chkVersion.Text = "Version";
            this.chkVersion.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreVsHost
            // 
            this.chkIgnoreVsHost.AutoSize = true;
            this.chkIgnoreVsHost.Checked = true;
            this.chkIgnoreVsHost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreVsHost.Location = new System.Drawing.Point(391, 321);
            this.chkIgnoreVsHost.Margin = new System.Windows.Forms.Padding(4);
            this.chkIgnoreVsHost.Name = "chkIgnoreVsHost";
            this.chkIgnoreVsHost.Size = new System.Drawing.Size(133, 21);
            this.chkIgnoreVsHost.TabIndex = 7;
            this.chkIgnoreVsHost.Text = "VS Hosting Files";
            this.chkIgnoreVsHost.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreSymbols
            // 
            this.chkIgnoreSymbols.AutoSize = true;
            this.chkIgnoreSymbols.Checked = true;
            this.chkIgnoreSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreSymbols.Location = new System.Drawing.Point(195, 321);
            this.chkIgnoreSymbols.Margin = new System.Windows.Forms.Padding(4);
            this.chkIgnoreSymbols.Name = "chkIgnoreSymbols";
            this.chkIgnoreSymbols.Size = new System.Drawing.Size(129, 21);
            this.chkIgnoreSymbols.TabIndex = 7;
            this.chkIgnoreSymbols.Text = "Debug Symbols";
            this.chkIgnoreSymbols.UseVisualStyleBackColor = true;
            this.chkIgnoreSymbols.CheckedChanged += new System.EventHandler(this.chkIgnoreSymbols_CheckedChanged);
            // 
            // cmdFeedXML
            // 
            this.cmdFeedXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFeedXML.Location = new System.Drawing.Point(1036, 65);
            this.cmdFeedXML.Margin = new System.Windows.Forms.Padding(4);
            this.cmdFeedXML.Name = "cmdFeedXML";
            this.cmdFeedXML.Size = new System.Drawing.Size(35, 28);
            this.cmdFeedXML.TabIndex = 5;
            this.cmdFeedXML.Text = "...";
            this.cmdFeedXML.UseVisualStyleBackColor = true;
            this.cmdFeedXML.Click += new System.EventHandler(this.cmdFeedXML_Click);
            // 
            // lblFeedXML
            // 
            this.lblFeedXML.AutoSize = true;
            this.lblFeedXML.Location = new System.Drawing.Point(20, 71);
            this.lblFeedXML.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeedXML.Name = "lblFeedXML";
            this.lblFeedXML.Size = new System.Drawing.Size(128, 17);
            this.lblFeedXML.TabIndex = 3;
            this.lblFeedXML.Text = "Feed NauXML File:";
            // 
            // cmdOutputFolder
            // 
            this.cmdOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOutputFolder.Location = new System.Drawing.Point(1036, 27);
            this.cmdOutputFolder.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOutputFolder.Name = "cmdOutputFolder";
            this.cmdOutputFolder.Size = new System.Drawing.Size(35, 28);
            this.cmdOutputFolder.TabIndex = 2;
            this.cmdOutputFolder.Text = "...";
            this.cmdOutputFolder.UseVisualStyleBackColor = true;
            this.cmdOutputFolder.Click += new System.EventHandler(this.cmdOutputFolder_Click);
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(20, 33);
            this.lblOutputFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(147, 17);
            this.lblOutputFolder.TabIndex = 0;
            this.lblOutputFolder.Text = "Project Output Folder:";
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.tsSeparator1,
            this.btnRefresh,
            this.btnOpenOutputs,
            this.toolStripSeparator1,
            this.btnPublish,
            this.btnDeploy,
            this.btnBuild});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1123, 27);
            this.tsMain.Stretch = true;
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "Commands";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(24, 24);
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(24, 24);
            this.btnOpen.Text = "&Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(91, 24);
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 24);
            this.btnRefresh.Text = "Refresh Files";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenOutputs
            // 
            this.btnOpenOutputs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOpenOutputs.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenOutputs.Image")));
            this.btnOpenOutputs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenOutputs.Name = "btnOpenOutputs";
            this.btnOpenOutputs.Size = new System.Drawing.Size(175, 24);
            this.btnOpenOutputs.Text = "Open Output Folder";
            this.btnOpenOutputs.Click += new System.EventHandler(this.btnOpenOutputs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPublish
            // 
            this.btnPublish.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPublish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPublish.Image = ((System.Drawing.Image)(resources.GetObject("btnPublish.Image")));
            this.btnPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(67, 24);
            this.btnPublish.Text = "Publish";
            // 
            // btnDeploy
            // 
            this.btnDeploy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDeploy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeploy.Image = ((System.Drawing.Image)(resources.GetObject("btnDeploy.Image")));
            this.btnDeploy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(59, 24);
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnBuild.Image = ((System.Drawing.Image)(resources.GetObject("btnBuild.Image")));
            this.btnBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(71, 24);
            this.btnBuild.Text = "Build";
            this.btnBuild.Click += new System.EventHandler(this.cmdBuild_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // txtFeedXML
            // 
            this.txtFeedXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedXML.BackColor = System.Drawing.Color.White;
            this.txtFeedXML.HelpfulText = "The file your application downloads to determine if there are updates";
            this.txtFeedXML.Location = new System.Drawing.Point(195, 68);
            this.txtFeedXML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.txtFeedXML.Name = "txtFeedXML";
            this.txtFeedXML.Size = new System.Drawing.Size(832, 22);
            this.txtFeedXML.TabIndex = 4;
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.BackColor = System.Drawing.Color.White;
            this.txtOutputFolder.HelpfulText = "The folder that contains the files you want to distribute";
            this.txtOutputFolder.Location = new System.Drawing.Point(195, 30);
            this.txtOutputFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(832, 22);
            this.txtOutputFolder.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1123, 613);
            this.Controls.Add(this.ToolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1131, 645);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feed Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.panFiles.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog fbdOutputFolder;
		private System.Windows.Forms.SaveFileDialog sfdFeedXML;
		private System.Windows.Forms.ImageList imgFiles;
		private System.Windows.Forms.ListView lstFiles;
		private System.Windows.Forms.ColumnHeader colFilename;
		private System.Windows.Forms.ColumnHeader colVersion;
		private System.Windows.Forms.ColumnHeader colSize;
		private System.Windows.Forms.ColumnHeader colDate;
		private System.Windows.Forms.ColumnHeader colHash;
		private System.Windows.Forms.ToolStripContainer ToolStripContainer1;
		private System.Windows.Forms.GroupBox grpSettings;
		private System.Windows.Forms.CheckBox chkCleanUp;
		private System.Windows.Forms.CheckBox chkCopyFiles;
		private System.Windows.Forms.Label lblIgnore;
		private System.Windows.Forms.Label lblMisc;
		private System.Windows.Forms.Label lblCompare;
		private System.Windows.Forms.CheckBox chkHash;
		private System.Windows.Forms.CheckBox chkDate;
		private System.Windows.Forms.CheckBox chkSize;
		private System.Windows.Forms.CheckBox chkVersion;
		private System.Windows.Forms.CheckBox chkIgnoreVsHost;
		private System.Windows.Forms.CheckBox chkIgnoreSymbols;
		private System.Windows.Forms.Button cmdFeedXML;
		private HelpfulTextBox txtFeedXML;
		private System.Windows.Forms.Label lblFeedXML;
		private System.Windows.Forms.Button cmdOutputFolder;
		private HelpfulTextBox txtOutputFolder;
		private System.Windows.Forms.Label lblOutputFolder;
		private Panel panFiles;
        private ErrorProvider errorProvider1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStrip tsMain;
        private ToolStripButton btnNew;
        private ToolStripButton btnOpen;
        private ToolStripButton btnSave;
        private ToolStripButton btnSaveAs;
        private ToolStripSeparator tsSeparator1;
        private ToolStripButton btnRefresh;
        private ToolStripButton btnOpenOutputs;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDeploy;
        private ToolStripButton btnBuild;
        private ToolStripButton btnPublish;
        private GroupBox groupBox1;
        private Button btnLoadServerConfig;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Label labelServerConfigPath;
        private Button btnSaveAsServerConfig;
        private Button btnSaveServerConfig;
        private Label label1;
        private TextBox txtOssEndPoint;
        private TextBox txtOssAccessKeyID;
        private Label label3;
        private TextBox txtOssBucketName;
        private Label label2;
        private TextBox txtOssAccessKeySecret;
        private Label label4;
        private Label label5;
        private TextBox txtOssSourceRoot;
    }
}
