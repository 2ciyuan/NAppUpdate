using FeedBuilder.Properties;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Linq;

namespace FeedBuilder
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region " Private constants/variables"
        FeedBuilder.ServerProfile.ServerProfile _serverProfile = null;

        private const string DialogFilter = "Feed configuration files (*.config)|*.config|All files (*.*)|*.*";
        private const string DefaultFileName = "FeedBuilder.config";
        private OpenFileDialog _openDialog;

        #endregion

        private ArgumentsParser _argParser;

        #region " Properties"

        public string FileName { get; set; }
        public bool ShowGui { get; set; }

        #endregion

        #region " Loading/Initialization/Lifetime"

        private void frmMain_Load(Object sender, EventArgs e)
        {
            Visible = false;
            InitializeFormSettings();
            string[] args = Environment.GetCommandLineArgs();
            // The first arg is the path to ourself
            //If args.Count >= 2 Then
            //    If File.Exists(args(1)) Then
            //        Dim p As New FeedBuilderSettingsProvider()
            //        p.LoadFrom(args(1))
            //        Me.FileName = args(1)
            //    End If
            //End If

            // The first arg is the path to ourself
            _argParser = new ArgumentsParser(args);
            if (!_argParser.HasArgs) return;
            FileName = _argParser.FileName;
            if (!string.IsNullOrEmpty(FileName))
            {
                if (File.Exists(FileName))
                {
                    FeedBuilderSettingsProvider p = new FeedBuilderSettingsProvider();
                    p.LoadFrom(FileName);
                }
                else
                {
                    _argParser.ShowGui = true;
                    _argParser.Build = false;
                    FileName = _argParser.FileName;
                    UpdateTitle();
                }
            }
            if (_argParser.ShowGui) Show();
            if (_argParser.Build) Build();
            if (!_argParser.ShowGui) Close();
        }

        private void InitializeFormSettings()
        {
            if (!string.IsNullOrEmpty(Settings.Default.OutputFolder) && Directory.Exists(Settings.Default.OutputFolder)) txtOutputFolder.Text = Settings.Default.OutputFolder;
            if (!string.IsNullOrEmpty(Settings.Default.FeedXML)) txtFeedXML.Text = Settings.Default.FeedXML;

            chkVersion.Checked = Settings.Default.CompareVersion;
            chkSize.Checked = Settings.Default.CompareSize;
            chkDate.Checked = Settings.Default.CompareDate;
            chkHash.Checked = Settings.Default.CompareHash;

            chkIgnoreSymbols.Checked = Settings.Default.IgnoreDebugSymbols;
            chkIgnoreVsHost.Checked = Settings.Default.IgnoreVsHosting;
            chkIgnoreUpdateFeed.Checked = Settings.Default.IgnoreUpdateFeed;
            chkCopyFiles.Checked = Settings.Default.CopyFiles;
            chkCleanUp.Checked = Settings.Default.CleanUp;
            labelServerConfigPath.Text = Settings.Default.ServerConfigFilePath;

            if (Settings.Default.IgnoreFiles == null) Settings.Default.IgnoreFiles = new StringCollection();
            ReadFiles();
            UpdateTitle();
            LoadProFile(Settings.Default.ServerConfigFilePath);
        }

        private void UpdateTitle()
        {
            if (string.IsNullOrEmpty(FileName)) Text = "Feed Builder";
            else Text = "Feed Builder - " + FileName;
        }

        private void SaveFormSettings()
        {

            if (!string.IsNullOrEmpty(txtOutputFolder.Text.Trim()) && Directory.Exists(txtOutputFolder.Text.Trim())) Settings.Default.OutputFolder = txtOutputFolder.Text.Trim();
            // ReSharper disable AssignNullToNotNullAttribute
            if (!string.IsNullOrEmpty(txtFeedXML.Text.Trim()) && Directory.Exists(Path.GetDirectoryName(txtFeedXML.Text.Trim()))) Settings.Default.FeedXML = txtFeedXML.Text.Trim();

            Settings.Default.CompareVersion = chkVersion.Checked;
            Settings.Default.CompareSize = chkSize.Checked;
            Settings.Default.CompareDate = chkDate.Checked;
            Settings.Default.CompareHash = chkHash.Checked;

            Settings.Default.IgnoreDebugSymbols = chkIgnoreSymbols.Checked;
            Settings.Default.IgnoreVsHosting = chkIgnoreVsHost.Checked;
            Settings.Default.IgnoreUpdateFeed = chkIgnoreUpdateFeed.Checked;
            Settings.Default.CopyFiles = chkCopyFiles.Checked;
            Settings.Default.CleanUp = chkCleanUp.Checked;
            Settings.Default.ServerConfigFilePath = labelServerConfigPath.Text;

            if (Settings.Default.IgnoreFiles == null) Settings.Default.IgnoreFiles = new StringCollection();
            Settings.Default.IgnoreFiles.Clear();
            foreach (ListViewItem thisItem in lstFiles.Items)
            {
                if (!thisItem.Checked) Settings.Default.IgnoreFiles.Add(thisItem.Text);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormSettings();
        }

        #endregion

        #region " Commands Events"

        private void btnOpenOutputs_Click(object sender, EventArgs e)
        {
            OpenOutputsFolder();
        }

        private void btnNew_Click(Object sender, EventArgs e)
        {
            Settings.Default.Reset();
            InitializeFormSettings();
        }

        private void btnOpen_Click(Object sender, EventArgs e)
        {
            OpenFileDialog dlg;
            if (_openDialog == null)
            {
                dlg = new OpenFileDialog
                {
                    CheckFileExists = true,
                    FileName = string.IsNullOrEmpty(FileName) ? DefaultFileName : FileName
                };
                _openDialog = dlg;
            }
            else dlg = _openDialog;
            dlg.Filter = DialogFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;
            FeedBuilderSettingsProvider p = new FeedBuilderSettingsProvider();
            p.LoadFrom(dlg.FileName);
            FileName = dlg.FileName;
            InitializeFormSettings();
        }

        private void btnSave_Click(Object sender, EventArgs e)
        {
            Save(false);
        }

        private void btnSaveAs_Click(Object sender, EventArgs e)
        {
            Save(true);
        }

        private void btnRefresh_Click(Object sender, EventArgs e)
        {
            ReadFiles();
        }

        #endregion

        #region " Options Events"

        private void cmdOutputFolder_Click(Object sender, EventArgs e)
        {
            fbdOutputFolder.SelectedPath = Directory.GetCurrentDirectory();
            if (fbdOutputFolder.ShowDialog(this) != DialogResult.OK) return;
            txtOutputFolder.Text = fbdOutputFolder.SelectedPath;
            ReadFiles();
        }

        private void cmdFeedXML_Click(Object sender, EventArgs e)
        {
            sfdFeedXML.SelectedPath = Directory.GetCurrentDirectory();
            if (sfdFeedXML.ShowDialog(this) != DialogResult.OK) return;
            txtFeedXML.Text = sfdFeedXML.SelectedPath + @"\UpdateFeed.xml";
        }

        private void chkIgnoreSymbols_CheckedChanged(object sender, EventArgs e)
        {
            ReadFiles();
        }

        private void chkCopyFiles_CheckedChanged(Object sender, EventArgs e)
        {
            chkCleanUp.Enabled = chkCopyFiles.Checked;
            if (!chkCopyFiles.Checked) chkCleanUp.Checked = false;
        }

        #endregion

        #region " Helper Methods "

        private void Build()
        {
            if (string.IsNullOrEmpty(txtFeedXML.Text))
            {
                const string msg = "The feed file location needs to be defined.\n" + "The outputs cannot be generated without this.";
                if (_argParser.ShowGui) MessageBox.Show(msg);
                Console.WriteLine(msg);
                return;
            }
            // If the target folder doesn't exist, create a path to it
            string dest = txtFeedXML.Text.Trim();
            var destDir = Directory.GetParent(new FileInfo(dest).FullName);
            if (!Directory.Exists(destDir.FullName)) Directory.CreateDirectory(destDir.FullName);

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);

            doc.AppendChild(dec);
            XmlElement feed = doc.CreateElement("Feed");
            doc.AppendChild(feed);

            XmlElement tasks = doc.CreateElement("Tasks");

            Console.WriteLine("Processing feed items");
            int itemsCopied = 0;
            int itemsCleaned = 0;
            int itemsSkipped = 0;
            int itemsFailed = 0;
            int itemsMissingConditions = 0;
            foreach (ListViewItem thisItem in lstFiles.Items)
            {
                string destFile = "";
                string folder = "";
                string filename = "";
                try
                {
                    folder = Path.GetDirectoryName(txtFeedXML.Text.Trim());
                    filename = thisItem.Text;
                    if (folder != null) destFile = Path.Combine(folder, filename);
                }
                catch { }
                if (destFile == "" || folder == "" || filename == "")
                {
                    string msg = string.Format("The file could not be pathed:\nFolder:'{0}'\nFile:{1}", folder, filename);
                    if (_argParser.ShowGui) MessageBox.Show(msg);
                    Console.WriteLine(msg);
                    continue;
                }

                if (thisItem.Checked)
                {
                    var fileInfoEx = (FileInfoEx)thisItem.Tag;
                    XmlElement task = doc.CreateElement("FileUpdateTask");
                    task.SetAttribute("localPath", fileInfoEx.RelativeName);

                    // generate FileUpdateTask metadata items
                    task.SetAttribute("lastModified", fileInfoEx.FileInfo.LastWriteTime.ToFileTime().ToString(CultureInfo.InvariantCulture));
                    task.SetAttribute("fileSize", fileInfoEx.FileInfo.Length.ToString(CultureInfo.InvariantCulture));
                    if (!string.IsNullOrEmpty(fileInfoEx.FileVersion)) task.SetAttribute("version", fileInfoEx.FileVersion);

                    XmlElement conds = doc.CreateElement("Conditions");
                    XmlElement cond;
                    bool hasFirstCondition = false;

                    //File Exists
                    cond = doc.CreateElement("FileExistsCondition");
                    cond.SetAttribute("type", "or");
                    conds.AppendChild(cond);


                    //Version
                    if (chkVersion.Checked && !string.IsNullOrEmpty(fileInfoEx.FileVersion))
                    {
                        cond = doc.CreateElement("FileVersionCondition");
                        cond.SetAttribute("what", "below");
                        cond.SetAttribute("version", fileInfoEx.FileVersion);
                        conds.AppendChild(cond);
                        hasFirstCondition = true;
                    }

                    //Size
                    if (chkSize.Checked)
                    {
                        cond = doc.CreateElement("FileSizeCondition");
                        cond.SetAttribute("type", hasFirstCondition ? "or-not" : "not");
                        cond.SetAttribute("what", "is");
                        cond.SetAttribute("size", fileInfoEx.FileInfo.Length.ToString(CultureInfo.InvariantCulture));
                        conds.AppendChild(cond);
                    }

                    //Date
                    if (chkDate.Checked)
                    {
                        cond = doc.CreateElement("FileDateCondition");
                        if (hasFirstCondition) cond.SetAttribute("type", "or");
                        cond.SetAttribute("what", "older");
                        // local timestamp, not UTC
                        cond.SetAttribute("timestamp", fileInfoEx.FileInfo.LastWriteTime.ToFileTime().ToString(CultureInfo.InvariantCulture));
                        conds.AppendChild(cond);
                    }

                    //Hash
                    if (chkHash.Checked)
                    {
                        cond = doc.CreateElement("FileChecksumCondition");
                        cond.SetAttribute("type", hasFirstCondition ? "or-not" : "not");
                        cond.SetAttribute("checksumType", "sha256");
                        cond.SetAttribute("checksum", fileInfoEx.Hash);
                        conds.AppendChild(cond);
                    }

                    if (conds.ChildNodes.Count == 0) itemsMissingConditions++;
                    task.AppendChild(conds);
                    tasks.AppendChild(task);

                    if (chkCopyFiles.Checked)
                    {
                        if (CopyFile(fileInfoEx.FileInfo.FullName, destFile)) itemsCopied++;
                        else itemsFailed++;
                    }
                }
                else
                {
                    try
                    {
                        if (chkCleanUp.Checked & File.Exists(destFile))
                        {
                            File.Delete(destFile);
                            itemsCleaned += 1;
                        }
                        else itemsSkipped += 1;
                    }
                    catch (IOException)
                    {
                        itemsFailed += 1;
                    }
                }
            }
            feed.AppendChild(tasks);
            doc.Save(txtFeedXML.Text.Trim());

            // open the outputs folder if we're running from the GUI or 
            // we have an explicit command line option to do so
            if (!_argParser.HasArgs || _argParser.OpenOutputsFolder) OpenOutputsFolder();
            Console.WriteLine("Done building feed.");
            if (itemsCopied > 0) Console.WriteLine("{0,5} items copied", itemsCopied);
            if (itemsCleaned > 0) Console.WriteLine("{0,5} items cleaned", itemsCleaned);
            if (itemsSkipped > 0) Console.WriteLine("{0,5} items skipped", itemsSkipped);
            if (itemsFailed > 0) Console.WriteLine("{0,5} items failed", itemsFailed);
            if (itemsMissingConditions > 0) Console.WriteLine("{0,5} items without any conditions", itemsMissingConditions);
        }

        private bool CopyFile(string sourceFile, string destFile)
        {
            // If the target folder doesn't exist, create the path to it
            var fi = new FileInfo(destFile);
            var d = Directory.GetParent(fi.FullName);
            if (!Directory.Exists(d.FullName)) CreateDirectoryPath(d.FullName);

            // Copy with delayed retry
            int retries = 3;
            while (retries > 0)
            {
                try
                {
                    if (File.Exists(destFile)) File.Delete(destFile);
                    File.Copy(sourceFile, destFile);
                    retries = 0; // success
                    return true;
                }
                catch (IOException)
                {
                    // Failed... let's try sleeping a bit (slow disk maybe)
                    if (retries-- > 0) Thread.Sleep(200);
                }
                catch (UnauthorizedAccessException)
                {
                    // same handling as IOException
                    if (retries-- > 0) Thread.Sleep(200);
                }
            }
            return false;
        }

        private void CreateDirectoryPath(string directoryPath)
        {
            // Create the folder/path if it doesn't exist, with delayed retry
            int retries = 3;
            while (retries > 0 && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                if (retries-- < 3) Thread.Sleep(200);
            }
        }

        private void OpenOutputsFolder()
        {
            string dir = Path.GetDirectoryName(txtFeedXML.Text.Trim());
            if (dir == null) return;
            CreateDirectoryPath(dir);
            Process process = new Process
            {
                StartInfo = {
                    UseShellExecute = true,
                    FileName = dir
                }
            };
            process.Start();
        }

        private int GetImageIndex(string ext)
        {
            switch (ext.Trim('.'))
            {
                case "bmp":
                    return 1;
                case "dll":
                    return 2;
                case "doc":
                case "docx":
                    return 3;
                case "exe":
                    return 4;
                case "htm":
                case "html":
                    return 5;
                case "jpg":
                case "jpeg":
                    return 6;
                case "pdf":
                    return 7;
                case "png":
                    return 8;
                case "txt":
                    return 9;
                case "wav":
                case "mp3":
                    return 10;
                case "wmv":
                    return 11;
                case "xls":
                case "xlsx":
                    return 12;
                case "zip":
                    return 13;
                default:
                    return 0;
            }
        }

        private void ReadFiles()
        {
            if (string.IsNullOrEmpty(txtOutputFolder.Text.Trim()) || !Directory.Exists(txtOutputFolder.Text.Trim())) return;

            lstFiles.BeginUpdate();
            lstFiles.Items.Clear();

            string outputDir = txtOutputFolder.Text.Trim();
            int outputDirLength = txtOutputFolder.Text.Trim().Length;

            FileSystemEnumerator enumerator = new FileSystemEnumerator(txtOutputFolder.Text.Trim(), "*.*", true);
            foreach (FileInfo fi in enumerator.Matches())
            {
                string thisFile = fi.FullName;
                if ((IsIgnorable(thisFile))) continue;
                FileInfoEx thisInfo = new FileInfoEx(thisFile, outputDirLength);
                ListViewItem thisItem = new ListViewItem(thisInfo.RelativeName, GetImageIndex(thisInfo.FileInfo.Extension));
                thisItem.SubItems.Add(thisInfo.FileVersion);
                thisItem.SubItems.Add(thisInfo.FileInfo.Length.ToString(CultureInfo.InvariantCulture));
                thisItem.SubItems.Add(thisInfo.FileInfo.LastWriteTime.ToString(CultureInfo.InvariantCulture));
                thisItem.SubItems.Add(thisInfo.Hash);
                thisItem.SubItems.Add("-.-");
                thisItem.Checked = (!Settings.Default.IgnoreFiles.Contains(thisInfo.FileInfo.Name));
                thisItem.Tag = thisInfo;
                lstFiles.Items.Add(thisItem);
            }
            lstFiles.EndUpdate();
        }

        private bool IsIgnorable(string filename)
        {
            if ((chkIgnoreSymbols.Checked && Path.GetExtension(filename) == ".pdb")) return true;
            if ((chkIgnoreVsHost.Checked && filename.ToLower().Contains("vshost.exe"))) return true;
            if ((chkIgnoreUpdateFeed.Checked && filename.ToLower().Contains("updatefeed.xml"))) return true;
            return false;
        }

        private void Save(bool forceDialog)
        {
            SaveFormSettings();
            if (forceDialog || string.IsNullOrEmpty(FileName))
            {
                SaveFileDialog dlg = new SaveFileDialog
                {
                    Filter = DialogFilter,
                    FileName = DefaultFileName
                };
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FeedBuilderSettingsProvider p = new FeedBuilderSettingsProvider();
                    p.SaveAs(dlg.FileName);
                    FileName = dlg.FileName;
                }
            }
            else
            {
                FeedBuilderSettingsProvider p = new FeedBuilderSettingsProvider();
                p.SaveAs(FileName);
            }
            UpdateTitle();
        }

        #endregion

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0) return;
            e.Effect = files[0].EndsWith(".config") ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0) return;
            try
            {
                string fileName = files[0];
                FeedBuilderSettingsProvider p = new FeedBuilderSettingsProvider();
                p.LoadFrom(fileName);
                FileName = fileName;
                InitializeFormSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file could not be opened: \n" + ex.Message);
            }
        }

        private void btnLoadServerConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Profile Files (*.pf)|*.pf|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false,
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadProFile(dlg.FileName);
            }
        }

        private void LoadProFile(string serverConfigFilePath)
        {
            _serverProfile = FeedBuilder.ServerProfile.ServerProfile.LoadFromFile(serverConfigFilePath);
            labelServerConfigPath.Text = serverConfigFilePath;

            txtOssEndPoint.Text = _serverProfile.OssEndPoint;
            txtOssBucketName.Text = _serverProfile.OssBucketName;
            txtOssAccessKeyID.Text = _serverProfile.OssAccessKeyID;
            txtOssAccessKeySecret.Text = _serverProfile.OssAccessKeySecret;
            txtOssSourceRoot.Text = _serverProfile.OssSourceRoot;
        }

        private void btnSaveServerConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labelServerConfigPath.Text))
            {
                SaveProFile(labelServerConfigPath.Text);
            }
            else
            {
                btnSaveAsServerConfig_Click(sender, e);
            }
        }
        private void btnSaveAsServerConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "Profile Files (*.pf)|*.pf|All Files (*.*)|*.*",
                FilterIndex = 1,
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                labelServerConfigPath.Text = dlg.FileName;
                SaveProFile(dlg.FileName);
            }
        }

        private void SaveProFile(string serverConfigFilePath)
        {
            _serverProfile.OssEndPoint = txtOssEndPoint.Text;
            _serverProfile.OssBucketName = txtOssBucketName.Text;
            _serverProfile.OssAccessKeyID = txtOssAccessKeyID.Text;
            _serverProfile.OssAccessKeySecret = txtOssAccessKeySecret.Text;
            _serverProfile.OssSourceRoot = txtOssSourceRoot.Text;

            _serverProfile.SaveToFile(serverConfigFilePath);
        }

        private void btnBuildUpdateFeed_Click(object sender, EventArgs e)
        {
            Build();
        }

        private void btnUploadFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serverProfile == null)
                {
                    MessageBox.Show("请先加载服务器配置!");
                    return;
                }

                //清除临时目录
                string tempDir = Directory.GetCurrentDirectory() + @"\temp\";
                if (Directory.Exists(tempDir)) { Directory.Delete(tempDir, true); }


                var aot = new AliyunOSSTransfer(_serverProfile.OssEndPoint
                    , _serverProfile.OssAccessKeyID, _serverProfile.OssAccessKeySecret);
                var aos = new AliyunOssSource(aot, _serverProfile.OssBucketName, _serverProfile.OssSourceRoot);

                int uploadProgressSubItemIndex = 5;                 //很遗憾，C#有bug，没有办法根据ColumnName进行索引
                foreach (ListViewItem thisItem in lstFiles.Items)
                {
                    //先清除上次的上传标志
                    thisItem.SubItems[uploadProgressSubItemIndex].Text = "-.-";

                    //没有选中的文件不上传
                    if (!thisItem.Checked)
                    {
                        thisItem.SubItems[uploadProgressSubItemIndex].Text = "不上传";
                        continue;
                    }

                    //跨线程更新listView的文字
                    Action<string> notifySubitemProgressText = (notifyText) =>
                    {
                        lstFiles.BeginInvoke((MethodInvoker)delegate ()
                        {
                            thisItem.SubItems[uploadProgressSubItemIndex].Text = notifyText;
                        });
                    };

                    //更新进度
                    Action<UpdateProgressInfo> onProgress = (updateProgressInfo) =>
                    {
                        notifySubitemProgressText(string.Format("{0}%", updateProgressInfo.Percentage));
                    };

                    FileInfoEx fileInfo = (FileInfoEx)thisItem.Tag;

                    //将文件拷贝到临时文件夹里面，避免要上传的文件被占用
                    Directory.CreateDirectory(tempDir);
                    string tempFilePath = tempDir + fileInfo.FileInfo.Name;
                    File.Copy(fileInfo.FileInfo.FullName, tempFilePath, true);

                    //线程上传，这样才能及时更新进度
                    Thread uploadThread = new Thread(delegate ()
                    {
                        if (aos.DeployData(fileInfo.FileInfo.Name, "", onProgress, tempFilePath) == false)
                        {
                            notifySubitemProgressText("失败");
                        }
                    });
                    uploadThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("上传文件出错:%s", ex.Message));
            }
        }
    }
}
