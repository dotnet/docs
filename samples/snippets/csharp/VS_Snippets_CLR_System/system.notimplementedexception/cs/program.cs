using System;

class Program
{
// <Snippet1>
static void Main(string[] args)
{
    try
    {
        FutureFeature();
    }
    catch (NotImplementedException notImp)
    {
        Console.WriteLine(notImp.Message);
    }
}

static void FutureFeature()
{
    // Not developed yet.
    throw new NotImplementedException();
}
//</Snippet1>
}
