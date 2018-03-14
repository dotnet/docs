

#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Reflection;

//<Snippet1>
public ref class EnvironmentSample
{
public:
   static void Main()
   {
      
      //<Snippet2>
      OuterMethod();
      
      //</Snippet2>

      //<Snippet6>               
      Console::WriteLine( "Initial WS:{0}", Environment::WorkingSet );
      array<Int32>^i1;
      array<Int32>^i2;
      array<Int32>^i3;
      i1 = gcnew array<Int32>(10000);
      Console::WriteLine( "WS 1:{0}", Environment::WorkingSet );
      i2 = gcnew array<Int32>(10000);
      Console::WriteLine( "WS 2:{0}", Environment::WorkingSet );
      i3 = gcnew array<Int32>(10000);
      Console::WriteLine( "WS 3:{0}", Environment::WorkingSet );
      
      //</Snippet6>               
   }


   //<Snippet3>  
   static void OuterMethod()
   {
      InnerMethod();
   }

   static void InnerMethod()
   {
      Console::WriteLine( "StackTrace after calling Main()->OuterMethod()->InnerMethod():{0}", Environment::StackTrace );
   }

   //</Snippet3>  
};

int main()
{
   EnvironmentSample::Main();
}

//</Snippet1>
