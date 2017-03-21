                ' Create a Web control from the persisted control string.
                Dim ctrl As System.Web.UI.Control = ControlParser.ParseControl(host, inputForm.TxBox.Text.Trim())