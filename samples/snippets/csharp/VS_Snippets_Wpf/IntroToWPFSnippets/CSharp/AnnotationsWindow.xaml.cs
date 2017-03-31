// AnnotationsStyling SDK Sample - ThemeWindow.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Globalization;
using System.Collections;
using System.Windows.Markup;


namespace SDKSample
{
    // ============================ class ThemeWindow =============================
    /// <summary>
    ///   Provides the interaction logic for ThemeWindow.xaml.</summary>
    public partial class AnnotationsWindow : Window
    {

        // ------------------------ ThemeWindow constructor -----------------------
        public AnnotationsWindow()
        {
            InitializeComponent();

            // Open the file that contains the FlowDocument...
            using (FileStream xamlFile = new FileStream("AFlowDocument.xaml", FileMode.Open, FileAccess.Read))
            {
                // and parse the file with the XamlReader.Load method.
                FlowDocument content = XamlReader.Load(xamlFile) as FlowDocument;

                // Finally, set the Document property to the FlowDocument object that was
                // parsed from the input file.
                this.Viewer.Document = content;
            }
        }


        // ------------------------- OnStyleSelected --------------------------
        /// <summary>
        ///   Replaces the default StickyNote style when a new
        ///   style is selected from the drop down combo box.</summary>
        private void OnStyleSelected(object sender, SelectionChangedEventArgs e)
        {
            // Extract the selected style.
            ComboBox source = (ComboBox)e.Source;
            StyleMetaData selectedStyle = (StyleMetaData)source.SelectedItem;
            Style newStyle = new Style(typeof(StickyNoteControl));
            newStyle.BasedOn = selectedStyle.Value;

            // Replace the default StickyNote style with the one that was just selected.
            Type defaultKey = typeof(StickyNoteControl);
            if (Viewer.Resources.Contains(defaultKey))
                Viewer.Resources.Remove(defaultKey);
            Viewer.Resources.Add(defaultKey, newStyle);

            // Re-load annotations so that they pickup new style.
            AnnotationService service = AnnotationService.GetService(Viewer);
            service.Disable();
            service.Enable(service.Store);
        }


        #region Boilerplate Annotations Code

        // ----------------------------- OnLoaded -----------------------------
        /// <summary>
        ///   Turns Annotations on.</summary>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Make sure that an AnnotationService isn’t already enabled.
            AnnotationService service = AnnotationService.GetService(Viewer);
            if (service == null)
           {
                // (a) Create a Stream for the annotations to be stored in.
                AnnotationStream =
                  new FileStream("annotations.xml", FileMode.OpenOrCreate);
                // (b) Create an AnnotationService on our
                // FlowDocumentPageViewer.
                service = new AnnotationService(Viewer);
                // (c) Create an AnnotationStore and give it the stream we
                // created. (Autoflush == false)
                AnnotationStore store = new XmlStreamStore(AnnotationStream);
                // (d) "Turn on annotations". Annotations will be persisted in
                // the stream created at (a).
                service.Enable(store);
            }
        }// end:OnLoaded


        // ---------------------------- OnUnLoaded ----------------------------
        /// <summary>
        ///   Turns Annotations off.</summary>
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            // (a) Check that an AnnotationService
            // actually existed and was Enabled.
            AnnotationService service = AnnotationService.GetService(Viewer);
            if (service != null && service.IsEnabled)
            {
                // (b) Flush changes to annotations to our stream.
                service.Store.Flush();
                // (c) Turn off annotations.
                service.Disable();
                // (d) Close our stream.
                AnnotationStream.Close();
            }
        }

        // The stream that we will store annotations in.
        Stream AnnotationStream;

        #endregion Boilerplate Annotations Code

    }// end:partial class ThemeWindow


    // =============== class ResourceEntryToComboItemConverter ================
    [ValueConversion(typeof(System.Collections.ObjectModel.Collection<StyleMetaData>),
        typeof(System.Collections.ObjectModel.Collection<ResourceDictionary>))]
    public class ResourceEntryToComboItemConverter : IValueConverter
    {

        // ----------------------------- Convert ------------------------------
        /// <summary>
        ///   Parses a collection of ResourceDictionaries and
        ///   extracts all StickyNote styles.</summary>
        /// <returns>
        ///   A list of Styles and their associated
        ///   keys (for identification).</returns>
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            System.Collections.ObjectModel.Collection<ResourceDictionary> unfiltered =
                value as System.Collections.ObjectModel.Collection<ResourceDictionary>;

            System.Collections.ObjectModel.Collection<StyleMetaData> filtered =
                new System.Collections.ObjectModel.Collection<StyleMetaData>();

            foreach (ResourceDictionary dict in unfiltered)
            {
                foreach (string key in dict.Keys)
                {
                    Style aStyle = dict[key] as Style;
                    if (aStyle != null && aStyle.TargetType.Equals(typeof(StickyNoteControl)))
                        filtered.Add(new StyleMetaData(key, aStyle));
                }
            }

            return filtered;
        }// end:Convert


        // --------------------------- ConvertBack ----------------------------
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return null;
        }

    }// end:class ResourceEntryToComboItemConverter


    // ========================= class StyleMetaData ==========================
    /// <summary>
    ///   Provides a simple wrapper that associates a
    ///   Style with its ResourceDictionary key.</summary>
    public class StyleMetaData : DependencyObject
    {
        public StyleMetaData(string key, Style value)
        {
            Key = key;
            Value = value;
        }

        public static DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(StyleMetaData));

        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        public Style Value;

    }// end:class StyleMetaData


}// end:namespace SdkSample
