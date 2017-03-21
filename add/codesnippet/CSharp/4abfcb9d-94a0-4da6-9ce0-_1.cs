            m_MyServiceContainer.AddService(typeof(Control),
                            new ServiceCreatorCallback(this.CreateNewControl));