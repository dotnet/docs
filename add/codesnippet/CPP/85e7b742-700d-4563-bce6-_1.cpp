   // Creates a  message filter.
   ref class TestMessageFilter: public IMessageFilter
   {
   public:
      [SecurityPermission(SecurityAction::LinkDemand, Flags = SecurityPermissionFlag::UnmanagedCode)]
      virtual bool PreFilterMessage( Message % m )
      {
         
         // Blocks all the messages relating to the left mouse button.
         if ( m.Msg >= 513 && m.Msg <= 515 )
         {
            Console::WriteLine( "Processing the messages : {0}", m.Msg );
            return true;
         }

         return false;
      }

   };
