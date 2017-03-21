		// The collection of AutoFormat objects for the IndentLabel object
        public override DesignerAutoFormatCollection AutoFormats
        {
            get
            {
                if (_autoFormats == null)
                {
					// Create the collection
                    _autoFormats = new DesignerAutoFormatCollection();

					// Create and add each AutoFormat object
                    _autoFormats.Add(new IndentLabelAutoFormat("MyClassic"));
                    _autoFormats.Add(new IndentLabelAutoFormat("MyBright"));
                    _autoFormats.Add(new IndentLabelAutoFormat("Default"));
                }
                return _autoFormats;
            }
        }