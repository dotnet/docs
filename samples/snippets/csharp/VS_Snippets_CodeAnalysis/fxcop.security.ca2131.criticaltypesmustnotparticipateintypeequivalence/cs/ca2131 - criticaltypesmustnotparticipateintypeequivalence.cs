//<Snippet1>
using System;
using System.Security;
using System.Runtime.InteropServices;

[assembly: SecurityRules(SecurityRuleSet.Level2)]
[assembly: AllowPartiallyTrustedCallers]

namespace TransparencyWarningsDemo
{

    // CA2131 error - critical type participating in equivilance
    [SecurityCritical]
    [TypeIdentifier("3a5b6203-2bf1-4f83-b5b4-1bdc334ad3ea", "ICriticalEquivilentInterface")]
    public interface ICriticalEquivilentInterface
    {
        void Method1();
    }

    [TypeIdentifier("3a5b6203-2bf1-4f83-b5b4-1bdc334ad3ea", "ITransparentEquivilentInterface")]
    public interface ITransparentEquivilentInterface
    {
        // CA2131 error - critical method in a type participating in equivilance
        [SecurityCritical]
        void CriticalMethod();
    }

    [SecurityCritical]
    [TypeIdentifier("3a5b6203-2bf1-4f83-b5b4-1bdc334ad3ea", "ICriticalEquivilentInterface")]
    public struct EquivilentStruct
    {
        // CA2131 error - critical field in a type participating in equivalence
        [SecurityCritical]
        public int CriticalField;
    }
}

//</Snippet1>