public:
   myKeyPressClass^ myKeyPressHandler;

   Form1()
   {
      myKeyPressHandler = gcnew myKeyPressClass;

      InitializeComponent();

      textBox1->KeyPress += gcnew KeyPressEventHandler(
         myKeyPressHandler, &myKeyPressClass::myKeyCounter );
   }