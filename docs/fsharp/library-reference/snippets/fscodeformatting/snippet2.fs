
let myFunction1 a b = a + b
let myFunction2(a, b) = a + b
let someFunction param1 param2 =
    let result = myFunction1 param1
                     param2
    result * 100
let someOtherFunction param1 param2 =
    let result = myFunction2(param1,
                     param2)
    result * 100