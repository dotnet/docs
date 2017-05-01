#include "Form1.h"

#using <System.Windows.Forms.dll>
#using <System.dll>
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Windows::Forms;

using namespace TestMaskedTextBoxExample;

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew TestMaskedTextBox());
}

