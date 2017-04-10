// <snippet2>
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

	/// <summary>
	/// Summary description for AggregateData
	/// </summary>
	public class AggregateData
	{

		public AggregateData()
		{

		}

		static DataTable table;

		private DataTable CreateData()
		{
			table = new DataTable();
			table.Columns.Add("Name", typeof(string));
			table.Columns.Add("Number", typeof(int));
			table.Rows.Add(new object[] { "one", 1 });
			table.Rows.Add(new object[] { "two", 2 });
			table.Rows.Add(new object[] { "three", 3 });
			return table;
		}

		public DataTable Select()
		{
			if (table == null)
			{
				return CreateData();
			}
			else
			{
				return table;
			}
		}

		public int Insert(NewData newRecord)
		{
			table.Rows.Add(new object[] { newRecord.Name, newRecord.Number });
			return 1;
		}
	}

	public class NewData
	{
		private string nameValue;
		private int numberValue;

		public string Name
		{
			get { return nameValue; }
			set { nameValue = value; }
		}

		public int Number
		{
			get { return numberValue; }
			set { numberValue = value; }
		}

	}
}
// </snippet2>
