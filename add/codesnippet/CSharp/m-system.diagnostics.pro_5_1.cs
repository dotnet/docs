         Process myProcess = new Process();
         // Get the process start information of notepad.
         ProcessStartInfo  myProcessStartInfo = new ProcessStartInfo("notepad.exe");
         // Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
         myProcess.StartInfo = myProcessStartInfo;
         // Create a notepad.
         myProcess.Start();      
         System.Threading.Thread.Sleep(1000);
         ProcessModule myProcessModule;
         // Get all the modules associated with 'myProcess'.
         ProcessModuleCollection myProcessModuleCollection = myProcess.Modules;
         Console.WriteLine("ToString properties of the modules associated "
            +"with 'notepad' are:");
         // Display the ToString of each of the modules.
         for( int i=0;i<myProcessModuleCollection.Count;i++)
         {
            myProcessModule = myProcessModuleCollection[i];
            Console.WriteLine(myProcessModuleCollection[i].ModuleName+" : "
               +myProcessModule.ToString());
         }
         // Get the main module associated with 'myProcess'.
         myProcessModule = myProcess.MainModule;
         // Display the ToString of the main module.
         Console.WriteLine("The process's main module is : "+myProcessModule.ToString());
         myProcess.CloseMainWindow();