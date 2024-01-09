module GetType1
// <Snippet2>
let values: obj[] = [| "word"; true; 120; 136.34; 'a' |]
for value in values do
   printfn $"{value} - type {value.GetType().Name}"

// The example displays the following output:
//       word - type String
//       True - type Boolean
//       120 - type Int32
//       136.34 - type Double
//       a - type Char
// </Snippet2>