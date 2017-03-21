   Public Function ShiftAndWrap(value As Integer, positions As Integer) As Integer
      positions = positions And &h1F
      
      ' Save the existing bit pattern, but interpret it as an unsigned integer.
      Dim number As UInteger = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0)
      ' Preserve the bits to be discarded.
      Dim wrapped AS UInteger = number >> (32 - positions)
      ' Shift and wrap the discarded bits.
      Return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) Or wrapped), 0)
   End Function