
// <UsingAliasQualifier>
using S = System.Net.Sockets;

class A
{
    public static int x;
}

class C
{
    public void F(int A, object S)
    {
        // Use global::A.x instead of A.x
        global::A.x += A;

        // Using ::, S must resolve to a namespace alias:
        S::Socket s = S as S::Socket;

        // In this form, if S were a class, it would be a compile-time error:
        S.Socket s1 = S as S.Socket;
    }
}
// </UsingAliasQualifier>
