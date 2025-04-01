//<snippet10>
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Return a value type with a lambda expression
        Task<int> task1 = Task<int>.Factory.StartNew(() => 1);
        int i = task1.Result;

        // Return a named reference type with a multi-line statement lambda.
        Task<Test> task2 = Task<Test>.Factory.StartNew(() =>
        {
            string s = ".NET";
            double d = 4.0;
            return new Test { Name = s, Number = d };
        });
        Test test = task2.Result;

        // Return an array produced by a PLINQ query
        Task<string[]> task3 = Task<string[]>.Factory.StartNew(() =>
        {
            string path = @"C:\Users\Public\Pictures\Sample Pictures\";
            string[] files = System.IO.Directory.GetFiles(path);

            string[] result = (from file in files.AsParallel()
                          let info = new System.IO.FileInfo(file)
                          where info.Extension == ".jpg"
                          select file).ToArray();

            return result;
        });

        foreach (string name in task3.Result)
            Console.WriteLine(name);
    }
    class Test
    {
        public string Name { get; set; }
        public double Number { get; set; }
    }
}
//</snippet10>
