namespace Restriction
{
    public class Program
    {
        public void Main(string[] args)
        {
            var sample = new WhereClause1();
            sample.QuerySyntaxExample();
            sample.MethodSyntaxExample();
            var sample2 = new WhereClause2();
            sample2.MethodSyntaxExample();
            sample2.QuerySyntaxExample();
        }
    }
}