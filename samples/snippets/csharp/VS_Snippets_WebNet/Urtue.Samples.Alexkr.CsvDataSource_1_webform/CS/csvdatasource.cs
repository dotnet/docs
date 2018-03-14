namespace Samples.AspNet.CS.Controls {
// <Snippet1>
    using System;
    using System.Collections;
    using System.Data;
    using System.IO;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    // The CsvDataSource is a data source control that retrieves its
    // data from a comma-separated value file.
    [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class CsvDataSource : DataSourceControl
    {
        public CsvDataSource() : base() {}

        // The comma-separated value file to retrieve data from.
        public string FileName {
            get {
                return ((CsvDataSourceView)this.GetView(String.Empty)).SourceFile;
            }
            set {
                // Only set if it is different.
                if ( ((CsvDataSourceView)this.GetView(String.Empty)).SourceFile != value) {
                    ((CsvDataSourceView)this.GetView(String.Empty)).SourceFile = value;
                    RaiseDataSourceChangedEvent(EventArgs.Empty);
                }
            }
        }

        // Do not add the column names as a data row. Infer columns if the CSV file does
        // not include column names.
        public bool IncludesColumnNames {
            get {
                return ((CsvDataSourceView)this.GetView(String.Empty)).IncludesColumnNames;
            }
            set {
                // Only set if it is different.
                if ( ((CsvDataSourceView)this.GetView(String.Empty)).IncludesColumnNames != value) {
                    ((CsvDataSourceView)this.GetView(String.Empty)).IncludesColumnNames = value;
                    RaiseDataSourceChangedEvent(EventArgs.Empty);
                }
            }
        }

// <Snippet3>
        // Return a strongly typed view for the current data source control.
        private CsvDataSourceView view = null;
        protected override DataSourceView GetView(string viewName) {
            if (null == view) {
                view = new CsvDataSourceView(this, String.Empty);
            }
            return view;
        }
// </Snippet3>
// <Snippet4>
        // The ListSourceHelper class calls GetList, which
        // calls the DataSourceControl.GetViewNames method.
        // Override the original implementation to return
        // a collection of one element, the default view name.
        protected override ICollection GetViewNames() {
            ArrayList al = new ArrayList(1);
            al.Add(CsvDataSourceView.DefaultViewName);
            return al as ICollection;
        }
    }
// </Snippet4>

// <Snippet5>
    // The CsvDataSourceView class encapsulates the
    // capabilities of the CsvDataSource data source control.
    public class CsvDataSourceView : DataSourceView
    {

        public CsvDataSourceView(IDataSource owner, string name) :base(owner, DefaultViewName) {

        }

        // The data source view is named. However, the CsvDataSource
        // only supports one view, so the name is ignored, and the
        // default name used instead.
        public static string DefaultViewName = "CommaSeparatedView";

        // The location of the .csv file.
        private string sourceFile = String.Empty;
        internal string SourceFile {
            get {
                return sourceFile;
            }
            set {
                // Use MapPath when the SourceFile is set, so that files local to the
                // current directory can be easily used.
                string mappedFileName = HttpContext.Current.Server.MapPath(value);
                sourceFile = mappedFileName;
            }
        }

        // Do not add the column names as a data row. Infer columns if the CSV file does
        // not include column names.
        private bool columns = false;
        internal bool IncludesColumnNames {
            get {
                return columns;
            }
            set {
                columns = value;
            }
        }

// <Snippet6>
        // Get data from the underlying data source.
        // Build and return a DataView, regardless of mode.
        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments selectArgs) {
            IEnumerable dataList = null;
            // Open the .csv file.
            if (File.Exists(this.SourceFile)) {
                DataTable data = new DataTable();

                // Open the file to read from.
                using (StreamReader sr = File.OpenText(this.SourceFile)) {
                    // Parse the line
                    string s = "";
                    string[] dataValues;
                    DataColumn col;

                    // Do the following to add schema.
                    dataValues = sr.ReadLine().Split(',');
                    // For each token in the comma-delimited string, add a column
                    // to the DataTable schema.
                    foreach (string token in dataValues) {
                        col = new DataColumn(token,typeof(string));
                        data.Columns.Add(col);
                    }

                    // Do not add the first row as data if the CSV file includes column names.
                    if (! IncludesColumnNames)
                        data.Rows.Add(CopyRowData(dataValues, data.NewRow()));

                    // Do the following to add data.
                    while ((s = sr.ReadLine()) != null) {
                        dataValues = s.Split(',');
                        data.Rows.Add(CopyRowData(dataValues, data.NewRow()));
                    }
                }
                data.AcceptChanges();
                DataView dataView = new DataView(data);
// <Snippet7>
                if (selectArgs.SortExpression != String.Empty) {
                    dataView.Sort = selectArgs.SortExpression;
                }
// </Snippet7>
                dataList = dataView;
            }
            else {
                throw new System.Configuration.ConfigurationErrorsException("File not found, " + this.SourceFile);
            }

            if (null == dataList) {
                throw new InvalidOperationException("No data loaded from data source.");
            }

            return dataList;
        }

        private DataRow CopyRowData(string[] source, DataRow target) {
            try {
                for (int i = 0;i < source.Length;i++) {
                    target[i] = source[i];
                }
            }
            catch (System.IndexOutOfRangeException) {
                // There are more columns in this row than
                // the original schema allows.  Stop copying
                // and return the DataRow.
                return target;
            }
            return target;
        }
// </Snippet6>
// <Snippet8>
        // The CsvDataSourceView does not currently
        // permit deletion. You can modify or extend
        // this sample to do so.
        public override bool CanDelete {
            get {
                return false;
            }
        }
        protected override int ExecuteDelete(IDictionary keys, IDictionary values)
        {
            throw new NotSupportedException();
        }
// </Snippet8>
// <Snippet9>
        // The CsvDataSourceView does not currently
        // permit insertion of a new record. You can
        // modify or extend this sample to do so.
        public override bool CanInsert {
            get {
                return false;
            }
        }
        protected override int ExecuteInsert(IDictionary values)
        {
            throw new NotSupportedException();
        }
// </Snippet9>
// <Snippet10>
        // The CsvDataSourceView does not currently
        // permit update operations. You can modify or
        // extend this sample to do so.
        public override bool CanUpdate {
            get {
                return false;
            }
        }
        protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
        {
            throw new NotSupportedException();
        }
// </Snippet10>
    }
// </Snippet5>
// </Snippet1>
}