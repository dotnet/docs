
// The following code example creates hash tables using different Hashtable constructors
// and demonstrates the differences in the behavior of the hash tables,
// even if each one contains the same elements.
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Globalization;

ref class myCultureComparer : public IEqualityComparer
{
public:
    CaseInsensitiveComparer^ myComparer;

public:
    myCultureComparer()
    {
        myComparer = CaseInsensitiveComparer::DefaultInvariant;
    }

public:
    myCultureComparer(CultureInfo^ myCulture)
    {
        myComparer = gcnew CaseInsensitiveComparer(myCulture);
    }

public:
    virtual bool Equals(Object^ x, Object^ y)
    {
        if (myComparer->Compare(x, y) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

public:
    virtual int GetHashCode(Object^ obj)
    {
        // Compare the hash code for the lowercase versions of the strings.
        return obj->ToString()->ToLower()->GetHashCode();
    }
};

public ref class SamplesHashtable
{

public:
	static void Main()
	{
	   
	   // Create the dictionary.
	   SortedList^ mySL = gcnew SortedList;
	   mySL->Add( "FIRST", "Hello" );
	   mySL->Add( "SECOND", "World" );
	   mySL->Add( "THIRD", "!" );
	   
	   // Create a hash table using the default hash code provider and the default comparer.
	   Hashtable^ myHT1 = gcnew Hashtable( mySL,(float).8 );
	   
	   // Create a hash table using the specified case-insensitive hash code provider and case-insensitive comparer.
	   Hashtable^ myHT2 = gcnew Hashtable( mySL,(float).8,gcnew myCultureComparer() );
	   
	   // Create a hash table using the specified KeyComparer.
	   // The KeyComparer uses a case-insensitive hash code provider and a case-insensitive comparer,
	   // which are based on the Turkish culture (tr-TR), where "I" is not the uppercase version of "i".
	   CultureInfo^ myCul = gcnew CultureInfo( "tr-TR" );
	   Hashtable^ myHT3 = gcnew Hashtable( mySL,(float).8, gcnew myCultureComparer( myCul ) );
	   
	   // Search for a key in each hash table.
	   Console::WriteLine( "first is in myHT1: {0}", myHT1->ContainsKey( "first" ) );
	   Console::WriteLine( "first is in myHT2: {0}", myHT2->ContainsKey( "first" ) );
	   Console::WriteLine( "first is in myHT3: {0}", myHT3->ContainsKey( "first" ) );
	}
};

int main()
{
	SamplesHashtable::Main();
}

/* 
This code produces the following output.  Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: True
first is in myHT3: False

*/
// </Snippet1>
