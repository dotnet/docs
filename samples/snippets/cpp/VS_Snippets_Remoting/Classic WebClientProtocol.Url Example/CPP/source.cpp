using namespace System;

// Class added so sample will compile
public ref class myMath
{
public:
   String^ Url;
   int Add( int /*a*/, int /*b*/ )
   {
      return 0;
   }
};

// Structure added so sample will compile
public value struct myNum
{
public:
   String^ Text;
};

public ref class Sample
{
public:
   void sampleFunction()
   {
      myMath^ math = gcnew myMath;
      myNum Num1 = myNum(  );
      myNum Num2 = myNum(  );
      
      // <Snippet1>
      // Set the URL property to a different Web server than that described in the
      // service description.
      math->Url = "http://www.contoso.com/math.asmx";
      int total = math->Add( Convert::ToInt32( Num1.Text ), Convert::ToInt32( Num2.Text ) );
      // </Snippet1>
   }
};
