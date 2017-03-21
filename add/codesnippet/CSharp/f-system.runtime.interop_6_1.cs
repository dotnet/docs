    [DllImport("My.dll", CharSet=CharSet.Ansi,
                   BestFitMapping=false,
                   ThrowOnUnmappableChar=true)]
    static extern int SomeFuncion2(int parm);