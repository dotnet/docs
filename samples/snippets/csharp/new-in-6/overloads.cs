using System.Threading.Tasks;

namespace NewStyle
{
    public class Example
    {
        static Task DoThings() 
        {
             return Task.FromResult(0); 
        }

        public static void TestMethod()
        {
            Task.Run(DoThings); 

            Task.Run(() => DoThings());
        }
    }
}