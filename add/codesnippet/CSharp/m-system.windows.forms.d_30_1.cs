        public MyGlyph(BehaviorService behaviorSvc, Control control) : 
            base(new MyBehavior())
        {
            this.behaviorSvc = behaviorSvc;
            this.control = control;
        }