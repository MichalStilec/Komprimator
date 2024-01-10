using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TxtCompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nastavení kódování pro podporu českých znaků
            Console.OutputEncoding = Encoding.UTF8;

            // Inicializace konfigurace a logů
            Config config = new Config();
            Logs logs = new Logs();

            // Načtení cesty k vstupnímu souboru, výslednému souboru a souboru s logy
            string inputFilePath = "data/" + config.LoadInput();
            string resultFilePath = "data/" + config.LoadResult();
            string logsVar = "data/logs.json";

            bool exitProgram = false;

            while (!exitProgram)
            {
                try
                {
                    // Uživatelské rozhraní pro volbu možností
                    Console.WriteLine("Právě pracujete se souborem: " + inputFilePath + "\n");
                    Console.WriteLine("Vyberte jednu z možností: \n" +
                                      "1. Zapnout kompresi \n" +
                                      "2. Vybrat soubor pro kompresi \n" +
                                      "3. Změnit místo uložení výsledku \n" +
                                      "4. Nápověda \n" +
                                      "5. Unit testy \n" +
                                      "0. Ukončit program \n");

                    string answer = Console.ReadLine();

                    switch (answer)
                    {
                        case "1":
                            // Kompresní operace
                            Console.Clear();
                            string inputText = File.ReadAllText(inputFilePath);
                            string modifiedText = RemoveVowelsFromWords(inputText);
                            File.WriteAllText(resultFilePath, modifiedText);
                            logs.LogSuccess("Komprese souboru " + inputFilePath + " byla uspesna");
                            Console.WriteLine("Komprese souboru " + inputFilePath + " byla úspěšná\n");
                            break;

                        case "2":
                            // Výběr souboru pro kompresi
                            Console.Clear();
                            Console.Write("Napište zde název souboru: ");
                            string filePath = Console.ReadLine();
                            Console.Clear();
                            if (File.Exists(filePath))
                            {
                                if (filePath != resultFilePath && filePath.EndsWith(".txt"))
                                {
                                    inputFilePath = filePath;
                                    logs.LogSuccess("Soubor " + filePath + " byl uspesne nahran");
                                    Console.WriteLine("Soubor " + filePath + " byl úspěšně nahrán\n");
                                }
                                else
                                {
                                    Console.WriteLine("Soubor musí končit příponou .txt a zároveň nesmí být vaším výsledným souborem\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Soubor neexistuje\n");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Zachycení výjimek
                    logs.LogError(ex);
                    Console.WriteLine($"Vyskytl se během programu error, je zapsán do logu\n");
                }
            }
        }
        /// <summary>
        /// Metoda pro otestování funkčnosti programu
        /// </summary>
        static void RunUnitTests()
        {
            Console.Clear();
            // Test RemoveVowelsFromWords
            string test1Input = "Tohle je test";
            string test1Expected = "Thl j tst";
            Console.WriteLine("Input 1 = " + test1Input);
            Console.WriteLine("Output 1 = " + test1Expected);
            string test1Output = RemoveVowelsFromWords(test1Input);
            Console.WriteLine($"Test 1 výsledek: {test1Output == test1Expected}\n");

            // Test RemoveVowels
            string test2Input = "test";
            string test2Expected = "tst";
            Console.WriteLine("Input 2 = " + test2Input);
            Console.WriteLine("Output 2 = " + test2Expected);
            string test2Output = RemoveVowels(test2Input);
            Console.WriteLine($"Test 2 výsledek: {test2Output == test2Expected}\n");

            Console.WriteLine("Zmáčkněte ENTER pro pokračování");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Do této metody se vloží zadaný soubor a náslědně jsou slova ze souboru rozdělena.
        /// Slova jsou rozdělena po jednom a zároveň jsou posíláná do další metody, která 
        /// odstraní samohlásky z těchto slov.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static string RemoveVowelsFromWords(string input)
        {
            // Division of text into words
            string[] words = input.Split(' ');

            // Removing vowels from words
            StringBuilder result = new StringBuilder();
            string modifiedWord = "";
            foreach (string word in words)
            {
                if (word.Length != 1) 
                {
                    modifiedWord = RemoveVowels(word);
                }
                else
                {
                    modifiedWord = word;
                }

                result.Append(modifiedWord + " ");
            }

            return result.ToString().Trim(); // Removing the excess white space at the end
        }

        /// <summary>
        /// Odstraní všechny samohlásky ze slov
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static string RemoveVowels(string input)
        {
            // Vowel declarations
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'ů' };

            StringBuilder result = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (!vowels.Contains(c))
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}