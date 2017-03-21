public class Sample : Control {
    private int currentIndex = 0;
   
    protected override void OnInit(EventArgs e) {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    protected override object SaveControlState() {
        return currentIndex != 0 ? (object)currentIndex : null;
    }

    protected override void LoadControlState(object state) {
        if (state != null) {
            currentIndex = (int)state;
        }
    }
}