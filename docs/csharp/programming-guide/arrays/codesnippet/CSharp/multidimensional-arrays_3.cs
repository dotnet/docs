        // Two-dimensional array.
        int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        // The same array with dimensions specified.
        int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        // A similar array with string elements.
        string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                                { "five", "six" } };

        // Three-dimensional array.
        int[, ,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, 
                                         { { 7, 8, 9 }, { 10, 11, 12 } } };
        // The same array with dimensions specified.
        int[, ,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } }, 
                                               { { 7, 8, 9 }, { 10, 11, 12 } } };

        // Accessing array elements.
        System.Console.WriteLine(array2D[0, 0]);
        System.Console.WriteLine(array2D[0, 1]);
        System.Console.WriteLine(array2D[1, 0]);
        System.Console.WriteLine(array2D[1, 1]);
        System.Console.WriteLine(array2D[3, 0]);
        System.Console.WriteLine(array2Db[1, 0]);
        System.Console.WriteLine(array3Da[1, 0, 1]);
        System.Console.WriteLine(array3D[1, 1, 2]);

        // Getting the total count of elements or the length of a given dimension.
        var allLength = array3D.Length;
        var total = 1;
        for (int i = 0; i < array3D.Rank; i++) {
            total *= array3D.GetLength(i);
        }
        System.Console.WriteLine("{0} equals {1}", allLength, total);

        // Output:
        // 1
        // 2
        // 3
        // 4
        // 7
        // three
        // 8
        // 12
        // 12 equals 12