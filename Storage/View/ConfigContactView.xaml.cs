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
using FirstFloor.ModernUI.Windows.Controls;
using Storage.ViewModel;

namespace Storage.View
{
    /// <summary>
    /// ConfigContactView.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigContactView : UserControl
    {
        public ConfigContactView()
        {
            InitializeComponent();

            this.ViewModel = new ContactViewModel();
            this.contactDataGrid.RowEditEnding += contactDataGrid_RowEditEnding;
        }
        public ContactViewModel ViewModel
        {
            get
            {
                return this.DataContext as ContactViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            Label nameLabel = new Label("");



            var wnd = new ModernWindow
            {
                Style = (Style)App.Current.Resources["EmptyWindow"],
                Content = new TextBox()	 // your content here
            };
            wnd.Show();
        }

        void contactDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //this.contactDataGrid.CanUserAddRows = false;
            if (e.Row.ToString() == null)
            {
                MessageBox.Show("请输入姓名");
            }
        }

    }
}
