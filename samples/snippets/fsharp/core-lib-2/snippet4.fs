let reportError componentName code =
    failwithf "Component %s reported a failure. Error code: 0x%x" componentName code
reportError "Filesystem monitor" 0x80000005