// Per Kitg, from cut QuickStart (vswhidbey 160832)
//<Snippet1>
using namespace System;
using namespace System::Reflection;

[assembly:AssemblyKeyFileAttribute("TestPublicKey.snk")];
[assembly:AssemblyDelaySignAttribute(true)];

namespace DelaySign
{
    public ref class Test { };
}
//</Snippet1>