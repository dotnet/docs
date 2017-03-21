private:
   XmlSerializerNamespaces^ CreateFromQNames()
   {
      XmlQualifiedName^ q1 =
         gcnew XmlQualifiedName( "money","http://www.cohowinery.com" );

      XmlQualifiedName^ q2 =
         gcnew XmlQualifiedName( "books","http://www.cpandl.com" );

      array<XmlQualifiedName^>^ names = { q1, q2 };

      return gcnew XmlSerializerNamespaces( names );
   }