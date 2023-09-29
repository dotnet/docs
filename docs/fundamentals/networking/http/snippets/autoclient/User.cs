public sealed record class User(
    int? Id,
    string Name,
    string Username,
    string Email,
    Address Address,
    string Phone,
    string Website,
    Company Company)
{
    public sealed override string ToString() => $"{Name} (Email: {Email}, Id: {Id})";
}
