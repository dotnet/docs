module binary1

// <Snippet1>
open System

let getBinaryString (value: byte) =
   let retValue = Convert.ToString(value, 2)
   String('0', 8 - retValue.Length) + retValue

let flags = [ true; false ]
for flag in flags do
      // Get binary representation of flag.
      let value = BitConverter.GetBytes(flag)[0];
      printfn $"Original value: {flag}"
      printfn $"Binary value:   {value} ({getBinaryString value})"
      // Restore the flag from its binary representation.
      let newFlag = BitConverter.ToBoolean([|value|], 0)
      printfn $"Restored value: {newFlag}\n"

// The example displays the following output:
//       Original value: True
//       Binary value:   1 (00000001)
//       Restored value: True
//
//       Original value: False
//       Binary value:   0 (00000000)
//       Restored value: False
// </Snippet1>