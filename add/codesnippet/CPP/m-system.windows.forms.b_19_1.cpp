   private:
      void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         String^ xml = "<US><states>"
            + "<state><name>Washington</name><capital>Olympia</capital> "
            + "<flower>Coast Rhododendron</flower></state>"
            + "<state><name>Oregon</name><capital>Salem</capital>"
            + "<flower>Oregon Grape</flower></state>"
            + "<state><name>California</name><capital>Sacramento</capital>"
            + "<flower>California Poppy</flower></state>"
            + "<state><name>Nevada</name><capital>Carson City</capital>"
            + "<flower>Sagebrush</flower></state>"
            + "</states></US>";
         
         // Convert the xml string to bytes and load into a memory stream.
         array<Byte>^ xmlBytes = Encoding::UTF8->GetBytes( xml );
         MemoryStream^ stream = gcnew MemoryStream( xmlBytes,false );
         
         // Create a DataSet and load the xml into it.
         dataSet2->ReadXml( stream );
         
         // Set the data source.
         bindingSource1->DataSource = dataSet2;
         bindingSource1->ResetBindings( true );
      }