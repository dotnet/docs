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
using System.Web.Security;
using System.Web.UI.WebControls;
namespace PassiveSTS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.STSLogin.UserName))
            {
                FormsAuthentication.RedirectFromLoginPage(STSLogin.UserName, false);
            }
        }
    }
}