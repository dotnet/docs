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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// This is the namespace to add when using claims in your code
using System.Security.Claims;

namespace WebApplication
{
    public partial class Claims : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Create a ClaimsPrincipal object from the current user to work with claims
                ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;

                // We can use the FindFirst method to get the first occurance of a specific claim.
                // This is very useful when you only expect a single instance of a particular claim type.
                // Note the ClaimTypes class contains many common claims defined as properties for your use.

                // Elsewhere we use the Name property from the User.Identity, here we show
                // that it is also a claim just as the others below that are not mapped to
                // properties within IPrincipal based identities
                Claim claimName = claimsPrincipal.FindFirst(ClaimTypes.Name);
                if (claimName != null)
                {
                    this.nameLabel.Text = claimName.Value;
                }
                else
                {

                    this.nameLabel.Text = "Name claim not found";
                }
                // ClaimsPrincipal.Claims returns a collection of claims that we can query, iterate over
                // or in this case set as a datasource of a GridView control. Lots of flexibility. 
                this.ClaimsGridView.DataSource = claimsPrincipal.Claims;
                this.ClaimsGridView.DataBind();
            }

        }
    }
}