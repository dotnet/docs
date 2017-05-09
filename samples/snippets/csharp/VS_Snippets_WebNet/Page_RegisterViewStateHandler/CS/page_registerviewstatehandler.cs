/*
   The following program demonstrates the 'RegisterViewStateHandler' method of 'Page' class.
   
   The program creates 'MyForm' derived from 'HtmlForm' and calls 'RegisterViewStateHandler'
   method of 'Page' class which tells the page to save its view state if there are server 
   controls on the page. Dsiplay a textbox and a button and saves the content of text box.
   When a click event of button is raised it will displays the content of previous and 
   current textbox.
*/
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PageSample
{
// <Snippet1>
   // Create a custom HtmlForm server control named MyForm. 
   public class MyForm : HtmlForm
   {
      // MyForm inherits all the base funcitionality
      // of the HtmlForm control.
      public MyForm():base()
      {
      }
      // Override the OnInit method that MyForm inherited from HtmlForm.
      
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override void OnInit( EventArgs e)
      {
         // Save the view state if there are server controls on
         // a page that calls MyForm.
         Page.RegisterViewStateHandler();
      }
   }
// </Snippet1>
   public class WebPage : System.Web.UI.Page
   {
      private MyForm myFormObj;
      private Label label1;
      private Label label2;
      private TextBox textBoxObj;
      private Button buttonObj;

      public WebPage()
      {
         Page.Init += new System.EventHandler(Page_Init);
      }

      private void Page_Load(object sender, System.EventArgs e)
      {
         myFormObj.Method = "post";
         Controls.Add(myFormObj);
         textBoxObj.Text = "Welcome to ASP.Net";

         label1.Text = "Enter a name";
         buttonObj.Text = "ClickMe";
         buttonObj.Click += new EventHandler(Button_Click);
         myFormObj.Controls.Add(label1);
         myFormObj.Controls.Add(textBoxObj);
         myFormObj.Controls.Add(buttonObj);
         myFormObj.Controls.Add(label2);
      }
      private void Button_Click(object sender, EventArgs e)
      {
         String temp = "<br>Name is " + textBoxObj.Text + "<br>";
         temp += "Saved content of previous page is " + ViewState["name"] as String;
         label2.Text = temp;
      }
      
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override void LoadViewState(object viewState)
      {
         if(viewState != null)
            base.LoadViewState(viewState);
      }
 
      
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override object SaveViewState()
      {
         ViewState["name"] = textBoxObj.Text;
         return base.SaveViewState();
      }
      private void Page_Init(object sender, EventArgs e)
      {
         this.Load += new System.EventHandler(this.Page_Load);

         myFormObj = new MyForm();
         label1 = new Label();
         label2 = new Label();
         textBoxObj = new TextBox();
         buttonObj = new Button();
      }
   };
}