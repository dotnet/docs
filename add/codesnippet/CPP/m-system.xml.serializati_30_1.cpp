private:
   void PrintNamespacePairs( XmlSerializerNamespaces^ namespaces )
   {
      array<XmlQualifiedName^>^ qualifiedNames = namespaces->ToArray();
      for ( int i = 0; i < qualifiedNames->Length; i++ )
      {
         Console::WriteLine( "{0}\t{1}",
            qualifiedNames[ i ]->Name, qualifiedNames[ i ]->Namespace );
      }
   }