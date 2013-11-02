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
using Storage.Model;
using Storage.ViewModel;

namespace Storage.View
{
    /// <summary>
    /// ConfigKindView.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigKindView : Page
    {
        public ConfigKindView()
        {
            InitializeComponent();
            ViewModel = new KindViewModel();
            this.kindDataGrid.LoadingRow += kindDataGrid_LoadingRow;
        }

        void kindDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        public KindViewModel ViewModel
        {
            get
            {
                return this.DataContext as KindViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            ModernDialog addWindow = getAddKindWindow();
            addWindow.Show();
        }
        ModernDialog getAddKindWindow()
        {
            Grid grid = new Grid();
            grid.Width = 300;
            grid.Height = 300;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Label nameLabel = new Label();
            nameLabel.Content = "名称";
            nameLabel.HorizontalAlignment = HorizontalAlignment.Left;
            nameLabel.Margin = new Thickness(30, 60, 0, 20);
            Label noteLabel = new Label();
            noteLabel.Content = "备注";
            noteLabel.HorizontalAlignment = HorizontalAlignment.Left;
            noteLabel.Margin = new Thickness(30, 0, 0, 20);

            TextBox nameBox = new TextBox();
            nameBox.Width = 160;
            nameBox.MaxWidth = 160;
            nameBox.Margin = new Thickness(30, 60, 0, 20);
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
            grid.Children.Add(noteLabel);
            grid.Children.Add(noteBox);

            nameLabel.SetValue(Grid.RowProperty, 0);
            nameLabel.SetValue(Grid.ColumnProperty, 0);
            nameBox.SetValue(Grid.RowProperty, 0);
            nameBox.SetValue(Grid.ColumnProperty, 1);
            noteLabel.SetValue(Grid.RowProperty, 1);
            noteLabel.SetValue(Grid.ColumnProperty, 0);
            noteBox.SetValue(Grid.RowProperty, 1);
            noteBox.SetValue(Grid.ColumnProperty, 1);

            List<Button> dialogBtns = new List<Button>();
            dialogBtns.Add(submitBtn);
            dialogBtns.Add(cancelBtn);
            ModernDialog wnd = new ModernDialog
            {
                Content = grid,
                Title = "添加新品种",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                Buttons = dialogBtns,
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
            Kind newKind = new Kind();
            ModernDialog dialog = (ModernDialog)Window.GetWindow(sender as Button);
            Grid grid = dialog.Content as Grid;
            List<string> info = new List<string>();
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (i % 2 == 1)
                {
                    TextBox currentText = grid.Children[i] as TextBox;
                    info.Add(currentText.Text);
                }
            }
            newKind.Name = info[0];
            newKind.Note = info[1];

            if (info[0].Equals("") || info[0] == null)
            {
                ModernDialog.ShowMessage("请填写新品种名称！", "", MessageBoxButton.OK);
                return;
            }

            this.ViewModel.KindList.Add(newKind);
            ModernDialog.ShowMessage("添加新品种成功！", "", MessageBoxButton.OK);
            dialog.Close();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (kindDataGrid.SelectedItems == null || kindDataGrid.SelectedItems.Count == 0)
            {
                ModernDialog.ShowMessage("请先选择需要删除的品种！", "", MessageBoxButton.OK);
            }
            else
            {
                string msg = "";
                msg += "确定删除以下品种？\n";
                List<Kind> kindList = new List<Kind>();
                foreach (Kind kind in kindDataGrid.SelectedItems)
                {
                    kindList.Add(kind);
                    msg += "\t" + kind.Name + "\n";
                }
                if (ModernDialog.ShowMessage(msg, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    for (int i = 0; i < kindList.Count; i++)
                    {
                        this.ViewModel.KindList.Remove(kindList[i]);
                    }
                }

            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.modBtn.Content.Equals("修改"))
            {
                this.modBtn.Content = "修改中";
                this.kindDataGrid.IsReadOnly = false;
                this.modBtn.Background = Brushes.BlueViolet;
            }
            else
            {
                this.modBtn.Content = "修改";
                this.kindDataGrid.IsReadOnly = true;
                this.modBtn.Background = null;
                ViewModel.KindUpd();
            }
        }
    }
}
