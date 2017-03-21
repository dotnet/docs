   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property System::Drawing::Font^ testFont 
      {
         System::Drawing::Font^ get()
         {
            return font;
         }
         void set( System::Drawing::Font^ value )
         {
            font = value;
         }
      }
   private:
      Font^ font;