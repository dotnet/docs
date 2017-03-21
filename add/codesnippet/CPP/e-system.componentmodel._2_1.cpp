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