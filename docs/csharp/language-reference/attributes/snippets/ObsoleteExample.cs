// <Snippet1>
using System;

namespace AttributeExamples
{
    [Obsolete("use class B")]
    public class A
    {
        public void Method() { }
    }

    public class B
    {
        [Obsolete("use NewMethod", true)]
        public void OldMethod() { }

        public void NewMethod() { }
    }

    public static class ObsoleteProgram
    {
        public static void Main()
        {
            // Generates 2 warnings:
            A a = new A();

            // Generate no errors or warnings:
            B b = new B();
            b.NewMethod();

            // Generates an error, compilation fails.
            // b.OldMethod();
        }
    }
}
// </Snippet1>

namespace ExampleConstantInterpolation
{
    // <Snippet2>
    public class B
    {
        [Obsolete($"use {nameof(NewMethod)} instead", true)]
        public void OldMethod() { }

        public void NewMethod() { }
    }
    // </Snippet2>

}

