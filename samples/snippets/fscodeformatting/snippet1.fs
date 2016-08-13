
let printList list1 =
    for elem in list1 do
        if elem > 0 then
            printf "%d" elem
        elif elem = 0 then
            printf "Zero"
        else
            printf "(Negative number)"
        printf " "
    printfn "Done!"
printfn "Top-level context."
printList [-1;0;1;2;3]