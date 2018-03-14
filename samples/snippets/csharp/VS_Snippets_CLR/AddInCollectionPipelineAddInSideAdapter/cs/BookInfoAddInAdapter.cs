// <Snippet6>
using System;
namespace LibraryContractsAddInAdapters {

public class BookInfoAddInAdapter
{
    internal static LibraryContractsBase.BookInfo ContractToViewAdapter(Library.IBookInfoContract contract)
    {
        if (!System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(contract) &&
            (contract.GetType().Equals(typeof(BookInfoViewToContractAddInAdapter))))
        {
            return ((BookInfoViewToContractAddInAdapter)(contract)).GetSourceView();
        }
        else {
            return new BookInfoContractToViewAddInAdapter(contract);
        }

    }

    internal static Library.IBookInfoContract ViewToContractAdapter(LibraryContractsBase.BookInfo view)
    {
        if (!System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(view) &&
            (view.GetType().Equals(typeof(BookInfoContractToViewAddInAdapter))))
        {
            return ((BookInfoContractToViewAddInAdapter)(view)).GetSourceContract();
        }
        else {
            return new BookInfoViewToContractAddInAdapter(view);
        }
    }
}
}
// </Snippet6>
