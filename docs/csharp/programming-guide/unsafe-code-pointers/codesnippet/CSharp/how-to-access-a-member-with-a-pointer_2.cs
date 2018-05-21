struct CoOrds
{
    public int x;
    public int y;
}

class AccessMembers
{
    static void Main() 
    {
        CoOrds home;

        unsafe 
        {
            CoOrds* p = &home;
            p->x = 25;
            p->y = 12;

            System.Console.WriteLine("The coordinates are: x={0}, y={1}", p->x, p->y );
        }
    }
}