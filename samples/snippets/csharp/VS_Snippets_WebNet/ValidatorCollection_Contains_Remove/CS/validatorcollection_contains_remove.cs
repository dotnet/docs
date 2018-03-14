// System.Web.UI.ValidatorCollection.Contains()
// System.Web.UI.ValidatorCollection.Remove()
/*
   The following program demonstrates 'Contains' and 'Remove'
   methods of the 'ValidatorCollection' class in 'System.Web.UI'.
   It checks for the 'RequiredFieldValidator' in the ValidatorCollection
   and removes it from the collection.
*/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class MyPage : Page
{
   // Create the controls for the web page.
   protected TextBox myTextBox;
   protected Button myButton;
   protected Label myLabel;
   protected Label myLabel1;
   protected RequiredFieldValidator myRequiredFieldValidator;
   protected HtmlForm myForm;

   public MyPage() : base()
   {
   }

   public void Page_Load(object sender, EventArgs e)
   {
      if(!this.IsPostBack)
      {
         Response.Write("<b>ValidatorCollection Example</b><br><br>");
         myLabel1.Text = "Enter a Number : ";
         AddControls();
      }
      else
      {
         this.Validate();
         if (this.IsValid)
            Response.Write("Page is valid");
         else
            Response.Write("Page is not valid");
      }
   }

   public void Page_Init(object sender, EventArgs e)
   {
      myTextBox = new TextBox();
      myButton = new Button();
      myLabel = new Label();
      myLabel1 = new Label();
      myRequiredFieldValidator = new RequiredFieldValidator();
      myForm = new HtmlForm();

      myForm.Method = "POST";

      // Call the required properties on the controls.
      myTextBox.ID = "Number";
      myButton.Text = "Submit";
      myRequiredFieldValidator.ControlToValidate = "Number";
      myRequiredFieldValidator.ErrorMessage = "Number entry is Mandatory.";
   }

   // Add all the controls to the form.
   private void AddControls()
   {
// <Snippet1>
      Controls.Add(myForm);
      myForm.Controls.Add(myLabel1);
      myForm.Controls.Add(myTextBox);
      myForm.Controls.Add(myButton);
      this.Validators.Add(myRequiredFieldValidator);
      myForm.Controls.Add(myLabel);


      // Remove the RequiredFieldValidator.
      if(Validators.Contains(myRequiredFieldValidator))
      {
         this.Validators.Remove(myRequiredFieldValidator);
         Response.Write("RequiredFieldValidator is removed from ValidatorCollection<br>");
         Response.Write("ValidatorCollection count after removing the Validator: "+Validators.Count+"<br>");
      }
      else
      {
         Response.Write("ValidatorCollection does not contain RequiredFieldValidator");
      }
// </Snippet1>

   }
}