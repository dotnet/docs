
using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class ShortStringDictionary: public DictionaryBase
{
public:

   property String^ Item [String^]
   {
      String^ get( String^ key )
      {
         return (dynamic_cast<String^>(Dictionary[ key ]));
      }

      void set( String^ value, String^ key )
      {
         Dictionary[ key ] = value;
      }
   }

   property ICollection^ Keys 
   {
      ICollection^ get()
      {
         return (Dictionary->Keys);
      }
   }

   property ICollection^ Values 
   {
      ICollection^ get()
      {
         return (Dictionary->Values);
      }
   }
   void Add( String^ key, String^ value )
   {
      Dictionary->Add( key, value );
   }

   bool Contains( String^ key )
   {
      return (Dictionary->Contains( key ));
   }

   void Remove( String^ key )
   {
      Dictionary->Remove( key );
   }


protected:
   virtual void OnInsert( Object^ key, Object^ value ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }

      if ( value->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "value must be of type String.","value" );
      else
      {
         String^ strValue = dynamic_cast<String^>(value);
         if ( strValue->Length > 5 )
                  throw gcnew ArgumentException( "value must be no more than 5 characters in length.","value" );
      }
   }

   virtual void OnRemove( Object^ key, Object^ /*value*/ ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }
   }

   virtual void OnSet( Object^ key, Object^ /*oldValue*/, Object^ newValue ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }

      if ( newValue->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "newValue must be of type String.","newValue" );
      else
      {
         String^ strValue = dynamic_cast<String^>(newValue);
         if ( strValue->Length > 5 )
                  throw gcnew ArgumentException( "newValue must be no more than 5 characters in length.","newValue" );
      }
   }

   virtual void OnValidate( Object^ key, Object^ value ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }

      if ( value->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "value must be of type String.","value" );
      else
      {
         String^ strValue = dynamic_cast<String^>(value);
         if ( strValue->Length > 5 )
                  throw gcnew ArgumentException( "value must be no more than 5 characters in length.","value" );
      }
   }

};

public ref class SamplesDictionaryBase
{
public:
   static void Main()
   {
        DictionaryBase^ myDictionary = gcnew ShortStringDictionary();

        // <Snippet2>
        for each (DictionaryEntry de in myDictionary)
        {
            //...
        }
        // </Snippet2>

        // <Snippet3>
        ICollection^ myCollection = gcnew ShortStringDictionary();
        bool lockTaken = false;
        try
        {
            Monitor::Enter(myCollection->SyncRoot, lockTaken);
            for each (Object^ item in myCollection);
            {
                // Insert your code here.
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor::Exit(myCollection->SyncRoot);
            }
        }
        // </Snippet3>
    }
};

int main()
{
    SamplesDictionaryBase::Main();
}
