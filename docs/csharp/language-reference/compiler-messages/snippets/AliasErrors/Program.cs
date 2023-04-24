// See https://aka.ms/new-console-template for more information

using unsafe IntPointer = int*;
using static unsafe UnsafeExamples.UnsafeType;
// using unsafe UnsafeExamples; // not allowed


//using NullableString = System.String?;
using NullableInt = System.Int32?;

namespace UnsafeExamples;
unsafe static class UnsafeType
{
    public static int* field;
}
