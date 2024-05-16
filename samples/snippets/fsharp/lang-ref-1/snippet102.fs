let list1 = [ 1; 2; 3 ]

let sumPlus x =
    // OK: inner list1 hides the outer list1.
    let list1 = [ 1; 5; 10 ]
    x + List.sum list1
