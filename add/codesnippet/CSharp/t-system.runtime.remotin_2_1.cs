[Serializable]
public class LogicalCallContextData : ILogicalThreadAffinative
{
   int _nAccesses;
   IPrincipal _principal;

   public string numOfAccesses {
      get {
         return String.Format("The identity of {0} has been accessed {1} times.", 
                              _principal.Identity.Name, 
                              _nAccesses);
      }
   }

   public IPrincipal Principal {
      get { 
         _nAccesses ++;
         return _principal;
      }
   }
   
   public LogicalCallContextData(IPrincipal p) {
      _nAccesses = 0;
      _principal = p;
   }
}