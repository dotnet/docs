// Per Kitg, from cut QuickStart (vswhidbey 160832)
//<Snippet1>
using System;
using System.Reflection;

[assembly:AssemblyKeyFileAttribute("TestPublicKey.snk")]
[assembly:AssemblyDelaySignAttribute(true)]

namespace DelaySign
{
	public class Test { }
}
//</Snippet1>