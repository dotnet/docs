private:
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Object^ o = e->ObjectBeingDeserialized;
      Console::WriteLine( "Object being deserialized: {0}", o );
   }