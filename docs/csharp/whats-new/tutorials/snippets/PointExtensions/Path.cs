namespace ExtensionMembers;

// <PathType>
public sealed class Path
{
    private readonly List<(int dX, int dY)> offsets = [];

    public Path(IEnumerable<(int dX, int dY)> offsets)
    {
        this.offsets.AddRange(offsets);
    }

    public int Count => offsets.Count;

    internal (int dX, int dY) GetOffset(int index) => offsets[index];

    internal void SetOffset(int index, (int dX, int dY) offset) =>
        offsets[index] = offset;
}
// </PathType>
