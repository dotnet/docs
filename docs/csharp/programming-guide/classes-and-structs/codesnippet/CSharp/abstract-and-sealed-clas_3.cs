    // compile with: /target:library
    public class D
    {
        public virtual void DoWork(int i)
        {
            // Original implementation.
        }
    }

    public abstract class E : D
    {
        public abstract override void DoWork(int i);
    }

    public class F : E
    {
        public override void DoWork(int i)
        {
            // New implementation.
        }
    }