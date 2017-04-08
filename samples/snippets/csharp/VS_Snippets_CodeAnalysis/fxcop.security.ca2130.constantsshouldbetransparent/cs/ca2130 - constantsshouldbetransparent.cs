//<Snippet1>
using System;
using System.Security;

//[assembly: SecurityRules(SecurityRuleSet.Level2)]
//[assembly: AllowPartiallyTrustedCallers]

namespace TransparencyWarningsDemo
{

    public enum EnumWithCriticalValues
    {
        TransparentEnumValue,

        // CA2130 violation
        [SecurityCritical]
        CriticalEnumValue
    }

    public class ClassWithCriticalConstant
    {
        // CA2130 violation
        [SecurityCritical]
        public const int CriticalConstant = 21;
    }
}

//</Snippet1>