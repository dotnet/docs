namespace objectoriented
{
    //<SnippetPublicAccess>
    public class Bicycle
    {
        public void Pedal() { }
    }
    //</SnippetPublicAccess>

    //<SnippetMethodAccess>
    // public class:
    public class Tricycle
    {
        // protected method:
        protected void Pedal() { }

        // private field:
        private int wheels = 3;

        // protected internal property:
        protected internal int Wheels
        {
            get { return wheels; }
        }
    }
    //</SnippetMethodAccess>
}