using System;

namespace Interfaces
{
    // <FirstInterfaces>
    interface IControl
    {
        void Paint();
    }
    interface ITextBox: IControl
    {
        void SetText(string text);
    }
    interface IListBox: IControl
    {
        void SetItems(string[] items);
    }
    interface IComboBox: ITextBox, IListBox {}
    // </FirstInterfaces>

    // <ImplementInterfaces>
    interface IDataBound
    {
        void Bind(Binder b);
    }
    public class EditBox: IControl, IDataBound
    {
        public void Paint() { }
        public void Bind(Binder b) { }
    }
    // </ImplementInterfaces>

    public class Program
    {
        static void UsageOne()
        {
            // <UseInterfaces>
            EditBox editBox = new EditBox();
            IControl control = editBox;
            IDataBound dataBound = editBox;
            // </UseInterfaces>
        }

        static void UsageTwo()
        {
            // <DynamicCast>
            object obj = new EditBox();
            IControl control = (IControl)obj;
            IDataBound dataBound = (IDataBound)obj;
            // </DynamicCast>
        }

        public static void Main(string[] args)
        {

        }


    }

    public class Binder {}
}

namespace ExplicitInterface
{
    using Interfaces;

    // <ExplicitInterfaceImplementation>
    public class EditBox: IControl, IDataBound
    {
        void IControl.Paint() { }
        void IDataBound.Bind(Binder b) { }
    }
    // </ExplicitInterfaceImplementation>

    class UsageCode
    {
        static void Example()
        {
            /* <CastingFail>
            EditBox editBox = new EditBox();
            editBox.Paint();            // Error, no such method
            IControl control = editBox;
            control.Paint();            // Ok
            </CastingFail>
            */
        }
    }

}
