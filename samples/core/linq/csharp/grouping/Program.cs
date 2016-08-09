namespace Grouping
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq grouping examples within the project
            GroupBy1.QuerySyntaxExample();
            GroupBy1.MethodSyntaxExample();

            GroupBy2.QuerySyntaxExample();
            GroupBy2.MethodSyntaxExample();

            GroupBy3.QuerySyntaxExample();
            GroupBy3.MethodSyntaxExample();

            GroupByNested1.QuerySyntaxExample();

            GroupByComparer1.MethodSyntaxExample();

            GroupByComparer2.MethodSyntaxExample();
        }
    }
}
