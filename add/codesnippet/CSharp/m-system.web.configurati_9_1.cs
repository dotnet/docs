
            // Clear the url mapping collection.
            urlMappings.Clear();

            // Update the configuration file.

            // Define the save modality.
            ConfigurationSaveMode saveMode =
              ConfigurationSaveMode.Minimal;

            urlMappings.EmitClear =
               Convert.ToBoolean(parm2);

            if (parm1 == "none")
            {
              if (!urlMappingSection.IsReadOnly())
                configuration.Save();
              msg = String.Format(
              "Default modality, EmitClear:      {0}",
              urlMappings.EmitClear.ToString());
            }
            else
            {
              if (parm1 == "full")
                saveMode = ConfigurationSaveMode.Full;
              else
                if (parm1 == "modified")
                  saveMode = ConfigurationSaveMode.Modified;

              if (!urlMappingSection.IsReadOnly())
                configuration.Save(saveMode);

              msg = String.Format(
               "Save modality:      {0}",
               saveMode.ToString());
            }
