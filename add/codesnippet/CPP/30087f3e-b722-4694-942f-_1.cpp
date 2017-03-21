        // Calculate the text bounds, exluding the check box.
        Rectangle getTextRectangle()
        {
            Graphics ^g = this->CreateGraphics();
            textRectangleValue.X = ClientRectangle.X +
                        CheckBoxRenderer::GetGlyphSize(g,
                        CheckBoxState::UncheckedNormal).Width;
            textRectangleValue.Y = ClientRectangle.Y;
            textRectangleValue.Width = ClientRectangle.Width -
                        CheckBoxRenderer::GetGlyphSize(g,
                        CheckBoxState::UncheckedNormal).Width;
            textRectangleValue.Height = ClientRectangle.Height;

            delete g;
            return textRectangleValue;
        }