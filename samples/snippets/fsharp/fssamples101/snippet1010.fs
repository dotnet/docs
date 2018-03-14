let show a = printfn "hash(%A) : %d" a (hash a)
show 1;
show 2;
show "1"
show "2"
show "abb"
show "aBc" // case-sensitive
show None;
show (Some 1);
show (Some 0);
show [1;2;3];
show [1;2;3;4;5;6;7;8];
show [1;2;3;4;5;6;7;8;9;10;11];
show [1;2;3;4;5;6;7;8;9;10;11;12;13;14;15]