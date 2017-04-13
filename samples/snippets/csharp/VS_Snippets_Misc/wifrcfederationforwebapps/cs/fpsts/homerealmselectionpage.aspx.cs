//-----------------------------------------------------------------------------
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//-----------------------------------------------------------------------------

using System;
using System.Globalization;
using System.IdentityModel.Services;
using System.IO;
using System.Text;
using System.Web;

//
// Summary: Class that presents the home realm selection page
//

public partial class HomeRealmSelectionPage : System.Web.UI.Page
{
    const string identityProvider1Page = "http://localhost:4001/IPSTS1/default.aspx";
    const string identityProvider2Page = "http://localhost:4002/IPSTS2/default.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // Did we preserve the query string that was sent by RP
            string query = Request.QueryString.ToString();

            Response.Write("In Postback");
            Response.Write("Selected index: " + RealmSelection.SelectedIndex);
            string redirectPage = "";

            // Depending on the selection made redirect the user to right 
            // identity provider
            switch (this.RealmSelection.SelectedIndex)
            {
                // case 0 is the 'descriptive text'...
                // case 1 is IP STS 1
                // case 2 is IP STS 2
                case 1:
                    {
                        Response.Write("Redirect to Identity Provider 1 (IPSTS1)");
                        redirectPage = identityProvider1Page;
                        break;
                    }

                case 2:
                    {
                        Response.Write("Redirect to Identity Provider 2(IPSTS2)");
                        redirectPage = identityProvider2Page;
                        break;
                    }
                default:
                    break;
            }

            if (null != redirectPage)
            {
                // this means we have to redirect the user to identity provider STS                 
                SignInRequestMessage msg;
                msg = new SignInRequestMessage(new Uri(redirectPage), "http://localhost:3000/FPSTS/Default.aspx");
                msg.Context = Request.QueryString["wctx"];
                StringBuilder pathAndQuery = new StringBuilder();
                using (StringWriter strWriter = new StringWriter(pathAndQuery, CultureInfo.InvariantCulture))
                {
                    msg.Write(strWriter);
                    HttpContext.Current.Response.Redirect(pathAndQuery.ToString());
                }
            }
        }
        else
        {
            // Populate the identity provider lists here
            RealmSelection.Items.Add("Select an identity provider.");
            RealmSelection.Items.Add("IPSTS-1");
            RealmSelection.Items.Add("IPSTS-2");
        }
    
    }
}
