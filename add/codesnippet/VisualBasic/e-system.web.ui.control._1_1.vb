   ' This is the constructor for a custom Page class. 
   ' When this constructor is called, it associates the Control.Load event,
   ' which the Page class inherits from the Control class, with the Page_Load
   ' event handler for this version of the page.
   Public Sub New()
      AddHandler Load, AddressOf Page_Load
   End Sub 'New
   