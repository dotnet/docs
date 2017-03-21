using namespace System;
using namespace System::Collections;
using namespace System::Security;
using namespace System::Security::Policy;
using namespace System::Security::Permissions;
using namespace System::Globalization;
public ref class Evidence_Example
{
public:
   bool CreateEvidence()
   {
      bool retVal = true;
      try
      {
         // Create empty evidence using the default contructor.
         Evidence^ ev1 = gcnew Evidence;
         Console::WriteLine( "Created empty evidence with the default constructor." );

         // Constructor used to create null host evidence.
         Evidence^ ev2a = gcnew Evidence( nullptr );
         Console::WriteLine( "Created an Evidence object with null host evidence." );

         // Constructor used to create host evidence.
         Url^ url = gcnew Url( "http://www.treyresearch.com" );
         Console::WriteLine( "Adding host evidence {0}", url );
         ev2a->AddHost( url );
         Evidence^ ev2b = gcnew Evidence( ev2a );
         Console::WriteLine( "Copy evidence into new evidence" );
         IEnumerator^ enum1 = ev2b->GetHostEnumerator();
         enum1->MoveNext();
         Console::WriteLine( enum1->Current );

         // Constructor used to create both host and assembly evidence.
         array<Object^>^oa1 = {};
         Site^ site = gcnew Site( "www.wideworldimporters.com" );
         array<Object^>^oa2 = {url,site};
         Evidence^ ev3a = gcnew Evidence( oa1,oa2 );
         enum1 = ev3a->GetHostEnumerator();
         IEnumerator^ enum2 = ev3a->GetAssemblyEnumerator();
         enum2->MoveNext();
         Object^ obj1 = enum2->Current;
         enum2->MoveNext();
         Console::WriteLine( "URL = {0}  Site = {1}", obj1, enum2->Current );
         
         // Constructor used to create null host and null assembly evidence.
         Evidence^ ev3b = gcnew Evidence( (array<Object^>^)nullptr, (array<Object^>^)nullptr );
         Console::WriteLine( "Create new evidence with null host and assembly evidence" );
      }
      catch ( Exception^ e )
      {
         Console::WriteLine( "Fatal error: {0}", e );
         return false;
      }

      return retVal;
   }

   Evidence^ DemonstrateEvidenceMembers()
   {
      Evidence^ myEvidence = gcnew Evidence;
      String^ sPubKeyBlob = "00240000048000009400000006020000"
      "00240000525341310004000001000100"
      "19390E945A40FB5730204A25FA5DC4DA"
      "B18688B412CB0EDB87A6EFC50E2796C9"
      "B41AD3040A7E46E4A02516C598678636"
      "44A0F74C39B7AB9C38C01F10AF4A5752"
      "BFBCDF7E6DD826676AD031E7BCE63393"
      "495BAD2CA4BE03B529A73C95E5B06BE7"
      "35CA0F622C63E8F54171BD73E4C8F193"
      "CB2664163719CA41F8159B8AC88F8CD3";
      array<Byte>^pubkey = HexsToArray( sPubKeyBlob );

      // Create a strong name.
      StrongName^ mSN = gcnew StrongName( gcnew StrongNamePublicKeyBlob( pubkey ),"SN01",gcnew Version( "0.0.0.0" ) );

      // Create assembly and host evidence.
      Console::WriteLine( "Adding assembly evidence." );
      myEvidence->AddAssembly( "SN01" );
      myEvidence->AddAssembly( gcnew Version( "0.0.0.0" ) );
      myEvidence->AddAssembly( mSN );
      Console::WriteLine( "Count of evidence items = {0}", myEvidence->Count );

      Url^ url = gcnew Url( "http://www.treyresearch.com" );
      Console::WriteLine( "Adding host evidence {0}", url );
      myEvidence->AddHost( url );
      PrintEvidence( myEvidence ).ToString();
      Console::WriteLine( "Count of evidence items = {0}", myEvidence->Count );

      Console::WriteLine( "\nCopy the evidence to an array using CopyTo, then display the array." );
      array<Object^>^evidenceArray = gcnew array<Object^>(myEvidence->Count);
      myEvidence->CopyTo( evidenceArray, 0 );
      for each (Object^ obj in evidenceArray)
      {
         Console::WriteLine(obj->ToString());
      }

      Console::WriteLine( "\nDisplay the contents of the properties." );
      Console::WriteLine( "Locked is the only property normally used by code." );
      Console::WriteLine( "IsReadOnly, IsSynchronized, and SyncRoot properties are not normally used." );
      
      Console::WriteLine( "\nThe default value for the Locked property = {0}", myEvidence->Locked );

      Console::WriteLine( "\nGet the hashcode for the evidence." );
      Console::WriteLine( "HashCode = {0}", myEvidence->GetHashCode() );

      Console::WriteLine( "\nGet the type for the evidence." );
      Console::WriteLine( "Type = {0}", myEvidence->GetType() );

      Console::WriteLine( "\nMerge new evidence with the current evidence." );
      array<Object^>^oa1 = {};
      Site^ site = gcnew Site( "www.wideworldimporters.com" );
      array<Object^>^oa2 = {url,site};
      Evidence^ newEvidence = gcnew Evidence( oa1,oa2 );
      myEvidence->Merge( newEvidence );
      Console::WriteLine( "Evidence count = {0}", PrintEvidence( myEvidence ) );

      Console::WriteLine( "\nRemove URL evidence." );
      myEvidence->RemoveType( url->GetType() );
      Console::WriteLine( "Evidence count is now: {0}", myEvidence->Count );

      Console::WriteLine( "\nMake a copy of the current evidence." );
      Evidence^ evidenceCopy = gcnew Evidence( myEvidence );
      Console::WriteLine( "Count of new evidence items = {0}", evidenceCopy->Count );
      Console::WriteLine( "Does the copy equal the current evidence? {0}", myEvidence->Equals( evidenceCopy ) );

      Console::WriteLine( "\nClear the current evidence." );
      myEvidence->Clear();
      Console::WriteLine( "Count is now {0}", myEvidence->Count );

      return myEvidence;
   }

   static int PrintEvidence( Evidence^ myEvidence )
   {
      int p = 0;
      Console::WriteLine( "\nCurrent evidence = " );
      if ( nullptr == myEvidence )
            return 0;

      IEnumerator^ list = myEvidence->GetEnumerator();
      IEnumerator^ myEnum1 = list;
      while ( myEnum1->MoveNext() )
      {
         Object^ obj = safe_cast<Object^>(myEnum1->Current);
         Console::WriteLine( obj );
         p++;
      }

      Console::WriteLine( "\n" );
      return p;
   }

   // Convert a hexadecimal string to an array.
   static array<Byte>^ HexsToArray( String^ sHexString )
   {
      array<Byte>^arr = gcnew array<Byte>(sHexString->Length / 2);
      for ( int i = 0; i < sHexString->Length; i += 2 )
      {
         arr[ i / 2 ] = Byte::Parse( sHexString->Substring( i, 2 ), NumberStyles::HexNumber );

      }
      return arr;
   }
};


// Main method.
int main()
{
   try
   {
      Evidence_Example^ EvidenceTest = gcnew Evidence_Example;
      bool ret = EvidenceTest->CreateEvidence();
      if ( ret )
      {
         Console::WriteLine( "Evidence successfully created." );
      }
      else
      {
         Console::WriteLine( "Evidence creation failed." );
      }
      EvidenceTest->DemonstrateEvidenceMembers();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
      Environment::ExitCode = 101;
   }
}