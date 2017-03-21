    // This is the program entry point. It allows the user to enter 
    // her credentials and the Internet resource (Web page) to access.
    // It also unregisters the standard and registers the customized basic 
    // authentication.
    public static void Main(string[] args) 
    {
    
      if (args.Length < 3)
        showusage();
      else 
      {    
         
        // Read the user's credentials.
        uri = args[0];
        username = args[1];
        password = args[2];

        if (args.Length == 3)
          domain = string.Empty;
        else
          // If the domain exists, store it. Usually the domain name
          // is by default the name of the server hosting the Internet
          // resource.
          domain = args[3];

        // Unregister the standard Basic authentication module.
        AuthenticationManager.Unregister("Basic");

        // Instantiate the custom Basic authentication module.
        CustomBasic customBasicModule = new CustomBasic();
           
        // Register the custom Basic authentication module.
        AuthenticationManager.Register(customBasicModule);
 
        // Display registered Authorization modules.
        displayRegisteredModules();
        
        // Read the specified page and display it on the console.
        getPage(uri);
      }
      return;
    }