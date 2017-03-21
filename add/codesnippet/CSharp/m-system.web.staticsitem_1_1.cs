        // Clean up any collections or other state that an instance of this may hold.
        protected override void Clear() {
            lock (this) {
                rootNode = null;
                base.Clear();
            }
        }