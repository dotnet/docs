// CharEnumerator.Current.cpp : main project file.


using namespace System;

void Example1()
{
   // <Snippet1>
   String ^ title = "A Tale of Two Cities";
   CharEnumerator ^ chEnum = title->GetEnumerator();
   int ctr = 1;
   String ^ outputLine1 = nullptr;
   String ^ outputLine2 = nullptr;
   String ^ outputLine3 = nullptr; 

   while (chEnum->MoveNext())
   {
      outputLine1 += ctr < 10 || ctr % 10 != 0 ? "  " : (ctr / 10) + " ";
      outputLine2 += (ctr % 10) + " ";
      outputLine3 += chEnum->Current + " ";
      ctr++;
   }

   Console::WriteLine("The length of the string is {0} characters:", 
                     title->Length);
   Console::WriteLine(outputLine1);
   Console::WriteLine(outputLine2);    
   Console::WriteLine(outputLine3);
   // The example displays the following output to the console:      
   //       The length of the string is 20 characters:
   //                         1                   2
   //       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
   //       A   T a l e   o f   T w o   C i t i e s
   // </Snippet1>   
   Console::ReadLine();
}

void Example2()
{
   // <Snippet2>
   String ^ title = "A Tale of Two Cities";
   int ctr = 1;
   String ^ outputLine1 = nullptr;
   String ^ outputLine2 = nullptr;
   String ^ outputLine3 = nullptr; 

   for each (wchar_t ch in title)
   {
      outputLine1 += ctr < 10 || ctr % 10 != 0 ? "  " : (ctr / 10) + " ";
      outputLine2 += (ctr % 10) + " ";
      outputLine3 += ch + " ";
      ctr++;
   }

   Console::WriteLine("The length of the string is {0} characters:", 
                     title->Length);
   Console::WriteLine(outputLine1);
   Console::WriteLine(outputLine2);    
   Console::WriteLine(outputLine3);
   // The example displays the following output to the console:      
   //       The length of the string is 20 characters:
   //                         1                   2
   //       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
   //       A   T a l e   o f   T w o   C i t i e s
   // </Snippet2>
   Console::ReadLine();
}

void main()
{
   Example1();
   Console::WriteLine();
   Example2();
}

