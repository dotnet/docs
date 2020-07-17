using namespace System;

// Struct added so sample will compile
public value struct myMath
{
public:
   int Timeout;
};

public ref class Sample
{
public:
   void sampleFunction()
   {
      myMath math = myMath(  );
      
      // <Snippet1>
      math.Timeout = 15000;
      // </Snippet1>
   }
};
