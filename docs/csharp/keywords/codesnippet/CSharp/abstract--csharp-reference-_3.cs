    abstract class BaseClass   // Abstract class
    {
        protected int _x = 100;
        protected int _y = 150;
        public abstract void AbstractMethod();   // Abstract method
        public abstract int X    { get; }
        public abstract int Y    { get; }
    }

    class DerivedClass : BaseClass
    {
        public override void AbstractMethod()
        {
            _x++;
            _y++;
        }

        public override int X   // overriding property
        {
            get
            {
                return _x + 10;
            }
        }

        public override int Y   // overriding property
        {
            get
            {
                return _y + 10;
            }
        }

        static void Main()
        {
            DerivedClass o = new DerivedClass();
            o.AbstractMethod();
            Console.WriteLine("x = {0}, y = {1}", o.X, o.Y);
        }
    }
    // Output: x = 111, y = 161
