// <snippet1>
// <snippet2>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Threading;
using namespace System::Windows::Forms;
// </snippet2>

namespace CrossThreadDemo
{
    public ref class Form1 : public Form
    {
        // <snippet3>
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextDelegate(String^ text);
        // </snippet3>

        // <snippet4>
        // This thread is used to demonstrate both thread-safe and
        // unsafe ways to call a Windows Forms control.
    private:
        Thread^ demoThread;
        // </snippet4>

        // <snippet5>
        // This BackgroundWorker is used to demonstrate the
        // preferred way of performing asynchronous operations.
    private:
        BackgroundWorker^ backgroundWorker1;
        // </snippet5>

    private:
        TextBox^ textBox1;
    private:
        Button^ setTextUnsafeBtn;
    private:
        Button^ setTextSafeBtn;
    private:
        Button^ setTextBackgroundWorkerBtn;

    private:
        System::ComponentModel::IContainer^ components;

    public:
        Form1()
        {
            components = nullptr;
            InitializeComponent();
        }

    protected:
        ~Form1()
        {
            if (components != nullptr)
            {
                delete components;
            }
        }

        // <snippet6>
        // This event handler creates a thread that calls a
        // Windows Forms control in an unsafe way.
    private:
        void setTextUnsafeBtn_Click(Object^ sender, EventArgs^ e)
        {
            this->demoThread =
                gcnew Thread(gcnew ThreadStart(this,&Form1::ThreadProcUnsafe));

            this->demoThread->Start();
        }

        // This method is executed on the worker thread and makes
        // an unsafe call on the TextBox control.
    private:
        void ThreadProcUnsafe()
        {
            this->textBox1->Text = "This text was set unsafely.";
        }
        // </snippet6>

        // <snippet7>
        // This event handler creates a thread that calls a
        // Windows Forms control in a thread-safe way.
    private:
        void setTextSafeBtn_Click(Object^ sender, EventArgs^ e)
        {
            this->demoThread =
                gcnew Thread(gcnew ThreadStart(this,&Form1::ThreadProcSafe));

            this->demoThread->Start();
        }

        // This method is executed on the worker thread and makes
        // a thread-safe call on the TextBox control.
    private:
        void ThreadProcSafe()
        {
            this->SetText("This text was set safely.");
        }
        // </snippet7>

        // <snippet8>
        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control.
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextDelegate and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly.

    private:
        void SetText(String^ text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this->textBox1->InvokeRequired)
            {
                SetTextDelegate^ d = 
                    gcnew SetTextDelegate(this, &Form1::SetText);
                this->Invoke(d, gcnew array<Object^> { text });
            }
            else
            {
                this->textBox1->Text = text;
            }
        }
        // </snippet8>

        // <snippet9>
        // This event handler starts the form's
        // BackgroundWorker by calling RunWorkerAsync.
        //
        // The Text property of the TextBox control is set
        // when the BackgroundWorker raises the RunWorkerCompleted
        // event.
    private:
        void setTextBackgroundWorkerBtn_Click(Object^ sender, EventArgs^ e)
        {
            this->backgroundWorker1->RunWorkerAsync();
        }

        // This event handler sets the Text property of the TextBox
        // control. It is called on the thread that created the
        // TextBox control, so the call is thread-safe.
        //
        // BackgroundWorker is the preferred way to perform asynchronous
        // operations.

    private:
        void backgroundWorker1_RunWorkerCompleted(
            Object^ sender,
            RunWorkerCompletedEventArgs^ e)
        {
            this->textBox1->Text =
                "This text was set safely by BackgroundWorker.";
        }
        // </snippet9>

        #pragma region Windows Form Designer generated code

    private:
        void InitializeComponent()
        {
            this->textBox1 = gcnew System::Windows::Forms::TextBox();
            this->setTextUnsafeBtn = gcnew System::Windows::Forms::Button();
            this->setTextSafeBtn = gcnew System::Windows::Forms::Button();
            this->setTextBackgroundWorkerBtn = 
                gcnew System::Windows::Forms::Button();
            this->backgroundWorker1 = 
                gcnew System::ComponentModel::BackgroundWorker();
            this->SuspendLayout();
            //
            // textBox1
            //
            this->textBox1->Location = System::Drawing::Point(12, 12);
            this->textBox1->Name = "textBox1";
            this->textBox1->Size = System::Drawing::Size(240, 20);
            this->textBox1->TabIndex = 0;
            //
            // setTextUnsafeBtn
            //
            this->setTextUnsafeBtn->Location = System::Drawing::Point(15, 55);
            this->setTextUnsafeBtn->Name = "setTextUnsafeBtn";
            this->setTextUnsafeBtn->TabIndex = 1;
            this->setTextUnsafeBtn->Text = "Unsafe Call";
            this->setTextUnsafeBtn->Click += 
                gcnew System::EventHandler(
                this,&Form1::setTextUnsafeBtn_Click);
            //
            // setTextSafeBtn
            //
            this->setTextSafeBtn->Location = System::Drawing::Point(96, 55);
            this->setTextSafeBtn->Name = "setTextSafeBtn";
            this->setTextSafeBtn->TabIndex = 2;
            this->setTextSafeBtn->Text = "Safe Call";
            this->setTextSafeBtn->Click += 
                gcnew System::EventHandler(this,&Form1::setTextSafeBtn_Click);
            //
            // setTextBackgroundWorkerBtn
            //
            this->setTextBackgroundWorkerBtn->Location = 
                System::Drawing::Point(177, 55);
            this->setTextBackgroundWorkerBtn->Name = 
                "setTextBackgroundWorkerBtn";
            this->setTextBackgroundWorkerBtn->TabIndex = 3;
            this->setTextBackgroundWorkerBtn->Text = "Safe BW Call";
            this->setTextBackgroundWorkerBtn->Click += 
                gcnew System::EventHandler(
                this,&Form1::setTextBackgroundWorkerBtn_Click);
            //
            // backgroundWorker1
            //
            this->backgroundWorker1->RunWorkerCompleted += 
                gcnew System::ComponentModel::RunWorkerCompletedEventHandler(
                this,&Form1::backgroundWorker1_RunWorkerCompleted);
            //
            // Form1
            //
            this->ClientSize = System::Drawing::Size(268, 96);
            this->Controls->Add(this->setTextBackgroundWorkerBtn);
            this->Controls->Add(this->setTextSafeBtn);
            this->Controls->Add(this->setTextUnsafeBtn);
            this->Controls->Add(this->textBox1);
            this->Name = "Form1";
            this->Text = "Form1";
            this->ResumeLayout(false);
            this->PerformLayout();

        }

        #pragma endregion
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew CrossThreadDemo::Form1());
}
// </snippet1>
