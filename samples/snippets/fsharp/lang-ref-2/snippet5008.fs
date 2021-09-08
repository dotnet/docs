// A single-case partial active pattern can be parameterized
let (| Foo|_|) s x = if x = s then Some Foo else None
// A multi-case active patterns cannot be parameterized
// let (| Even|Odd|Special |) (s: int) (x: int) = if x = s then Special elif x % 2 = 0 then Even else Odd
