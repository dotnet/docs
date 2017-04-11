// <Snippet5>
using System;

namespace LibraryContractsAddInAdapters 
{
public class BookInfoViewToContractAddInAdapter : System.AddIn.Pipeline.ContractBase, Library.IBookInfoContract 
{
    private LibraryContractsBase.BookInfo _view;
    public BookInfoViewToContractAddInAdapter(LibraryContractsBase.BookInfo view) 
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

    internal LibraryContractsBase.BookInfo GetSourceView() {
        return _view;
    }
}
}
// </Snippet5>
