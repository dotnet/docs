// Action`1.cpp : main project file.

//#include "stdafx.h"

// <Snippet2>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

namespace ActionExample
{
   public ref class Message
   {
   public:
      static void ShowWindowsMessage(String^ message)
      {
         MessageBox::Show(message);
      }
   };
}

int main()
{
   Action<String^>^ messageTarget;

   if (Environment::GetCommandLineArgs()->Length > 1)
      messageTarget = gcnew Action<String^>(&ActionExample::Message::ShowWindowsMessage);
   else
      messageTarget = gcnew Action<String^>(&Console::WriteLine);

   messageTarget("Hello, World!");
   return 0;
}
// </Snippet2>

