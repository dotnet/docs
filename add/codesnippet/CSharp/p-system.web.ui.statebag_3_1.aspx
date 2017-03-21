      private string GetMruList(string selectedValue) {
         StateBag state = ViewState;
         if (state.Count > 0) {
            int upperBound = state.Count;
            string[] keys = new string[upperBound];
            StateItem[] values = new StateItem[upperBound];
            state.Keys.CopyTo(keys, 0);
            state.Values.CopyTo(values, 0);
            StringBuilder options = new StringBuilder();
            for(int i = 0; i < upperBound; i++) {
               options.AppendFormat("<option {0} value={1}>{2}", (selectedValue == keys[i])?"selected":"", keys[i], values[i].Value);
            }
            return options.ToString();
         }
         return "";
      }