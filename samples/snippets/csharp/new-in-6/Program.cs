using System;
using System.Runtime.CompilerServices;

namespace NewInCSharp6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = new OldStyle.Student();
            t.Grades.Add(4.5);
        }

        private void PerformFailingOperation() {}
    }

    public class RecoverableException : Exception
    {
    }
}
