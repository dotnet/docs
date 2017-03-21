      PerformanceCounter^ PC = gcnew PerformanceCounter;
      PC->CategoryName = "Process";
      PC->CounterName = "Private Bytes";
      PC->InstanceName = "Explorer";
      MessageBox::Show( PC->NextValue().ToString() );