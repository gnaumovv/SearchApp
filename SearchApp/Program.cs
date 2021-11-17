using System;

namespace SearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TXT files = new TXT();
            files.Explore(@"C:\Users\German\Desktop\A");
            Console.WriteLine();
            //foreach (string path in args)
            //{
            //    files.Explore(path);
            //    Console.WriteLine("\nNext search\n");
            //}
        }
    }
}
