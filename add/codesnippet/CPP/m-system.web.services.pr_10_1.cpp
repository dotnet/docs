   // Receive the file name stored by GetInitializer and store it in
   // a member variable for this specific instance.
public:
   virtual void Initialize( Object^ initializer ) override
   {
      filename = dynamic_cast<String^>(initializer);
   }