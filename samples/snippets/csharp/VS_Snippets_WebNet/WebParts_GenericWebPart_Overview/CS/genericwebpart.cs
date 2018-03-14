// <snippet3>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class genericwebpart_sample : System.Web.UI.Page
{
  GenericWebPart calendarPart;
  GenericWebPart listPart;

  protected void Page_Load(Object sender, EventArgs e)
  {
    calendarPart = WebPartManager1.GetGenericWebPart(Calendar1);
    listPart = WebPartManager1.GetGenericWebPart(BulletedList1);

    if (!IsPostBack)
    {
      Label2.Text = String.Empty;
      Label3.Text = String.Empty;
    }
  }

  // <snippet4>
  protected void Button1_Click(object sender, EventArgs e)
  {

    Label2.Text =
      @"<h3>Calendar GenericWebPart Properties</h3>" +
      "<em>Title: </em>" + calendarPart.Title +
      "<br />" +
      "<em>CatalogIconImageUrl:  </em>" + calendarPart.CatalogIconImageUrl +
      "<br />" +
      "<em>TitleUrl: </em>" + calendarPart.TitleUrl +
      "<br />" +
      "<em>Decription: </em>" + calendarPart.Description +
      "<br />" +
      "<em>TitleIconImageUrl: </em>" + calendarPart.TitleIconImageUrl +
      "<br />" +
      "<em>ChildControl ID: </em>" + calendarPart.ChildControl.ID +
      "<br />" +
      "<em>ChildControl Type: </em>" + calendarPart.ChildControl.GetType().Name +
      "<br />" +
      "<em>GenericWebPart ID: </em>" + calendarPart.ID +
      "<br />" +
      "<em>GenericWebPart Type: </em>" + calendarPart.GetType().Name +
      "<br />" +
      "<em>GenericWebPart Parent ID: </em>" + calendarPart.Parent.ID;

    Label3.Text =
      @"<h3>BulletedList GenericWebPart Properties</h3>" +
      "<em>Title: </em>" + listPart.Title +
      "<br />" +
      "<em>CatalogIconImageUrl:  </em>" + listPart.CatalogIconImageUrl +
      "<br />" +
      "<em>TitleUrl: </em>" + listPart.TitleUrl +
      "<br />" +
      "<em>Decription: </em>" + listPart.Description +
      "<br />" +
      "<em>TitleIconImageUrl: </em>" + listPart.TitleIconImageUrl +
      "<br />" +
      "<em>ChildControl ID: </em>" + listPart.ChildControl.ID +
      "<br />" +
      "<em>ChildControl Type: </em>" + listPart.ChildControl.GetType().Name +
      "<br />" +
      "<em>GenericWebPart ID: </em>" + listPart.ID +
      "<br />" +
      "<em>GenericWebPart Type: </em>" + listPart.GetType().Name +
      "<br />" +
      "<em>GenericWebPart Parent ID: </em>" + listPart.Parent.ID;
  }
  // </snippet4>

}
// </snippet3>