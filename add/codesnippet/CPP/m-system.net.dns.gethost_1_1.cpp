public:
        static void DoGetHostEntry(String^ hostname)
        {
            IPHostEntry^ host = Dns::GetHostEntry(hostname);

            Console::WriteLine("GetHostEntry({0}) returns:", host->HostName);
            
            for (int i = 0; i < host->AddressList->Length; i++)
            {				
				Console::WriteLine("    {0}", host->AddressList[i]->ToString());			
            }
        }