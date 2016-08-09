using Partitioning;

namespace Partitioning
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq partitioning examples within the project
            TakeSample1.Example();

            SkipSample1.Example();

            TakeWhileSample1.Example();

            TakeWhileSample2.Example();

            SkipWhileSample1.Example();

            SkipWhileSample2.Example();
        }
    }
}
