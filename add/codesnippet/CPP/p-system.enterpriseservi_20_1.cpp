[SecurityRole("Role1")]
public ref class ContextUtil_IsSecurityEnabled: public ServicedComponent
{
public:
   void Example()
   {
      // Display whether role-based security is active for the current COM+
      // context.
      Console::WriteLine( "Role-based security active in current context: {0}", 
         ContextUtil::IsSecurityEnabled );
   }
};