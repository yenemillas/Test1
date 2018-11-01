using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;

namespace TelelinguaWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private string _path;
        private ObservableCollection<FileInfo> _files;
        #endregion

        #region Properties
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }



        public ObservableCollection<FileInfo> Files
        {
            get { return _files; }
            set { _files = value; }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            InitializeCommand();
            Files = new ObservableCollection<FileInfo>();
            Path = @"C:\Temp";
        }
        #endregion

        #region Methods
        private void InitializeCommand()
        {

            GetFileCommand = new RelayCommand(ExecuteGetFileCommand, CanExecuteGetFileCommand);
            FolderBrowserCommand = new RelayCommand(ExecuteFolderBrowserCommand, CanExecuteFolderBrowserCommand);

        }
        #endregion

        #region GetFileCommand

        public RelayCommand GetFileCommand { get; private set; }

        private void ExecuteGetFileCommand()
        {
            if (Directory.Exists(Path))
            {
                Files.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(Path);
                directoryInfo.GetFiles().ToList().ForEach(item => Files.Add(item));
            }
        }

        private bool CanExecuteGetFileCommand()
        {
            return true;
        }

        #endregion

        #region GetDirectoryCommand

        public RelayCommand FolderBrowserCommand { get; private set; }

        private void ExecuteFolderBrowserCommand()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Path = dialog.SelectedPath;
                }

            }
        }

        private bool CanExecuteFolderBrowserCommand()
        {
            return true;
        }

        #endregion 

    }
}
