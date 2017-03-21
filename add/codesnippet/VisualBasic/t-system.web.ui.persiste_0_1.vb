
      <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(TemplateItem))> Public Property MessageTemplate() As ITemplate
         Get
            Return _messageTemplate
         End Get
         Set(ByVal Value As ITemplate)
            _messageTemplate = Value
         End Set
      End Property
