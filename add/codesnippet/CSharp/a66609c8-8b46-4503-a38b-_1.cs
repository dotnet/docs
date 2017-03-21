        // Set the VisualStyleRenderer to a new element.
        private bool SetRenderer(VisualStyleElement element)
        {
            if (!VisualStyleRenderer.IsElementDefined(element))
            {
                return false;
            }

            if (renderer == null)
            {
                renderer = new VisualStyleRenderer(element);
            }
            else
            {
                renderer.SetParameters(element);
            }

            return true;
        }