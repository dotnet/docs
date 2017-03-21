using System;
using System.Reflection;

[assembly:AssemblyKeyFileAttribute("TestPublicKey.snk")]
[assembly:AssemblyDelaySignAttribute(true)]

namespace DelaySign
{
	public class Test { }
}