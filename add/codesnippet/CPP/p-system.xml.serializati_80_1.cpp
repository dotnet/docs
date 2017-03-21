   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "UnknownNode Name: {0}", e->Name );
   }