        Type t2 = Type.GetType(test,
                               (aName) => aName.Name == "MyAssembly" ? 
                                   Assembly.LoadFrom(@".\MyPath\v5.0\MyAssembly.dll") : 
                                   Assembly.Load(aName),
                               (assem, name, ignore) => assem == null ? 
                                   Type.GetType(name, false, ignore) : 
                                       assem.GetType(name, false, ignore), true
                              ); 