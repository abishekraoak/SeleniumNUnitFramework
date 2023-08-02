using System;
using Newtonsoft.Json;

namespace SeleniumNUnitFramework.Utilities
{
    public class Configuration
    {
        public string SpanishPointURL { get; set; }
        public string ContentCollabHeaderText { get; set; }
        public string ParagraphText { get; set; }

        public static Configuration Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Configuration file not found.", filePath);
            }

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Configuration>(json);
            }
            catch (JsonException ex)
            {
                throw new FormatException("Invalid configuration file format.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while loading configuration.", ex);
            }
        }
    }
}

