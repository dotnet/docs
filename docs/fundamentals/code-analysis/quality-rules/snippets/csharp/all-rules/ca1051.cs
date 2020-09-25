namespace ca1051
{
    //<snippet1>
    public class BadPublicInstanceFields
    {
        // Violates rule DoNotDeclareVisibleInstanceFields.
        public int instanceData = 32;
    }

    public class GoodPublicInstanceFields
    {
        private int instanceData = 32;

        public int InstanceData
        {
            get { return instanceData; }
            set { instanceData = value; }
        }
    }
    //</snippet1>
}
