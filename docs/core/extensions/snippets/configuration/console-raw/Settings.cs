public sealed class Settings
{
    public required int KeyOne { get; set; }
    public required bool KeyTwo { get; set; }
    public required NestedSettings KeyThree { get; set; } = null!;
}
