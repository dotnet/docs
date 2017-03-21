public:
    virtual bool Layout(Object^ container,
		LayoutEventArgs^ layoutEventArgs) override
    {
        Control^ parent = nullptr;
        try
        {
            parent = (Control ^) container;
        }
        catch (InvalidCastException^ ex)
        {
            throw gcnew ArgumentException(
                "The parameter 'container' must be a control", "container", ex);
        }
        // Use DisplayRectangle so that parent.Padding is honored.
        Rectangle parentDisplayRectangle = parent->DisplayRectangle;
        Point nextControlLocation = parentDisplayRectangle.Location;

        for each (Control^ currentControl in parent->Controls)
        {
            // Only apply layout to visible controls.
            if (!currentControl->Visible)
            {
                continue;
            }

            // Respect the margin of the control:
            // shift over the left and the top.
            nextControlLocation.Offset(currentControl->Margin.Left,
                currentControl->Margin.Top);

            // Set the location of the control.
            currentControl->Location = nextControlLocation;

            // Set the autosized controls to their
            // autosized heights.
            if (currentControl->AutoSize)
            {
                currentControl->Size = currentControl->GetPreferredSize(
                    parentDisplayRectangle.Size);
            }

            // Move X back to the display rectangle origin.
            nextControlLocation.X = parentDisplayRectangle.X;

            // Increment Y by the height of the control
            // and the bottom margin.
            nextControlLocation.Y += currentControl->Height +
                currentControl->Margin.Bottom;
        }

        // Optional: Return whether or not the container's
        // parent should perform layout as a result of this
        // layout. Some layout engines return the value of
        // the container's AutoSize property.

        return false;
    }