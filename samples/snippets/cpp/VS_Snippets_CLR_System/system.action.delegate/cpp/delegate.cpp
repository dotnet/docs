// Lambda.cpp : main project file.

//#include "stdafx.h"

// <Snippet1>
using namespace System;
using namespace System::Windows::Forms;

public delegate void ShowValue();


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
   ShowValue^ showMethod;
   showMethod = gcnew ShowValue(testName, &Name::DisplayToWindow);
   showMethod();
   return 0;
}
// </Snippet1>
