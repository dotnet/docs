[JustInTimeActivation]
[ObjectPooling(MinPoolSize=2, MaxPoolSize=100, CreationTimeout=1000)]
public class ObjectInspector : ServicedComponent
{

    public string IdentifyObject (Object obj)
    {
        // Return this object to the pool after use.
        ContextUtil.DeactivateOnReturn = true;

        // Get the supplied object's type.        
        Type objType = obj.GetType();
        
        // Return its name.
        return(objType.FullName);

    }

    protected override void Activate()
    {
        MessageBox.Show( String.Format("Now entering...\nApplication: {0}\nInstance: {1}\nContext: {2}\n",
                                       ContextUtil.ApplicationId.ToString(), ContextUtil.ApplicationInstanceId.ToString(),
                                       ContextUtil.ContextId.ToString() ) );
    }

    protected override void Deactivate()
    {
        MessageBox.Show("Bye Bye!");
    }

    // This object can be pooled.
    protected override bool CanBePooled()
    {
        return(true);
    }

}