//Program.cpp file

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;
using namespace System::Printing;
using namespace System::Collections;

namespace EnumerateSubsetOfPrintQueues {

   private ref class Program {

   public: 
      static void Main (array<System::String^>^ args) 
      {
         //<SnippetListSubsetOfPrintQueues>
         // Specify that the list will contain only the print queues that are installed as local and are shared
         array<System::Printing::EnumeratedPrintQueueTypes>^ enumerationFlags = {EnumeratedPrintQueueTypes::Local,EnumeratedPrintQueueTypes::Shared};

         LocalPrintServer^ printServer = gcnew LocalPrintServer();

         //Use the enumerationFlags to filter out unwanted print queues
         PrintQueueCollection^ printQueuesOnLocalServer = printServer->GetPrintQueues(enumerationFlags);

         Console::WriteLine("These are your shared, local print queues:\n\n");

         for each (PrintQueue^ printer in printQueuesOnLocalServer)
         {
            Console::WriteLine("\tThe shared printer " + printer->Name + " is located at " + printer->Location + "\n");
         }
         Console::WriteLine("Press enter to continue.");
         Console::ReadLine();
         //</SnippetListSubsetOfPrintQueues>
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
int main (array<System::String^>^ args)
{
   EnumerateSubsetOfPrintQueues::Program::Main(args);
   return 0;
}
