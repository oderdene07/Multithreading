//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading;

//namespace Multithreading
//{
//    class ProgramTest
//    {
//        public static int res = 0;
//        public static void DoWork(object filePath)
//        {
//            int temp = 0;

//            var data = File.ReadAllText((string)filePath);
//            var lines = data.Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            foreach(var line in lines)
//            {
//                temp += int.Parse(line);
//            }
//            lock ((object)res)
//            {
//                res += temp;
//            }
//        }

//        public static void Main()
//        {
//            string[] filePaths = Directory.GetFiles(@"data\", "*.txt", SearchOption.TopDirectoryOnly);
//            Thread th1 = new Thread(DoWork);
//            th1.Start(filePaths[0]);

//            Thread th2 = new Thread(DoWork);
//            th2.Start(filePaths[1]);

//            Thread th3 = new Thread(DoWork);
//            th3.Start(filePaths[2]);
            
//            Thread th4 = new Thread(DoWork);
//            th4.Start(filePaths[3]);


//            //Thread.Sleep(100);
            
//            while (true)
//            {
//                if(!th1.IsAlive && !th2.IsAlive && !th3.IsAlive && !th4.IsAlive)
//                {
//                    Console.WriteLine(res);
//                    break;
//                }
//                else
//                {
//                    continue;
//                }
//            }
            
//        }
//    }
//}
