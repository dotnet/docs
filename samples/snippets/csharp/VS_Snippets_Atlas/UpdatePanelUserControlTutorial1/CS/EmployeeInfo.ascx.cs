using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class EmployeeInfo : System.Web.UI.UserControl
{
    private int _EmployeeID;

    public int EmployeeID
    {
        get { return _EmployeeID; }
        set
        {
            _EmployeeID = value;
            this.EmployeeDataSource.SelectParameters["SelectedEmployeeID"].DefaultValue =
                _EmployeeID.ToString();
        }
    }

    //<Snippet1>
    public UpdatePanelUpdateMode UpdateMode
    {
        get { return this.EmployeeInfoUpdatePanel.UpdateMode; }
        set { this.EmployeeInfoUpdatePanel.UpdateMode = value; }
    }

    public void Update()
    {
        this.EmployeeInfoUpdatePanel.Update();
    }
    //</Snippet1>

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        this.LastUpdatedLabel.Text = DateTime.Now.ToString();
    }
}
