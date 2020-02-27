// Place this code into a console project called ArgsEcho to build the argsecho.exe target

using namespace System;

int main(array<System::String ^> ^args)
{
    Console::WriteLine("Received the following arguments:\n");

    for (int i = 0; i < args->Length; i++)
    {
        Console::WriteLine("[" + i + "] = " + args[i]);
    }

    Console::WriteLine("\nPress any key to exit");
    Console::ReadLine();
    return 0;
}