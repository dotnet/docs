//<Snippet1>
using System;
using System.Security;
using System.Collections.Generic;

namespace TransparencyWarningsDemo
{

    [SecurityCritical]
    public class SecurityCriticalClass { }

    public class TransparentMethodsReferenceCriticalCodeClass
    {
        [SecurityCritical]
        private object m_criticalField;

        [SecurityCritical]
        private void CriticalMethod() { }

        public void TransparentMethod()
        {
            // CA2140 violation - transparent method accessing a critical type.  This can be fixed by any of:
            //  1. Make TransparentMethod critical
            //  2. Make TransparentMethod safe critical
            //  3. Make CriticalClass safe critical
            //  4. Make CriticalClass transparent
            List<SecurityCriticalClass> l = new List<SecurityCriticalClass>();

            // CA2140 violation - transparent method accessing a critical field.  This can be fixed by any of:
            //  1. Make TransparentMethod critical
            //  2. Make TransparentMethod safe critical
            //  3. Make m_criticalField safe critical
            //  4. Make m_criticalField transparent
            m_criticalField = l;

            // CA2140 violation - transparent method accessing a critical method.  This can be fixed by any of:
            //  1. Make TransparentMethod critical
            //  2. Make TransparentMethod safe critical
            //  3. Make CriticalMethod safe critical
            //  4. Make CriticalMethod transparent
            CriticalMethod();
        }
    }
}

//</Snippet1>