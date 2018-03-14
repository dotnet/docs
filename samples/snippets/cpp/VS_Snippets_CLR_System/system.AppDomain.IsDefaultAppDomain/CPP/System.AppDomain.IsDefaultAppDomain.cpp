//<Snippet1>
using namespace System;
using namespace System::Reflection;

// This method has the same signature as the CrossAppDomainDelegate,
// so that it can be executed easily in the new application domain.
//
static void ShowDomainInfo()
{
    AppDomain^ ad = AppDomain::CurrentDomain;
    Console::WriteLine();
    Console::WriteLine( L"FriendlyName: {0}", ad->FriendlyName );
    Console::WriteLine( L"Id: {0}", ad->Id );
    Console::WriteLine( L"IsDefaultAppDomain: {0}", ad->IsDefaultAppDomain() );
}

// The following attribute indicates to the loader that assemblies
// in the global assembly cache should be shared across multiple 
// application domains.
//
[LoaderOptimizationAttribute(LoaderOptimization::MultiDomainHost)]
int main()
{
    // Show information for the default application domain.
    ShowDomainInfo();

    // Create a new application domain and display its information.
    AppDomain^ newDomain = AppDomain::CreateDomain( L"MyMultiDomain" );
    newDomain->DoCallBack( gcnew CrossAppDomainDelegate( ShowDomainInfo ) );

    return 0;
}

//</Snippet1>
