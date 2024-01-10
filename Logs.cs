using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace TxtCompression
{
    public class Logs
    {
        /// <summary>
        /// Tato metoda se používá když se něco stane úspěšně v programu a následně se to zapíše do logu
        /// </summary>
        string logFilePath = "logs/logs.json";
        public void LogSuccess(String s)
        {
            // Create an object to store the error information
            var successLog = new
            {
                Timestamp = DateTime.Now,
                SuccessMessage = s
            };

            // Convert the object to JSON
            string jsonSuccessLog = JsonSerializer.Serialize(successLog, new JsonSerializerOptions { WriteIndented = true });

            // Read existing content (if any)
            string existingContent = File.Exists(logFilePath) ? File.ReadAllText(logFilePath) : "";

            // Append the new log
            string updatedContent = existingContent + Environment.NewLine + jsonSuccessLog;

            // Write the updated content back to the file
            File.WriteAllText(logFilePath, updatedContent);
        }
        /// <summary>
        /// Tato metoda se používá když se vyskytne chyba v programu a následně se to zapíše do logu
        /// </summary>
        /// <param name="s"></param>
        public void LogFail(String s)
        {
            // Create an object to store the error information
            var failLog = new
            {
                Timestamp = DateTime.Now,
                FailMessage = s
            };

            // Convert the object to JSON
            string jsonFailLog = JsonSerializer.Serialize(failLog, new JsonSerializerOptions { WriteIndented = true });

            // Read existing content (if any)
            string existingContent = File.Exists(logFilePath) ? File.ReadAllText(logFilePath) : "";

            // Append the new log
            string updatedContent = existingContent + Environment.NewLine + jsonFailLog;

            // Write the updated content back to the file
            File.WriteAllText(logFilePath, updatedContent);
        }
        /// <summary>
        /// Tato metoda se používá když se vyskytne error v programu a následně se to zapíše do logu
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(Exception ex)
        {
            // Create an object to store the error information
            var errorLog = new
            {
                Timestamp = DateTime.Now,
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace
            };

            // Convert the object to JSON
            string jsonErrorLog = JsonSerializer.Serialize(errorLog, new JsonSerializerOptions { WriteIndented = true });

            // Read existing content (if any)
            string existingContent = File.Exists(logFilePath) ? File.ReadAllText(logFilePath) : "";

            // Append the new log
            string updatedContent = existingContent + Environment.NewLine + jsonErrorLog;

            // Write the updated content back to the file
            File.WriteAllText(logFilePath, updatedContent);
        }
    }
}
