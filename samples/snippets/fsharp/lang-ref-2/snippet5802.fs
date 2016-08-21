let divide x y =
  if (y = 0) then raise (System.ArgumentException("Divisor cannot be zero!"))
  else
     x / y