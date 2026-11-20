using System.Collections.ObjectModel;

public class FindFilesProgressInfo { }

public class Examples
{
    // <CancellationParameter>
    public static Task ReadAsync(byte[] buffer, int offset, int count,
                                 CancellationToken cancellationToken)
    // </CancellationParameter>
    {
        return Task.Run(() => Thread.Sleep(1), cancellationToken);
    }

    // <ProgressParameter>
    public static Task ReadAsync(byte[] buffer, int offset, int count,
                                 IProgress<long> progress)
    // </ProgressParameter>
    {
        return Task.Run(() => Thread.Sleep(1));
    }

    // <ProgressTupleParameter>
    public static Task<ReadOnlyCollection<FileInfo>> FindFilesAsync(
        string pattern,
        IProgress<Tuple<double, ReadOnlyCollection<List<FileInfo>>>> progress)
    // </ProgressTupleParameter>
    {
        return Task.FromResult(new ReadOnlyCollection<FileInfo>(Array.Empty<FileInfo>()));
    }

    // <ProgressInfoParameter>
    public static Task<ReadOnlyCollection<FileInfo>> FindFilesAsync(
        string pattern,
        IProgress<FindFilesProgressInfo> progress)
    // </ProgressInfoParameter>
    {
        return Task.FromResult(new ReadOnlyCollection<FileInfo>(Array.Empty<FileInfo>()));
    }
}

static class Program { static void Main() { } }
