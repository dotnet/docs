//<Snippet1>
using System;

namespace InSourceSuppression
{
    public class Class1
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "args")]
        static void Main(string[] args) { }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
        "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Guid")]
        public static bool IsValidGuid(string guid)
        {
            try
            {
              new Guid(guid); //Causes CA1806: DoNotIgnoreMethodResults
              return true;
            }
            catch (ArgumentNullException) {}
            catch (OverflowException) {}
            catch (FormatException) {}
            return false;
        }
   }
}
//</Snippet1>

