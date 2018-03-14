static member SomeStaticMethod(a, b, c) =
   (a + b + c)

static member SomeOtherStaticMethod(a, b, c) =
   SomeType.SomeStaticMethod(a, b, c) * 100