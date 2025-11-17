namespace ca1700
{
    //<snippet1>
    // This enum violates the rule.
    public enum BadPaymentStatus
    {
        Pending = 0,
        Completed = 1,
        ReservedError = 2,
        Reserved = 3,
    }

    // This enum satisfies the rule.
    public enum GoodPaymentStatus
    {
        Pending = 0,
        Completed = 1,
        Error = 2,
        Unknown = 3,
    }
    //</snippet1>
}
