// Delegate.cpp : main project file.

//#include "stdafx.h"

// <Snippet1>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public delegate void DisplayMessage(String^ message);

public ref class TestCustomDelegate
{
public:
   static void ShowWindowsMessage(String^ message)
   {
      MessageBox::Show(message);      
   }
};

int main()
{
    DisplayMessage^ messageTarget; 
      
    if (Environment::GetCommandLineArgs()->Length > 1)
       messageTarget = gcnew DisplayMessage(&TestCustomDelegate::ShowWindowsMessage);
    else
       messageTarget = gcnew DisplayMessage(&Console::WriteLine);
    
    messageTarget(L"Hello World!");
    return 0;
}
// </Snippet1>