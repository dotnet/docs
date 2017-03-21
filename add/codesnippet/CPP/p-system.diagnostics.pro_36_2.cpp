   ref class MyButton: public Button
   {
   public:
      void MyProcessExited( Object^ source, EventArgs^ e )
      {
         MessageBox::Show( "The process has exited." );
      }
   };

public:
   MyButton^ button1;
private:
   void MyProcessExited( Object^ source, EventArgs^ e )
   {
       MessageBox::Show( "The process has exited." );
   }
   void button1_Click( Object^ sender, EventArgs^ e )
   {
      Process^ myProcess = gcnew Process;
      ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo( "mspaint" );
      myProcess->StartInfo = myProcessStartInfo;
      myProcess->Start();
      myProcess->Exited += gcnew System::EventHandler( this, &Form1::MyProcessExited );

      // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
      myProcess->EnableRaisingEvents = true;

      // Set method handling the exited event to be called  ;
      // on the same thread on which MyButton was created.
      myProcess->SynchronizingObject = button1;
      MessageBox::Show( "Waiting for the process 'mspaint' to exit...." );
      myProcess->WaitForExit();
      myProcess->Close();
   }