namespace Restriction
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq restriction examples within the project
            WhereClause1.QuerySyntaxExample();
            WhereClause1.MethodSyntaxExample();

            WhereClause2.QuerySyntaxExample();
            WhereClause2.MethodSyntaxExample();

            WhereClause3.QuerySyntaxExample();
            WhereClause3.MethodSyntaxExample();

            WhereClause4.Example();
        }
    }
}