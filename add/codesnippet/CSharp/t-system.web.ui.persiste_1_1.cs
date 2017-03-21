      [PersistenceMode(PersistenceMode.InnerProperty),
      TemplateContainer(typeof(TemplateItem))]
      public ITemplate MessageTemplate {
         get {
            return _messageTemplate;
         }
         set {
            _messageTemplate = value;
         }
      }