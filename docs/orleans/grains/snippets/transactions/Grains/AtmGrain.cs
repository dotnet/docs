namespace Transactional.Grains;

[StatelessWorker]
public class AtmGrain : Grain, IAtmGrain
{
    public Task Transfer(
        Guid fromId,
        Guid toId,
        uint amountToTransfer) =>
        Task.WhenAll(
            GrainFactory.GetGrain<IAccountGrain>(fromId).Withdraw(amountToTransfer),
            GrainFactory.GetGrain<IAccountGrain>(toId).Deposit(amountToTransfer));
}
