
    let array1 = Array.create 10 ""
    for i in 0 .. array1.Length - 1 do
        Array.set array1 i (i.ToString())
    for i in 0 .. array1.Length - 1 do
        printf "%s " (Array.get array1 i)