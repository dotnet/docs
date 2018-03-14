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
using System.Drawing;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    /* For illustrative purposes this sample application simply shows all the parameters of 
                  * claims (i.e. claim types and claim values), which are issued by a security token 
                  * service (STS), to its clients. In production code, security implications of echoing 
                  * the properties of claims to the clients should be carefully considered. For example, 
                  * some of the security considerations are: (i) accepting the only claim types that are 
                  * expected by relying party applications; (ii) sanitizing the claim parameters before 
                  * using them; and (iii) filtering out claims that contain sensitive personal information). 
                  * DO NOT use this sample code ‘as is’ in production code.
                 */

    private Table table;

    //In order to use a specific IdentityProvider pass the IdentityProvider's URL in the 'whr' query string like this:
    // http://localhost:2000/FederationPassiveRP/Default.aspx?whr=http://localhost:4002/IPSTS2/default.aspx 
    // This will directly select IPSTS2 as the IdentityProvider instead of displaying the selection page on FPSTS.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                this.WelcomeMessage.Text = "Welcome " + Page.User.Identity.Name;

                ClaimsPrincipal claimsPrincipal = Page.User as ClaimsPrincipal;

                if (claimsPrincipal != null)
                {
                    ShowClaimsFromClaimsPrincipal(claimsPrincipal);
                }
            }
        }
    }

    protected void SignOutButton_Click(object sender, EventArgs e)
    {
        FederatedAuthentication.WSFederationAuthenticationModule.SignOut("http://localhost:2000/FederationPassiveRP/default.aspx");
    }

    /// <summary>
    /// Build a table listing the claims accepted about the identity.
    /// </summary>
    /// <param name="claimsIdentity">Given identity</param>
    private void ShowClaimsFromClaimsPrincipal(ClaimsPrincipal claimsPrincipal)
    {
        CreateLabel();
        CreateTable();

        foreach (Claim claim in claimsPrincipal.Claims)
        {
          DisplayClaim(claim);
        }

        // add the table to the returned page
        this.Controls.Add(this.table);
    }

    /// <summary>
    /// Displays a claim in a row of the table.
    /// </summary>
    /// <param name="claim"> claim value to write out </param>
    private void DisplayClaim(Claim claim)
    {
        string claimType = claim.Type;
        string claimValue = claim.Value;
        string valueType = claim.ValueType.Substring(claim.ValueType.IndexOf('#') + 1);
        string subjectName = claim.Subject.Name;
        string issuerName = claim.Issuer;
        string originalIssuer = claim.OriginalIssuer;

        // Display the claim properties in a table row.
        AddRowToTable(claimType, claim.Value, valueType, claim.Subject.Name, claim.Issuer, claim.OriginalIssuer);
    }

    private void AddRowToTable(string claimType, string claimValue, string valueType, string subjectName, string issuerName, string originalIssuer)
    {
        TableCell tc1 = new TableCell();
        tc1.Text = claimType;

        TableCell tc2 = new TableCell();
        tc2.Text = claimValue;

        TableCell tc3 = new TableCell();
        tc3.Text = valueType;

        TableCell tc4 = new TableCell();
        tc4.Text = subjectName;

        TableCell tc5 = new TableCell();
        tc5.Text = issuerName;
        
        TableCell tc6 = new TableCell();
        tc6.Text = originalIssuer;

        TableRow tr = new TableRow();

        tr.Controls.Add(tc1);
        tr.Controls.Add(tc2);
        tr.Controls.Add(tc3);
        tr.Controls.Add(tc4);
        tr.Controls.Add(tc5);
        tr.Controls.Add(tc6);

        tr.BorderColor = System.Drawing.Color.Chocolate;

        this.table.Controls.Add(tr);
    }

    private void CreateLabel()
    {
        Label labelTitle = new Label();
        labelTitle.Font.Bold = true;
        labelTitle.ForeColor = Color.Blue;
        labelTitle.Font.Size = FontUnit.Larger;
        labelTitle.Text = "Claims from ClaimsPrincipal";
        this.Controls.Add(labelTitle);
    }

    private void CreateTable()
    {
        // Build table and header row
        this.table = new Table();
        table.BorderWidth = 1;
        table.Font.Name = "Franklin Gothic Book";
        table.Font.Size = 10;
        table.CellPadding = 3;
        table.CellSpacing = 3;
        table.BorderColor = System.Drawing.Color.Chocolate;

        TableHeaderCell thc1 = new TableHeaderCell();
        thc1.Text = "Claim Type";

        TableHeaderCell thc2 = new TableHeaderCell();
        thc2.Text = "Claim Value";

        TableHeaderCell thc3 = new TableHeaderCell();
        thc3.Text = "Value Type";

        TableHeaderCell thc4 = new TableHeaderCell();
        thc4.Text = "Subject Name";

        TableHeaderCell thc5 = new TableHeaderCell();
        thc5.Text = "Issuer Name";

        TableHeaderCell thc6 = new TableHeaderCell();
        thc6.Text = "Original Issuer";

        TableHeaderRow th = new TableHeaderRow();
        th.Controls.Add(thc1);
        th.Controls.Add(thc2);
        th.Controls.Add(thc3);
        th.Controls.Add(thc4);
        th.Controls.Add(thc5);
        th.Controls.Add(thc6);
        th.BorderWidth = 1;
        th.BorderColor = System.Drawing.Color.Chocolate;
        // add a row for each claim
        table.Controls.Add(th);
    }
}
