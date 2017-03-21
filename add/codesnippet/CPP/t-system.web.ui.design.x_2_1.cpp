public:
   property String^ XslFileURL 
   {
      [EditorAttribute(XslUrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return xslURL;
      }

      [EditorAttribute(XslUrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         xslURL = value;
      }
   }

private:
   String^ xslURL;