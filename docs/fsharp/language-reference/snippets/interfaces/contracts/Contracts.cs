namespace Contracts;

// <DefaultInterface>
public interface IHealthCheck
{
    string Status();
}

public interface IReadyCheck : IHealthCheck
{
    string IHealthCheck.Status() => "Ready";
}
// </DefaultInterface>

// <ProtectedBase>
public class CounterBase
{
    protected int count = 7;
}
// </ProtectedBase>
