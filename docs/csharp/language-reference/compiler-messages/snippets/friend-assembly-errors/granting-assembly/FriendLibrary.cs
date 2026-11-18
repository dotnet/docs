using System.Runtime.CompilerServices;

#if DEMONSTRATE_CS0281
// <MismatchedFriendKey>
[assembly: InternalsVisibleTo("FriendConsumer, PublicKey=0024000004800000940000000602000000240000525341310004000001000100031d7b6f3abc16c7de526fd67ec2926fe68ed2f9901afbc5f1b6b428bf6cd9086021a0b38b76bc340dc6ab27b65e4a593fa0e60689ac98dd71a12248ca025751d135df7b98c5f9d09172f7b62dabdd302b2a1ae688731ff3fc7a6ab9e8cf39fb73c60667e1b071ef7da5838dc009ae0119a9cbff2c581fc0f2d966b77114b2c4")]
// </MismatchedFriendKey>
#else
// <MatchingFriendIdentity>
[assembly: InternalsVisibleTo("FriendConsumer")]
// </MatchingFriendIdentity>
#endif

namespace FriendLibrary;

// <FriendMember>
internal static class Greeting
{
    internal static string Message => "Friend access granted.";
}
// </FriendMember>
