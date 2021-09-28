namespace ca1044
{
    //<snippet1>
    public class BadClassWithWriteOnlyProperty
    {
        string _someName;

        // Violates rule PropertiesShouldNotBeWriteOnly.
        public string Name
        {
            set
            {
                _someName = value;
            }
        }
    }

    public class GoodClassWithReadWriteProperty
    {
        public string Name { get; set; }
    }
    //</snippet1>
}
