// Action.cpp : main project file.

//#include "stdafx.h"

// <Snippet2>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Name
{
private:
   String^ instanceName;
   
public:
   Name(String^ name)
   {
      instanceName = name;
   }

   void DisplayToConsole()
   {
      Console::WriteLine(this->instanceName);
   }

   void DisplayToWindow()
   {
      MessageBox::Show(this->instanceName);
   }
};


int main()
{
   Name^ testName = gcnew Name(L"Koani");
   System::Action^ showMethod;
   showMethod += gcnew Action(testName, &Name::DisplayToWindow);
   showMethod();
   return 0;
}
// </Snippet2>
