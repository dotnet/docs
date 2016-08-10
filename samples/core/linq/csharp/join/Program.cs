namespace Join
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq join examples within the project
            CrossJoinExample1.MethodSyntaxExample();
            CrossJoinExample1.QuerySyntaxExample();

            GroupJoinExample1.MethodSyntaxExample();
            GroupJoinExample1.QuerySyntaxExample();

            CrossJoinWithGroupJoinExample1.MethodSyntaxExample();
            CrossJoinWithGroupJoinExample1.QuerySyntaxExample();

            LeftOuterJoinExample1.MethodSyntaxExample();
            LeftOuterJoinExample1.QuerySyntaxExample();
        }
    }
}