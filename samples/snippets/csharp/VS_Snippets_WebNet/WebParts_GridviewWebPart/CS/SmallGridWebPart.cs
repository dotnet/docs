// <snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.Configuration;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class SmallGridWebPart : WebPart
  {
    private String connString;

    // Use predefined strings for commands in the data source.
    private const string selectStmt = @"Select * from [Customers]";
    private const string deleteCmd = @"DELETE FROM [Customers] " +
      @"WHERE [CustomerID] = @CustomerID";
    private const string insertCmd = @"INSERT INTO [Customers] " +
      @"([CustomerID], [CompanyName], [ContactName], " +
      @"[Phone]) VALUES (@CustomerID, @CompanyName, " +
      @"@ContactName, @Phone)";
    private const string updateCmd = @"UPDATE [Customers] SET " +
      @"[CompanyName] = @CompanyName, [ContactName] = @ContactName, " +
      @"[Phone] = @Phone WHERE [CustomerID] = @CustomerID";


    public SmallGridWebPart()
    {
       ExportMode = WebPartExportMode.All;
    }

    // This override prevents users from closing the control.
    public override bool AllowClose
    {
      get
      {
        return false;
      }
      // No implementation for the set accessor. We have to have 
      // it because the base property has it, but we want to 
      // prevent users from closing the control and developers 
      // from being able to update the property.
      set { ; }
    }

    // Allow page developers to set the connection string.
    public String ConnectionString
    {
      get { return connString; }
      set { connString = value; }
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();

      // Create the SqlDataSource control.
      SqlDataSource ds = new SqlDataSource(this.ConnectionString, selectStmt);
      ds.ID = "dsCustomers";
      ds.DataSourceMode = SqlDataSourceMode.DataSet;
      ds.InsertCommandType = SqlDataSourceCommandType.Text;
      ds.InsertCommand = insertCmd;
      ds.UpdateCommandType = SqlDataSourceCommandType.Text;
      ds.UpdateCommand = updateCmd;
      ds.DeleteCommandType = SqlDataSourceCommandType.Text;
      ds.DeleteCommand = deleteCmd;
      ParameterCollection deleteParams = new ParameterCollection();
      deleteParams.Add(BuildParam("CustomerID", TypeCode.String));
      ParameterCollection insertParams = new ParameterCollection();
      insertParams.Add(BuildParam("CustomerID", TypeCode.String));
      insertParams.Add(BuildParam("CompanyName", TypeCode.String));
      insertParams.Add(BuildParam("ContactName", TypeCode.String));
      insertParams.Add(BuildParam("Phone", TypeCode.String));
      ParameterCollection updateParams = new ParameterCollection();
      updateParams.Add(BuildParam("CustomerID", TypeCode.String));
      updateParams.Add(BuildParam("CompanyName", TypeCode.String));
      updateParams.Add(BuildParam("ContactName", TypeCode.String));
      updateParams.Add(BuildParam("Phone", TypeCode.String));

      this.Controls.Add(ds);

      // Create the GridView control and bind it to the SqlDataSource.
      GridView grid = new GridView();
      grid.ID = "customerGrid";
      grid.Font.Size = 8;
      grid.AllowPaging = true;
      grid.AllowSorting = true;
      grid.AutoGenerateColumns = false;
      String[] fields = { "CustomerID" };
      grid.DataKeyNames = fields;
      grid.DataSourceID = "dsCustomers";
      CommandField controlButton = new CommandField();
      controlButton.ShowEditButton = true;
      controlButton.ShowSelectButton = true;
      grid.Columns.Add(controlButton);
      BoundField customerID = BuildBoundField("CustomerID");
      customerID.ReadOnly = true;
      grid.Columns.Add(customerID);
      grid.Columns.Add(BuildBoundField("CompanyName"));
      grid.Columns.Add(BuildBoundField("ContactName"));
      grid.Columns.Add(BuildBoundField("Phone"));

      this.Controls.Add(grid);

    }

    private Parameter BuildParam(String paramName, TypeCode dataTypeCode)
    {
      Parameter theParm = new Parameter(paramName, dataTypeCode);
      return theParm;
    }

    private BoundField BuildBoundField(String fieldName)
    {
      BoundField theField = new BoundField();
      theField.DataField = fieldName;
      theField.HeaderText = fieldName;
      theField.SortExpression = fieldName;
      return theField;
    }

  } 

}
// </snippet2>