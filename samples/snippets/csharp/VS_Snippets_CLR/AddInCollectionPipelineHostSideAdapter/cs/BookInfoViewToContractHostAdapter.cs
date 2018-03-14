// <Snippet6>
using System.AddIn.Pipeline;
namespace LibraryContractsHostAdapters
{
public class BookInfoViewToContractHostAdapter : ContractBase, Library.IBookInfoContract
{
    private LibraryContractsHAV.BookInfo _view;

    public BookInfoViewToContractHostAdapter(LibraryContractsHAV.BookInfo view)
    {
        _view = view;
    }

    public virtual string ID()
    {
        return _view.ID();
    }
    public virtual string Author()
    {
        return _view.Author();
    }
    public virtual string Title()
    {
        return _view.Title();
    }
    public virtual string Genre()
    {
        return _view.Genre();
    }
    public virtual string Price()
    {
        return _view.Price();
    }
    public virtual string Publish_Date()
    {
        return _view.Publish_Date();
    }
    public virtual string Description()
    {
        return _view.Description();
    }
    internal LibraryContractsHAV.BookInfo GetSourceView()
    {
        return _view;
    }
}
}
// </Snippet6>