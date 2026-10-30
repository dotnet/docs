using System.Runtime.CompilerServices;

#if DEMONSTRATE_CS1700
// <InvalidFriendName>
[assembly: InternalsVisibleTo("FriendConsumer, Retargetable=f")]
// </InvalidFriendName>
#else
// <ValidFriendName>
[assembly: InternalsVisibleTo("FriendConsumer")]
// </ValidFriendName>
#endif
