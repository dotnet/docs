    // Create an event for this user control
    public event System.EventHandler myControl;

    // Override the default constructor.
    protected override void Construct()
    {
        // Specify the handler for the OnInit method.
        this.myControl += new EventHandler(MyInit);
    }

    protected override void OnInit(EventArgs e)
    {
        myControl(this, e);
        Response.Write("The OnInit() method is used to raise the Init event.");
    }

    // Use the MyInit handler to set the Message property
    void MyInit(object sender, System.EventArgs e)
    {
        Message = "Hello World!";
    }