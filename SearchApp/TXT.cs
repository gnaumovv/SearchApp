﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SearchApp
{
    class TXT
    {  
        public void Explore(string currDirectoryPath)
        {
            if (Directory.Exists(currDirectoryPath))
            {
                if (Directory.GetFiles(currDirectoryPath) != null)
                    foreach (string currFilePath in Directory.GetFiles(currDirectoryPath))
                    {
                        string result = "";

                        foreach (string word in RuWord.Get(GetText(currFilePath)))
                            result += word + " ";

                        if (result != "")
                        {
                            Console.Write("\n\"" + currFilePath + "\"##\"");
                            Console.Write(result.Trim());
                            Console.Write("\"");
                        }
                    }

                if (Directory.GetDirectories(currDirectoryPath) != null)
                    foreach (string nextDirectoryName in Directory.GetDirectories(currDirectoryPath)) this.Explore(nextDirectoryName);
            }
        }

        string GetText(string filePath)
        {
            FileStream file = null;
            string text = null;

            try
            {
                file = new FileStream(filePath, FileMode.Open);
                byte[] input = new byte[file.Length];
                file.Read(input, 0, input.Length);
                text = System.Text.Encoding.Default.GetString(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (file != null)
                    file.Close();
            }

            return text;
        }
    }
}
