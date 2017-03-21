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