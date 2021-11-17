using System;

namespace SearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TXT files = new TXT();

            for (int i = 0; i < args.Length; i++)
            { 
                files.Explore(args[i]);
                if (i < args.Length-1)  
                    Console.WriteLine($"\n\nNext search: {args[i+1]}\n");
            }
            Console.WriteLine();
        }
    }
}
