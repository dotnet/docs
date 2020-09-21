public class Book
{
    public Book(string title)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title), "All books must have a title.");
    }

    public string Title { get; }
}