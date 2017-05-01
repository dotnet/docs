using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;

namespace SequenceExamples
{
    static class IGrouping
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\n");
            //GroupKey();
            EnumerateGroup();
        }

        private static void EnumerateGroup()
        {
            // <Snippet1>
            // Get an IGrouping object.
            IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType).
                First();

            // Output the key of the IGrouping, then iterate
            // through each value in the sequence of values
            // of the IGrouping and output its Name property.
            Console.WriteLine("\nValues that have the key '{0}':", group.Key);
            foreach (System.Reflection.MemberInfo mi in group)
                Console.WriteLine(mi.Name);

            // The output is similar to:

            // Values that have the key 'Method':
            // get_Chars
            // get_Length
            // IndexOf
            // IndexOfAny
            // LastIndexOf
            // LastIndexOfAny
            // Insert
            // Replace
            // Replace
            // Remove
            // Join
            // Join
            // Equals
            // Equals
            // Equals
            // ...

            // </Snippet1>
        }

        private static void GroupKey()
        {
            // <Snippet2>
            // Get a sequence of IGrouping objects.
            IEnumerable<IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo>> memberQuery =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType);

            // Output the key of each IGrouping object and the count of values.
            foreach (IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group in memberQuery)
                Console.WriteLine("(Key) {0} (Member count) {1}", group.Key, group.Count());

            // The output is similar to:
            // (Key) Method (Member count) 113
            // (Key) Constructor (Member count) 8
            // (Key) Property (Member count) 2
            // (Key) Field (Member count) 1

            // </Snippet2>
        }

        private static void Test()
        {
            IOrderedEnumerable<IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo>> memberQuery =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType).
                OrderBy(group => group.Count());

            foreach (IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group in memberQuery)
            {
                Console.WriteLine("\n(Key) {0}", group.Key);
                foreach (System.Reflection.MemberInfo mi in group)
                    Console.WriteLine(mi.Name);
            }
        }
    }
}
