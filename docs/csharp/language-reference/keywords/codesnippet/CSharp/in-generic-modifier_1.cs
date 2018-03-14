    // Contravariant interface.
    interface IContravariant<in A> { }

    // Extending contravariant interface.
    interface IExtContravariant<in A> : IContravariant<A> { }

    // Implementing contravariant interface.
    class Sample<A> : IContravariant<A> { }

    class Program
    {
        static void Test()
        {
            IContravariant<Object> iobj = new Sample<Object>();
            IContravariant<String> istr = new Sample<String>();

            // You can assign iobj to istr because
            // the IContravariant interface is contravariant.
            istr = iobj;
        }
    }