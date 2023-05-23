// <GlobalUsing>
global using System.Text;
// </GlobalUsing>

// <UsingStatic>
using static System.Console;
// </UsingStatic>

// <UsingUnsafeStatic>
using static unsafe UnsafeExamples.UnsafeType;
// </UsingUnsafeStatic>

// <UsingAlias>
using JSON = System.Text.Json;
using ValueMap = System.Collections.Generic.Dictionary<string, decimal>;
using TimedData = (System.DateTime timeRecorded, decimal value);
// </UsingAlias>

Console.WriteLine("Using directives");


