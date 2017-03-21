         ' Get the current CpuMask property value.
            Dim cpuMask As Integer = _
            processModelSection.CpuMask
         
         ' Set the CpuMask property to 0x000000FF.
         processModelSection.CpuMask = &HFF
         