    // Covariant delegate.
    public delegate R DCovariant<out R>();

    // Methods that match the delegate signature.
    public static Control SampleControl()
    { return new Control(); }

    public static Button SampleButton()
    { return new Button(); }

    public void Test()
    {            
        // Instantiate the delegates with the methods.
        DCovariant<Control> dControl = SampleControl;
        DCovariant<Button> dButton = SampleButton;

        // You can assign dButton to dControl
        // because the DCovariant delegate is covariant.
        dControl = dButton;

        // Invoke the delegate.
        dControl(); 
    }