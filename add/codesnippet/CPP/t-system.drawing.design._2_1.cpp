   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property Image^ testImage 
      {
         Image^ get()
         {
            return testImg;
         }
         void set( Image^ value )
         {
            testImg = value;
         }
      }
   private:
      Image^ testImg;