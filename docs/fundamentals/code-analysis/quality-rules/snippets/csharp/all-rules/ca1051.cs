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
        public int InstanceData { get; set; } = 32;
    }
    //</snippet1>
}
