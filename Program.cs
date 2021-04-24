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
            if(Process.GetProcessesByName("steam").Length == 1 && Process.GetProcessesByName("steamwebhelper").Length == 1)
            {
                Process steam = Process.GetProcessesByName("steam")[0];
                Process steamwebhelper = Process.GetProcessesByName("steamwebhelper")[0];
                steam.Kill();
                steamwebhelper.Kill();
            }
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
                    Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "-gameidlaunch 730");
                    Thread.Sleep(10000);
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
            string dll = "https://github.com/qtCRYPTO/simple-cheat-loader/raw/main/test.dll"; //uses default test dll from the repo but can be changed to any link
            //make sure that your repo is public if u want to download ur cheats dll from github
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
