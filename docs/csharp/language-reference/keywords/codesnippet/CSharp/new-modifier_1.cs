    public class BaseC
    {
        public int x;
        public void Invoke() { }
    }
    public class DerivedC : BaseC
    {
        new public void Invoke() { }
    }