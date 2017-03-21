public:
   virtual IPermission^ Union( IPermission^ target ) override
   {
#if ( debug ) 
      Console::WriteLine( "************* Entering Union *********************" );
#endif 

      if ( target == nullptr )
      {
         return this;
      }

#if ( debug ) 
      Console::WriteLine( "This is = {0}", ((NameIdPermission)this).Name );
      Console::WriteLine( "Target is {0}", ((NameIdPermission)target).m_Name );
#endif 

      if (  !VerifyType( target ) )
      {
         throw gcnew ArgumentException( String::Format( "Argument_WrongType", this->GetType()->FullName ) );
      }

      NameIdPermission^ operand = dynamic_cast<NameIdPermission^>(target);

      if ( operand->IsSubsetOf( this ) )
      {
         return this->Copy();
      }
      else if ( this->IsSubsetOf( operand ) )
      {
         return operand->Copy();
      }
      else
      {
         return nullptr;
      }
   }