//<Snippet1>
using System;
using System.Data;
using System.Security.Permissions;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ASPNet.Design.Samples_CS
{
    [Designer(typeof(CustomDataSourceDesigner)),
        ToolboxData("<{0}:CustomDataSource runat=\"server\"></{0}:CustomDataSource>")]
    public class CustomDataSource : ObjectDataSource
    {
        private ObjectDataSourceView _view = null;
        private string _defaultViewName = "BookList";

        public CustomDataSource() : base() { }

        // Gets a view by name
        protected override DataSourceView GetView(string viewName)
        {
            // This data source only allows one view
            if (viewName != _defaultViewName)
                return null;
            else if (_view == null)
            {
                _view = new CustomDataSourceView(this, 
                    _defaultViewName, HttpContext.Current);
            }

            return _view;
        }

        // Gets a list of view names for this class
        protected override ICollection GetViewNames()
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(_defaultViewName);
            return ar as ICollection;
        }

    }

    // The runtime data source view
    public class CustomDataSourceView : ObjectDataSourceView
    {
        private ArrayList _data = null;

        public CustomDataSourceView(CustomDataSource owner, 
            string viewName, HttpContext context)
            : base(owner, viewName, context)
        {
            owner.SelectCountMethod = "GetCount";
        }

        // This method would typically get a set of live data  
        // rather than create some dummy data
        protected override IEnumerable ExecuteSelect(
            DataSourceSelectArguments arguments)
        {
            if (_data == null)
            {
                // Create a set of runtime fake data
                _data = new ArrayList();
                _data.Add(new BookItem("ID_1", "Runtime Title 01"));
                _data.Add(new BookItem("ID_2", "Runtime Title 02"));
                _data.Add(new BookItem("ID_3", "Runtime Title 03"));
            }

            return _data as IEnumerable;
        }

        // Allow getting the record count
        public override bool CanRetrieveTotalRowCount
        {
            get { return true; }
        }

        // Returns the number of records in the current set of data
        public int GetCount()
        {
            if (_data == null)
                return 0;
            else
                return _data.Count;
        }
        
        // Do not allow deletions
        public override bool CanDelete
        {
            get { return false; }
        }
        // Do not allow insertions
        public override bool CanInsert
        {
            get { return false; }
        }
        // Do not allow paging
        public override bool CanPage
        {
            get { return false; }
        }
        // Do not allow sorting
        public override bool CanSort
        {
            get { return false; }
        }
        // Do not allow updating
        public override bool CanUpdate
        {
            get { return false; }
        }

    }

    // A class to define each record of the data
    public class BookItem
    {
        private string _id;
        private string _title;

        public BookItem(string id, string title)
        {
            _id = id;
            _title = title;
        }

        public string ID
        {
            get { return _id; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }

    // Custom designer for the CustomDataSource control.
    public class CustomDataSourceDesigner : DataSourceDesigner
    {
        private CustomDataSource _control;
        private string _defaultViewName = "BookList";
        private CustomDesignDataSourceView _view = null;

        // Initialize the designer
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _control = (CustomDataSource)Component;
        }

        // Get a view
        public override DesignerDataSourceView GetView(string viewName)
        {
            if (!viewName.Equals(_defaultViewName))
                return null;

            if (_view == null)
            {
                _view = new CustomDesignDataSourceView(this,
                    _defaultViewName);
            }

            return _view;
        }

        // Get a list of view names
        public override string[] GetViewNames()
        {
            return new string[] { "BookList" };
        }

        // Do not allow refreshing the schema
        public override bool CanRefreshSchema
        {
            get { return false; }
        }
        // Do not allow resizing
        public override bool AllowResize
        {
            get { return false; }
        }
    }

    //<Snippet2>
    // A design-time data source view
    public class CustomDesignDataSourceView : DesignerDataSourceView
    {
        private ArrayList _data = null;

        public CustomDesignDataSourceView(
            CustomDataSourceDesigner owner, string viewName)
            : base(owner, viewName)
        {}

        //<Snippet3>
        // Get data for design-time display
        public override IEnumerable GetDesignTimeData(
            int minimumRows, out bool isSampleData)
        {
            if (_data == null)
            {
                // Create a set of design-time fake data
                _data = new ArrayList();
                for (int i = 1; i <= minimumRows; i++)
                {
                    _data.Add(new BookItem("ID_" + i.ToString(),
                        "Design-Time Title 0" + i.ToString()));
                }
            }
            isSampleData = true;
            return _data as IEnumerable;
        }
        //</Snippet3>

        //<Snippet4>
        public override IDataSourceViewSchema Schema
        {
            get { return new BookListViewSchema(); }
        }
        //</Snippet4>

        // Allow getting the record count
        public override bool CanRetrieveTotalRowCount
        {
            get { return true; }
        }
        // Do not allow deletions
        public override bool CanDelete
        {
            get { return false; }
        }
        // Do not allow insertions
        public override bool CanInsert
        {
            get { return false; }
        }
        // Do not allow updates
        public override bool CanUpdate
        {
            get { return false; }
        }
        // Do not allow paging
        public override bool CanPage
        {
            get { return false; }
        }
        // Do not allow sorting
        public override bool CanSort
        {
            get { return false; }
        }
    }
    //</Snippet2>

    //<Snippet5>
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
    //</Snippet5>
}
//</Snippet1>