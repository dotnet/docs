    // Demonstrate the use of the SizeOf method of the Marshal
    // class.
    Console::WriteLine("Number of bytes needed by a Point object: {0}",
        Marshal::SizeOf(Point::typeid));
    Point point;
    Console::WriteLine("Number of bytes needed by a Point object: {0}",
        Marshal::SizeOf(point));