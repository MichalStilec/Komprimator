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
                    // Path to input file
                    //string inputFilePath = "input.txt";


                    // Path to result file

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
                            Console.Clear();
                            // Reading the content of the input file
                            string inputText = File.ReadAllText("data/" + inputFilePath);

                            // Removes the vowels
                            string modifiedText = RemoveVowelsFromWords(inputText);

                            // Saving the edited text to the result file
                            File.WriteAllText(resultFilePath, modifiedText);
                            logs.LogSuccess("Komprese souboru " + inputFilePath + " byla uspesna");
                            Console.WriteLine("Komprese souboru " + inputFilePath + " byla úspěšná\n");
                            break;

                        case "2":
                            Console.Clear();
                            Console.Write("Napište zde název souboru: ");
                            string filePath = "data/" + Console.ReadLine();
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

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Pokud si nepřejete změnit cestu pro ukládání výsledku, zmáčkněte ENTER");
                            Console.Write("Napište zde cestu k souboru .txt pro ukládání výsledku: ");
                            string savePath = Console.ReadLine();
                            resultFilePath = savePath;
                            if (resultFilePath == "")
                            {
                                Console.Clear();
                                Console.WriteLine("Cesta pro ukládání výsledku byla vrácena do původního stavu\n");
                                resultFilePath = "data/result.txt";
                            }
                            else
                            {
                                Console.Clear();
                                logs.LogSuccess("Cesta souboru " + resultFilePath + " byla uspesna");
                                Console.Write("Úspěšně jste nastavili novou cestu pro ukládání výsledku\n");
                            }

                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("--------------------------------------------------------------------------------------------\n" +
                                              "1. Zapnout kompresi: Tato volba provede kompresi obsahu zadaného souboru. \n" +
                                              "   Program odebere samohlásky z jednotlivých slov a výsledek uloží do nového souboru.\n\n" +
                                              "2. Vybrat soubor pro kompresi: Umožňuje uživateli vybrat jiný vstupní soubor pro kompresi. \n" +
                                              "   Zadejte název souboru, který chcete komprimovat (musí být v bin/Debug/net6.0/data).\n" +
                                              "   Pokud chcete vybrat soubor mimo složku net6.0, uveďte cestu k souboru bez \"\".\n" +
                                              "   Také je možné zadat název souboru před spuštěním programu v configu \n" +
                                              "   (bin/Debug/net6.0/config/config.cfg). \n\n" +
                                              "3. Změnit místo uložení výsledku: Změní, dle vaší cesty, místo uložení výsledného souboru\n\n" +
                                              "4. Nápověda: Zobrazí tuto nápovědu, která vysvětluje jednotlivé možnosti programu.\n\n" +
                                              "5. Unit testy: Zobrazí jak program funguje a výsledek testu.\n\n" +
                                              "0. Ukončit program: Ukončí běh programu.\n" +
                                              "-------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Zmáčkněte ENTER pro pokračování");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case "5":
                            RunUnitTests();
                            break;

                        case "0":
                            exitProgram = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Neplatná volba, zkuste to znovu\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Vyskytl se během programu error: {ex.Message}");
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