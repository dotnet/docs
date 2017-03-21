    Private cacheLock As New ReaderWriterLockSlim()
    Private innerCache As New Dictionary(Of Integer, String)