using System;
using System.Threading;

namespace HospitalManager.Helpers
{
    public static class ConsoleActions
    {
        public static void ClearChosenNumberFromLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        
        public static void ShowWaitingDots()
        {
            Console.Write(". ");
            Thread.Sleep(1000);
            Console.Write(". ");
            Thread.Sleep(1000);
            Console.Write(". ");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
