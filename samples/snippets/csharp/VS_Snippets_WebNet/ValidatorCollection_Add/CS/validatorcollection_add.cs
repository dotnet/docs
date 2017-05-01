// System.Web.UI.ValidatorCollection.Add()
/*
   The following program demonstrates the 'Add' method of the
   'ValidatorCollection' class in 'System.Web.UI'. It adds a
   'RequiredFieldValidator' to the ValidatorCollection using
   Page.Validators in Page_Load method and validates the
   TextBox on clicking the Submit button.
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
         Response.Write("<b>ValidatorCollection Add Example</b>");
         myLabel1.Text = "Enter a Number : ";
         AddControls();
         myLabel.Text = "RequiredFieldValidator is added to the Collection";
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
      myRequiredFieldValidator.ErrorMessage = "Data entry is Mandatory.";

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
      myForm.Controls.Add(myRequiredFieldValidator);
// </Snippet1>
   }

}
