public:
   property String^ XmlFileURL 
   {
      [EditorAttribute(XmlUrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return xmlURL;
      }


      [EditorAttribute(XmlUrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         xmlURL = value;
      }

   }

private:
   String^ xmlURL;