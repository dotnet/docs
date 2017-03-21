public interface class IUserData
{
    void DoSomeStuff(
        [MarshalAs(UnmanagedType::CustomMarshaler,
             MarshalType="MyCompany.NewOldMarshaler")]
        INew^ pINew
    );
};