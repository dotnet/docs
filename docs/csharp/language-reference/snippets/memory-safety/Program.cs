// Entry point so the snippet project produces an executable and is verified by a build.
MemorySafety.Relaxations.CreatePointer();
MemorySafety.Relaxations.PinArray([1, 2, 3]);
MemorySafety.Relaxations.AllocateOnStack();
System.Console.WriteLine(MemorySafety.Relaxations.SizeOfStruct());
System.Console.WriteLine(MemorySafety.Relaxations.ReadValue([10, 20, 30]));
System.Console.WriteLine(MemorySafety.Relaxations.Signature);
System.Console.WriteLine(await MemorySafety.Relaxations.ReadSignatureAsync());
