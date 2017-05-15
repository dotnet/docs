using System;
using System.Reflection;

public class Sample {

    public void Method(Type t, MemberInfo mi) {
        
// <Snippet1>
MemberInfo[] others = t.GetMember(mi.Name, mi.MemberType, BindingFlags.Public |
BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
// </Snippet1>

    }
}
