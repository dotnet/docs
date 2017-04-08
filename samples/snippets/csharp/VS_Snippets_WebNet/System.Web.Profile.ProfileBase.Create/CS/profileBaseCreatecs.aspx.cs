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

using System.Web.Profile;

public partial class _Default : System.Web.UI.Page
{
    class MyCustomProfile : ProfileBase
    {
        public string ZipCode;
    }
    void Page_Load(object sender, EventArgs e)
    {
        //<Snippet1>
        MyCustomProfile myProfile = (MyCustomProfile)ProfileBase.Create("username");
        myProfile.ZipCode = "98052";
        myProfile.Save();
        //</Snippet1>
        //<Snippet2>
        MyCustomProfile profile = (MyCustomProfile)ProfileBase.Create("username", true);
        profile.ZipCode = "98052";
        profile.Save();
        //</Snippet2>
    }
}
