using Avalonia.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using yueqin.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace yueqin.Helpers
{
    public static class Helpers
    {
        private static string _localFolder = string.Empty;

        private static string LocalFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(_localFolder))
                {
                    return _localFolder;
                }

                _localFolder =
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder
                            .LocalApplicationData), nameof(yueqin));

                if (!Directory.Exists(_localFolder))
                {
                    Directory.CreateDirectory(_localFolder);
                }

                return _localFolder;
            }
        }

        private static string optionsfileName = $"{nameof(YueqinOptions)}.json";

        public static string GetLocalFilePath(string fileName)
        {
            return Path.Combine(LocalFolder, fileName);
        }
        public static YueqinOptions GetYueqinOptionsFromFile()
        {
            var path = GetLocalFilePath(optionsfileName);
            var jsonOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            if (!File.Exists(path))
            {
                var defaultYueqinOptions =   YueqinOptions.GetDefaultYueqinOptions();
                return SaveYueqinOptionsToFile(defaultYueqinOptions);
            }

            string yueqinOptionsTxt = File.ReadAllText(path);
            var yueqinOptions = JsonSerializer.Deserialize<YueqinOptions>(yueqinOptionsTxt, jsonOptions);
            return yueqinOptions;
        }
        public static YueqinOptions SaveYueqinOptionsToFile(YueqinOptions yueqinOptions)
        {
            var path = GetLocalFilePath(optionsfileName);
            var jsonOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(yueqinOptions, jsonOptions);
            File.WriteAllText(path, json);
            return yueqinOptions;

        }
    }
}
