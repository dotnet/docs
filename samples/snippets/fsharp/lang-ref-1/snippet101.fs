let list1 = [ 1; 2; 3]
// Error: duplicate definition.
let list1 = []
let function1 () =
   let list1 = [1; 2; 3]
   let list1 = []
   list1
