[Serializable]
public ref class LogicalCallContextData: public ILogicalThreadAffinative
{
private:
   int _nAccesses;
   IPrincipal^ _principal;

public:

   property String^ numOfAccesses 
   {
      String^ get()
      {
         return String::Format( "The identity of {0} has been accessed {1} times.", _principal->Identity->Name, _nAccesses );
      }
   }

   property IPrincipal^ Principal 
   {
      IPrincipal^ get()
      {
         _nAccesses++;
         return _principal;
      }
   }

   LogicalCallContextData( IPrincipal^ p )
   {
      _nAccesses = 0;
      _principal = p;
   }

};