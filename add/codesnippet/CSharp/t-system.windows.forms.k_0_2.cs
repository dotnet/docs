    myKeyPressClass myKeyPressHandler = new myKeyPressClass();
    public Form1()
    {
         InitializeComponent();
     
         textBox1.KeyPress += new KeyPressEventHandler(myKeyPressHandler.myKeyCounter);
    }