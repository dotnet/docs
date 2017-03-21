   String^ m_authenticationType;
   bool m_canPreAuthenticate;

public:

   // The CustomBasic constructor initializes the properties of the customized
   // authentication.
   CustomBasic()
   {
      m_authenticationType = "Basic";
      m_canPreAuthenticate = false;
   }


   property String^ AuthenticationType 
   {

      // Define the authentication type. This type is then used to identify this
      // custom authentication module. The default is set to Basic.
      virtual String^ get()
      {
         return m_authenticationType;
      }

   }

   property bool CanPreAuthenticate 
   {

      // Define the pre-authentication capabilities for the module. The default is set
      // to false.
      virtual bool get()
      {
         return m_canPreAuthenticate;
      }

   }
