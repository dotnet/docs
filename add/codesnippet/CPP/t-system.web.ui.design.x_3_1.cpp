private:
   property String^ XmlFile 
   {
      [EditorAttribute(XmlFileEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return xml_;
      }

      [EditorAttribute(XmlFileEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         xml_ = value;
      }
   }
   String^ xml_;