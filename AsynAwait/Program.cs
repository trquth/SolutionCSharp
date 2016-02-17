using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task task = new Task(ProcessDataAsync);
            //task.Start();
            //task.Wait();
            //Console.ReadLine();
            //while (true)
            //{
            //    Example();
            //    string result = Console.ReadLine();
            //    Console.WriteLine("You typed: " + result);
            //}
            //Task task = new Task(() => ShowText());
            //Task<int> task2 = new Task<int>(() => ShowNumber());
            //Task<Int64> task3 = new Task<Int64>(x => CountResult((int)x),10000000);
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Int64> t = new Task<Int64>(() => Sum(cts.Token, 1000), cts.Token);
            t.Start();
            cts.Cancel();

            try
            {
                // If the task got canceled, Result will throw an AggregateException
                Console.WriteLine("The sum is: " + t.Result);   // An Int32 value
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => e is OperationCanceledException);
                Console.WriteLine("Sum was canceled");
            }
            //task.Start();           
            //task3.Start();
            //task2.Start();
            //Console.WriteLine("Result: "+task2.Result);
            //Console.WriteLine("Result 2: " + task3.Result);
            Console.WriteLine("Main method complete. Press <enter> to finish.");
            Console.ReadLine();
        }
        #region Example      
        static async void ProcessDataAsync()
        {
            Task<int> task = ReadFileText("C:\\Users\\thien.tran\\Desktop\\Git\\VitrualMethod\\AsynAwait\\Demo.txt");
            Console.WriteLine("Please wait patiently " +
        "while I do something important.");
            int x = await task;
            Console.WriteLine("Count " + x);
        }
        //Doc file
        static async Task<int> ReadFileText(string file)
        {
            Console.WriteLine("Start!");
            int count = 0;
            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();
                count += v.Length;

                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("Exit!!!!!!");
            return count;
        }
        //Example 2
        static async void Example()
        {
            int i = await Task.Run(() => Allocate());
            Console.WriteLine("Compute: " + i);
        }
        static int Allocate()
        {
            int size = 0;
            for (int i = 0; i < 1000; i++)
            {
                string value = i.ToString();
                if (value==null)
                {
                    return 0;
                }
                size += value.Length;
            }
            return size;
        }
        private static void ShowText()
        {
            Console.WriteLine("Hello word!!!");
        }
        private static int ShowNumber()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                result += i;
            }

            return result;
        }
        private static Int64 CountResult(int x)
        {
            Int64 result = 0;
            for (int i = 0; i < x; i++)
            {
                result += i;
            }
            return result;
        }
        #endregion
        private static Int64 Sum(CancellationToken ct, int n)
        {
            Int64 count=0;
            for (; n>0 ; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked { count += n; }
            }
            return count;
        }
    }

}
