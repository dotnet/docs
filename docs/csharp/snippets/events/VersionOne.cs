namespace events;

// <EventArgsV1>
public class FileFoundArgs : EventArgs
{
    public string FoundFile { get; }

    public FileFoundArgs(string fileName) => FoundFile = fileName;
}
// </EventArgsV1>

// <FileSearcherV1>
public class FileSearcher
{
    // <DeclareEvent>
    public event EventHandler<FileFoundArgs>? FileFound;
    // </DeclareEvent>

    public void Search(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            // <InvokeEvent>
            FileFound?.Invoke(this, new FileFoundArgs(file));
            // </InvokeEvent>
        }
    }
}
// </FileSearcherV1>

