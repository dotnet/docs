public void RemoveMyButton()
 {
    int btns;
    btns = toolBar1.Buttons.Count;
 
    // Remove the last toolbar button.
    toolBar1.Buttons.RemoveAt(btns - 1);
 }
   