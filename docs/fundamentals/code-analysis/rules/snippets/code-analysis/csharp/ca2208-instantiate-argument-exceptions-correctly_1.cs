public class Book
{
    public Book(string title)
    {
        Title = title ?? throw new ArgumentNullException("All books must have a title.", nameof(title));
    }

    public string Title { get; }
}