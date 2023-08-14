let (height, width) = (10, 10)

seq {
    for row in 0 .. width - 1 do
        for col in 0 .. height - 1 -> (row, col, row * width + col)
}
