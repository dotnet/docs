using System.Web.UI;
using System.Web.UI.WebControls;

// <Snippet1>
using System;
using System.Globalization;

partial class NumericUserInput : System.Web.UI.Page
{
   protected void OKButton_Click(object sender, EventArgs e)
   {
      string locale;
      CultureInfo culture = null;
      double number = 0;
      bool result = false;

      // Exit if input is absent.
      if (String.IsNullOrEmpty(this.NumericString.Text)) return;

      // Hide form elements.
      this.NumericInput.Visible = false;

      // Get user culture/region
      if (!(Request.UserLanguages.Length == 0 || String.IsNullOrEmpty(Request.UserLanguages[0])))
      {
         try
         {
            locale = Request.UserLanguages[0];
            culture = new CultureInfo(locale, false);

            // Parse input using user culture.
            result = Double.TryParse(this.NumericString.Text, NumberStyles.Any,
                                     culture.NumberFormat, out number);
         }
         catch { }
         // If parse fails, parse input using any additional languages.
         if (!result)
         {
            if (Request.UserLanguages.Length > 1)
            {
               for (int ctr = 1; ctr <= Request.UserLanguages.Length - 1; ctr++)
               {
                  try
                  {
                     locale = Request.UserLanguages[ctr];
                     // Remove quality specifier, if present.
                     locale = locale.Substring(1, locale.IndexOf(';') - 1);
                     culture = new CultureInfo(Request.UserLanguages[ctr], false);
                     result = Double.TryParse(this.NumericString.Text, NumberStyles.Any, culture.NumberFormat, out number);
                     if (result) break;
                  }
                  catch { }
               }
            }
         }
      }
      // If parse operation fails, use invariant culture.
      if (!result)
         result = Double.TryParse(this.NumericString.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out number);

      // Double result.
      number *= 2;

      // Display result to user.
      if (result)
      {
         Response.Write("<P />");
         Response.Write(Server.HtmlEncode(this.NumericString.Text) + " * 2 = " + number.ToString("N", culture) + "<BR />");
      }
      else
      {
         // Unhide form.
         this.NumericInput.Visible = true;

         Response.Write("<P />");
         Response.Write("Unable to recognize " + Server.HtmlEncode(this.NumericString.Text));
      }
   }
}
// </Snippet1>

// needed for code to compile
partial class NumericUserInput
{
   protected UserControl NumericInput = new UserControl();
   protected TextBox NumericString = new TextBox();
   protected Button OKButton = new Button();
}
