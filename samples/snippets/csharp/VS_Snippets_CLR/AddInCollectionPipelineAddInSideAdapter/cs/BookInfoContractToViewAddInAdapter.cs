// <Snippet4>
using System;
using System.AddIn.Pipeline;
namespace LibraryContractsAddInAdapters 
{
    
public class BookInfoContractToViewAddInAdapter : LibraryContractsBase.BookInfo 
{
    private Library.IBookInfoContract _contract;
    private System.AddIn.Pipeline.ContractHandle _handle;
    public BookInfoContractToViewAddInAdapter(Library.IBookInfoContract contract) 
    {
        _contract = contract;
        _handle = new ContractHandle(contract);
    }

    public override string ID()
    {
        return _contract.ID();
    }
    public override string Author()
    {
        return _contract.Author();
    }
    public override string Title()
    {
        return _contract.Title();
    }
    public override string Genre()
    {
        return _contract.Genre();
    }
    public override string Price()
    {
        return _contract.Price();
    }
    public override string Publish_Date()
    {
        return _contract.Publish_Date();
    }
    public override string Description()
    {
        return _contract.Description();
    }

    internal Library.IBookInfoContract GetSourceContract() {
        return _contract;
    }
}
}
// </Snippet4>
