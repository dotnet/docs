   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property System::Windows::Forms::AnchorStyles testAnchor 
      {
         System::Windows::Forms::AnchorStyles get()
         {
            return anchor;
         }
         void set( System::Windows::Forms::AnchorStyles value )
         {
            anchor = value;
         }
      }
   private:
      AnchorStyles anchor;