using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace Multithreading
{
    class Program
    {
        public static int total = 0;
        public static void Sum(object filename)
        {
            int temp = 0;
            var data = File.ReadAllText((string)filename);

            var lines = data.Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in lines)
            {
                temp += int.Parse(item);
            }
            lock((object)total)
            {
                total += temp;
            }
        }

        public static void Multithread()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string[] filePaths = Directory.GetFiles(@"data\", "*.txt", SearchOption.TopDirectoryOnly);
            foreach (string filePath in filePaths)
            {
                Thread thread = new Thread(Sum);
                thread.Start(filePath);

            }
            Thread.Sleep(100);
            Console.WriteLine(total);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine("RunTime " + ts.Milliseconds);
        }
        public static void SingleThread()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string[] filePaths = Directory.GetFiles(@"data\", "*.txt", SearchOption.TopDirectoryOnly);
            foreach (string filePath in filePaths)
            {
                Thread thread = new Thread(Sum);
                thread.Start(filePath);
                thread.Join();

            }
            Thread.Sleep(100);
            Console.WriteLine(total);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine("RunTime " + ts.Milliseconds);
        }

        public static void Main()
        {
            Multithread();
            total = 0;
            SingleThread();
        }
    }
}
