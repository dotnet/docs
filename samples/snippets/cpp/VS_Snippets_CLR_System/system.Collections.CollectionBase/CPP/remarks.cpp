

// The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class Int16Collection: public CollectionBase
{
public:

   property Int16 Item [int]
   {
      Int16 get( int index )
      {
         return ( (Int16)(List[ index ]));
      }

      void set( int index, Int16 value )
      {
         List[ index ] = value;
      }
   }
   int Add( Int16 value )
   {
      return (List->Add( value ));
   }

   int IndexOf( Int16 value )
   {
      return (List->IndexOf( value ));
   }

   void Insert( int index, Int16 value )
   {
      List->Insert( index, value );
   }

   void Remove( Int16 value )
   {
      List->Remove( value );
   }

   bool Contains( Int16 value )
   {
      // If value is not of type Int16, this will return false.
      return (List->Contains( value ));
   }

protected:
   virtual void OnInsert( int /*index*/, Object^ /*value*/ ) override
   {
      // Insert additional code to be run only when inserting values.
   }

   virtual void OnRemove( int /*index*/, Object^ /*value*/ ) override
   {
      // Insert additional code to be run only when removing values.
   }

   virtual void OnSet( int /*index*/, Object^ /*oldValue*/, Object^ /*newValue*/ ) override
   {
      // Insert additional code to be run only when setting values.
   }

   virtual void OnValidate( Object^ value ) override
   {
      if ( value->GetType() != Type::GetType( "System.Int16" ) )
            throw gcnew ArgumentException( "value must be of type Int16.","value" );
   }

};

public ref class SamplesCollectionBase
{
public:
    static void Main()
    {
        // Create and initialize a new CollectionBase.
        Int16Collection^ myCollectionBase = gcnew Int16Collection();

        // Add elements to the collection.
        myCollectionBase->Add( (Int16) 1 );
        myCollectionBase->Add( (Int16) 2 );
        myCollectionBase->Add( (Int16) 3 );
        myCollectionBase->Add( (Int16) 5 );
        myCollectionBase->Add( (Int16) 7 );

        // <Snippet2>
        // Get the ICollection interface from the CollectionBase
        // derived class.
        ICollection^ myCollection = myCollectionBase;
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
        // </Snippet2>
    }
};

int main()
{
    SamplesCollectionBase::Main();
}
