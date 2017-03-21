   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property String^ testFilename 
      {
         String^ get()
         {
            return filename;
         }
         void set( String^ value )
         {
            filename = value;
         }
      }
   private:
      String^ filename;