      GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce
      GC.Collect(2, GCCollectionMode.Forced, True, True)