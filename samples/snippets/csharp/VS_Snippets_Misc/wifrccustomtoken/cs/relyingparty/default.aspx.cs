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
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web.UI;

namespace RelyingParty
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                // Create a ClaimsPrincipal object from the current user to work with claims
                ClaimsPrincipal claimsPrincipal = Page.User as ClaimsPrincipal;

                // ClaimsPrincipal.Claims returns a collection of claims that we can query, iterate over
                // or in this case set as a datasource of a GridView control. Lots of flexibility. 
                this.ClaimsGridView.DataSource = claimsPrincipal.Claims;
                this.ClaimsGridView.DataBind();

        
                if (claimsPrincipal != null)
                {
                    DisplayReceivedToken(claimsPrincipal);
                }
            }
        }

        private void DisplayReceivedToken(ClaimsPrincipal claimsPrincipal)
        {
            ClaimsIdentity identity = claimsPrincipal.Identity as ClaimsIdentity;
            BootstrapContext bootstrapContext = identity.BootstrapContext as BootstrapContext;
            this.tokenStringLabel.Text += bootstrapContext.Token;
            this.tokenStringLabel.Visible = true;
        }
    }
}