// <snippet0>
using System;
using System.EnterpriseServices;
using System.Windows.Forms;

[assembly: ApplicationName("ObjectInspector")]
[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: System.Reflection.AssemblyKeyFile("Inspector.snk")]

// <snippet1>
[JustInTimeActivation]
[ObjectPooling(MinPoolSize=2, MaxPoolSize=100, CreationTimeout=1000)]
public class ObjectInspector : ServicedComponent
{

    // <snippet2>
    public string IdentifyObject (Object obj)
    {
        // Return this object to the pool after use.
        ContextUtil.DeactivateOnReturn = true;

        // Get the supplied object's type.        
        Type objType = obj.GetType();
        
        // Return its name.
        return(objType.FullName);

    }
    // </snippet2>

    // <snippet3>
    protected override void Activate()
    {
        MessageBox.Show( String.Format("Now entering...\nApplication: {0}\nInstance: {1}\nContext: {2}\n",
                                       ContextUtil.ApplicationId.ToString(), ContextUtil.ApplicationInstanceId.ToString(),
                                       ContextUtil.ContextId.ToString() ) );
    }
    // </snippet3>

    // <snippet4>
    protected override void Deactivate()
    {
        MessageBox.Show("Bye Bye!");
    }
    // </snippet4>

    // <snippet5>
    // This object can be pooled.
    protected override bool CanBePooled()
    {
        return(true);
    }
    // </snippet5>

}
// </snippet1>
// </snippet0>
