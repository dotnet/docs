        public override void RenderBeginTag(string tagName)
        {
            // Call the overloaded RenderBeginTag(HtmlTextWriterTag)
            // method.
            RenderBeginTag(GetTagKey(tagName));
        }