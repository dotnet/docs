using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

class Program
{
    static void Main(string[] args)
    {
    }
}

namespace n1
{
    //<Snippet1>
    // Contravariant interface.
    interface IContravariant<in A> { }

    // Extending contravariant interface.
    interface IExtContravariant<in A> : IContravariant<A> { }

    // Implementing contravariant interface.
    class Sample<A> : IContravariant<A> { }

    class Program
    {
        static void Test()
        {
            IContravariant<Object> iobj = new Sample<Object>();
            IContravariant<String> istr = new Sample<String>();

            // You can assign iobj to istr because
            // the IContravariant interface is contravariant.
            istr = iobj;
        }
    }
    //</Snippet1>

    class Sample
    {
    //<Snippet2>
    // Contravariant delegate.
    public delegate void DContravariant<in A>(A argument);

    // Methods that match the delegate signature.
    public static void SampleControl(Control control)
    { }
    public static void SampleButton(Button button)
    { }

    public void Test()
    {

        // Instantiating the delegates with the methods.
        DContravariant<Control> dControl = SampleControl;
        DContravariant<Button> dButton = SampleButton;

        // You can assign dControl to dButton
        // because the DContravariant delegate is contravariant.
        dButton = dControl;

        // Invoke the delegate.
        dButton(new Button());
    }
    //</Snippet2>
    }
}

namespace n2
{
    //<Snippet3>
    // Covariant interface.
    interface ICovariant<out R> { }

    // Extending covariant interface.
    interface IExtCovariant<out R> : ICovariant<R> { }

    // Implementing covariant interface.
    class Sample<R> : ICovariant<R> { }

    class Program
    {
        static void Test()
        {
            ICovariant<Object> iobj = new Sample<Object>();
            ICovariant<String> istr = new Sample<String>();

            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            iobj = istr;
        }
    }
    //</Snippet3>

    class Sample
    {
    //<Snippet4>
    // Covariant delegate.
    public delegate R DCovariant<out R>();

    // Methods that match the delegate signature.
    public static Control SampleControl()
    { return new Control(); }

    public static Button SampleButton()
    { return new Button(); }

    public void Test()
    {
        // Instantiate the delegates with the methods.
        DCovariant<Control> dControl = SampleControl;
        DCovariant<Button> dButton = SampleButton;

        // You can assign dButton to dControl
        // because the DCovariant delegate is covariant.
        dControl = dButton;

        // Invoke the delegate.
        dControl();
    }
    //</Snippet4>
    }
}
