// <Snippet7>
using System;
namespace LibraryContractsHostAdapters
{
public class BookInfoHostAdapter
{

    internal static LibraryContractsHAV.BookInfo ContractToViewAdapter(Library.IBookInfoContract contract)
    {
        if (!System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(contract) &&
            (contract.GetType().Equals(typeof(BookInfoViewToContractHostAdapter))))
        {
            return ((BookInfoViewToContractHostAdapter)(contract)).GetSourceView();

        }
        else {
            return new BookInfoContractToViewHostAdapter(contract);
        }
    }

    internal static Library.IBookInfoContract ViewToContractAdapter(LibraryContractsHAV.BookInfo view)
    {
        if (!System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(view) &&
            (view.GetType().Equals(typeof(BookInfoContractToViewHostAdapter))))
        {
            return ((BookInfoContractToViewHostAdapter)(view)).GetSourceContract();
        }
        else {
            return new BookInfoViewToContractHostAdapter(view);
        }
    }
}
}
// </Snippet7>
