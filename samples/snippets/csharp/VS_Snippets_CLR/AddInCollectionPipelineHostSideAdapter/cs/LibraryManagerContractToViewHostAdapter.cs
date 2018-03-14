// <Snippet1>
using System.Collections.Generic;
using System.AddIn.Pipeline;
namespace LibraryContractsHostAdapters
{
// <Snippet2>
[HostAdapterAttribute()]
public class LibraryManagerContractToViewHostAdapter : LibraryContractsHAV.LibraryManager
{
// </Snippet2>

    // <Snippet3>
    private Library.ILibraryManagerContract _contract;
    private System.AddIn.Pipeline.ContractHandle _handle;

    public LibraryManagerContractToViewHostAdapter(Library.ILibraryManagerContract contract)
    {
        _contract = contract;
        _handle = new System.AddIn.Pipeline.ContractHandle(contract);
    }
    // </Snippet3>

    // <Snippet4>
    public override void ProcessBooks(IList<LibraryContractsHAV.BookInfo> books) {
        _contract.ProcessBooks(CollectionAdapters.ToIListContract<LibraryContractsHAV.BookInfo,
            Library.IBookInfoContract>(books,
            LibraryContractsHostAdapters.BookInfoHostAdapter.ViewToContractAdapter,
            LibraryContractsHostAdapters.BookInfoHostAdapter.ContractToViewAdapter));
    }
    // </Snippet4>

    public override LibraryContractsHAV.BookInfo GetBestSeller()
    {
        return BookInfoHostAdapter.ContractToViewAdapter(_contract.GetBestSeller());
    }

    internal Library.ILibraryManagerContract GetSourceContract()
    {
        return _contract;
    }
    public override string Data(string txt)
    {
        string rtxt = _contract.Data(txt);
        return rtxt;
    }
}
}
// </Snippet1>
