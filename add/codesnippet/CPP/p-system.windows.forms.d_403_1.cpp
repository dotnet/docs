private:
    void AddLinkColumn()
    {
        DataGridViewLinkColumn^ links = gcnew DataGridViewLinkColumn();

		links->UseColumnTextForLinkValue = true;
        links->HeaderText = ColumnName::ReportsTo.ToString();
        links->DataPropertyName = ColumnName::ReportsTo.ToString();
        links->ActiveLinkColor = Color::White;
        links->LinkBehavior = LinkBehavior::SystemDefault;
        links->LinkColor = Color::Blue;
        links->TrackVisitedState = true;
        links->VisitedLinkColor = Color::YellowGreen;

        DataGridView1->Columns->Add(links);
    }