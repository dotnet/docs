    class Program
    {
        static void Main(string[] args)
        {
            SampleObject root = new SampleObject();

            SampleObject currentObject = root;

            for (int i = 0; i < 10; i++)
            {
                SampleObject o = new SampleObject();

                currentObject.Child = o;

                currentObject = o;
            }
        }
    }