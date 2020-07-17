public override String ToString()
{
    if (Length == 0)
        return String.Empty;

    string ret = string.FastAllocateString(Length);
    StringBuilder chunk = this;
    unsafe
    {
        fixed (char* destinationPtr = ret)
        {
            do
            {
                if (chunk.m_ChunkLength > 0)
                {
                    // Copy these into local variables so that they are stable even in the presence of ----s (hackers might do this)
                    char[] sourceArray = chunk.m_ChunkChars;
                    int chunkOffset = chunk.m_ChunkOffset;
                    int chunkLength = chunk.m_ChunkLength;

                    // Check that we will not overrun our boundaries.
                    if ((uint)(chunkLength + chunkOffset) <= ret.Length && (uint)chunkLength <= (uint)sourceArray.Length)
                    {
                        fixed (char* sourcePtr = sourceArray)
                            string.wstrcpy(destinationPtr + chunkOffset, sourcePtr, chunkLength);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("chunkLength", Environment.GetResourceString("ArgumentOutOfRange_Index"));
                    }
                }
                chunk = chunk.m_ChunkPrevious;
            } while (chunk != null);
        }
    }
    return ret;
}