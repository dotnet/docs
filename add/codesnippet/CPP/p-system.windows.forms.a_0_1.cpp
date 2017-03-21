    private:
        void UpdateButton_Click(Object^ sender, EventArgs^ e)
        {
            if (applyToClient->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::ClientAreaEnabled;
            }
            else if (applyToNonClient->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::NonClientAreaEnabled;
            }
            else if (applyToAll->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::ClientAndNonClientAreasEnabled;
            }
            else if (disableStyles->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::NoneEnabled;
            }

            // Repaint the form and all child controls.
            this->Invalidate(true);
        }