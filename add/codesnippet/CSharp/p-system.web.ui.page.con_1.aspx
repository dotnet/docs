      void Page_Load(Object sender,EventArgs e) 
      {
         Response.Write("<h3>Page.Context Example:</h3>");

         // Add three custom exceptions.
         Context.AddError(new Exception(
             "<h3 style='color: red'>New Exception #1.</h3>"));
         Context.AddError(new Exception(
             "<h3 style='color: red'>New Exception #2.</h3>"));
         Context.AddError(new Exception(
             "<h3 style='color: red'>New Exception #3.</h3>"));
 
         // Capture all the new Exceptions in an array.
         Exception[] errs = Context.AllErrors;
 
         foreach (Exception ex in errs)
         {
            Response.Write("<p style='text-align:center; ");
            Response.Write("font-weight:bold'>");
            Response.Write(Server.HtmlEncode(ex.ToString()) + "</p>"); 
         }
 
         // Clear the exceptions so ASP.NET won't handle them.
         Context.ClearError();
      }