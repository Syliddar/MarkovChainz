using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MarkovSharp;
using MarkovSharp.TokenisationStrategies;

namespace MarkovChainz
{
    internal static class Program
    {
        private static string _sourceTextFolder = @"G:\";
        public static void Main()
        {
            Console.WriteLine("Hello MNUG!");
            string input = Console.ReadLine();

            while (input != "exit")
            {
                switch (input.ToUpper())
                {
                    case "MOVIE":
                        Movie();
                        break;
                    case "SUBMOVIE":
                        SubMovie();
                        break;
                    case "TWITTER":
                        Twitter();
                        break;
                    case "TWEET":
                        Tweet();
                        break;
                    case "MURICA":
                        Murica();
                        break;
                    case "SHERLOCK":
                        Sherlock();
                        break;
                    case "CLEAR":
                        Console.Clear();
                        break;
                }
                input = Console.ReadLine();
            }
        }

        private static void Twitter()
        {
            string[] sourceText = File.ReadAllLines(_sourceTextFolder + "Twooter.txt");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("String Markov Chain with Level = " + i);
                StringWalk(sourceText, i);
                Console.ReadLine();
            }
        }
        private static void Tweet()
        {
            string[] sourceText = File.ReadAllLines(_sourceTextFolder + "Twooter.txt");
            StringWalk(sourceText, 1);
        }

        private static void Movie()
        {
            string[] sourceText = File.ReadAllLines(_sourceTextFolder + "Movie.txt");

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("String Markov Chain with Level = " + i);
                StringWalk(sourceText, i);
                Console.ReadLine();
            }
        }
        private static void SubMovie()
        {
            string[] sourceText = File.ReadAllLines(_sourceTextFolder + "Movie.txt");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("Substring Markov Chain with Level = " + i);
                SubStringWalk(sourceText, i);
                Console.ReadLine();
            }
        }
        private static void Murica()
        {
            string[] sourceText = File.ReadAllLines(_sourceTextFolder + "Murica.txt");
            StringWalk(sourceText);
        }

        private static void Sherlock()
        {
            string[] sourceText = File.ReadAllLines(_sourceTextFolder + "Sherlock.txt");
            StringWalk(sourceText);
        }

        private static void StringWalk(string[] sourceText, int level = 1)
        {
            StringMarkov model = new StringMarkov(level);
            model.Learn(sourceText);
            string format = model.Walk().First();
            while (format.Trim() == String.Empty)
            {
                format = model.Walk().First();
            }
            Console.WriteLine(format);
        }
        private static void SubStringWalk(string[] sourceText, int level = 1)
        {
            SubstringMarkov model = new SubstringMarkov(level);
            model.Learn(sourceText);
            string format = model.Walk().First();
            while (format.Trim() == String.Empty)
            {
                format = model.Walk().First();
            }
            Console.WriteLine(format.Trim());
        }
    }
}
