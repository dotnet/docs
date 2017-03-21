            ' Create a manually rendered tag.
            writer.WriteBeginTag("img")
            writer.WriteAttribute("alt", "AtlValue")
            writer.WriteAttribute("myattribute", "No &quot;encoding &quot; required", False)
            writer.Write(HtmlTextWriter.TagRightChar)