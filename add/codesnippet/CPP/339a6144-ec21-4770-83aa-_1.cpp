        // Set the VisualStyleRenderer to a new element.
    private:
        bool SetRenderer(VisualStyleElement^ element)
        {
            if (!VisualStyleRenderer::IsElementDefined(element))
            {
                return false;
            }

            if (renderer == nullptr)
            {
                renderer = gcnew VisualStyleRenderer(element);
            }
            else
            {
                renderer->SetParameters(element);
            }

            return true;
        }