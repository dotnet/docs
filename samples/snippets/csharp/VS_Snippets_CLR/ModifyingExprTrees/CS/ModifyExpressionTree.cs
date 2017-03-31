using System;
using System.Linq.Expressions;

namespace ModifyingExprTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet3>
            Expression<Func<string, bool>> expr = name => name.Length > 10 && name.StartsWith("G");
            Console.WriteLine(expr);

            AndAlsoModifier treeModifier = new AndAlsoModifier();
            Expression modifiedExpr = treeModifier.Modify((Expression) expr);

            Console.WriteLine(modifiedExpr);

            /*  This code produces the following output:
                
                name => ((name.Length > 10) && name.StartsWith("G"))
                name => ((name.Length > 10) || name.StartsWith("G"))
            */

            // </Snippet3>

            Console.ReadLine();
        }
    }
}
