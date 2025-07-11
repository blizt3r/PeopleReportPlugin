using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PeopleReportPlugin.Background
{
    public class SettingsData
    {
        public string FolderPath { get; set; }
        public List<string> CameraIds { get; set; }
    }

    public static class Settings
    {
        private static string SettingsFile =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                         "PeopleReportPlugin", "settings.json");

        public static void Save(SettingsData data)
        {
            var dir = Path.GetDirectoryName(SettingsFile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // Use Newtonsoft.Json with formatting
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(SettingsFile, json);
        }

        public static SettingsData Load()
        {
            if (!File.Exists(SettingsFile))
            {
                return new SettingsData { CameraIds = new List<string>(), FolderPath = "" };
            }

            try
            {
                var json = File.ReadAllText(SettingsFile);
                return JsonConvert.DeserializeObject<SettingsData>(json)
                    ?? new SettingsData { CameraIds = new List<string>(), FolderPath = "" };
            }
            catch
            {
                return new SettingsData { CameraIds = new List<string>(), FolderPath = "" };
            }
        }
    }
}
