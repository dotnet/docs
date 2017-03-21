   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property ICollection^ testCollection 
      {
         ICollection^ get()
         {
            return Icollection;
         }
         void set( ICollection^ value )
         {
            Icollection = value;
         }
      }
   private:
      ICollection^ Icollection;