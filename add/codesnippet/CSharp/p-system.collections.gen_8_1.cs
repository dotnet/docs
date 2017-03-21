        // Get the default comparer that 
        // sorts first by the height.
        Comparer<Box> defComp = Comparer<Box>.Default;

        // Calling Boxes.Sort() with no parameter
        // is the same as calling Boxs.Sort(defComp)
        // because they are both using the default comparer.
        Boxes.Sort();

        foreach (Box bx in Boxes)
        {
            Console.WriteLine("{0}\t{1}\t{2}",
                bx.Height.ToString(), bx.Length.ToString(), 
                bx.Width.ToString());
        }