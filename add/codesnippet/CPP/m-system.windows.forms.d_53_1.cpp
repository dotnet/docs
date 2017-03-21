      IUIService^ UIservice = dynamic_cast<IUIService^>(this->GetService( System::Windows::Forms::Design::IUIService::typeid ));
      if ( UIservice != nullptr )
            UIservice->ShowMessage( "Test message", "Test caption", System::Windows::Forms::MessageBoxButtons::AbortRetryIgnore );