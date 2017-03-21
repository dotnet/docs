    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    void StackDepth2()
    {
        try
        {
            consistentLevel2 = false;
            if (depth == 2)
                Thread.Sleep(-1);
            StackDepth3();
        }
        finally
        {
            consistentLevel2 = true;
        }
    }