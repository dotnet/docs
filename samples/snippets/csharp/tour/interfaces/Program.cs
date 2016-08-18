using System;

namespace Interfaces
{
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

    interface IDataBound
    {
        void Bind(Binder b);
    }
    public class EditBox: IControl, IDataBound
    {
        public void Paint() { }
        public void Bind(Binder b) { }
    } 

    public class Program
    {
        static void UsageOne()
        {
            EditBox editBox = new EditBox();
            IControl control = editBox;
            IDataBound dataBound = editBox;
        }

        static void UsageTwo()
        {
            object obj = new EditBox();
            IControl control = (IControl)obj;
            IDataBound dataBound = (IDataBound)obj;
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

    public class EditBox: IControl, IDataBound
    {
        void IControl.Paint() { }
        void IDataBound.Bind(Binder b) { }
    }

    class UsageCode
    {
        static void Example()
        {
            /*
            EditBox editBox = new EditBox();
            editBox.Paint();            // Error, no such method
            IControl control = editBox;
            control.Paint();            // Ok
            */
        }
    }

}
