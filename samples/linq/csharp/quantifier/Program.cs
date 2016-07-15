namespace Quantifier
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq quantifiers examples within the project
            AnySample1.Example();

            AnySample2.MethodSyntaxExample();
            AnySample2.QuerySyntaxExample();

            AllSample1.Example();

            AllSample2.MethodSyntaxExample();
            AllSample2.QuerySyntaxExample();
        }
    }
}
