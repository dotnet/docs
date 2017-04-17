using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace ArrayEditorExample
{
    public class ArrayEditorTestComponent : Component
    {
        //<Snippet1>
        [EditorAttribute(typeof(System.ComponentModel.Design.ArrayEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public object[] componentArray
        {
            get
            {
                return compArray;
            }
            set
            {
                compArray = value;
            }
        }
        private object[] compArray;
        //</Snippet1>

        public ArrayEditorTestComponent()
        {
            compArray = new Component[] { new Component(), new Component(), this };
        }
    }
}