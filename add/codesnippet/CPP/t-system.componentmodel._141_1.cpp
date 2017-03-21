   public ref class Customer: public IEditableObject
   {
   private:
      ref struct CustomerData
      {
      internal:
         String^ id;
         String^ firstName;
         String^ lastName;
      };

   internal:
      CustomersList^ parent;
      CustomerData^ custData;
      CustomerData^ backupData;
      bool inTxn;

      // Implements IEditableObject
   public:
      virtual void BeginEdit()
      {
         Console::WriteLine( "Start BeginEdit" );
         if (  !inTxn )
         {
            this->backupData = custData;
            inTxn = true;
            Console::WriteLine( "BeginEdit - {0}", this->backupData->lastName );
         }

         Console::WriteLine( "End BeginEdit" );
      }

      virtual void CancelEdit()
      {
         Console::WriteLine( "Start CancelEdit" );
         if ( inTxn )
         {
            this->custData = backupData;
            inTxn = false;
            Console::WriteLine( "CancelEdit - {0}", this->custData->lastName );
         }

         Console::WriteLine( "End CancelEdit" );
      }

      virtual void EndEdit()
      {
         Console::WriteLine( "Start EndEdit{0}{1}", this->custData->id, this->custData->lastName );
         if ( inTxn )
         {
            backupData = gcnew CustomerData;
            inTxn = false;
            Console::WriteLine( "Done EndEdit - {0}{1}", this->custData->id, this->custData->lastName );
         }

         Console::WriteLine( "End EndEdit" );
      }


   public:

      Customer( String^ ID )
      {
         this->custData = gcnew CustomerData;
         this->custData->id = ID;
         this->custData->firstName = "";
         this->custData->lastName = "";
         inTxn = false;
      }

      property String^ ID 
      {
         String^ get()
         {
            return this->custData->id;
         }

      }

      property String^ FirstName 
      {
         String^ get()
         {
            return this->custData->firstName;
         }

         void set( String^ value )
         {
            this->custData->firstName = value;
			this->OnCustomerChanged();
         }

      }

      property String^ LastName 
      {
         String^ get()
         {
            return this->custData->lastName;
         }

         void set( String^ value )
         {
            this->custData->lastName = value;
			this->OnCustomerChanged();
         }

      }

   internal:

      property CustomersList^ Parent 
      {
         CustomersList^ get()
         {
            return parent;
         }

         void set( CustomersList^ value )
         {
            parent = value;
         }

      }

	  void OnCustomerChanged()
	  {
         if (!inTxn && Parent != nullptr)
         {
			 Parent->CustomerChanged(this);
		 }
	  }

   public:
      virtual String^ ToString() override
      {
         StringWriter^ sb = gcnew StringWriter;
         sb->Write( this->FirstName );
         sb->Write( " " );
         sb->Write( this->LastName );
         return sb->ToString();
      }
   };