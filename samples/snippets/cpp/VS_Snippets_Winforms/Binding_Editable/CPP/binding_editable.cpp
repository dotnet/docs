

#using <system.dll>

using namespace System;
using namespace System::IO;
using namespace System::Collections;
using namespace System::ComponentModel;

namespace IBindingList_Doc
{

   ref class Customer;

   // sample for IBindingList
   //<snippet2>
   public ref class CustomersList: public CollectionBase, public IBindingList
   {
   private:
      ListChangedEventArgs^ resetEvent;
      ListChangedEventHandler^ onListChanged;
      virtual event ListChangedEventHandler^ ListChanged;

   public:
      property bool AllowEdit 
      {
         // Implements IBindingList.
         virtual bool get() sealed
         {
            return true;
         }
      }

      virtual property bool AllowNew 
      {
         bool get()
         {
            return true;
         }
      }

      property bool AllowRemove 
      {
         virtual bool get()
         {
            return true;
         }

      }

      property bool SupportsChangeNotification 
      {
         virtual bool get()
         {
            return true;
         }

      }

      property bool SupportsSearching 
      {
         virtual bool get()
         {
            return true;
         }

      }

      property bool SupportsSorting 
      {
         virtual bool get()
         {
            return true;
         }

      }

      // Methods.
      virtual Object^ AddNew()
      {
         Customer^ c = gcnew Customer( this->Count->ToString() );
         List->Add( c );
         return c;
      }


      property bool IsSorted 
      {

         // Unsupported properties.
         virtual bool get()
         {
            throw gcnew NotSupportedException;
            return false;
         }

      }

      property ListSortDirection SortDirection 
      {
         virtual ListSortDirection get()
         {
            throw gcnew NotSupportedException;
            return ListSortDirection::Ascending;
         }

      }

      property PropertyDescriptor^ SortProperty 
      {
         virtual PropertyDescriptor^ get()
         {
            throw gcnew NotSupportedException;
            return nullptr;
         }

      }

      // Unsupported Methods.
      virtual void AddIndex( PropertyDescriptor^ property )
      {
         throw gcnew NotSupportedException;
      }

      virtual void ApplySort( PropertyDescriptor^ property, ListSortDirection direction )
      {
         throw gcnew NotSupportedException;
      }

      virtual int Find( PropertyDescriptor^ property, Object^ key )
      {
         throw gcnew NotSupportedException;
         return 0;
      }

      virtual void RemoveIndex( PropertyDescriptor^ property )
      {
         throw gcnew NotSupportedException;
      }

      virtual void RemoveSort()
      {
         throw gcnew NotSupportedException;
      }


      // Worker functions to populate the list with data.
      static Customer^ ReadCustomer1()
      {
         Customer^ cust = gcnew Customer( "536-45-1245" );
         cust->FirstName = "Jo";
         cust->LastName = "Brown";
         return cust;
      }

      static Customer^ ReadCustomer2()
      {
         Customer^ cust = gcnew Customer( "246-12-5645" );
         cust->FirstName = "Robert";
         cust->LastName = "Brown";
         return cust;
      }

   protected:
      virtual void OnListChanged( ListChangedEventArgs^ ev )
      {
         if ( onListChanged != nullptr )
         {
            onListChanged( this, ev );
         }
      }

      virtual void OnClear() override
      {
         List->Clear();
      }

      virtual void OnClearComplete() override
      {
         OnListChanged( resetEvent );
      }

      virtual void OnInsertComplete( int index, Object^ value ) override
      {
         Customer^ c = safe_cast<Customer^>(value);
         c->Parent = this;
         OnListChanged( gcnew ListChangedEventArgs( ListChangedType::ItemAdded,index ) );
      }

      virtual void OnRemoveComplete( int index, Object^ value ) override
      {
         Customer^ c = safe_cast<Customer^>(value);
         c->Parent = this;
         OnListChanged( gcnew ListChangedEventArgs( ListChangedType::ItemDeleted,index ) );
      }

      virtual void OnSetComplete( int index, Object^ oldValue, Object^ newValue ) override
      {
         if ( oldValue != newValue )
         {
            Customer^ oldcust = safe_cast<Customer^>(oldValue);
            Customer^ newcust = safe_cast<Customer^>(newValue);
            oldcust->Parent = 0;
            newcust->Parent = this;
            OnListChanged( gcnew ListChangedEventArgs( ListChangedType::ItemAdded,index ) );
         }
      }

   public:

      // Constructor
      CustomersList()
      {
         resetEvent = gcnew ListChangedEventArgs( ListChangedType::Reset,-1 );
      }

      void LoadCustomers()
      {
         IList^ l = static_cast<IList^>(this);
         l->Add( ReadCustomer1() );
         l->Add( ReadCustomer2() );
         OnListChanged( resetEvent );
      }

      property Object^ Item [int]
      {
         Object^ get( int index )
         {
            return static_cast<Customer^>(List->Item[ index ]);
         }

         void set( int index, Object^ value )
         {
            List->Item[ index ] = value;
         }

      }
      int Add( Customer^ value )
      {
         return List->Add( value );
      }

      Customer^ AddNew()
      {
         return safe_cast<Customer^>(static_cast<IBindingList^>(this)->AddNew());
      }

      void Remove( Customer^ value )
      {
         List->Remove( value );
      }

   internal:

      // Called by Customer when it changes.
      void CustomerChanged( Customer^ cust )
      {
         int index = List->IndexOf( cust );
         OnListChanged( gcnew ListChangedEventArgs( ListChangedType::ItemChanged,index ) );
      }

   };
   //</snippet2>

   // sample for IEditableObject
   //<snippet1>
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
   //</snippet1>
   // end of Customer class - sample for IEditableObject
}
