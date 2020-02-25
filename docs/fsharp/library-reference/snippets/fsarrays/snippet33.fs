
    let removeOutliers array1 min max =
        Array.partition (fun elem -> elem > min && elem < max) array1
        |> fst
    removeOutliers [| 1 .. 100 |] 50 60
    |> printf "%A"