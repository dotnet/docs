         try
         {
            System::Diagnostics::Process^ myProc = gcnew System::Diagnostics::Process;
            //Attempting to start a non-existing executable
            myProc->StartInfo->FileName = "c:\nonexist.exe";
            //Start the application and assign it to the process component.
            myProc->Start();
         }
         catch ( Win32Exception^ w ) 
         {
            Console::WriteLine( w->Message );
            Console::WriteLine( w->ErrorCode );
            Console::WriteLine( w->NativeErrorCode );
            Console::WriteLine( w->StackTrace );
            Console::WriteLine( w->Source );
            Exception^ e = w->GetBaseException();
            Console::WriteLine( e->Message );
         }