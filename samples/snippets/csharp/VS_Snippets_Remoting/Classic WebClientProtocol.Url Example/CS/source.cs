using System;

public class Sample {

    public void sampleFunction() {
        myMath math = new myMath();
        myNum Num1 = new myNum();
        myNum Num2 = new myNum();
// <Snippet1>
// Set the URL property to a different Web server than that described in the
// service description.
math.Url = "http://www.contoso.com/math.asmx";
int total = math.Add(Convert.ToInt32(Num1.Text), Convert.ToInt32(Num2.Text));

// </Snippet1>

    }
}

// Class added so sample will compile
public class myMath {
    public string Url;
    public int Add(int a, int b) {
        return 0;
    }
}

// Structure added so sample will compile
public struct myNum {
    public string Text;
}
