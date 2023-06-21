using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Media;
using System.Text;
using System.Windows;
using System.Runtime.InteropServices;
using System.Drawing;

class Program
{
    static string whichLanguage = "de";
    //static SoundPlayer calmDown;
    //static SoundPlayer ps500;
    //static SoundPlayer rockMeAmadeus;
    //static SoundPlayer majorTom;
    static SoundPlayer witz1D = new SoundPlayer("Witz1D.wav");
    static SoundPlayer witz2D = new SoundPlayer("Witz2D.wav");
    static SoundPlayer witz3D = new SoundPlayer("Witz3D.wav");
    static SoundPlayer witz4D = new SoundPlayer("Witz4D.wav");
    static SoundPlayer witz5D = new SoundPlayer("Witz5D.wav");
    static SoundPlayer witz6D = new SoundPlayer("Witz6D.wav");
    static SoundPlayer witz7D = new SoundPlayer("Witz7D.wav");
    static SoundPlayer witz8D = new SoundPlayer("Witz8D.wav");
    static SoundPlayer witz9D = new SoundPlayer("Witz9D.wav");
    static SoundPlayer witz10D = new SoundPlayer("Witz10D.wav");
    static SoundPlayer witz1E = new SoundPlayer("Witz1E.wav");
    static SoundPlayer witz2E = new SoundPlayer("Witz2E.wav");
    static SoundPlayer witz3E = new SoundPlayer("Witz3E.wav");
    static SoundPlayer witz4E = new SoundPlayer("Witz4E.wav");
    static SoundPlayer witz5E = new SoundPlayer("Witz5E.wav");
    static SoundPlayer witz6E = new SoundPlayer("Witz6E.wav");
    static int whichMusic = 0;
    static string back = "";
    static int subtitle = 1;
    static string subtitleLanguage = "de";

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    static void HideCursor()
    {
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        var consoleHandle = GetStdHandle(-11);
        uint consoleMode;                                               //Quelle des Hidecursor aus ChatGPT
        GetConsoleMode(consoleHandle, out consoleMode);
        consoleMode &= ~ENABLE_VIRTUAL_TERMINAL_PROCESSING;
        SetConsoleMode(consoleHandle, consoleMode);
    }

    static void ShowCursor()
    {
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        var consoleHandle = GetStdHandle(-11);
        uint consoleMode;
        GetConsoleMode(consoleHandle, out consoleMode);
        consoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
        SetConsoleMode(consoleHandle, consoleMode);
    }

    [DllImport("kernel32.dll")]
    static extern IntPtr GetStdHandle(int nStdHandle);
    static void CollectingMenue()
    {
        if (whichLanguage == "de")
        {
            string collectingMenue = File.ReadAllText("Film_German.txt");
            Console.WriteLine(collectingMenue);
        }
        else
        {
            string collectingMenue = File.ReadAllText("Film_English.txt");
            Console.WriteLine(collectingMenue);
        }

        CollectWhich();
    }
    static void Laws()
    {
        if (whichLanguage == "de")
        {
            string laws = File.ReadAllText("Laws_German.txt");
            Console.WriteLine(laws);
        }
        else
        {
            string laws = File.ReadAllText("Laws_English.txt");
            Console.WriteLine(laws);
        }
        var key1 = Console.ReadKey(true);

        if (key1.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            back = "escape";

        }
    }

    static void Music()
    {
        string[] music = File.ReadAllLines("Music.txt");

        char arrow = '\u21D2';

    Musik:

        if (whichLanguage == "de")
        {
            Console.WriteLine("Musik");
        }
        else
        {
            Console.WriteLine("Music");
        }
        Console.WriteLine("‾‾‾‾‾");

        for (int i = 0; i < music.Length; i++)
        {
            if (whichMusic == i)
            {
                Console.Write($"{arrow} ");
            }
            else
            {
                Console.Write("  ");
            }

            if (i == music.Length - 1 && whichLanguage == "en")
            {
                Console.WriteLine("Back ↩                        [ESC]");
            }
            else
            {
                Console.WriteLine(music[i]);
            }
        }


        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.M)
        {
            //majorTom.Play();
            whichMusic = 0;
        }
        else if (key.Key == ConsoleKey.C)
        {
            //calmDown = new SoundPlayer("Rema, Selena Gomez - Calm Down.wav");
            //calmDown.PlayLooping();
            whichMusic = 1;
        }
        else if (key.Key == ConsoleKey.P)
        {
            //ps500 = new SoundPlayer("BONEZ MC RAF Camora - 500 PS.wav");
            //ps500.PlayLooping();
            whichMusic = 2;
        }
        else if (key.Key == ConsoleKey.R)
        {
            //rockMeAmadeus = new SoundPlayer("Falco - Rock me Amadeus.wav");
            //rockMeAmadeus.PlayLooping();
            whichMusic = 3;
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            back = "escape";
        }

        if (back != "escape")
        {
            Console.Clear();
            goto Musik;

        }
        else
        {
            Console.Clear();
        }

    }

    static void Language()
    {
        char arrow = '\u21D2';
        string[] language;

    Language:
        if (whichLanguage == "de")
        {
            language = File.ReadAllLines("Language_German.txt");
            Console.WriteLine("Sprache");
            Console.WriteLine("‾‾‾‾‾‾‾");
        }
        else
        {
            language = File.ReadAllLines("Language_English.txt");
            Console.WriteLine("Language");
            Console.WriteLine("‾‾‾‾‾‾‾‾");
        }

        for (int i = 0; i < language.Length; i++)
        {
            if (whichLanguage == "de" && i == 0)
            {
                Console.Write($"{arrow} ");
            }
            else if (whichLanguage == "en" && i == 1)
            {
                Console.Write($"{arrow} ");
            }
            else
            {
                Console.Write("  ");
            }
            Console.WriteLine(language[i]);
        }

        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.G)
        {
            whichLanguage = "de";
        }
        else if (key.Key == ConsoleKey.E)
        {
            whichLanguage = "en";
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            back = "escape";
        }
        Console.Clear();

        if (back != "escape")
        {
            goto Language;
        }
    }
    static void CollectWhich()
    {

    Hauptmenue:
        var key1 = Console.ReadKey(true);

        if (key1.Key == ConsoleKey.R)
        {
            Console.Clear();
            Laws();
        }
        else if (key1.Key == ConsoleKey.M)
        {
            Console.Clear();
            Music();
        }
        else if (key1.Key == ConsoleKey.L)
        {
            Console.Clear();
            Language();
        }
        else if (key1.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Environment.Exit(1);
        }
        else if (key1.Key == ConsoleKey.S)
        {
            Console.Clear();
            Settings();
        }
        else if (key1.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            string[] A = File.ReadAllLines("A.txt");
            string[] E = File.ReadAllLines("E.txt");
            string[] N = File.ReadAllLines("N.txt");
            string[] R = File.ReadAllLines("R.txt");
            string[] S = File.ReadAllLines("S.txt");
            string[] T = File.ReadAllLines("T.txt");
            string[] bindestrich = File.ReadAllLines("-.txt");

            while (true)
            {
                Console.Clear();
                Thread.Sleep(250);

                for (int i = 0; i < 16; i++)
                {
                    Console.WriteLine();
                }

                Console.SetCursorPosition(Console.CursorLeft + 35, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < E.Length; i++)
                {
                    Console.WriteLine(E[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 35, Console.CursorTop);
                }
                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(Console.CursorLeft + 7, Console.CursorTop - 5);

                for (int i = 0; i < N.Length; i++)
                {
                    Console.WriteLine(N[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 42, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(Console.CursorLeft + 7, Console.CursorTop - 5);

                for (int i = 0; i < T.Length; i++)
                {
                    Console.WriteLine(T[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 49, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(Console.CursorLeft + 7, Console.CursorTop - 5);

                for (int i = 0; i < E.Length; i++)
                {
                    Console.WriteLine(E[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 56, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(Console.CursorLeft + 7, Console.CursorTop - 5);

                for (int i = 0; i < R.Length; i++)
                {
                    Console.WriteLine(R[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 63, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(Console.CursorLeft + 7, Console.CursorTop - 5);

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.CursorLeft + 70, Console.CursorTop);
                }
                for (int i = 0; i < bindestrich.Length; i++)
                {
                    Console.WriteLine(bindestrich[i]);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(Console.CursorLeft + 77, Console.CursorTop - 3);

                for (int i = 0; i < S.Length; i++)
                {
                    Console.WriteLine(S[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 77, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.SetCursorPosition(Console.CursorLeft + 7, Console.CursorTop - 5);

                for (int i = 0; i < T.Length; i++)
                {
                    Console.WriteLine(T[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 84, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(Console.CursorLeft + 6, Console.CursorTop - 5);

                for (int i = 0; i < A.Length; i++)
                {
                    Console.WriteLine(A[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 90, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(Console.CursorLeft + 8, Console.CursorTop - 5);

                for (int i = 0; i < R.Length; i++)
                {
                    Console.WriteLine(R[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 98, Console.CursorTop);
                }

                Thread.Sleep(200);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Console.CursorLeft + 6, Console.CursorTop - 5);

                for (int i = 0; i < T.Length; i++)
                {
                    Console.WriteLine(T[i]);
                    Console.SetCursorPosition(Console.CursorLeft + 104, Console.CursorTop);
                }

                Thread.Sleep(250);

                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(100);


                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;

                }
            }
            Movie();
        }
        else
        {
            goto Hauptmenue;
        }

    }
    static void Settings()
    {

    Einstellungen:
        if (whichLanguage == "de")
        {
            Console.WriteLine("Einstellungen");
            Console.WriteLine("‾‾‾‾‾‾‾‾‾‾‾‾‾");

            if (subtitle == 0)
            {
                Console.WriteLine("(AUS) - Untertitel [S]");
            }
            else
            {
                Console.WriteLine("(EIN) - Untertitel        [S]");

                if (subtitleLanguage == "de")
                {
                    Console.WriteLine("(DE) - Untertitel-Sprache [L]");
                }
                else
                {
                    Console.WriteLine("(EN) - Untertitel-Sprache [L]");
                }

            }
            Console.WriteLine("Zurück ↩          [ESC]");
        }
        else
        {
            Console.WriteLine("Settings");
            Console.WriteLine("‾‾‾‾‾‾‾‾");

            if (subtitle == 0)
            {
                Console.WriteLine("(OFF) - Subtitle [S]");
            }
            else
            {
                Console.WriteLine("(ON) - Subtitle        [S]");

                if (subtitleLanguage == "de")
                {
                    Console.WriteLine("(GE) - Subtitle-Language [L]");
                }
                else
                {
                    Console.WriteLine("(EN) - Subtitle-Language [L]");
                }
            }
            Console.WriteLine("Back ↩ [ESC]");
        }

        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.S)
        {
            if (subtitle == 0)
            {
                subtitle = 1;
            }
            else
            {
                subtitle = 0;
            }
        }
        else if (key.Key == ConsoleKey.L)
        {
            if (subtitleLanguage == "de")
            {
                subtitleLanguage = "en";
            }
            else
            {
                subtitleLanguage = "de";
            }
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            back = "escape";
        }

        Console.Clear();

        if (back != "escape")
        {
            goto Einstellungen;
        }
    }

    static void PrintJoke(string text, int mühle)
    {
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
        Console.Write(text);
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText($"Mühle_Test{mühle}.txt"));
    }
    static void Movie()
    {
        if (whichMusic == 0)
        {
            //majorTom.Stop();
        }
        else if (whichMusic == 1)
        {
            //calmDown.Stop();
        }
        else if (whichMusic == 2)
        {
            //ps500.Stop();
        }
        else
        {
            //rockMeAmadeus.Stop();
        }

        Console.WriteLine(File.ReadAllText("Mühle_Test0.txt"));
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText("Mühle_Test3.txt"));
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText("Mühle_Test1.txt"));
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText("Mühle_Test2.txt"));

        if (subtitle == 1)
        {
            if (subtitleLanguage == "de")
            {
            Witz1D:
                if (whichLanguage == "de")
                {
                    witz1D.Play();
                }
                else
                {
                    witz1E.Play();
                }

                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 0);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 3);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 1);
                PrintJoke("Freitagabend. \"Schatz, sollen wir uns ein schönes Wochenende machen?\" - \"Klar!\" - \"Klasse, dann bis Montag!\"", 2);
            Witz2D:
                if (whichLanguage == "de")
                {
                    witz2D.Play();
                }
                else
                {
                    witz2E.Play();
                }

                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 0);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 3);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 1);
                PrintJoke("Ein Informatiker schiebt einen Kinderwagen durch den Park. Kommt ein älteres Ehepaar: „Junge oder Mädchen?“ Informatiker: „Richtig!“ ", 2);

            Witz3D:
                if (whichLanguage == "de")
                {
                    witz3D.Play();
                }
                else
                {
                    witz3E.Play();
                }
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 0);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 3);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 1);
                PrintJoke("Was ist die Lieblingsbeschäftigung von Bits? – Busfahren.", 2);
            Witz4D:
                if (whichLanguage == "de")
                {
                    witz4D.Play();
                }
                else
                {
                    goto Witz5D;
                }
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 0);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 3);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 1);
                PrintJoke("Treffen sich zwei Jäger im Wald – beide tot.", 2);
            Witz5D:
                if (whichLanguage == "de")
                {
                    witz5D.Play();
                }
                else
                {
                    witz4E.Play();
                }
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 0);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 3);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 1);
                PrintJoke("„Was machen Mathematiker im Garten?“ – Wurzeln ziehen", 2);
            Witz6D:
                if (whichLanguage == "de")
                {
                    witz6D.Play();
                }
                else
                {
                    goto Witz7D;
                }

                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 0);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 3);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 1);
                PrintJoke("Egal, wie gut du schläfst: Albert schläft wie Einstein.", 2);
            Witz7D:
                if (whichLanguage == "de")
                {
                    witz7D.Play();
                }
                else
                {
                    goto Witz8D;
                }

                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 0);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 3);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 1);
                PrintJoke("„Was ist das Wichtigste bei einem Schweißausbruch?“ – Das W!", 2);
            Witz8D:
                if (whichLanguage == "de")
                {
                    witz8D.Play();
                }
                else
                {
                    witz5E.Play();
                }
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 0);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 3);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 1);
                PrintJoke("Meine Oma arbeitet für das FBI – wir nennen sie jetzt nur noch Top-Sigrid.", 2);
            Witz9D:
                if (whichLanguage == "de")
                {
                    witz9D.Play();
                }
                else
                {
                    goto Witz10D;
                }

                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 0);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 3);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 1);
                PrintJoke("Geht ein Neutron in die Disco. Sagt der Türsteher: „Nur für geladene Gäste!“", 2);
            Witz10D:
                if (whichLanguage == "de")
                {
                    witz10D.Play();
                }
                else
                {
                    witz6E.Play();
                }
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 0);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 3);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 1);
                PrintJoke("„Dingdong. „Guten Tag, wir sammeln fürs Kinderheim. Haben Sie etwas abzugeben?“ – „Kevin, Justin – kommt mal her!“", 2);
            }
            else
            {
            Witz1E:
                if (whichLanguage == "de")
                {
                    witz1D.Play();
                }
                else
                {
                    witz1E.Play();
                }
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 0);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 3);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 1);
                PrintJoke("Friday evening. \"Honey, shall we have a nice weekend?\" - \"Clear!\" - \"Great, then see you on Monday!\"", 2);

            Witz2E:
                if (whichLanguage == "de")
                {
                    witz2D.Play();
                }
                else
                {
                    witz2E.Play();
                }
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 0);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 3);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 1);
                PrintJoke("A computer scientist pushes a stroller through the park. An older couple comes: \"Boy or girl?\" Computer scientist: \"True!\"", 2);

            Witz3E:
                if (whichLanguage == "de")
                {
                    witz3D.Play();
                }
                else
                {
                    witz3E.Play();
                }
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 0);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 3);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 1);
                PrintJoke("What is Bits' favorite pastime? – Bus driving.", 2);

            Witz4E:
                if (whichLanguage == "de")
                {
                    witz5D.Play();
                }
                else
                {
                    witz4E.Play();
                }
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 0);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 3);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 1);
                PrintJoke("What do mathematicians do in the garden? - Pulling roots", 2);

            Witz5E:
                if (whichLanguage == "de")
                {
                    witz8D.Play();
                }
                else
                {
                    witz5E.Play();
                }
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 0);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 3);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 1);
                PrintJoke("My grandma works for the FBI - we just call her Top Sigrid now.", 2);

            Witz6E:
                if (whichLanguage == "de")
                {
                    witz10D.Play();
                }
                else
                {
                    witz6E.Play();
                }
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 0);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 3);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 1);
                PrintJoke("Ding dong. \"Hello, we are collecting for the orphanage. Do you have something to give?” – “Kevin, Justin – come here!”", 2);
            }
        }
        else
        {
            if (whichLanguage == "en")
            {
                witz1E.Play();

                for (int i = 0; i < 17; i++)
                {
                    Animation();
                }

                witz2E.Play();

                for (int i = 0; i < 18; i++)
                {
                    Animation();
                }

                witz3E.Play();

                for (int i = 0; i < 8; i++)
                {
                    Animation();
                }

                witz4E.Play();

                for (int i = 0; i < 8; i++)
                {
                    Animation();
                }

                witz5E.Play();

                for (int i = 0; i < 12; i++)
                {
                    Animation();
                }

                witz6E.Play();

                for (int i = 0; i < 17; i++)
                {
                    Animation();
                }

            }
            else
            {
                witz1D.Play();

                for (int i = 0; i < 17; i++)
                {
                    Animation();
                }

                witz2D.Play();

                for (int i = 0; i < 18; i++)
                {
                    Animation();
                }

                witz3D.Play();

                for (int i = 0; i < 8; i++)
                {
                    Animation();
                }

                witz4D.Play();

                for (int i = 0; i < 8; i++)
                {
                    Animation();
                }

                witz5D.Play();

                for (int i = 0; i < 8; i++)
                {
                    Animation();
                }

                witz6D.Play();

                for (int i = 0; i < 10; i++)
                {
                    Animation();
                }

                witz7D.Play();

                for (int i = 0; i < 8; i++)
                {
                    Animation();
                }

                witz8D.Play();

                for (int i = 0; i < 12; i++)
                {
                    Animation();
                }

                witz9D.Play();

                for (int i = 0; i < 12; i++)
                {
                    Animation();
                }

                witz10D.Play();

                for (int i = 0; i < 17; i++)
                {
                    Animation();
                }



            }
        }
    }

    static void Animation()
    {
        Console.WriteLine(File.ReadAllText("Mühle_Test0.txt"));
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText("Mühle_Test3.txt"));
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText("Mühle_Test1.txt"));
        Thread.Sleep(150);
        Console.Clear();
        Console.WriteLine(File.ReadAllText("Mühle_Test2.txt"));
        Thread.Sleep(150);
        Console.Clear();
    }
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        //majorTom = new SoundPlayer("Peter Schilling - Major Tom.wav"); Auskommentierte Musik aufgrund Größe!
        //majorTom.PlayLooping();

        Console.OutputEncoding = Encoding.UTF8;
    Begin:
        CollectingMenue();

        if (back == "escape")
        {
            back = "";
            goto Begin;
        }

    }
}