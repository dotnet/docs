//<Snippet1>
// friend_signed_A.cs
// Compile with: 
// csc /target:library /keyfile:FriendAssemblies.snk friend_signed_A.cs
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("friend_signed_B, PublicKey=0024000004800000940000000602000000240000525341310004000001000100e3aedce99b7e10823920206f8e46cd5558b4ec7345bd1a5b201ffe71660625dcb8f9a08687d881c8f65a0dcf042f81475d2e88f3e3e273c8311ee40f952db306c02fbfc5d8bc6ee1e924e6ec8fe8c01932e0648a0d3e5695134af3bb7fab370d3012d083fa6b83179dd3d031053f72fc1f7da8459140b0af5afc4d2804deccb6")]
class Class1
{
    public void Test()
    {
        System.Console.WriteLine("Class1.Test");
        System.Console.ReadLine();
    }
}
//</Snippet1>
