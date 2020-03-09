//let sqrList = [ for i in 1..10 -> i*i ]
// Adding a type annotation fixes the problem:
let sqrList : int list = [ for i in 1..10 -> i*i ]