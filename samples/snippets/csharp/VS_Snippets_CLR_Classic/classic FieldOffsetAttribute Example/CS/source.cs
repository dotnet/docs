using System;
using System.Runtime.InteropServices;

// <Snippet1>
 [StructLayout(LayoutKind.Explicit)]
 public class SYSTEM_INFO
 {
 [FieldOffset(0)] public ulong OemId;
 [FieldOffset(8)] public ulong PageSize;
 [FieldOffset(16)] public ulong ActiveProcessorMask;
 [FieldOffset(24)] public ulong NumberOfProcessors;
 [FieldOffset(32)] public ulong ProcessorType;
 }
// </Snippet1>

