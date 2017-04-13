using System;

public class Sample {

    public void sampleFunction() {
        myMath math = new myMath();
// <Snippet1>
math.Timeout = 15000;

// </Snippet1>
    }
}

// Struct added so sample will compile
public struct myMath {
    public int Timeout;
}
