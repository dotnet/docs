private:
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "UnknownNode Namespace URI: {0}", e->NamespaceURI );
   }