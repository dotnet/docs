namespace MyNamespace;

public class MyType
{
    /// <returns>This is the returns text of MyMethod. It comes from triple slash comments.</returns>
    /// <remarks>This is the remarks text of MyMethod. It comes from triple slash comments.</remarks>
    /// <include file="MyAssembly.xml" path="doc/members/member[@name='M:MyNamespace.MyType.MyMethod']/*" />
    public int MyMethod(int p) => p;
}
