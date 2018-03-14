namespace QueryExecution
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq query execution examples within the project
            DeferredExecutionExample1.QuerySyntaxExample();
            DeferredExecutionExample1.MethodSyntaxExample();

            ImmediateExecutionExample1.QuerySyntaxExample();
            ImmediateExecutionExample1.MethodSyntaxExample();

            DeferredExecutionExample2.QuerySyntaxExample();
            DeferredExecutionExample2.MethodSyntaxExample();
        }
    }
}