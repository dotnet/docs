      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ evidence = assembly->Evidence;
      CodeGroup^ resolvedCodeGroup =
         codeGroup->ResolveMatchingCodeGroups( evidence );