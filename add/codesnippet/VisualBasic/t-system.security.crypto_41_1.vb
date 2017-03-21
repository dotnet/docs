        'Create new X509 store from local certificate store.
        Dim store As New X509Store("MY", StoreLocation.CurrentUser)
        store.Open(OpenFlags.OpenExistingOnly Or OpenFlags.ReadWrite)

        'Output store information.
        Console.WriteLine("Store Information")
        Console.WriteLine("Number of certificates in the store: {0}", store.Certificates.Count)
        Console.WriteLine("Store location: {0}", store.Location)
        Console.WriteLine("Store name: {0} {1}", store.Name, Environment.NewLine)

        'Put certificates from the store into a collection so user can select one.
        Dim fcollection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Dim collection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(fcollection, "Select an X509 Certificate", "Choose a certificate to examine.", X509SelectionFlag.SingleSelection)
        Dim certificate As X509Certificate2 = collection(0)
        X509Certificate2UI.DisplayCertificate(certificate)