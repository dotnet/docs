namespace Projection
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq projection examples within the project
            SelectSample1.MethodSyntaxExample();
            SelectSample1.QuerySyntaxExample();

            SelectSample2.MethodSyntaxExample();
            SelectSample2.QuerySyntaxExample();

            SelectSample3.MethodSyntaxExample();
            SelectSample3.QuerySyntaxExample();

            SelectSample4.QuerySyntaxExample();
            SelectSample4.MethodSyntaxExample();

            SelectSample5.MethodSyntaxExample();
            SelectSample5.QuerySyntaxExample();

            SelectSample6.MethodSyntaxExample();
            SelectSample6.QuerySyntaxExample();

            SelectSample7.Example();

            SelectSample8.MethodSyntaxExample();
            SelectSample8.QuerySyntaxExample();

            SelectManySample1.QuerySyntaxExample();

            SelectManySample2.MethodSyntaxExample();
            SelectManySample2.QuerySyntaxExample();

            SelectManySample3.MethodSyntaxExample();
            SelectManySample3.QuerySyntaxExample();

            SelectManySample4.MethodSyntaxExample();
            SelectManySample4.QuerySyntaxExample();

            SelectManySample5.Example();
        }
    }
}