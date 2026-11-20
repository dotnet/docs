using System.Runtime.CompilerServices;

#if DEMONSTRATE_CS1725
// <InvalidFriendIdentity>
[assembly: InternalsVisibleTo("FriendConsumer, Version=1.1.0.0")]
// </InvalidFriendIdentity>
#else
// <ValidFriendIdentity>
[assembly: InternalsVisibleTo("FriendConsumer")]
// </ValidFriendIdentity>
#endif
