
        // This explicit interface implementation
        // compares first by the length.
        // Returns -1 because the length of BoxA
        // is less than the length of BoxB.
        BoxLengthFirst LengthFirst = new BoxLengthFirst(); 

        Comparer<Box> bc = (Comparer<Box>) LengthFirst;

        Box BoxA = new Box(2, 6, 8);
        Box BoxB = new Box(10, 12, 14);
        int x = LengthFirst.Compare(BoxA, BoxB);
        Console.WriteLine();
        Console.WriteLine(x.ToString());