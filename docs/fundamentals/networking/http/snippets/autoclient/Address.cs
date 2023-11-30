public sealed record class Address(
    string Street,
    string? Suite,
    string City,
    string ZipCode,
    Geo Geo);
