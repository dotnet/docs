using System;
using System.Runtime.InteropServices;

namespace ca2243
{
    //<snippet1>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public sealed class AssemblyFileVersionAttribute : Attribute
    {
        public AssemblyFileVersionAttribute(string version) { }

        public string Version { get; set; }
    }

    // Since the parameter is typed as a string, it is possible
    // to pass an invalid version number at compile time. The rule
    // would be violated by the following code: [assembly : AssemblyFileVersion("xxxxx")]
    //</snippet1>
}
