// Entry point so the snippet project produces an executable and is verified by a build.
UnsafeEvolution.Relaxations.CreatePointer();
UnsafeEvolution.Relaxations.PinArray([1, 2, 3]);
UnsafeEvolution.Relaxations.AllocateOnStack();
System.Console.WriteLine(UnsafeEvolution.Relaxations.SizeOfStruct());
System.Console.WriteLine(UnsafeEvolution.Relaxations.ReadValue([10, 20, 30]));
