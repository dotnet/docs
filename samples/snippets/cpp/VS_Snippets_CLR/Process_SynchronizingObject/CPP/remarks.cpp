// This is kind of a ripoff of 'process_synchronizingobject.cs' for use as a znippet
// for the remarks section.

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

namespace SynchronizingObjectTest
{
    public ref class SyncForm : System::Windows::Forms::Form
    {

    public:
        SyncForm() : components( nullptr )
        {
            InitializeComponent();
        }

        ~SyncForm()
        {
            if ( components != nullptr )
            {
                delete components;
            }
        }

        static void Main()
        {
            Application::Run(gcnew SyncForm);
        }
#if 0   // Dispose is implicit
    protected:
        virtual void Dispose( bool disposing ) override
        {
            if( disposing )
            {
                if (components != null)
                {
                    components->Dispose();
                }
            }
            base->Dispose( disposing );
        }
#endif

    private:
        System::ComponentModel::Container^ components;
        Process^ process1;
        Button^ button1;
        Label^ label1;

        void InitializeComponent()
        {
            this->button1 = gcnew Button();
            this->label1 = gcnew Label();
            this->SuspendLayout();
            //
            // button1
            //
            this->button1->Location = System::Drawing::Point(20, 20);
            this->button1->Name = "button1";
            this->button1->Size = System::Drawing::Size(160, 30);
            this->button1->TabIndex = 0;
            this->button1->Text = "Click Me";
            this->button1->Click += gcnew EventHandler(this, &SyncForm::button1_Click);
            //
            // textbox
            //
            this->label1->Location = System::Drawing::Point(20, 20);
            this->label1->Name = "textbox1";
            this->label1->Size = System::Drawing::Size(160, 30);
            this->label1->TabIndex = 1;
            this->label1->Text = "Waiting for the process 'notepad' to exit....";
            this->label1->ForeColor = System::Drawing::Color::Red;
            this->label1->Visible = false;
            //
            // Form1
            //
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(200, 70);
            this->Controls->Add(this->button1);
            this->Controls->Add(this->label1);
            this->Name = "SyncForm";
            this->Text = "SyncForm";
            this->ResumeLayout(false);
        }



        void button1_Click(Object^ sender, System::EventArgs^ e)
        {
            this->button1->Hide();
            this->label1->Show();

            process1 = gcnew Process();
            ProcessStartInfo^ process1StartInfo= gcnew ProcessStartInfo("notepad");

            // <Snippet2>
            this->process1->StartInfo->Domain = "";
            this->process1->StartInfo->LoadUserProfile = false;
            this->process1->StartInfo->Password = nullptr;
            this->process1->StartInfo->StandardErrorEncoding = nullptr;
            this->process1->StartInfo->StandardOutputEncoding = nullptr;
            this->process1->StartInfo->UserName = "";
            this->process1->SynchronizingObject = this;
            // </Snippet2>

            // Set method handling the exited event to be called
            process1->Exited += gcnew EventHandler(this, &SyncForm::TheProcessExited);
            // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
            process1->EnableRaisingEvents = true;

            this->Refresh();
            process1->StartInfo = process1StartInfo;
            process1->Start();

            process1->WaitForExit();
            process1->Close();
        }

        void TheProcessExited(Object^ source, EventArgs^ e)
        {
            this->label1->Hide();
            this->button1->Show();
            MessageBox::Show("The process has exited.");
        }
    };
}

[STAThread]
int main()
{
    SynchronizingObjectTest::SyncForm::Main();
}