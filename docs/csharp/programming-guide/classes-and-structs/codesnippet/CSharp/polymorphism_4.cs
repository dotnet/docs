    public class BaseClass
    {
        public void DoWork() { WorkField++; }
        public int WorkField;
        public int WorkProperty
        {
            get { return 0; }
        }
    }

    public class DerivedClass : BaseClass
    {
        public new void DoWork() { WorkField++; }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }