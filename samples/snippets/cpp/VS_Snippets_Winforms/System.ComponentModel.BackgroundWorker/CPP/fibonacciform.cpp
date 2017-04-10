

// <snippet1>
// <snippet2>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Threading;
using namespace System::Windows::Forms;

// </snippet2>
public ref class FibonacciForm: public System::Windows::Forms::Form
{
private:

   // <snippet14>
   int numberToCompute;
   int highestPercentageReached;
   // </snippet14>

   System::Windows::Forms::NumericUpDown^ numericUpDown1;
   System::Windows::Forms::Button^ startAsyncButton;
   System::Windows::Forms::Button^ cancelAsyncButton;
   System::Windows::Forms::ProgressBar^ progressBar1;
   System::Windows::Forms::Label ^ resultLabel;
   System::ComponentModel::BackgroundWorker^ backgroundWorker1;

public:
   FibonacciForm()
   {
      InitializeComponent();
      numberToCompute = highestPercentageReached = 0;
      InitializeBackgoundWorker();
   }


private:

   // Set up the BackgroundWorker object by 
   // attaching event handlers. 
   void InitializeBackgoundWorker()
   {
      backgroundWorker1->DoWork += gcnew DoWorkEventHandler( this, &FibonacciForm::backgroundWorker1_DoWork );
      backgroundWorker1->RunWorkerCompleted += gcnew RunWorkerCompletedEventHandler( this, &FibonacciForm::backgroundWorker1_RunWorkerCompleted );
      backgroundWorker1->ProgressChanged += gcnew ProgressChangedEventHandler( this, &FibonacciForm::backgroundWorker1_ProgressChanged );
   }

   // <snippet13>
   void startAsyncButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Reset the text in the result label.
      resultLabel->Text = String::Empty;

      // Disable the UpDown control until 
      // the asynchronous operation is done.
      this->numericUpDown1->Enabled = false;

      // Disable the Start button until 
      // the asynchronous operation is done.
      this->startAsyncButton->Enabled = false;

      // Enable the Cancel button while 
      // the asynchronous operation runs.
      this->cancelAsyncButton->Enabled = true;

      // Get the value from the UpDown control.
      numberToCompute = (int)numericUpDown1->Value;

      // Reset the variable for percentage tracking.
      highestPercentageReached = 0;

      // <snippet3>
      // Start the asynchronous operation.
      backgroundWorker1->RunWorkerAsync( numberToCompute );
      // </snippet3>
   }
   // </snippet13>

   // <snippet4>
   void cancelAsyncButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {  
      // Cancel the asynchronous operation.
      this->backgroundWorker1->CancelAsync();
      
      // Disable the Cancel button.
      cancelAsyncButton->Enabled = false;
   }
   // </snippet4>

   // <snippet5>
   // This event handler is where the actual,
   // potentially time-consuming work is done.
   void backgroundWorker1_DoWork( Object^ sender, DoWorkEventArgs^ e )
   {
      // Get the BackgroundWorker that raised this event.
      BackgroundWorker^ worker = dynamic_cast<BackgroundWorker^>(sender);

      // Assign the result of the computation
      // to the Result property of the DoWorkEventArgs
      // object. This is will be available to the 
      // RunWorkerCompleted eventhandler.
      e->Result = ComputeFibonacci( safe_cast<Int32>(e->Argument), worker, e );
   }
   // </snippet5>

   // <snippet6>
   // This event handler deals with the results of the
   // background operation.
   void backgroundWorker1_RunWorkerCompleted( Object^ /*sender*/, RunWorkerCompletedEventArgs^ e )
   {
      // First, handle the case where an exception was thrown.
      if ( e->Error != nullptr )
      {
         MessageBox::Show( e->Error->Message );
      }
      else
      if ( e->Cancelled )
      {
         // Next, handle the case where the user cancelled 
         // the operation.
         // Note that due to a race condition in 
         // the DoWork event handler, the Cancelled
         // flag may not have been set, even though
         // CancelAsync was called.
         resultLabel->Text = "Cancelled";
      }
      else
      {
         // Finally, handle the case where the operation 
         // succeeded.
         resultLabel->Text = e->Result->ToString();
      }

      // Enable the UpDown control.
      this->numericUpDown1->Enabled = true;

      // Enable the Start button.
      startAsyncButton->Enabled = true;

      // Disable the Cancel button.
      cancelAsyncButton->Enabled = false;
   }
   // </snippet6>

   // <snippet7>
   // This event handler updates the progress bar.
   void backgroundWorker1_ProgressChanged( Object^ /*sender*/, ProgressChangedEventArgs^ e )
   {
      this->progressBar1->Value = e->ProgressPercentage;
   }
   // </snippet7>

   // <snippet10>
   // This is the method that does the actual work. For this
   // example, it computes a Fibonacci number and
   // reports progress as it does its work.
   long ComputeFibonacci( int n, BackgroundWorker^ worker, DoWorkEventArgs ^ e )
   {
      // The parameter n must be >= 0 and <= 91.
      // Fib(n), with n > 91, overflows a long.
      if ( (n < 0) || (n > 91) )
      {
         throw gcnew ArgumentException( "value must be >= 0 and <= 91","n" );
      }

      long result = 0;
      
      // <snippet8>
      // Abort the operation if the user has cancelled.
      // Note that a call to CancelAsync may have set 
      // CancellationPending to true just after the
      // last invocation of this method exits, so this 
      // code will not have the opportunity to set the 
      // DoWorkEventArgs.Cancel flag to true. This means
      // that RunWorkerCompletedEventArgs.Cancelled will
      // not be set to true in your RunWorkerCompleted
      // event handler. This is a race condition.
	  // <snippet11>
      if ( worker->CancellationPending )
      {
         e->Cancel = true;
      }
	  // </snippet11>
      else
      {
         if ( n < 2 )
         {
            result = 1;
         }
         else
         {
            result = ComputeFibonacci( n - 1, worker, e ) + ComputeFibonacci( n - 2, worker, e );
         }

         // <snippet12>
         // Report progress as a percentage of the total task.
         int percentComplete = (int)((float)n / (float)numberToCompute * 100);
         if ( percentComplete > highestPercentageReached )
         {
            highestPercentageReached = percentComplete;
            worker->ReportProgress( percentComplete );
         }
	 // </snippet12>
      }
      // </snippet8>

      return result;
   }
   // </snippet10>

   void InitializeComponent()
   {
      this->numericUpDown1 = gcnew System::Windows::Forms::NumericUpDown;
      this->startAsyncButton = gcnew System::Windows::Forms::Button;
      this->cancelAsyncButton = gcnew System::Windows::Forms::Button;
      this->resultLabel = gcnew System::Windows::Forms::Label;
      this->progressBar1 = gcnew System::Windows::Forms::ProgressBar;
      this->backgroundWorker1 = gcnew System::ComponentModel::BackgroundWorker;
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->numericUpDown1))->BeginInit();
      this->SuspendLayout();
      
      // 
      // numericUpDown1
      // 
      this->numericUpDown1->Location = System::Drawing::Point( 16, 16 );
      array<Int32>^temp0 = {91,0,0,0};
      this->numericUpDown1->Maximum = System::Decimal( temp0 );
      array<Int32>^temp1 = {1,0,0,0};
      this->numericUpDown1->Minimum = System::Decimal( temp1 );
      this->numericUpDown1->Name = "numericUpDown1";
      this->numericUpDown1->Size = System::Drawing::Size( 80, 20 );
      this->numericUpDown1->TabIndex = 0;
      array<Int32>^temp2 = {1,0,0,0};
      this->numericUpDown1->Value = System::Decimal( temp2 );

      // 
      // startAsyncButton
      // 
      this->startAsyncButton->Location = System::Drawing::Point( 16, 72 );
      this->startAsyncButton->Name = "startAsyncButton";
      this->startAsyncButton->Size = System::Drawing::Size( 120, 23 );
      this->startAsyncButton->TabIndex = 1;
      this->startAsyncButton->Text = "Start Async";
      this->startAsyncButton->Click += gcnew System::EventHandler( this, &FibonacciForm::startAsyncButton_Click );

      // 
      // cancelAsyncButton
      // 
      this->cancelAsyncButton->Enabled = false;
      this->cancelAsyncButton->Location = System::Drawing::Point( 153, 72 );
      this->cancelAsyncButton->Name = "cancelAsyncButton";
      this->cancelAsyncButton->Size = System::Drawing::Size( 119, 23 );
      this->cancelAsyncButton->TabIndex = 2;
      this->cancelAsyncButton->Text = "Cancel Async";
      this->cancelAsyncButton->Click += gcnew System::EventHandler( this, &FibonacciForm::cancelAsyncButton_Click );

      // 
      // resultLabel
      // 
      this->resultLabel->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->resultLabel->Location = System::Drawing::Point( 112, 16 );
      this->resultLabel->Name = "resultLabel";
      this->resultLabel->Size = System::Drawing::Size( 160, 23 );
      this->resultLabel->TabIndex = 3;
      this->resultLabel->Text = "(no result)";
      this->resultLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;

      // 
      // progressBar1
      // 
      this->progressBar1->Location = System::Drawing::Point( 18, 48 );
      this->progressBar1->Name = "progressBar1";
      this->progressBar1->Size = System::Drawing::Size( 256, 8 );
      this->progressBar1->Step = 2;
      this->progressBar1->TabIndex = 4;

      // 
      // backgroundWorker1
      // 
      this->backgroundWorker1->WorkerReportsProgress = true;
      this->backgroundWorker1->WorkerSupportsCancellation = true;

      // 
      // FibonacciForm
      // 
      this->ClientSize = System::Drawing::Size( 292, 118 );
      this->Controls->Add( this->progressBar1 );
      this->Controls->Add( this->resultLabel );
      this->Controls->Add( this->cancelAsyncButton );
      this->Controls->Add( this->startAsyncButton );
      this->Controls->Add( this->numericUpDown1 );
      this->Name = "FibonacciForm";
      this->Text = "Fibonacci Calculator";
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->numericUpDown1))->EndInit();
      this->ResumeLayout( false );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew FibonacciForm );
}
// </snippet1>
