using System;
using System.IO;
using System.Reflection;

namespace ca2002
{
    //<snippet1>
    class WeakIdentities
    {
        void LockOnWeakId1()
        {
            lock (typeof(WeakIdentities)) { }
        }

        void LockOnWeakId2()
        {
            MemoryStream stream = new();
            lock (stream) { }
        }

        void LockOnWeakId3()
        {
            lock ("string") { }
        }

        void LockOnWeakId4()
        {
            MemberInfo member = this.GetType().GetMember("LockOnWeakId1")[0];
            lock (member) { }
        }
        void LockOnWeakId5()
        {
            OutOfMemoryException outOfMemory = new();
            lock (outOfMemory) { }
        }
    }
    //</snippet1>
}
