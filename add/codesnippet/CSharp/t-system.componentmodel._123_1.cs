    [DesignerSerializer(typeof(MyCodeDomSerializer), typeof(CodeDomSerializer))]
    public class MyComponent : Component {
        private string localProperty = "Component Property Value";
        public string LocalProperty {
            get {
                return localProperty;
            }
            set {
                localProperty = value;
            }
        }
    }