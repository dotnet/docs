   [DesignerSerializer(CodeDomSerializerSample::MyCodeDomSerializer::typeid,
      CodeDomSerializer::typeid)]
   public ref class MyComponent: public Component
   {
   private:
      String^ localProperty;

   public:
      MyComponent()
      {
         localProperty = "Component Property Value";
      }

      property String^ LocalProperty 
      {
         String^ get()
         {
            return localProperty;
         }
         void set( String^ value )
         {
            localProperty = value;
         }
      }
   };
}