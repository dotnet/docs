    // A custom View Schema class
    public class BookListViewSchema : IDataSourceViewSchema
    {
        public BookListViewSchema()
        { }

        // The name of this View Schema
        public string Name
        {
            get { return "BookList"; }
        }

        // Build a Field Schema array
        public IDataSourceFieldSchema[] GetFields()
        {
            IDataSourceFieldSchema[] fields = new IDataSourceFieldSchema[2];
            fields[0] = new CustomIDFieldSchema();
            fields[1] = new CustomTitleFieldSchema();
            return fields;
        }
        // There are no child views, so return null
        public IDataSourceViewSchema[] GetChildren()
        {
            return null;
        }
    }

    // A custom Field Schema class for ID
    public class CustomIDFieldSchema : IDataSourceFieldSchema
    {
        public CustomIDFieldSchema()
        { }

        // Name is ID
        public string Name
        {
            get { return "ID"; }
        }
        // Data type is string
        public Type DataType
        {
            get { return typeof(string); }
        }
        // This is not an Identity field
        public bool Identity
        {
            get { return false; }
        }
        // This field is read only
        public bool IsReadOnly
        {
            get { return true; }
        }
        // This field is unique
        public bool IsUnique
        {
            get { return true; }
        }
        // This field can't be longer than 20
        public int Length
        {
            get { return 20; }
        }
        // This field can't be null
        public bool Nullable
        {
            get { return false; }
        }
        // This is a Primary Key
        public bool PrimaryKey
        {
            get { return true; }
        }

        // These properties do not apply
        public int Precision
        {
            get { return -1; }
        }
        public int Scale
        {
            get { return -1; }
        }
    }
    
    // A custom Field Schema class for Title
    public class CustomTitleFieldSchema : IDataSourceFieldSchema
    {
        public CustomTitleFieldSchema()
        { }

        // Name is Title
        public string Name
        {
            get { return "Title"; }
        }
        // Type is string
        public Type DataType
        {
            get { return typeof(string); }
        }
        // This is not an Identity field
        public bool Identity
        {
            get { return false; }
        }
        // This field is not read only
        public bool IsReadOnly
        {
            get { return false; }
        }
        // This field is not unique
        public bool IsUnique
        {
            get { return false; }
        }
        // This field can't be longer than 100
        public int Length
        {
            get { return 100; }
        }
        // This field can't be null
        public bool Nullable
        {
            get { return false; }
        }
        // This is not the Primary Key
        public bool PrimaryKey
        {
            get { return false; }
        }

        // These properties do not apply
        public int Precision
        {
            get { return -1; }
        }
        public int Scale
        {
            get { return -1; }
        }
    }