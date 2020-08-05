using System.Windows.Forms;
using System.Drawing;
// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class RegexLib
{
   public static bool IsValidCurrency(string currencyValue)
   {
      string pattern = @"\p{Sc}+\s*\d+";
      Regex currencyRegex = new Regex(pattern);
      return currencyRegex.IsMatch(currencyValue);
   }
}
// </Snippet3>

public class CurrencyForm : Form
{
   Button OKButton;
   TextBox sourceCurrency;
   Label status;

   public CurrencyForm()
   {
      sourceCurrency = new TextBox();
      sourceCurrency.Location = new Point(25, 50);
      sourceCurrency.Size = new Size(100, 25);
      sourceCurrency.Text = String.Empty;
      sourceCurrency.TextChanged += new System.EventHandler(this.sourceCurrency_TextChanged);
      this.Controls.Add(sourceCurrency);

      OKButton = new Button();
      OKButton.Location = new Point(100, 150);
      OKButton.Size = new Size(75, 25);
      OKButton.Text = "OK";
      OKButton.Click += new System.EventHandler(this.OKButton_Click);
      this.Controls.Add(OKButton);
      this.AcceptButton = OKButton;

      status = new Label();
      status.Location = new Point(0, this.Height - 55);
      status.Size = new Size(this.Width, 25);
      status.BorderStyle = BorderStyle.Fixed3D;
      status.Anchor = AnchorStyles.Bottom;
      this.Controls.Add(status);
   }

   public static void Main()
   {
      Form frm = new CurrencyForm();
      Application.Run(frm);
   }

   private void PerformConversion() {}

   public void sourceCurrency_TextChanged(object sender, EventArgs e)
   {
      status.Text = "";
   }

   // <Snippet2>
   public void OKButton_Click(object sender, EventArgs e)
   {
      if (! String.IsNullOrEmpty(sourceCurrency.Text))
         if (RegexLib.IsValidCurrency(sourceCurrency.Text))
            PerformConversion();
         else
            status.Text = "The source currency value is invalid.";
   }
   // </Snippet2>
}
