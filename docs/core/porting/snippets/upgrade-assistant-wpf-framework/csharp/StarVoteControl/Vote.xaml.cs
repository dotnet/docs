using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarVoteControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Vote : UserControl
    {
        public int VoteCount
        {
            get { return (int)GetValue(VoteCountProperty); }
            set { SetValue(VoteCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VoteCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VoteCountProperty =
            DependencyProperty.Register("VoteCount", typeof(int), typeof(Vote), new PropertyMetadata(0, (s, e) =>
            {
                if (s is Vote voteInstance)
                {
                    if ((int)e.NewValue < 0)
                        s.SetValue(VoteCountProperty, 0);
                    else if ((int)e.NewValue > 5)
                        s.SetValue(VoteCountProperty, 5);
                    else
                    {
                        Style unfilled = (Style)voteInstance.Resources["LabelStarUnfilled"];
                        Style filled = (Style)voteInstance.Resources["LabelStarFilled"];

                        voteInstance.lbl1.Style = unfilled;
                        voteInstance.lbl2.Style = unfilled;
                        voteInstance.lbl3.Style = unfilled;
                        voteInstance.lbl4.Style = unfilled;
                        voteInstance.lbl5.Style = unfilled;

                        int value = (int)e.NewValue;

                        if (value > 0) voteInstance.lbl1.Style = filled;
                        if (value > 1) voteInstance.lbl2.Style = filled;
                        if (value > 2) voteInstance.lbl3.Style = filled;
                        if (value > 3) voteInstance.lbl4.Style = filled;
                        if (value > 4) voteInstance.lbl5.Style = filled;
                    }
                }
            }));



        public static int GetVoteValue(DependencyObject obj)
        {
            return (int)obj.GetValue(VoteValueProperty);
        }

        public static void SetVoteValue(DependencyObject obj, int value)
        {
            obj.SetValue(VoteValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for VoteValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VoteValueProperty =
            DependencyProperty.RegisterAttached("VoteValue", typeof(int), typeof(Vote), new PropertyMetadata(0));



        public Vote()
        {
            InitializeComponent();
        }

        private void vote_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VoteCount = GetVoteValue((Label)sender);
        }
    }
}
