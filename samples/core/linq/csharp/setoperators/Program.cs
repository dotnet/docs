namespace SetOperators
{
    public class Program
    {
        //Entry point of application
        public static void Main(string[] args)
        {
            //Invoke the linq set operator examples within the project
           SetDistinct1.MethodSyntaxExample();
           
           SetDistinct2.QuerySyntaxExample();
           SetDistinct2.MethodSyntaxExample();
           
           SetUnion1.MethodSyntaxExample();
           
           SetUnion2.MethodSyntaxExample();
           
           SetIntersect1.MethodSyntaxExample();
           
           SetIntersect2.MethodSyntaxExample();
           
           SetExcept1.MethodSyntaxExample();
           
           SetExcept2.MethodSyntaxExample();
        }
    }
}
