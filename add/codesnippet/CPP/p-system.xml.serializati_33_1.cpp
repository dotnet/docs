private:
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      XmlNodeType myNodeType = e->NodeType;
      Console::WriteLine( myNodeType );
   }