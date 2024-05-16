seq {
    for i in 1..10 do
        yield i * i
}

// The 'yield' is implicit and doesn't need to be specified in most cases.
seq {
    for i in 1..10 do
        i * i
}
