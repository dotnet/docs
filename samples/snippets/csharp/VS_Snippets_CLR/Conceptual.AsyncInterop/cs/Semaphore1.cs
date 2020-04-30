using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
    // <Snippet13>
    static int N = 3;

    static SemaphoreSlim m_throttle = new SemaphoreSlim(N, N);

    static async Task DoOperation()
    {
        await m_throttle.WaitAsync();
        // do work
        m_throttle.Release();
    }
    // </Snippet13>
}
