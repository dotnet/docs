// WebControlDesignerCollectionEditors.cs
// <snippet5>
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing.Design;

namespace Examples.CS.WebControls.Design
{
    // Create the SimpleRadioButtonListDesigner class that provides
    // design-time support for a custom list class.
    public class CustomWebControl : 
        System.Web.UI.WebControls.WebControl
    {
        private string textData;

        // <snippet1>
        private TableCellCollection cells = null;

        // Associate the TableCellsCollectionEditor with the TestCells. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
            TableCellsCollectionEditor),
            typeof(UITypeEditor))]
        public TableCellCollection TestCells
        {
            get { return cells; }
        } // TestCells
        // </snippet1>

        // <snippet2>
        private TableRowCollection rows = null;

        // Associate the TableRowsCollectionEditor with the TestRows. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
           TableRowsCollectionEditor),
           typeof(UITypeEditor))]
        public TableRowCollection TestRows
        {
            get { return rows; }
        } // TestRows
        // </snippet2>

        // <snippet3>
        private ListItemCollection items = null;

        // Associate the ListItemsCollectionEditor with the ListItems. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
           ListItemsCollectionEditor),
           typeof(UITypeEditor))]
        public ListItemCollection ListItems
        {
            get { return items; }
        } // ListItems
        // </snippet3>

        // <snippet4>
        private DataGridColumnCollection columns = null;

        // Associate the DataGridColumnCollectionEditor with the TestColumns. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
           DataGridColumnCollectionEditor),
           typeof(UITypeEditor))]
        public DataGridColumnCollection TestColumns
        {
            get { return columns; }
        } // TestColumns
        // </snippet4>

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string TextEntry
        {
            get { return textData; }
            set { textData = value; }
        } // TextEntry

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(textData);
        } // Render
    } // CustomWebControl
} // Examples.CS.WebControls.Design
// </snippet5>

