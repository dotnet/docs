      // Use BindToMoniker to run the queued moniker, to get an instance of the recorder
      IQueuedComponent ^ qc = dynamic_cast<IQueuedComponent^>(System::Runtime::InteropServices::Marshal::BindToMoniker( "queue:/new:QueuedComponent" ));
      
      // Call the method that will be recorded
      qc->QueuedTask();
      
      // Force the release of the recorder object, to send the message to the queue
      System::Runtime::InteropServices::Marshal::ReleaseComObject( qc );