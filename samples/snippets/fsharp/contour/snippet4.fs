let rec factorial n =
    if n = 0
    then 1
    else n * factorial (n - 1)
System.Console.WriteLine(factorial anInt)