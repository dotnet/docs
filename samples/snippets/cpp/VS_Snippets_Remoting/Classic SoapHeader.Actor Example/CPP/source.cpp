

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Protocols;

// Following was added to make the sample compile.  
public ref class MyHeader: public SoapHeader
{
public:
   String^ MyValue;
};

public ref class MyWebService
{
public:
   MyHeader^ myHeader;
   int MyWebMethod( int num1, int num2 )
   {
      return num1 + num2;
   }

};


// <Snippet1>
int main()
{
   MyWebService^ ws = gcnew MyWebService;
   try
   {
      MyHeader^ customHeader = gcnew MyHeader;
      customHeader->MyValue = "Header Value for MyValue";
      customHeader->Actor = "http://www.contoso.com/MySoapHeaderHandler";
      ws->myHeader = customHeader;
      int results = ws->MyWebMethod( 3, 5 );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e );
   }

}

// </Snippet1>
