
// You can pull a function out of a tuple and apply it. Both squareIt and num
// were defined previously.
let funAndArgTuple = (squareIt, num)

// The following expression applies squareIt to num, returns 100, and 
// then displays 100.
System.Console.WriteLine((fst funAndArgTuple)(snd funAndArgTuple))