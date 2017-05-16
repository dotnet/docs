// ContactCollectionEditor.cs
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;

namespace Samples.AspNet.CS.Controls
{
    public class ContactCollectionEditor : CollectionEditor
    {
        public ContactCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(Contact);
        }
    }
}
