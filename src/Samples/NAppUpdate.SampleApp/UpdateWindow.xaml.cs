using System.ComponentModel;
using System.Windows;
using NAppUpdate.Framework;

namespace NAppUpdate.SampleApp
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window, INotifyPropertyChanged
    {
        private readonly UpdateManager _updateManager;
        private int _downloadProgress;

        public UpdateWindow(UpdateManager updateManager)
        {
            _updateManager = updateManager;
            InitializeComponent();

            this.DataContext = this;
        }

        public Update Update
        {
            get { return _updateManager.NewUpdate; }
        }

        public int DownloadProgress
        {
            get { return _downloadProgress; }
            set
            {
                _downloadProgress = value;
                InvokePropertyChanged("DownloadProgress");
            }
        }

        private void InstallNow_Click(object sender, RoutedEventArgs e)
        {
            _updateManager.DownloadUpdateAsync(finished =>
                                                   {
                                                       if (finished)
                                                           _updateManager.ApplyUpdate();
                                                   },
                                               progressPercent =>
                                                   {
                                                       this.DownloadProgress = progressPercent;
                                                   });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}