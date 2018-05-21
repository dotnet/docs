    struct SampleStruct
    {
       public int x;
       public int y;

       public SampleStruct(int x, int y)
       {
          this.x = x;
          this.y = y;
       }
    }

    class SampleClass
    {
       public string name;
       public int id;

       public SampleClass() {}

       public SampleClass(int id, string name)
       {
          this.id = id;
          this.name = name;
       }
    }

    class ProgramClass
    {
       static void Main()
       {
          // Create objects using default constructors:
          SampleStruct Location1 = new SampleStruct();
          SampleClass Employee1 = new SampleClass();

          // Display values:
          Console.WriteLine("Default values:");
          Console.WriteLine("   Struct members: {0}, {1}",
                 Location1.x, Location1.y);
          Console.WriteLine("   Class members: {0}, {1}",
                 Employee1.name, Employee1.id);

          // Create objects using parameterized constructors:
          SampleStruct Location2 = new SampleStruct(10, 20);
          SampleClass Employee2 = new SampleClass(1234, "Cristina Potra");

          // Display values:
          Console.WriteLine("Assigned values:");
          Console.WriteLine("   Struct members: {0}, {1}",
                 Location2.x, Location2.y);
          Console.WriteLine("   Class members: {0}, {1}",
                 Employee2.name, Employee2.id);
       }
    }
    /*
    Output:
    Default values:
       Struct members: 0, 0
       Class members: , 0
    Assigned values:
       Struct members: 10, 20
       Class members: Cristina Potra, 1234
    */