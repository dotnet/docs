// <Snippet1>
using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        ArrayList colors = new ArrayList();
        colors.Add("red");
        colors.Add("blue");
        colors.Add("green");
        colors.Add("yellow");
        colors.Add("beige");
        colors.Add("brown");
        colors.Add("magenta");
        colors.Add("purple");

        IEnumerator e = colors.GetEnumerator();
        while (e.MoveNext())
        {
            Object obj = e.Current;
            Console.WriteLine(obj);
        }

        Console.WriteLine();

        IEnumerator e2 = colors.GetEnumerator(2, 4);
        while (e2.MoveNext())
        {
            Object obj = e2.Current;
            Console.WriteLine(obj);
        }
    }
}

/* This code example produces
   the following ouput:
    red
    blue
    green
    yellow
    beige
    brown
    magenta
    purple

    green
    yellow
    beige
    brown
 */
// </Snippet1>