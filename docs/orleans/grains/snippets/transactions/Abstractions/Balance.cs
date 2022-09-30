namespace Transactional.Abstractions;

[Serializable]
public record class Balance
{
    public uint Value { get; set; } = 1_000;
}
