namespace ca1033
{
    //<snippet1>
    public interface ITest
    {
        void SomeMethod();
    }

    public class ViolatingBase : ITest
    {
        void ITest.SomeMethod()
        {
            // ...
        }
    }

    public class FixedBase : ITest
    {
        void ITest.SomeMethod()
        {
            SomeMethod();
        }

        protected void SomeMethod()
        {
            // ...
        }
    }

    sealed public class Derived : FixedBase, ITest
    {
        public void SomeMethod()
        {
            // The following would cause recursion and a stack overflow.
            // ((ITest)this).SomeMethod();

            // The following is unavailable if derived from ViolatingBase.
            base.SomeMethod();
        }
    }
    //</snippet1>
}
