// Guids.cs
// MUST match guids.h
using System;

namespace Contoso.VSSkinHost
{
    static class GuidList
    {
        public const string guidVSSkinHostPkgString = "58e844c8-4e18-42d7-8505-e8178e626d79";
        public const string guidVSSkinHostCmdSetString = "c7f8c1d2-ac97-429c-af01-89d26f5fc0ce";

        public static readonly Guid guidVSSkinHostCmdSet = new Guid(guidVSSkinHostCmdSetString);
    };
}