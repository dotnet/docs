    class A
    {
        protected int x = 123;
    }

    class B : A
    {
        static void Main()
        {
            A a = new A();
            B b = new B();

            // Error CS1540, because x can only be accessed by
            // classes derived from A.
            // a.x = 10; 

            // OK, because this class derives from A.
            b.x = 10;
        }
    }