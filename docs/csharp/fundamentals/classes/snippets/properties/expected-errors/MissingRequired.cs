// <MissingRequired>
var playlist = new Playlist(); // CS9035: Playlist.Title must be set.

public class Playlist
{
    public required string Title { get; init; }
}
// </MissingRequired>
