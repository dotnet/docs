using namespace System;
using namespace System::Threading;

int main()
{
//<Snippet1>
        Array^ myArray = gcnew array<Int32> { 1, 2, 4 };
        try
        {
            Monitor::Enter(myArray->SyncRoot); 
                
            for each (Int32 item in myArray)
                Console::WriteLine(item);
        }
        finally
        {
            Monitor::Exit(myArray->SyncRoot);
        }
//</Snippet1>

   return 1;
}