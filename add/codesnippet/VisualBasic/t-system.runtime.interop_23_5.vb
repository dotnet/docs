Public Interface IUserData
    Sub DoSomeStuff( _
        <MarshalAs(UnmanagedType.CustomMarshaler, _
        MarshalType := "MyCompany.NewOldMarshaler")> pINew As INew)
End Interface