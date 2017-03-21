        simpleServiceProcessInstaller = new ServiceProcessInstaller();
        simpleServiceInstaller = new ServiceInstaller();
                       
        // Set the account properties for the service process.
        simpleServiceProcessInstaller.Account = ServiceAccount.LocalService;
             
        // Set the installation properties for the service.
        // The ServiceInstaller.ServiceName must match the 
        // ServiceBase.ServiceName set in the service
        // implementation that is installed by this installer.
        simpleServiceInstaller.ServiceName = "SimpleService";

        simpleServiceInstaller.DisplayName = "Simple Service";
        simpleServiceInstaller.Description = "A simple service that runs on the local computer.";
        simpleServiceInstaller.StartType = ServiceStartMode.Manual;

        // Add the installers to the Installer collection.
        Installers.Add(simpleServiceInstaller);
        Installers.Add(simpleServiceProcessInstaller);