   public:
      ResolveNameEventArgs^ CreateResolveNameEventArgs( Object^ value, String^ name )
      {
         ResolveNameEventArgs^ e = gcnew ResolveNameEventArgs( name );
         // The name to resolve                       e.Name
         // Stores an Object matching the name        e.Value
         return e;
      }