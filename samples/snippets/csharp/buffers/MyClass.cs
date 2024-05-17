using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Text;

namespace MyBuffers
{
    class MyClass
    {
        #region snippet
        void WriteHello(IBufferWriter<byte> writer)
        {
            // Request at least 5 bytes.
            Span<byte> span = writer.GetSpan(5);
            ReadOnlySpan<char> helloSpan = "Hello".AsSpan();
            int written = Encoding.ASCII.GetBytes(helloSpan, span);

            // Tell the writer how many bytes were written.
            writer.Advance(written);
        }
        #endregion

        #region snippet3
        long FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
        {
            long position = 0;

            foreach (ReadOnlyMemory<byte> segment in buffer)
            {
                ReadOnlySpan<byte> span = segment.Span;
                var index = span.IndexOf(data);
                if (index != -1)
                {
                    return position + index;
                }

                position += span.Length;
            }

            return -1;
        }
        #endregion

        #region snippet5
        bool TryParseHeaderLength(ref ReadOnlySequence<byte> buffer, out int length)
        {
            // If there's not enough space, the length can't be obtained.
            if (buffer.Length < 4)
            {
                length = 0;
                return false;
            }

            // Grab the first 4 bytes of the buffer.
            var lengthSlice = buffer.Slice(buffer.Start, 4);
            if (lengthSlice.IsSingleSegment)
            {
                // Fast path since it's a single segment.
                length = BinaryPrimitives.ReadInt32BigEndian(lengthSlice.First.Span);
            }
            else
            {
                // There are 4 bytes split across multiple segments. Since it's so small, it
                // can be copied to a stack allocated buffer. This avoids a heap allocation.
                Span<byte> stackBuffer = stackalloc byte[4];
                lengthSlice.CopyTo(stackBuffer);
                length = BinaryPrimitives.ReadInt32BigEndian(stackBuffer);
            }

            // Move the buffer 4 bytes ahead.
            buffer = buffer.Slice(lengthSlice.End);

            return true;
        }
        #endregion

        #region snippet6
        static bool TryParseLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
        {
            SequencePosition position = buffer.Start;
            SequencePosition previous = position;
            var index = -1;
            line = default;

            while (buffer.TryGet(ref position, out ReadOnlyMemory<byte> segment))
            {
                ReadOnlySpan<byte> span = segment.Span;

                // Look for \r in the current segment.
                index = span.IndexOf((byte)'\r');

                if (index != -1)
                {
                    // Check next segment for \n.
                    if (index + 1 >= span.Length)
                    {
                        var next = position;
                        if (!buffer.TryGet(ref next, out ReadOnlyMemory<byte> nextSegment))
                        {
                            // You're at the end of the sequence.
                            return false;
                        }
                        else if (nextSegment.Span[0] == (byte)'\n')
                        {
                            //  A match was found.
                            break;
                        }
                    }
                    // Check the current segment of \n.
                    else if (span[index + 1] == (byte)'\n')
                    {
                        // It was found.
                        break;
                    }
                }

                previous = position;
            }

            if (index != -1)
            {
                // Get the position just before the \r\n.
                var delimeter = buffer.GetPosition(index, previous);

                // Slice the line (excluding \r\n).
                line = buffer.Slice(buffer.Start, delimeter);

                // Slice the buffer to get the remaining data after the line.
                buffer = buffer.Slice(buffer.GetPosition(2, delimeter));
                return true;
            }

            return false;
        }
        #endregion

        #region snippet7
        static void EmptySegments()
        {
            // This logic creates a ReadOnlySequence<byte> with 4 segments,
            // two of which are empty.
            var first = new BufferSegment(new byte[0]);
            var last = first.Append(new byte[] { 97 })
                            .Append(new byte[0]).Append(new byte[] { 98 });

            // Construct the ReadOnlySequence<byte> from the linked list segments.
            var data = new ReadOnlySequence<byte>(first, 0, last, 1);

            // Slice using numbers.
            var sequence1 = data.Slice(0, 2);

            // Slice using SequencePosition pointing at the empty segment.
            var sequence2 = data.Slice(data.Start, 2);

            Console.WriteLine($"sequence1.Length={sequence1.Length}"); // sequence1.Length=2
            Console.WriteLine($"sequence2.Length={sequence2.Length}"); // sequence2.Length=2

            // sequence1.FirstSpan.Length=1
            Console.WriteLine($"sequence1.FirstSpan.Length={sequence1.FirstSpan.Length}");

            // Slicing using SequencePosition will Slice the ReadOnlySequence<byte> directly
            // on the empty segment!
            // sequence2.FirstSpan.Length=0
            Console.WriteLine($"sequence2.FirstSpan.Length={sequence2.FirstSpan.Length}");

            // The following code prints 0, 1, 0, 1.
            SequencePosition position = data.Start;
            while (data.TryGet(ref position, out ReadOnlyMemory<byte> memory))
            {
                Console.WriteLine(memory.Length);
            }
        }

        class BufferSegment : ReadOnlySequenceSegment<byte>
        {
            public BufferSegment(Memory<byte> memory)
            {
                Memory = memory;
            }

            public BufferSegment Append(Memory<byte> memory)
            {
                var segment = new BufferSegment(memory)
                {
                    RunningIndex = RunningIndex + Memory.Length
                };
                Next = segment;
                return segment;
            }
        }
        #endregion

#if DAVID_FIX_CODE
        public void Reader1()
        {
        #region snippet8
            while (reader.TryRead(out byte b))
            {
                Process(b);
            }
        #endregion
        }
#endif

        private void Process(object b)
        {
            throw new NotImplementedException();
        }
    }

    class MyClass2
    {
        #region snippet2
        void WriteHello(IBufferWriter<byte> writer)
        {
            byte[] helloBytes = Encoding.ASCII.GetBytes("Hello");

            // Write helloBytes to the writer. There's no need to call Advance here
            // since Write calls Advance.
            writer.Write(helloBytes);
        }
        #endregion

#if DAVID_FIX_CODE
        #region snippet4
        SequencePosition? FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
        {
            SequencePosition position = buffer.Start;
            SequencePosition result = position;

            while (buffer.TryGet(ref position, out ReadOnlyMemory<byte> segment))
            {
                ReadOnlySpan<byte> span = segment.Span;
                var index = span.IndexOf(data);
                if (index != -1)
                {
                    return buffer.GetPosition(index, result);
                }

                result = position;
            }
            return null;
        }
        #endregion
#endif

        #region snippet9
        SequencePosition? FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
        {
            var reader = new SequenceReader<byte>(buffer);

            while (!reader.End)
            {
                // Search for the byte in the current span.
                var index = reader.CurrentSpan.IndexOf(data);
                if (index != -1)
                {
                    // It was found, so advance to the position.
                    reader.Advance(index);

                    return reader.Position;
                }
                // Skip the current segment since there's nothing in it.
                reader.Advance(reader.CurrentSpan.Length);
            }

            return null;
        }
        #endregion

        #region snippet11
        bool TryParseHeaderLength(ref ReadOnlySequence<byte> buffer, out int length)
        {
            var reader = new SequenceReader<byte>(buffer);
            return reader.TryReadBigEndian(out length);
        }
        #endregion

    }

    public static class MyClass3
    {
        #region snippet10
        static ReadOnlySpan<byte> NewLine => new byte[] { (byte)'\r', (byte)'\n' };

        static bool TryParseLine(ref ReadOnlySequence<byte> buffer,
                                 out ReadOnlySequence<byte> line)
        {
            var reader = new SequenceReader<byte>(buffer);

            if (reader.TryReadTo(out line, NewLine))
            {
                buffer = buffer.Slice(reader.Position);

                return true;
            }

            line = default;
            return false;
        }
        #endregion

    }
}
