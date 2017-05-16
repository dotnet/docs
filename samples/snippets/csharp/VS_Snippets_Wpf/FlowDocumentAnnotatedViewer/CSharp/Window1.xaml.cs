using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace FlowDocumentAnnotatedViewer
{
    public partial class MainWindow : Window
    {
        Stream stream;
        AnnotationService service;
        AnnotationStore store;
        IAnchorInfo info;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.Closed += new EventHandler(MainWindow_Closed);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Load annotations store
            this.stream = new FileStream("storage.xml", FileMode.OpenOrCreate);
            this.service = new AnnotationService(this.flowDocumentReader);
            this.store = new XmlStreamStore(this.stream);
            this.store.AutoFlush = true;
            this.service.Enable(this.store);

            // Detect when annotations are added or deleted
            this.service.Store.StoreContentChanged += new StoreContentChangedEventHandler(AnnotationStore_StoreContentChanged);

            // Bind to annotations in store
            BindToAnnotations(this.store.GetAnnotations());
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            if (this.service != null && this.service.IsEnabled)
            {
                this.service.Disable();
                this.stream.Close();
            }
        }

        void AnnotationStore_StoreContentChanged(object sender, StoreContentChangedEventArgs e)
        {
            // Bind to refreshed annotations store
            BindToAnnotations(this.store.GetAnnotations());
        }

        //<SnippetHandler>
        void annotationsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Annotation comment = (sender as ListBox).SelectedItem as Annotation;
            if (comment != null)
            {
                // IAnchorInfo info;
                // service is an AnnotationService object
                // comment is an Annotation object
                info = AnnotationHelper.GetAnchorInfo(this.service, comment);
                TextAnchor resolvedAnchor = info.ResolvedAnchor as TextAnchor;
                TextPointer textPointer = (TextPointer)resolvedAnchor.BoundingStart;
                textPointer.Paragraph.BringIntoView();
            }
        }
        //</SnippetHandler>

        void BindToAnnotations(IList<Annotation> annotations)
        {
            // Bind to annotations in store
            this.annotationsListBox.DataContext = annotations;

            // Sort annotations by creation time
            SortDescription sortDescription = new SortDescription();
            sortDescription.PropertyName = "CreationTime";
            sortDescription.Direction = ListSortDirection.Descending;
            ICollectionView view = CollectionViewSource.GetDefaultView(this.annotationsListBox.DataContext);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(sortDescription);
        }
    }
}