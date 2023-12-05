using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList nonGenericCollection = new ArrayList();
            //<snippet07>
            Parallel.ForEach(nonGenericCollection.Cast<object>(),
                currentElement =>
                {
                });
            //</snippet07>
        }
    }
}
