using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Social_Blade_Dashboard
{
    public class AnalyticsData
    {
        public int TimeUsed { get; set; }
        public int Clicks { get; set; }
        public string Username { get; set; }

    }

    public static class AnalyticsReader
    {
        private static ObservableCollection<AnalyticsData> ReadAnalyticsFiles()
        {
            string baseDirectory = @"C:\Users\yeric\Documents\GitHub\Social-Blade-Dashboard-C-WPF\Analytics\"; // Replace with your directory path
            ObservableCollection<AnalyticsData> allAnalytics = new ObservableCollection<AnalyticsData>();

            foreach (string subdirectory in Directory.GetDirectories(baseDirectory))
            {
                foreach (string filePath in Directory.GetFiles(subdirectory, "*.json"))
                {
                    string jsonData = File.ReadAllText(filePath);
                    AnalyticsData data = JsonConvert.DeserializeObject<AnalyticsData>(jsonData);
                    allAnalytics.Add(data);
                }
            }

            Console.WriteLine("Total files processed: " + allAnalytics.Count);
            return allAnalytics;

        }
    }
}
