
// The following code example implements the ReadOnlyCollectionBase class.
using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class ROCollection: public ReadOnlyCollectionBase
{
public:
   ROCollection( IList^ sourceList )
   {
      InnerList->AddRange( sourceList );
   }

   property Object^ Item [int]
   {
      Object^ get( int index )
      {
         return (InnerList[ index ]);
      }

   }
   int IndexOf( Object^ value )
   {
      return (InnerList->IndexOf( value ));
   }

   bool Contains( Object^ value )
   {
      return (InnerList->Contains( value ));
   }

};

public ref class SamplesCollectionBase
{
public:
    static void Main()
    {

        // Create an ArrayList.
        ArrayList^ myAL = gcnew ArrayList();
        myAL->Add( "red" );
        myAL->Add( "blue" );
        myAL->Add( "yellow" );
        myAL->Add( "green" );
        myAL->Add( "orange" );
        myAL->Add( "purple" );

        // Create a new ROCollection that contains the elements in myAL.
        ROCollection^ myReadOnlyCollection = gcnew ROCollection( myAL );

        // <Snippet2>
        // Get the ICollection interface from the ReadOnlyCollectionBase
        // derived class.
        ICollection^ myCollection = myReadOnlyCollection;
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
