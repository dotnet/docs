//<Snippet1>
using System;
using System.Security.Permissions;


namespace TransparencyWarningsDemo
{

    public class TransparentMethodSatisfiesLinkDemandsClass
    {
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public void LinkDemandMethod() { }


        public void TransparentMethod()
        {
            // CA2141 violation - transparent method calling a method protected with a link demand.  Any of the
            // following fixes will work here:
            //  1. Make TransparentMethod critical
            //  2. Make TransparentMethod safe critical
            //  3. Remove the LinkDemand from LinkDemandMethod  (In this case, that would be recommended anyway
            //     since it's level 2 -- however you could imagine it in a level 1 assembly)
            LinkDemandMethod();
        }
    }
}

//</Snippet1>