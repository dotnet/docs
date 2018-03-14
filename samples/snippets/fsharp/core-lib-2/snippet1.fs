open System
open System.Collections.Generic

let seq1 = seq { for i in 1..10 -> i, i*i }
let dictionary1 = dict seq1
if dictionary1.IsReadOnly then
    Console.WriteLine("The dictionary is read only.")
// The type is a read only IDictionary.
// If you try to add or remove elements,
// NotSupportedException is generated, as in the following line:
//dictionary1.Add(new KeyValuePair<int, int>(0, 0))
// You can use read-only methods as in the following lines.
if dictionary1.ContainsKey(5) then
    Console.WriteLine("Value for key 5: {0}", dictionary1.Item(5))
for elem in dictionary1 do
   Console.WriteLine("Key: {0} Value: {1}", elem.Key, elem.Value)