namespace Transactional.Abstractions;

public static class KnownAccounts
{
    public static readonly AccountLookup Xaawo = 
        new(nameof(Xaawo), Guid.Parse("617c2172-9662-429e-bc71-8f073449291a"));

    public static readonly AccountLookup Pasqualino = 
        new(nameof(Pasqualino), Guid.Parse("52693ee0-809f-49a1-a5e4-3989546a1af8"));

    public static readonly AccountLookup Derick = 
        new(nameof(Derick), Guid.Parse("35600117-c812-4783-9438-b996fe1f53e2"));

    public static readonly AccountLookup Ida = 
        new(nameof(Ida), Guid.Parse("2a10db62-0e59-48ee-947c-6873cb7c38e8"));

    public static readonly AccountLookup Stacy = 
        new(nameof(Stacy), Guid.Parse("7332afd1-3a0a-4fbe-90b0-6463f32da536"));

    public static readonly AccountLookup Xiao = 
        new(nameof(Xiao), Guid.Parse("f060b142-4321-45e2-ace3-918def1ffe1d"));
}

public readonly record struct AccountLookup(string Name, Guid Id);
