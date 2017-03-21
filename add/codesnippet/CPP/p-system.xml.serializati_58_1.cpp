private:
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "UnknownNode LocalName: {0}", e->LocalName );
   }