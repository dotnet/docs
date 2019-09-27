/*
 * 
 * WE PROBABLY DON'T NEED TO MIGRATE THESE TO CODE
 * PROBABLY BETTER THEY DON'T COMPILE AS IS
*/

#if NEVER
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipes
{
    class DoNotUse
    {
        private void dummy1()
        {
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> dataLossBuffer = result.Buffer;

                if (result.IsCompleted)
                {
                    break;
                }

                Process(ref dataLossBuffer, out Message message);

                reader.AdvanceTo(dataLossBuffer.Start, dataLossBuffer.End);
            }
        }
    }
}

#endif