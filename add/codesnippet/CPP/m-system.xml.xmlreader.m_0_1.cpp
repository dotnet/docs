      if ( reader->MoveToContent() == XmlNodeType::Element &&
         reader->Name->Equals( "price" ) )
      {
         _price = reader->ReadString();
      }