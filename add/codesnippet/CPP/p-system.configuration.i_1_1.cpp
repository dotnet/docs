      // Override the property 'HelpText'.
   property String^ HelpText 
   {
      virtual String^ get() override
      {
         return "Installer Description : This is a sample Installer\n"
              + "HelpText is used to provide useful information about the "
              + "installer.";
      }
   }