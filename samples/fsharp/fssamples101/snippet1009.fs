
    let show a b = 
        printfn "%A < %A: %b" a b (a < b)
        printfn "%A = %A: %b" a b (a = b)
        printfn "%A > %A: %b" a b (a > b)
    
    show 1 2;
    show 2 2;
    show "1" "2"
    show "abb" "abc" 
    show "aBc" "ABB" // case-sensitive
    show None (Some 1);
    show None None;
    show (Some 0) (Some 1);
    show (Some 1) (Some 1);
    show [1;2;3] [1;2;2];
    show [] [1;2;2]