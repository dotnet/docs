using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class Resource : IDisposable
    {
        private bool isDisposed = false;
        public int Argument
        {
            get
            {
                if (!isDisposed)
                    return 5;
                else throw new ObjectDisposedException("Resource");
            }
        }

        public void Dispose()
        {
            isDisposed = true;
        }
    }

    public class ExpressionTreeExecutionSampleTwo : Sample
    {
        public override string Name { get; } = "Executing Expression Trees, Sample 2: Bound Variables";
        
        public override void Run()
        {
            var del = CreateBoundFunc();
            Console.WriteLine(del(5));

            try {
                var del2 = CreateBoundResource();
                Console.WriteLine(del2(5));
            } catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        private static Func<int, int> CreateBoundFunc()
        {
            var constant = 5; // constant is captured by the expression tree
            Expression<Func<int, int>> expression = (b) => constant + b;
            var rVal = expression.Compile();
            return rVal;
        }

        private static Func<int, int> CreateBoundResource()
        {
            using (var constant = new Resource()) // constant is captured by the expression tree
            {
                Expression<Func<int, int>> expression = (b) => constant.Argument + b;
                var rVal = expression.Compile();
                return rVal;
            }
        }
    }
}