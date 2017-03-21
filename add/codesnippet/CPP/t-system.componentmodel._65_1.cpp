   public:
      property array<Object^>^ componentArray 
      {
         [EditorAttribute(System::ComponentModel::Design::ArrayEditor::typeid,
            System::Drawing::Design::UITypeEditor::typeid)]
         array<Object^>^ get()
         {
            return compArray;
         }
         void set( array<Object^>^ value )
         {
            compArray = value;
         }
      }
   private:
      array<Object^>^compArray;