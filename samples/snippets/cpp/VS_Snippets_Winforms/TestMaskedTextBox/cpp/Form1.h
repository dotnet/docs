#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace TestMaskedTextBoxExample
{
    public ref class TestMaskedTextBox: public Form
    {
    public:
        TestMaskedTextBox()
        {
            InitializeComponent();
        }
    protected:
        ~TestMaskedTextBox()
		{
			if(components)
			{
				delete components;
			}
		}

        /// <summary>
        /// Required designer variable.
        /// </summary>
    private:
        System::ComponentModel::Container ^components;


#pragma region^ Windows^ Form^ Designer^ generated^ code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private:
        void InitializeComponent()
        {
            //
            // Form1
            //
            this->ClientSize = System::Drawing::Size(690, 159);
            this->Name = "Form1";
            this->Text = "Form1";
        }

#pragma endregion
    };
}
