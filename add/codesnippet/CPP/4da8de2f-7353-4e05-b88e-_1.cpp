   // This method can signal whether to enable or disable the specified
   // ToolboxItem when the component associated with this designer is selected.
   bool IToolboxUser::GetToolSupported( ToolboxItem^ tool )
   {
      
      // Search the blocked type names array for the type name of the tool
      // for which support for is being tested. Return false to indicate the
      // tool should be disabled when the associated component is selected.
      for ( int i = 0; i < blockedTypeNames->Length; i++ )
         if ( tool->TypeName == blockedTypeNames[ i ] )
                  return false;

      
      // Return true to indicate support for the tool, if the type name of the
      // tool is not located in the blockedTypeNames string array.
      return true;
   }

