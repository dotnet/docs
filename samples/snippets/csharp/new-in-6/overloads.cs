using System.Threading.Tasks;

namespace NewStyle
{
    public class Example
    {
        // <AsyncMethod>
        static Task DoThings() 
        {
             return Task.FromResult(0); 
        }
        // </AsyncMethod>

        public static void TestMethod()
        {
            // <MethodGroup>
            Task.Run(DoThings); 
            // </MethodGroup>

            // <Lambda>
            Task.Run(() => DoThings());
            // </Lambda>
        }
    }
}