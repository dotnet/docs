      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ evidence = assembly->Evidence;
      CodeGroup^ codeGroup = fileCodeGroup->ResolveMatchingCodeGroups( evidence );