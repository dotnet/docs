        // Call the Paint methods from Main.

        SampleClass obj = new SampleClass();
        //obj.Paint();  // Compiler error.

        IControl c = obj;
        c.Paint();  // Calls IControl.Paint on SampleClass.

        ISurface s = obj;
        s.Paint(); // Calls ISurface.Paint on SampleClass.

        // Output:
        // IControl.Paint
        // ISurface.Paint
