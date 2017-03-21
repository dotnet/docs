      protected override void Render(HtmlTextWriter output) 
	   {
         output.Write("Welcome to Control Development!<br>");

			// Test if the page is loaded for the first time
			if (!Page.IsPostBack)
				output.Write("Page has just been loaded");
		   else
				output.Write("Postback has occured");
       }