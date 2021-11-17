using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace SearchApp
{
    static class RuWord
    {
        static string[] separators = { " ", "\r\n" };
        static Regex regex = new Regex("[а-яА-Я]", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static List<string> Get(string text)
        {
            text = text.Replace("-\r\n", ""); // Совмещение перенесённых слов
            
            string[] allWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> ruWords = new List<string>();
            MatchCollection matches;

            foreach (string word in allWords)
            {
                matches = regex.Matches(word);
                string oneWord = "";
                if (matches.Count > 0)
                {
                    foreach (Match match in matches) oneWord += match;
                    ruWords.Add(oneWord);
                }
            }

            return ruWords;
        }
    }
}
