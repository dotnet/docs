
//<snippet1>
using namespace System;
using namespace System::IO;
void CombinePaths( String^ p1, String^ p2 )
{
   try
   {
      String^ combination = Path::Combine( p1, p2 );
      Console::WriteLine( "When you combine '{0}' and '{1}', the result is: {2}'{3}'", p1, p2, Environment::NewLine, combination );
   }
   catch ( Exception^ e ) 
   {
      if (p1 == nullptr)
         p1 = "nullptr";
      if (p2 == nullptr)
         p2 = "nullptr";
      Console::WriteLine( "You cannot combine '{0}' and '{1}' because: {2}{3}", p1, p2, Environment::NewLine, e->Message );
   }

   Console::WriteLine();
}

int main()
{
   String^ path1 = "c:\\temp";
   String^ path2 = "subdir\\file.txt";
   String^ path3 = "c:\\temp.txt";
   String^ path4 = "c:^*&)(_=@#'\\^&#2.*(.txt";
   String^ path5 = "";
   String^ path6 = nullptr;
   CombinePaths( path1, path2 );
   CombinePaths( path1, path3 );
   CombinePaths( path3, path2 );
   CombinePaths( path4, path2 );
   CombinePaths( path5, path2 );
   CombinePaths( path6, path2 );
}

//</snippet1>
