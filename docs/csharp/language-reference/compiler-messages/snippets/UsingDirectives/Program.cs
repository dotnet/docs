// <GlobalUsing>
global using System.Text;
// </GlobalUsing>

// <UsingAlias>
using JSON = System.Text.Json;
using ValueMap = System.Collections.Generic.Dictionary<string, decimal>;
using TimedData = (System.DateTime timeRecorded, decimal value);
// </UsingAlias>

// <UsingStatic>
using static System.Console;
// </UsingStatic>

// <UsingUnsafeStatic>
using static unsafe UnsafeExamples.UnsafeType;
// </UsingUnsafeStatic>

//using NullableString = System.String?;
using NullableInt = System.Int32?;

namespace UnsafeExamples;
unsafe static class UnsafeType
{
    public static int* field;

}


