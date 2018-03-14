//<snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;
using System.Security.Permissions;

namespace CustomControls
{
	[AspNetHostingPermission(SecurityAction.Demand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	public class MyTableCell : TableCell, INamingContainer { };

	[AspNetHostingPermission(SecurityAction.Demand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	public class MyCell
	/*
	 * Class name: MyCell.
	 * Declares the class for the child controls to include in the control collection.
	 */
	{
		string _id;
		string _value;
		Color _backColor;

		public string CellID
		{
			get
			{ return _id; }
			set
			{ _id = value; }
		}

		public string Text
		{
			get
			{ return _value; }
			set
			{ _value = value; }
		}

		public Color BackColor
		{
			get
			{ return _backColor; }
			set
			{ _backColor = value; }
		}
	};

	[AspNetHostingPermission(SecurityAction.Demand,
	Level = AspNetHostingPermissionLevel.Minimal)]
	public class MyControlBuilder : ControlBuilder
	{

		public override Type GetChildControlType(string tagName, IDictionary attribs)
		{
			// Allows TableRow without "runat=server" attribute to be added to the collection.
			if (String.Compare(tagName, "mycell", true) == 0)
				return typeof(MyCell);
			return null;
		}

		public override void AppendLiteralString(string s)
		{
			// Ignores literals between rows.
		}

	}
	[AspNetHostingPermission(SecurityAction.Demand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	[ControlBuilderAttribute(typeof(MyControlBuilder))]
	public class MyCS_CustomControl : Control, INamingContainer
	/*
	 * Class name: MyCS_CustomControl.
	 * Processes the element declarations within a control declaration. 
	 * This builds the actual control.
	 */
	{
		// Declares the custom control that must be built programmatically.
		Table _table;

		private String _title;
		private int _rows;
		private int _columns;

		Hashtable _cellObjects = new Hashtable();

		// Rows property to be used as the attribute name in the Web page.  
		public int Rows
		{
			get
			{ return _rows; }
			set
			{ _rows = value; }
		}

		// Columns property to be used as the attribute name in the Web page.
		public int Columns
		{
			get
			{ return _columns; }
			set
			{ _columns = value; }
		}

		// Title property to be used as the attribute name in the Web page.
		public string Title
		{
			get
			{ return _title; }
			set
			{ _title = value; }
		}

		protected void createNewRow(int rowNumber)
		{

			// Creates a row and adds it to the table.
			TableRow row;

			row = new TableRow();
			_table.Rows.Add(row);

			// Creates a cell that contains text.

			for (int y = 0; y < Columns; y++)
				appendCell(row, rowNumber, y);

		}

		protected void appendCell(TableRow row, int rowNumber, int cellNumber)
		{
			TableCell cell;
			TextBox textbox;

			cell = new TableCell();
			textbox = new TextBox();
			cell.Controls.Add(textbox);
			textbox.ID = "r" + rowNumber.ToString() + "c" + cellNumber.ToString();

			// Checks for the MyCell child object.
			if (_cellObjects[textbox.ID] != null)
			{
				MyCell cellLookup;
				cellLookup = (MyCell)_cellObjects[textbox.ID];

				textbox.Text = cellLookup.Text;
				textbox.BackColor = cellLookup.BackColor;
			}
			else
				textbox.Text = "Row: " + rowNumber.ToString() + " Cell: " +
				cellNumber.ToString();

			row.Cells.Add(cell);

		}

		// Called at runtime when a child object is added to the collection.  
		protected override void AddParsedSubObject(object obj)
		{
			MyCell cell = obj as MyCell;
			if (cell != null)
			{
				_cellObjects.Add(cell.CellID, cell);
			}

		}

		protected override void OnPreRender(EventArgs e)
		/*
		 * Function name: OnPreRender.
		 * Carries out changes affecting the control state and renders the resulting UI.
		*/
		{

			// Increases the number of rows if needed.
			while (_table.Rows.Count < Rows)
			{
				createNewRow(_table.Rows.Count);
			}

			// Checks that each row has the correct number of columns.
			for (int i = 0; i < _table.Rows.Count; i++)
			{
				while (_table.Rows[i].Cells.Count < Columns)
				{
					appendCell(_table.Rows[i], i, _table.Rows[i].Cells.Count);
				}

				while (_table.Rows[i].Cells.Count > Columns)
				{
					_table.Rows[i].Cells.RemoveAt(_table.Rows[i].Cells.Count - 1);
				}
			}
		}

		protected override void CreateChildControls()
		/*
		 * Function name: CreateChildControls.
		 * Adds the Table and the text control to the control collection.
		 */
		{
			LiteralControl text;

			// Initializes the text control using the Title property.
			text = new LiteralControl("<h5>" + Title + "</h5>");
			Controls.Add(text);

			_table = new Table();
			_table.BorderWidth = 2;
			Controls.Add(_table);
		}
	}
}
//</snippet1>
