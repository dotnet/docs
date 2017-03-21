      IUIService^ UIservice = dynamic_cast<IUIService^>(this->GetService( System::Windows::Forms::Design::IUIService::typeid ));
      if ( UIservice != nullptr )
            UIservice->ShowError( gcnew Exception( "This is a message in a test exception, displayed by the IUIService",gcnew ArgumentException( "Test inner exception" ) ) );