
 // This class has a primary constructor that takes three arguments
 // and an additional constructor that calls the primary constructor.
 type MyClass(x0, y0, z0) =
     let mutable x = x0
     let mutable y = y0
     let mutable z = z0
     do
         printfn "Initialized object that has coordinates (%d, %d, %d)" x y z
     member this.X with get() = x and set(value) = x <- value
     member this.Y with get() = y and set(value) = y <- value
     member this.Z with get() = z and set(value) = z <- value
     new() = MyClass(0, 0, 0)

 // Create by using the new keyword.
 let myObject1 = new MyClass(1, 2, 3)
 // Create without using the new keyword.
 let myObject2 = MyClass(4, 5, 6)
 // Create by using named arguments.
 let myObject3 = MyClass(x0 = 7, y0 = 8, z0 = 9)
 // Create by using the additional constructor.
 let myObject4 = MyClass()