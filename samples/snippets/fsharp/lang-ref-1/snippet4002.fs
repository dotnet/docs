let rec Even x = if x = 0 then true else Odd(x - 1)
and Odd x = if x = 0 then false else Even(x - 1)
