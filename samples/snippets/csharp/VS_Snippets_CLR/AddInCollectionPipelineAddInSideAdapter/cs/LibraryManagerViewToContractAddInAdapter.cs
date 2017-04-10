// <Snippet1>
using System.IO;
using System.AddIn.Pipeline;
using System.AddIn.Contract;
using System.Collections.Generic;
namespace LibraryContractsAddInAdapters
{
//<Snippet2>
// The AddInAdapterAttribute
// identifes this pipeline
// segment as an add-in-side adapter.
[AddInAdapter]
public class LibraryManagerViewToContractAddInAdapter :
System.AddIn.Pipeline.ContractBase, Library.ILibraryManagerContract
{
//</Snippet2>
    private LibraryContractsBase.LibraryManager _view;
    public LibraryManagerViewToContractAddInAdapter(LibraryContractsBase.LibraryManager view)
    {
        _view = view;
    }
    // <Snippet3>
    public virtual void ProcessBooks(IListContract<Library.IBookInfoContract> books)
    {
        _view.ProcessBooks(CollectionAdapters.ToIList<Library.IBookInfoContract,
            LibraryContractsBase.BookInfo>(books,
            LibraryContractsAddInAdapters.BookInfoAddInAdapter.ContractToViewAdapter,
            LibraryContractsAddInAdapters.BookInfoAddInAdapter.ViewToContractAdapter));
    }
    // </Snippet3>
    public virtual Library.IBookInfoContract GetBestSeller()
    {
        return BookInfoAddInAdapter.ViewToContractAdapter(_view.GetBestSeller());
    }

    public virtual string Data(string txt)
    {
        string rtxt = _view.Data(txt);
        return rtxt;
    }

    internal LibraryContractsBase.LibraryManager GetSourceView()
    {
        return _view;
    }
}
}
//</Snippet1>