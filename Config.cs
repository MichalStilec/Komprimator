using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtCompression
{
    public class Config
    {
        Logs logs = new Logs();
        public class FilePaths
        {
            public string InputFilePath { get; set; }
            public string ResultFilePath { get; set; }
        }

        /// <summary>
        /// Instance třídy pro přístup k cestám
        /// </summary>
        public FilePaths Paths { get; set; }

        /// <summary>
        /// Metoda pro načtení cesty k vstupnímu souboru z konfiguračního souboru
        /// </summary>
        /// <returns></returns>
        public string LoadInput()
        {
            string configFile = "config/config.cfg";

            if (File.Exists(configFile))
            {
                // Načtení všech řádků konfiguračního souboru
                string[] lines = File.ReadAllLines(configFile);

                foreach (var line in lines)
                {
                    var parts = line.Split('=');

                    // Kontrola, zda řádek obsahuje klíč "Input File"
                    if (parts.Length == 2 && parts[0].Trim() == "Input File")
                    {
                        string trimmedValue = parts[1].Trim();

                        // Kontrola, zda hodnota končí příponou ".txt" a zda soubor existuje ve složce "data"
                        if (trimmedValue.EndsWith(".txt") && File.Exists("data/" + trimmedValue))
                        {
                            return trimmedValue;
                        }
                        else
                        {
                            // Logování chyby, pokud soubor není nalezen
                            logs.LogFail("Program nedokázal najít soubor z konfigurace");
                        }
                    }
                }
            }

            // Návrat výchozí hodnoty v případě nenalezení klíče nebo souboru
            return "input.txt";
        }

        /// <summary>
        /// Metoda pro načtení cesty k výslednému souboru z konfiguračního souboru
        /// </summary>
        /// <returns></returns>
        public string LoadResult()
        {
            string configFile = "config/config.cfg";

            if (File.Exists(configFile))
            {
                // Načtení všech řádků konfiguračního souboru
                string[] lines = File.ReadAllLines(configFile);

                foreach (var line in lines)
                {
                    var parts = line.Split('=');

                    // Kontrola, zda řádek obsahuje klíč "Result File"
                    if (parts.Length == 2 && parts[0].Trim() == "Result File")
                    {
                        string trimmedValue = parts[1].Trim();

                        // Kontrola, zda hodnota končí příponou ".txt" a zda soubor existuje ve složce "data"
                        if (trimmedValue.EndsWith(".txt") && File.Exists("data/" + trimmedValue))
                        {
                            Console.WriteLine(trimmedValue);
                            return trimmedValue;
                        }
                        else
                        {
                            // Logování chyby, pokud soubor není nalezen
                            logs.LogFail("Program nedokázal najít soubor z konfigurace");
                        }
                    }
                }
            }

            // Návrat výchozí hodnoty v případě nenalezení klíče nebo souboru
            return "result.txt";
        }
    }
}
