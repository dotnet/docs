using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default2 : System.Web.UI.Page
{
   // controls on web form
   TextBox inputNumber;
   Label outputNumber;

   // <Snippet1>
   protected void OkToSingle_Click(object sender, EventArgs e)
   {
      string locale;
      float number;
      CultureInfo culture; 

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return; 

      // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);
      
      // Convert user input from a string to a number
      try
      {
         number = Single.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (Exception)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet1>

   // <Snippet2>
   protected void OkToDouble_Click(object sender, EventArgs e)
   {
      string locale;
      double number;
      CultureInfo culture;

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return;

     // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);

      // Convert user input from a string to a number
      try
      {
         number = Double.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (OverflowException)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet2>

   // <Snippet3>
   protected void OkToDecimal_Click(object sender, EventArgs e)
   {
      string locale;
      decimal number;
      CultureInfo culture;

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return;

     // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);

      // Convert user input from a string to a number
      try
      {
         number = Decimal.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (Exception)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet3>

   // <Snippet4>
   protected void OkToInteger_Click(object sender, EventArgs e)
   {
      string locale;
      int number;
      CultureInfo culture;

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return;

     // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);

      // Convert user input from a string to a number
      try
      {
         number = Int32.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (Exception)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet4>

   // <Snippet5>
   protected void OkToLong_Click(object sender, EventArgs e)
   {
      string locale;
      long number;
      CultureInfo culture;

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return;

     // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);

      // Convert user input from a string to a number
      try
      {
         number = Int64.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (Exception)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet5>

   // <Snippet6>
   protected void OkToUInteger_Click(object sender, EventArgs e)
   {
      string locale;
      uint number;
      CultureInfo culture;

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return;

     // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);

      // Convert user input from a string to a number
      try
      {
         number = UInt32.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (Exception)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet6>

   // <Snippet7>
   protected void OkToULong_Click(object sender, EventArgs e)
   {
      string locale;
      ulong number;
      CultureInfo culture;

      // Return if string is empty
      if (String.IsNullOrEmpty(this.inputNumber.Text))
         return;

      // Get locale of web request to determine possible format of number
      if (Request.UserLanguages.Length == 0)
         return;
      locale = Request.UserLanguages[0];
      if (String.IsNullOrEmpty(locale))
         return;

     // Instantiate CultureInfo object for the user's locale
      culture = new CultureInfo(locale);

      // Convert user input from a string to a number
      try
      {
         number = UInt64.Parse(this.inputNumber.Text, culture.NumberFormat);
      }
      catch (FormatException)
      {
         return;
      }
      catch (Exception)
      {
         return;
      }
      // Output number to label on web form
      this.outputNumber.Text = "Number is " + number.ToString();
   }
   // </Snippet7>
}
