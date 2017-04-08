using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace SDKSample
{
	public partial class DPCustom
	{
		private Shirt myShirt;
		private void OnInit(object sender, EventArgs e)
		{
			myShirt = new Shirt();
			PopulateListbox(ShirtChoice, Enum.GetValues(typeof(ShirtTypes)));
			PopulateListbox(ShirtColorChoice, Enum.GetValues(typeof(ShirtColors)));
			PopulateListbox(ButtonChoice, Enum.GetValues(typeof(ButtonColors)));
			myShirt.ButtonColorChanged += new RoutedEventHandler(UIButtonColorChanged);
		}
		private void PopulateListbox (FrameworkElement fe, Array values) {
			ListBox lb = fe as ListBox;
			for (int j = 1; j < values.Length; j++)
			{
				ListBoxItem lbi = new ListBoxItem();
				lbi.Content = (Enum)values.GetValue(j);
				lb.Items.Add(lbi);
			}
		}
		private void ChooseShirt(object sender, SelectionChangedEventArgs e)
		{
			ListBoxItem lbi = ((e.Source as ListBox).SelectedItem as ListBoxItem);
			myShirt.ShirtType = (ShirtTypes)lbi.Content;
		}
		private void ChooseShirtColor(object sender, SelectionChangedEventArgs e)
		{
			ListBoxItem lbi = ((e.Source as ListBox).SelectedItem as ListBoxItem);
			myShirt.ShirtColor = (ShirtColors)lbi.Content;
		}
		private void ChooseButtonColor(object sender, SelectionChangedEventArgs e)
		{
			ListBoxItem lbi = ((e.Source as ListBox).SelectedItem as ListBoxItem);
			myShirt.ButtonColor = (ButtonColors)lbi.Content;
		}
		private void UIButtonColorChanged(object sender, RoutedEventArgs e)
		{
			Shirt s =  (Shirt)e.Source;
			ButtonColors b = s.ButtonColor;
			if (b == ButtonColors.None)
			{
				ButtonChoice.Visibility = Visibility.Hidden;
				ButtonChoiceLabel.Visibility = Visibility.Hidden;
			}
			else
			{
				ButtonChoice.Visibility = Visibility.Visible;
				ButtonChoiceLabel.Visibility = Visibility.Visible;
			}
		}
	}
	public enum ShirtTypes {
        None,
		Tee,
		Bowling,
		Dress,
		Rugby
	}
	public enum ShirtColors
	{
		None,
		White,
		Red,
		Green,
		Yellow
	}
	public enum ButtonColors
	{
		None,
		Black,
		White,
		Brown,
		Gray
	}

	public class Shirt : Canvas {
		public static readonly DependencyProperty ShirtColorProperty = DependencyProperty.Register("ShirtColor", typeof(ShirtColors), typeof(Shirt), new FrameworkPropertyMetadata(ShirtColors.None));
		public ShirtColors ShirtColor
		{
			get { return (ShirtColors)GetValue(ShirtColorProperty); }
			set { SetValue(ShirtColorProperty, value); }
		}
		public static readonly DependencyProperty ShirtTypeProperty = DependencyProperty.Register(
			"ShirtType",
			typeof(ShirtTypes), 
			typeof(Shirt), 
			new FrameworkPropertyMetadata(
				ShirtTypes.None,
				new PropertyChangedCallback(OnShirtTypeChangedCallback)
			), new ValidateValueCallback(ShirtValidateCallback));
		public ShirtTypes ShirtType {
			get {return(ShirtTypes)GetValue(ShirtTypeProperty);}
			set {SetValue(ShirtTypeProperty,value);}
		}
//<SnippetValidateValueCallback>
		private static bool ShirtValidateCallback(object value)
		{
			ShirtTypes sh = (ShirtTypes) value;
			return (sh==ShirtTypes.None || sh == ShirtTypes.Bowling || sh == ShirtTypes.Dress || sh == ShirtTypes.Rugby || sh == ShirtTypes.Tee);

		}
//</SnippetValidateValueCallback>
		private static void OnShirtTypeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.CoerceValue(ButtonColorProperty);
		}
//<SnippetPropertyChangedCallbackPlusDPDef>
		public static readonly DependencyProperty ButtonColorProperty = DependencyProperty.Register(
			"ButtonColor",
			typeof(ButtonColors), 
			typeof(Shirt), 
			new FrameworkPropertyMetadata(
			ButtonColors.Black,
			new PropertyChangedCallback(OnButtonColorChangedCallback),
			new CoerceValueCallback(CoerceButtonColor))
		);
		public ButtonColors ButtonColor
		{
			get { return (ButtonColors)GetValue(ButtonColorProperty); }
			set { SetValue(ButtonColorProperty, value); }
		}
		private static void OnButtonColorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			RoutedEventArgs newargs = new RoutedEventArgs(ButtonColorChangedEvent);
			(d as FrameworkElement).RaiseEvent(newargs);
		}
//</SnippetPropertyChangedCallbackPlusDPDef>
//<SnippetCoerceValueCallback>
		private static object CoerceButtonColor(DependencyObject d, object value)
		{
			ShirtTypes newShirtType = (d as Shirt).ShirtType;
			if (newShirtType == ShirtTypes.Dress || newShirtType == ShirtTypes.Bowling)
			{
				return ButtonColors.Black;				
			}
			return ButtonColors.None;
		}
//</SnippetCoerceValueCallback>
//<SnippetEventManagerClass>
		public static readonly RoutedEvent ButtonColorChangedEvent = EventManager.RegisterRoutedEvent("ButtonColorChanged",RoutingStrategy.Bubble,typeof(DependencyPropertyChangedEventHandler),typeof(Shirt));

		public event RoutedEventHandler ButtonColorChanged  {
			add {AddHandler(ButtonColorChangedEvent,value);}
			remove { RemoveHandler(ButtonColorChangedEvent, value); }
		}
//</SnippetEventManagerClass>
	}


}