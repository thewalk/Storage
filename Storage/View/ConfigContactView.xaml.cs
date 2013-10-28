using System;
using System.Collections.Generic;
using System.Data;
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
using Storage.Model;
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
            this.contactDataGrid.LoadingRow += contactDataGrid_LoadingRow;
        }

        void contactDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
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
            ModernDialog addWindow = getAddContactWindow();
            addWindow.Show();
        }

        ModernDialog getAddContactWindow()
        {
            Grid grid = new Grid();
            grid.Width = 300;
            grid.Height = 300;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Label nameLabel = new Label();
            nameLabel.Content = "姓名";
            nameLabel.HorizontalAlignment = HorizontalAlignment.Left;
            nameLabel.Margin = new Thickness(30, 60, 0, 20);
            Label IDLabel = new Label();
            IDLabel.Content = "身份证号";
            IDLabel.HorizontalAlignment = HorizontalAlignment.Left;
            IDLabel.Margin = new Thickness(30, 0, 0, 20);
            Label phoneLabel = new Label();
            phoneLabel.Content = "电话";
            phoneLabel.HorizontalAlignment = HorizontalAlignment.Left;
            phoneLabel.Margin = new Thickness(30, 0, 0, 20);
            Label addressLabel = new Label();
            addressLabel.Content = "地址";
            addressLabel.HorizontalAlignment = HorizontalAlignment.Left;
            addressLabel.Margin = new Thickness(30, 0, 0, 20);
            Label noteLabel = new Label();
            noteLabel.Content = "备注";
            noteLabel.HorizontalAlignment = HorizontalAlignment.Left;
            noteLabel.Margin = new Thickness(30, 0, 0, 20);

            TextBox nameBox = new TextBox();
            nameBox.Width = 160;
            nameBox.MaxWidth = 160;
            nameBox.Margin = new Thickness(30, 60, 0, 20);
            TextBox IDBox = new TextBox();
            IDBox.Width = 160;
            IDBox.MaxWidth = 160;
            IDBox.Margin = new Thickness(30, 0, 0, 20);
            TextBox phoneBox = new TextBox();
            phoneBox.Width = 160;
            phoneBox.MaxWidth = 160;
            phoneBox.Margin = new Thickness(30, 0, 0, 20);
            TextBox addressBox = new TextBox();
            addressBox.Width = 160;
            addressBox.MaxWidth = 160;
            addressBox.Margin = new Thickness(30, 0, 0, 20);
            TextBox noteBox = new TextBox();
            noteBox.Width = 160;
            noteBox.MaxWidth = 160;
            noteBox.Margin = new Thickness(30, 0, 0, 20);

            Button submitBtn = new Button();
            submitBtn.Content = "确认";
            submitBtn.Width = 100;
            Button cancelBtn = new Button();
            cancelBtn.Content = "取消";
            cancelBtn.Width = 100;

            grid.Children.Add(nameLabel);
            grid.Children.Add(nameBox);
            grid.Children.Add(IDLabel);
            grid.Children.Add(IDBox);
            grid.Children.Add(phoneLabel);
            grid.Children.Add(phoneBox);
            grid.Children.Add(addressLabel);
            grid.Children.Add(addressBox);
            grid.Children.Add(noteLabel);
            grid.Children.Add(noteBox);

            nameLabel.SetValue(Grid.RowProperty, 0);
            nameLabel.SetValue(Grid.ColumnProperty, 0);
            nameBox.SetValue(Grid.RowProperty, 0);
            nameBox.SetValue(Grid.ColumnProperty, 1);
            IDLabel.SetValue(Grid.RowProperty, 1);
            IDLabel.SetValue(Grid.ColumnProperty, 0);
            IDBox.SetValue(Grid.RowProperty, 1);
            IDBox.SetValue(Grid.ColumnProperty, 1);
            phoneLabel.SetValue(Grid.RowProperty, 2);
            phoneLabel.SetValue(Grid.ColumnProperty, 0);
            phoneBox.SetValue(Grid.RowProperty, 2);
            phoneBox.SetValue(Grid.ColumnProperty, 1);
            addressLabel.SetValue(Grid.RowProperty, 3);
            addressLabel.SetValue(Grid.ColumnProperty, 0);
            addressBox.SetValue(Grid.RowProperty, 3);
            addressBox.SetValue(Grid.ColumnProperty, 1);
            noteLabel.SetValue(Grid.RowProperty, 4);
            noteLabel.SetValue(Grid.ColumnProperty, 0);
            noteBox.SetValue(Grid.RowProperty, 4);
            noteBox.SetValue(Grid.ColumnProperty, 1);

            List<Button> dialogBtns = new List<Button>();
            dialogBtns.Add(submitBtn);
            dialogBtns.Add(cancelBtn);
            ModernDialog wnd = new ModernDialog
            {
                Content = grid,
                Title = "添加联系人",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode=ResizeMode.NoResize,
                Buttons= dialogBtns,
            };
            submitBtn.Click += submitBtn_Click;
            cancelBtn.Click += cancelBtn_Click;
            wnd.Height = 300;
            wnd.Width = 300;
            return wnd;
        }

        void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button cancelBtn = sender as Button;
            Window.GetWindow(cancelBtn).Close();
        }

        void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            Contact newContact = new Contact();
            ModernDialog dialog =(ModernDialog) Window.GetWindow(sender as Button);
            Grid grid  = dialog.Content as Grid;
            List<string> info = new List<string>();
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (i % 2 == 1)
                {
                    TextBox currentText = grid.Children[i] as TextBox;
                    info.Add(currentText.Text);
                }
            }
            newContact.Name = info[0];
            newContact.Identity = info[1];
            newContact.Phone = info[2];
            newContact.Address = info[3];
            newContact.Note = info[4];

            if (info[0].Equals("") || info[0] == null)
            {
                ModernDialog.ShowMessage("请填写联系人姓名！", "", MessageBoxButton.OK);
                return;
            }

            this.ViewModel.ContactList.Add(newContact);
            ModernDialog.ShowMessage("添加联系人成功！", "", MessageBoxButton.OK);
            dialog.Close();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contactDataGrid.SelectedItems == null || contactDataGrid.SelectedItems.Count == 0)
            {
                ModernDialog.ShowMessage("请先选择需要删除的联系人！", "", MessageBoxButton.OK);
            }
            else
            {
                string msg = "";
                msg += "确定删除以下联系人？\n";
                List<Contact> contactList = new List<Contact>();
                foreach (Contact contact in contactDataGrid.SelectedItems)
                {
                    contactList.Add(contact);
                    msg += "\t" + contact.Name +"\n";
                }
                if (ModernDialog.ShowMessage(msg, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    for (int i = 0; i < contactList.Count; i++)
                    {
                        this.ViewModel.ContactList.Remove(contactList[i]);
                    }
                }

            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.modBtn.Content.Equals("修改"))
            {
                this.modBtn.Content = "修改中";
                this.contactDataGrid.IsReadOnly = false;
                this.modBtn.Background = Brushes.BlueViolet;
            }
            else
            {
                this.modBtn.Content = "修改";
                this.contactDataGrid.IsReadOnly = true;
                this.modBtn.Background = null;
                ViewModel.ContactUpd();
            }
        }
    }
}
