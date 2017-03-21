   // This is the constructor for a custom Page class. 
   // When this constructor is called, it associates the Control.Load event,
   // which the Page class inherits from the Control class, with the Page_Load
   // event handler for this version of the page.
   public MyPage()
   {
      Load += new EventHandler(Page_Load);
   }