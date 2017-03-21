	private:
		void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
		{
			// For each screen, add the screen properties to a list box.
			for each (Screen^ screen in Screen::AllScreens) {
				listBox1->Items->Add( 
					String::Concat("Device Name: ", screen->DeviceName));
				listBox1->Items->Add( 
					String::Concat("Bounds: ", screen->Bounds));
				listBox1->Items->Add( 
					String::Concat("Type: ", screen->GetType()));
				listBox1->Items->Add( 
					String::Concat("Working Area: ", screen->WorkingArea));
				listBox1->Items->Add( 
					String::Concat("Primary Screen: ", screen->Primary));
			}
		}