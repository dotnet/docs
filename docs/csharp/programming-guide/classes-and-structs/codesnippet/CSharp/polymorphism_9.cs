        public class Base
        {
            public virtual void DoWork() {/*...*/ }
        }
        public class Derived : Base
        {
            public override void DoWork()
            {
                //Perform Derived's work here
                //...
                // Call DoWork on base class
                base.DoWork();
            }
        }