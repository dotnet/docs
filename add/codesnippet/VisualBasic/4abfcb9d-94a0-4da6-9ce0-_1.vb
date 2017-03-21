          m_MyServiceContainer.AddService(GetType(Control), New ServiceCreatorCallback( _
                    AddressOf CreateNewControl))