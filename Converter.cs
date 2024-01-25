using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Converter
{
    public class Converter
    {
        public static void Main()
        {
            Console.WriteLine("Enter text:");
            string inputText = Console.ReadLine();

            string outputText = ConvertWordsToNumbers(inputText);

            Console.WriteLine("Output text:");
            Console.WriteLine(outputText);
        }

        /// <summary>
        /// Словарь с числами
        /// </summary>
        public static Dictionary<string, int> wordToNumberMap = new Dictionary<string, int>
    {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
        {"ten", 10},
        {"eleven", 11},
        {"twelve", 12},
        {"thirteen", 13},
        {"fourteen", 14},
        {"fifteen", 15},
        {"sixteen", 16},
        {"seventeen", 17},
        {"eighteen", 18},
        {"nineteen", 19},
        {"twenty", 20},
        {"thirty", 30},
        {"forty", 40},
        {"fifty", 50},
        {"sixty", 60},
        {"seventy", 70},
        {"eighty", 80},
        {"ninety", 90}
    };
        /// <summary>
        /// Словарь с множителями
        /// </summary>
    public static Dictionary<string, int> multiplyersToNumberMap = new Dictionary<string, int>
    {
        {"hundred", 100},
        {"thousand", 1000},
        {"million", 1000000},
        {"billion", 1000000000}
    };


        /// <summary>
        /// Метод, изменяющий числительные, написанные словами, на числовое представление в тексте
        /// </summary>
        /// <param name="input">Входной текст</param>
        /// <returns>Отредактированный текст</returns>
        public static string ConvertWordsToNumbers(string input)
        {


            StringBuilder output = new StringBuilder();

            string[] words = input.Split(' ');

            List<string> numerals = new List<string>();


            for (int i = 0; i < words.Length; i++)
            {

                string word = words[i];
                string cleanedWord = Regex.Replace(word, "[^a-zA-Z]", "");
                cleanedWord = cleanedWord.ToLower();

                if (CheckIfNumeral(cleanedWord))
                {
                    numerals.Add(cleanedWord);
                }

                else if (numerals.Count > 0)
                {
                    ParseToInt(numerals);
                    output.Append(ParseToInt(numerals).ToString() + ' ');
                    numerals.Clear();
                    output.Append(cleanedWord + ' ');
                }
                else
                {
                    output.Append(cleanedWord + ' ');
                }

                if (numerals.Count > 0 && i == words.Length - 1)
                {

                    output.Append(ParseToInt(numerals).ToString() + ' ');
                    numerals.Clear();
                }



            }
            return output.ToString().Trim();
        }


        /// <summary>
        /// Метод, проверяющий на ключевое слово(числительное)
        /// </summary>
        /// <param name="numeral">Список для числительных</param>
        /// <returns>Булево значение</returns>
        public static bool CheckIfNumeral(string numeral)
        {

            if (wordToNumberMap.ContainsKey(numeral)
                || multiplyersToNumberMap.ContainsKey(numeral))
            {
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Метод, преобразующий числительные в числа
        /// </summary>
        /// <param name="numerals">Список числительных</param>
        /// <returns>Итоговое число</returns>
        public static int ParseToInt(List<string> numerals)
        {
            /// Переменная для хранения итогового числа
            int total = 0;
            /// Переменная для хранения множителя
            int multiplier = 1;

            for (int i = numerals.Count - 1; i >= 0; i--)
            {
                if (wordToNumberMap.ContainsKey(numerals[i]))
                {
                    total += wordToNumberMap[numerals[i]] * multiplier;
                }
                if (multiplyersToNumberMap.ContainsKey(numerals[i]))
                {
                    if (multiplyersToNumberMap[numerals[i]] < multiplier)
                    {
                        multiplier *= multiplyersToNumberMap[numerals[i]];
                    }
                    else
                    {
                        multiplier = multiplyersToNumberMap[numerals[i]];
                    }
                }
            }
            return total;

        }
    }
}