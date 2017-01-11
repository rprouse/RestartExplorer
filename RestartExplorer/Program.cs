using System;
using System.Diagnostics;
using System.Linq;

namespace RestartExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            KillExplorer();
            StartExplorer();
        }

        static void KillExplorer()
        {
            var explorer = Process.GetProcessesByName("explorer").FirstOrDefault();
            if(explorer == null)
            {
                WriteLine("Could not find the explorer process", ConsoleColor.DarkRed);
                return;
            }
            WriteLine($"Killing explorer PID {explorer.Id}", ConsoleColor.Cyan);
            explorer.Kill();
            explorer.WaitForExit(1000);
        }

        static void StartExplorer()
        {
            var explorer = new Process();
            explorer.StartInfo.FileName = "explorer.exe";
            explorer.StartInfo.UseShellExecute = true;
            if(explorer.Start())
            {
                WriteLine($"Restarted explorer PID {explorer.Id}", ConsoleColor.Green);
            }
            else
            {
                WriteLine("Failed to restart explorer", ConsoleColor.DarkRed);
            }
        }

        static void WriteLine(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}
