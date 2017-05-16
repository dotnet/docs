// <Snippet1>
using System;

class MyArrayRankSample
{
    public static void Main()
    {
        try
        {
            int[,,] myArray = new int[,,] {{{12,2,35},{300,78,33}},{{92,42,135},{30,7,3}}};
            Type myType = myArray.GetType();

            Console.WriteLine("Contents of myArray: {{{12,2,35},{300,78,33}},{{92,42,135},{30,7,3}}}");
            Console.WriteLine("myArray has {0} dimensions.", myType.GetArrayRank());
        }
        catch(NotSupportedException e)
        {
            Console.WriteLine("NotSupportedException raised.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception raised.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }      
    }
}
// </Snippet1>
