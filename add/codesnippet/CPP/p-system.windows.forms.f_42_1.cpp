public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Set the maximum size, so if user maximizes form, it 
      //will not cover entire desktop.  
      this->MaximumSize = System::Drawing::Size( 500, 500 );
   }