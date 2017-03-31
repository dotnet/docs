// <Snippet4>
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.DynamicData;
using System.Text;

public partial class DocGetTable : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e) 
     {
     
     }

    // Use GetTable methods.
    public string GetAdresses(int index)
    {
        // Get the default data model.
        MetaModel model = MetaModel.Default;
   
        MetaTable mTable;

        switch (index)
        {
            case 0:
                // <Snippet41>
                // Get the metatable for the table with the
                // specified entity type.
                mTable = model.GetTable(typeof(CustomerAddress));
                // </Snippet41>
                break;
            case 1:
                // <Snippet42>
                // Get the metatable for the table with the 
                // specified table name.
                mTable = model.GetTable("CustomerAddresses");
                // </Snippet42>
                break;
            case 2:
                // <Snippet43>
                // Get the metatable for the table with the 
                // specified table name and the specified data
                // context.
                mTable = model.GetTable("CustomerAddresses", typeof(AdventureWorksLTDataContext));
                // </Snippet43>
                break;
            default:
                mTable = model.GetTable(typeof(CustomerAddress));
                break;
        }

        // The following code dislays the actual value 
        // (adress) associated with a customer and link
        // to the related Addresses table.
        MetaForeignKeyColumn fkColumn = 
            (MetaForeignKeyColumn)mTable.GetColumn("Address");

        Customer row = (Customer)GetDataItem();


        StringBuilder addressList = new StringBuilder();

        foreach (CustomerAddress childRow in row.CustomerAddresses)
        {
            addressList.Append(childRow.AddressType);
            addressList.Append(":<br/>");
            addressList.Append("<a href='");
            addressList.Append(fkColumn.GetForeignKeyDetailsPath(childRow.Address));
            addressList.Append("'>");
            addressList.Append(childRow.Address.AddressLine1);
            addressList.Append("</a><br/><br/>");
        }

        return addressList.ToString();
        
    }

}
// </Snippet4>