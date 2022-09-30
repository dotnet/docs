namespace TransactionalExample.Abstractions;

public interface IAtmGrain : IGrainWithIntegerKey
{
    [Transaction(TransactionOption.Create)]
    Task Transfer(Guid fromAccount, Guid toAccount, decimal amountToTransfer);
}
