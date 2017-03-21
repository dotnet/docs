// Demonstrate the use of ResolvePolicy for passed in evidence.
void CheckEvidence( Evidence^ evidence )
{
   // Display the code groups to which the evidence belongs.
   Console::WriteLine( "ResolvePolicy for the given evidence." );
   Console::WriteLine( "\tCurrent evidence belongs to the following code groups:" );
   IEnumerator^ policyEnumerator = SecurityManager::PolicyHierarchy();

   // Resolve the evidence at all the policy levels.
   while ( policyEnumerator->MoveNext() )
   {
      PolicyLevel^ currentLevel = dynamic_cast<PolicyLevel^>(policyEnumerator->Current);
      CodeGroup^ cg1 = currentLevel->ResolveMatchingCodeGroups( evidence );
      Console::WriteLine( "\n\t{0} Level", currentLevel->Label );
      Console::WriteLine( "\t\tCodeGroup = {0}", cg1->Name );
      IEnumerator^ cgE1 = cg1->Children->GetEnumerator();
      while ( cgE1->MoveNext() )
      {
         Console::WriteLine( "\t\t\tGroup = {0}", (dynamic_cast<CodeGroup^>(cgE1->Current))->Name );
      }

      Console::WriteLine( "\tStoreLocation = {0}", currentLevel->StoreLocation );
   }

   return;
}