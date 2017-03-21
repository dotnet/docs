      XmlDocument^ doc1 = gcnew XmlDocument;
      doc1->Load( "books.xml" );
      XmlDocument^ doc2 = doc1->Implementation->CreateDocument();