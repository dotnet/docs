//<Snippet1>
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ReliabilityLibrary
{
   class WeakIdentities
   {
      void LockOnWeakId1()
      { 
         lock(typeof(WeakIdentities)) {}
      }

      void LockOnWeakId2() 
      {
         MemoryStream stream = new MemoryStream();
         lock(stream) {} 
      }

      void LockOnWeakId3() 
      { 
         lock("string") {} 
      }

      void LockOnWeakId4() 
      { 
         MemberInfo member = this.GetType().GetMember("LockOnWeakId1")[0];
         lock(member) {} 
      }
      void LockOnWeakId5()
      {
         OutOfMemoryException outOfMemory = new OutOfMemoryException();
         lock(outOfMemory) {}
      }
   }
}
//</Snippet1>
