using OfficeOpenXml; // EPPlus
using PeopleReportPlugin.Background;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace PeopleReportPlugin.Client
{
    public partial class View : UserControl
    {
        private SettingsData _settings;
        private Dictionary<string, Item> _availableCameras;

        public View()
        {
            InitializeComponent();
            LoadSettings();
            PopulateCameraDropdown();

            // ✅ Correct way to set EPPlus license context for EPPlus v5+
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void LoadSettings()
        {
            _settings = Settings.Load();
        }

        private void PopulateCameraDropdown()
        {
            var userCameras = Configuration.Instance.GetItemsByKind(Kind.Camera);
            _availableCameras = new Dictionary<string, Item>();

            foreach (var id in _settings.CameraIds)
            {
                var match = userCameras.FirstOrDefault(c => c.FQID.ObjectId.ToString() == id);
                if (match != null)
                {
                    _availableCameras[match.Name] = match;
                }
            }

            CameraDropdown.ItemsSource = _availableCameras.Keys;

            if (_availableCameras.Count > 0)
            {
                CameraDropdown.SelectedIndex = 0;
                TimeRangeDropdown.SelectedIndex = 0;
            }
        }

        private void LoadReport_Click(object sender, RoutedEventArgs e)
        {
            if (CameraDropdown.SelectedItem == null || TimeRangeDropdown.SelectedItem == null)
            {
                MessageBox.Show("Please select a camera and time range.");
                return;
            }

            string selectedCamera = CameraDropdown.SelectedItem.ToString();
            string timeRange = (TimeRangeDropdown.SelectedItem as ComboBoxItem)?.Content.ToString();

            var files = Directory.GetFiles(_settings.FolderPath, $"report-{timeRange}*.xlsx");

            if (files.Length == 0)
            {
                ReportOutput.Text = $"No report file found for time range '{timeRange}'.";
                return;
            }

            string latestFile = files.OrderByDescending(f => File.GetLastWriteTime(f)).FirstOrDefault();

            if (latestFile == null)
            {
                ReportOutput.Text = $"No matching report file found.";
                return;
            }

            string reportText = ParseExcelReport(latestFile, selectedCamera);
            ReportOutput.Text = reportText;
        }

        private string ParseExcelReport(string filePath, string cameraName)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var sheet = package.Workbook.Worksheets[0];
                    int rows = sheet.Dimension.Rows;

                    var lines = new List<string>
                    {
                        $"People Count Report for {cameraName}",
                        new string('-', 40)
                    };

                    for (int row = 2; row <= rows; row++)
                    {
                        string cam = sheet.Cells[row, 1].Text;
                        if (!string.Equals(cam, cameraName, StringComparison.OrdinalIgnoreCase))
                            continue;

                        string timestamp = sheet.Cells[row, 2].Text;
                        string enter = sheet.Cells[row, 3].Text;
                        string exit = sheet.Cells[row, 4].Text;

                        lines.Add($"{timestamp,-20} In: {enter,-5}  Out: {exit,-5}");
                    }

                    return string.Join("\n", lines);
                }
            }
            catch (Exception ex)
            {
                return $"Error reading report: {ex.Message}";
            }
        }
    }
}
