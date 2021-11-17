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
        static Regex regexNotRu = new Regex(@"[^а-яА-Я.,?!;:]+");

        public static List<string> Get(string text)
        {
            text = text.Replace("-\r\n", ""); // Совмещение перенесённых слов
            
            string[] allWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            MatchCollection matches;
            List<string> ruWords = new List<string>();

            foreach (string word in allWords)
            {
                matches = regexNotRu.Matches(word);
                if (matches.Count == 0)
                    ruWords.Add(word);
            }      

            return ruWords;
        }
    }
}
