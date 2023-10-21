namespace Http.Resilience.Example;

public record class Comment(
    int PostId, int Id, string Name, string Email, string Body);
