using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form2: Form
{
   protected Button okay;
   protected Button cancel;
   public TextBox TextBox1;

   public Form2()
   {
      this.okay = new Button();
      this.okay.Location = new Point(50,50);
      this.okay.Width = 50;
      this.okay.DialogResult = DialogResult.OK;
      this.okay.Text = "OK";

      this.cancel = new Button();
      this.cancel.Location = new Point(okay.Left + okay.Width + 10, 50);
      this.cancel.Width = 50;
      this.cancel.DialogResult = DialogResult.Cancel;
      this.cancel.Text = "Cancel";

      this.TextBox1 = new TextBox();
      this.TextBox1.Location = new Point(50,100);
      this.TextBox1.Width = 110;
      this.TextBox1.Text = "Enter Text";

      this.Controls.AddRange(new Control[] {okay, cancel, TextBox1});
   }
}

public class Form1: Form
{
   protected TextBox txtResult;
   protected Button showButton;

   [STAThread]
   static void Main() 
   {
      Application.Run(new Form1());
   }


   public Form1()
   {
      this.txtResult = new TextBox();
      
      this.showButton = new Button();
      this.showButton.Width = 100;
      this.showButton.Text = "Show Dialog";
      this.showButton.Location = new Point(0, txtResult.Height + 10);
      this.showButton.Click += new EventHandler(this.showButton_Click);
     

      this.Controls.AddRange(new Control[] {txtResult, showButton});
   }



   // <Snippet1>
   public void ShowMyDialogBox()
   {
      Form2 testDialog = new Form2();

      // Show testDialog as a modal dialog and determine if DialogResult = OK.
      if (testDialog.ShowDialog(this) == DialogResult.OK)
      {
         // Read the contents of testDialog's TextBox.
         this.txtResult.Text = testDialog.TextBox1.Text;
      }
      else
      {
         this.txtResult.Text = "Cancelled";
      }
      testDialog.Dispose();
   }
   // </Snippet1>


   private void showButton_Click(object sender, System.EventArgs e)
   {
      ShowMyDialogBox();
   }

}
