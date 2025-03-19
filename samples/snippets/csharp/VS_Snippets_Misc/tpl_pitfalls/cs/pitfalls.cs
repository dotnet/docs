using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pitfalls_cs
{
    class Program
    {
        Button button1 = new Button();
        Button button2 = new Button();
        int N = 100;
        static void Main(string[] args)
        {
            //<snippet01>
            ManualResetEventSlim mre = new ManualResetEventSlim();
            Enumerable.Range(0, Environment.ProcessorCount * 100)
                .AsParallel()
                .ForAll((j) =>
                    {
                        if (j == Environment.ProcessorCount)
                        {
                            Console.WriteLine($"Set on {Thread.CurrentThread.ManagedThreadId} with value of {j}");
                            mre.Set();
                        }
                        else
                        {
                            Console.WriteLine($"Waiting on {Thread.CurrentThread.ManagedThreadId} with value of {j}");
                            mre.Wait();
                        }
                    }); //deadlocks
            //</snippet01>
        }

        //<snippet02>
        private void button1_Click(object sender, EventArgs e)
        {
            Parallel.For(0, N, i =>
            {
                // do work for i
                button1.Invoke((Action)delegate { DisplayProgress(i); });
            });
        }
        //</snippet02>
        static void DisplayProgress(int i) { }

        //<snippet03>
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
                Parallel.For(0, N, i =>
                {
                    // do work for i
                    button1.Invoke((Action)delegate { DisplayProgress(i); });
                })
                 );
        }
        //</snippet03>

        private void Urg()
        {
        string path = @"C\";
        //<snippet04>
        FileStream fs = File.OpenWrite(path);
        byte[] bytes = new Byte[10000000];
        // ...
        Parallel.For(0, bytes.Length, (i) => fs.WriteByte(bytes[i]));
        //</snippet04>
        }
    }
}
