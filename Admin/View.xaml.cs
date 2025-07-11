using Microsoft.Win32;
using PeopleReportPlugin.Background;
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Windows;
using System.Windows.Controls;
using VideoOS.Platform;
//using VideoOS.Platform.Configuration;

namespace PeopleReportPlugin.Admin
{
    public partial class View : UserControl
    {
        private Item[] _allCameras;

        public View()
        {
            InitializeComponent();
            LoadCameras();
            LoadSettings();
        }

        private void LoadCameras()
        {
            // Load all cameras user has access to
            _allCameras = VideoOS.Platform.Configuration.Instance.GetItemsByKind(Kind.Camera).ToArray();


            CameraListBox.ItemsSource = _allCameras;
            CameraListBox.DisplayMemberPath = "Name";
        }

        private void LoadSettings()
        {
            var saved = Settings.Load();

            if (!string.IsNullOrEmpty(saved.FolderPath))
            {
                FolderPathBox.Text = saved.FolderPath;
            }

            if (saved.CameraIds != null)
            {
                foreach (var item in _allCameras)
                {
                    if (saved.CameraIds.Contains(item.FQID.ObjectId.ToString()))
                        CameraListBox.SelectedItems.Add(item);
                }
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderPathBox.Text = dlg.SelectedPath;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var selectedCameras = CameraListBox.SelectedItems.Cast<Item>().ToList();
            var folder = FolderPathBox.Text;

            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
            {
                MessageBox.Show("Please select a valid folder path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var settings = new SettingsData
            {
                FolderPath = folder,
                CameraIds = selectedCameras.Select(i => i.FQID.ObjectId.ToString()).ToList()
            };

            Settings.Save(settings);
            MessageBox.Show("Settings saved successfully.", "People Report", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
