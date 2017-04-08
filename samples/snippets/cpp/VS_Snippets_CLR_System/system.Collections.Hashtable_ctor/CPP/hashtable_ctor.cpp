
// The following code example creates hash tables using different Hashtable constructors
// and demonstrates the differences in the behavior of the hash tables,
// even if each one contains the same elements.
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Globalization;

ref class myComparer : IEqualityComparer
{
public:
    virtual bool Equals(Object^ x, Object^ y) 
    {
        return x->Equals(y);
    }

    virtual int GetHashCode(Object^ obj)
    {
        return obj->ToString()->ToLower()->GetHashCode();
    }
};

// <Snippet2>
ref class myCultureComparer : IEqualityComparer
{
private:
    CaseInsensitiveComparer^ myComparer;

public:
    myCultureComparer()
    {
        myComparer = CaseInsensitiveComparer::DefaultInvariant;
    }

    myCultureComparer(CultureInfo^ myCulture)
    {
        myComparer = gcnew CaseInsensitiveComparer(myCulture);
    }

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

    virtual int GetHashCode(Object^ obj)
    {
        return obj->ToString()->ToLower()->GetHashCode();
    }
};
// </Snippet2>

int main()
{
   
   // Create a hash table using the default hash code provider and the default comparer.
   Hashtable^ myHT1 = gcnew Hashtable((IEqualityComparer^)nullptr);
   myHT1->Add( "FIRST", "Hello" );
   myHT1->Add( "SECOND", "World" );
   myHT1->Add( "THIRD", "!" );
   
   // Create a hash table using the specified IEqualityComparer that uses
   // the default Object.Equals to determine equality.
   Hashtable^ myHT2 = gcnew Hashtable(gcnew myComparer());
   myHT2->Add( "FIRST", "Hello" );
   myHT2->Add( "SECOND", "World" );
   myHT2->Add( "THIRD", "!" );
   
   // Create a hash table using a case-insensitive hash code provider and
   // case-insensitive comparer based on the InvariantCulture.
   Hashtable^ myHT3 = gcnew Hashtable(
            CaseInsensitiveHashCodeProvider::DefaultInvariant,
            CaseInsensitiveComparer::DefaultInvariant);
   myHT3->Add( "FIRST", "Hello" );
   myHT3->Add( "SECOND", "World" );
   myHT3->Add( "THIRD", "!" );
   
   // Create a hash table using an IEqualityComparer that is based on
   // the Turkish culture (tr-TR) where "I" is not the uppercase
   // version of "i".
   CultureInfo^ myCul = gcnew CultureInfo("tr-TR");
   Hashtable^ myHT4 = gcnew Hashtable( gcnew myCultureComparer(myCul) );
   myHT4->Add( "FIRST", "Hello" );
   myHT4->Add( "SECOND", "World" );
   myHT4->Add( "THIRD", "!" );
   
   // Search for a key in each hash table.
   Console::WriteLine( "first is in myHT1: {0}", myHT1->ContainsKey( "first" ) );
   Console::WriteLine( "first is in myHT2: {0}", myHT2->ContainsKey( "first" ) );
   Console::WriteLine( "first is in myHT3: {0}", myHT3->ContainsKey( "first" ) );
   Console::WriteLine( "first is in myHT4: {0}", myHT4->ContainsKey( "first" ) );
}

/* 
This code produces the following output.  Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: False
first is in myHT3: True
first is in myHT4: False

*/
// </Snippet1>
