    class MyDesigner : ControlDesigner
    {
        private Adorner myAdorner;

        protected override void Dispose(bool disposing)
        {
            if (disposing && myAdorner != null)
            {
                BehaviorService b = BehaviorService;
                if (b != null)
                {
                    b.Adorners.Remove(myAdorner);
                }
            }
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Add the custom set of glyphs using the BehaviorService. 
            // Glyphs live on adornders.
            myAdorner = new Adorner();
            BehaviorService.Adorners.Add(myAdorner);
            myAdorner.Glyphs.Add(new MyGlyph(BehaviorService, Control));
        }
    }