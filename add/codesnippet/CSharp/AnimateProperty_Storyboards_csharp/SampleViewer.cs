
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{


    public class SampleViewer : Page
    {

        public SampleViewer()
        {
        
            this.Title = "Storyboard Examples";
            DockPanel mainPanel = new DockPanel();
            mainPanel.Background = Brushes.White;
            
            TabControl sampleDisplayControl = new TabControl();
            
            
            TabItem basicExampleItem = new TabItem();
            Frame myContainerFrame = new Frame();
            myContainerFrame.Content = new StoryboardExample();
            basicExampleItem.Header = "Basic Storyboard Example";
            basicExampleItem.Content = myContainerFrame;       
            sampleDisplayControl.Items.Add(basicExampleItem);
            
            TabItem myTabItem = new TabItem();
            myTabItem.Header = "Scope Example";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new ScopeExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);
            
            myTabItem = new TabItem();
            myTabItem.Header = "Multiple NameScopes Example";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new MultipleNameScopesExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);  
            
            myTabItem = new TabItem();
            myTabItem.Header = "ControllableStoryboardExample";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new ControlStoryboardExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);   

            myTabItem = new TabItem();
            myTabItem.Header = "FrameworkContentElementControllableStoryboardExample";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new FrameworkContentElementControlStoryboardExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);     
            
            myTabItem = new TabItem();
            myTabItem.Header = "FrameworkContentElementStoryboardExample";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new FrameworkContentElementStoryboardExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);     
            
            myTabItem = new TabItem();
            myTabItem.Header = "Control Template";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new ControlTemplateStoryboardExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);     
            
            myTabItem = new TabItem();
            myTabItem.Header = "FrameworkContentElementStoryboardWithHandoffBehaviorExample";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new FrameworkContentElementStoryboardWithHandoffBehaviorExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);              

            myTabItem = new TabItem();
            myTabItem.Header = "Seek Example";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new SeekExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);   

            myTabItem = new TabItem();
            myTabItem.Header = "FrameworkContentElement Seek Example";
            myContainerFrame = new Frame();
            myContainerFrame.Content = new FrameworkContentElementSeekExample();
            myTabItem.Content = myContainerFrame;            
            sampleDisplayControl.Items.Add(myTabItem);   
            
            
            mainPanel.Children.Add(sampleDisplayControl);
            
            this.Content = mainPanel;
            
        
        }
        
  
    }

    
}