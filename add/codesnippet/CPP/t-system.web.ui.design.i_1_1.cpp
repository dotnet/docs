public:
   property String^ imageURL 
   {
      [EditorAttribute(ImageUrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return imgURL;
      }


      [EditorAttribute(ImageUrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         imgURL = value;
      }

   }

private:
   String^ imgURL;