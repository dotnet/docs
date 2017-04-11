// <Snippet2>
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

public partial class ClientCallback : System.Web.UI.Page,
     System.Web.UI.ICallbackEventHandler
{
    //<Snippet4>
    //<Snippet3>
    protected System.Collections.Specialized.ListDictionary catalog;
    protected System.Collections.Specialized.ListDictionary saleitem;
    protected String returnValue;
    protected String validationLookUpStock = "LookUpStock";
    protected String validationLookUpSale = "LookUpSale";
    //</Snippet3>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            validationLookUpStock, "function LookUpStock() {  " +
            "var lb = document.forms[0].ListBox1; " +
            "if (lb.selectedIndex == -1) { alert ('Please make a selection.'); return; } " +
            "var product = lb.options[lb.selectedIndex].text;  " +
            @"CallServer(product, ""LookUpStock"");}  ", true);
        if (User.Identity.IsAuthenticated)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            validationLookUpSale, "function LookUpSale() {  " +
            "var lb = document.forms[0].ListBox1; " +
            "if (lb.selectedIndex == -1) { alert ('Please make a selection.'); return; } " +
            "var product = lb.options[lb.selectedIndex].text;  " +
            @"CallServer(product, ""LookUpSale"");} ", true);
        }

        String cbReference = "var param = arg + '|' + context;" + 
            Page.ClientScript.GetCallbackEventReference(this,
            "param", "ReceiveServerData", "context");
        String callbackScript;
        callbackScript = "function CallServer(arg, context)" +
            "{ " + cbReference + "} ;";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            "CallServer", callbackScript, true);

        catalog = new System.Collections.Specialized.ListDictionary();
        saleitem = new System.Collections.Specialized.ListDictionary();
        catalog.Add("monitor", 12);
        catalog.Add("laptop", 10);
        catalog.Add("keyboard", 23);
        catalog.Add("mouse", 17);
        saleitem.Add("monitor", 1);
        saleitem.Add("laptop", 0);
        saleitem.Add("keyboard", 0);
        saleitem.Add("mouse", 1);

        ListBox1.DataSource = catalog;
        ListBox1.DataTextField = "key";
        ListBox1.DataBind();
    }
    //</Snippet4>
    //<Snippet5>
    public void RaiseCallbackEvent(String eventArgument)
    {
        string[] argParts = eventArgument.Split('|');
        if ((argParts == null) || (argParts.Length != 2))
        {
            returnValue = "A problem occurred trying to retrieve stock count.";
            return;
        }
        string product = argParts[0];
        string validationaction = argParts[1];
        switch (validationaction)
        {
            case "LookUpStock":
                try
                {
                    Page.ClientScript.ValidateEvent("LookUpStockButton", validationaction);
                    if (catalog[product] == null)
                    {
                        returnValue = "Item not found.";
                    }
                    else
                    {
                        returnValue = catalog[product].ToString() + " in stock.";
                    }
                }
                catch
                {
                    returnValue = "Can not retrieve stock count.";
                } 
                break;
            case "LookUpSale":
                try
                {
                    Page.ClientScript.ValidateEvent("LookUpSaleButton", validationaction);
                    if (saleitem[product] == null)
                    {
                        returnValue = "Item not found.";
                    }
                    else
                    {
                        if (Convert.ToBoolean(saleitem[product]))
                            returnValue = "Item is on sale.";
                        else
                            returnValue = "Item is not on sale.";
                    }
                }
                catch
                {
                    returnValue = "Can not retrieve sale status.";
                }
                break;
        }

    }
    //</Snippet5>
    //<Snippet6>
    public String GetCallbackResult()
    {
        return returnValue;
    }
    //</Snippet6>
    //<Snippet7>
    protected override void Render(HtmlTextWriter writer)
    {
        Page.ClientScript.RegisterForEventValidation("LookUpStockButton",
            validationLookUpStock);
        if (User.Identity.IsAuthenticated)
        {
            Page.ClientScript.RegisterForEventValidation("LookUpSaleButton",
                validationLookUpSale);
        }
        base.Render(writer);
    }
    //</Snippet7>
}
// </Snippet2>