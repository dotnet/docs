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
