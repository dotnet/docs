//<Snippet1>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.CS
{
	public class SortingData
	{
		public SortingData()
		{
		}


		private static DataTable table;


		private DataTable CreateData()
		{
			table = new DataTable();
			table.Columns.Add("Name", typeof(string));
			table.Columns.Add("Number", typeof(int));
			table.Rows.Add(new object[] { "one", 1 });
			table.Rows.Add(new object[] { "two", 2 });
			table.Rows.Add(new object[] { "three", 3 });
			table.Rows.Add(new object[] { "four", 4 });
			return table;
		}

		public DataView SelectMethod(string sortExpression)
		{
			if (table == null)
			{
				table = CreateData();
			}

			DataView dv = new DataView(table);
			dv.Sort = sortExpression;
			return dv;
		}

	}
}
//</Snippet1>