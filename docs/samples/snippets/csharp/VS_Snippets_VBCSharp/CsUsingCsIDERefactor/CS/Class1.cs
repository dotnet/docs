using System;
using System.Collections.Generic;
using System.Text;

namespace CSUsingCsIDERefactor
{
    //<Snippet1>
    interface IBase
    {
        void Method();
    }
    public class Base
    {
        public void Method()
        { }
        public virtual void Method(int i)
        { }
    }
    public class Derived : Base, IBase
    {
        public new void Method()
        { }
        public override void Method(int i)
        { }
    }
    public class C : IBase
    {
        public void Method()
        { }
    }
    //</Snippet1>
}
