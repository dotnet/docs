//<snippet1>
using System;

public class IndexOfTest {
    public static void Main() {

        string strSource = "This is the string which we will perform the search on";

        Console.WriteLine("The search string is:{0}\"{1}\"{0}", Environment.NewLine, strSource);

        string strTarget = "";
        int found = 0;
        int totFinds = 0;

        do {
            Console.Write("Please enter a search value to look for in the above string (hit Enter to exit) ==> ");

            strTarget = Console.ReadLine();

            if (strTarget != "") {

                for (int i = 0; i < strSource.Length; i++) {

                    found = strSource.IndexOf(strTarget, i);

                    if (found >= 0) {
                        totFinds++;
                        i = found;
                    }
                    else
                        break;
                }
            }
            else
                return;

            Console.WriteLine("{0}The search parameter '{1}' was found {2} times.{0}",
                    Environment.NewLine, strTarget, totFinds);

            totFinds = 0;

        } while ( true );
    }
}
// </snippet1>
