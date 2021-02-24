using Lunar;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace simple_cheat_loader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "yourcheat | 0%";
            AutoType("starting loader...", 60);
            int a = 0;
            for (int i = 0; i <= 20; i++)
            {
                Thread.Sleep(40);
                Write("", ConsoleColor.Green);
                a += 4;
                Console.Title = $"yourcheat | {a}%";
            }
            Console.Title = "yourcheat | by yourname";
            Console.Clear();
            AutoType("waiting for database to verify...", 60);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.Clear();
            AutoType($" welcome back, {Environment.UserName}\n\n", 60);
            Write(" 1 - inject yourcheat", ConsoleColor.Red);
            Write("\n 2 - exit", ConsoleColor.Red);
            Write("\n - ", ConsoleColor.White);
            Write(string.Empty, ConsoleColor.Red);
            var c = Console.ReadLine();
            switch (c)
            {
                case "1":
                    Console.Clear();
                    AutoType(" waiting for csgo...", 60);
                    Console.Clear();
                    if (Process.GetProcessesByName("csgo").Length == 1)
                    {
                        AutoType(" csgo found, injecting yourcheat!", 60);
                        Thread.Sleep(2000);
                        MapDll();
                    }
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Write(" please enter a number", ConsoleColor.White);
                    break;
            }
        }

        private static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        private static void AutoType(string text, int ms)
        {
            for (int i = 0; i != text.Length; i++)
            {
                Thread.Sleep(ms);
                Write(text[i].ToString(), ConsoleColor.White);
            }
        }

        private static void MapDll()
        {
            string dll = "dlllinkhere";
            WebClient wc = new WebClient();
            byte[] dllbytes = wc.DownloadData(dll);

            Process csgo = Process.GetProcessesByName("csgo")[0];
            var mapper = new LibraryMapper(csgo, dllbytes);

            mapper.MapLibrary();
            Thread.Sleep(1000);
            Process.GetCurrentProcess().Kill();
        }
    }
}
