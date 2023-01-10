namespace CachingExamples.Memory;

public readonly record struct Photo(
    int AlbumId,
    int Id,
    string Title,
    string Url,
    string ThumbnailUrl);
