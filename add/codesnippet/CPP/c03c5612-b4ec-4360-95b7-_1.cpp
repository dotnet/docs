      // Create a Web control from the persisted control String*.
      System::Web::UI::Control^ ctrl = ControlParser::ParseControl( host, inputForm->tbox->Text->Trim() );