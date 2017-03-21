      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ executingEvidence = assembly->Evidence;

      PolicyStatement^ policy = codeGroup->Resolve( executingEvidence );