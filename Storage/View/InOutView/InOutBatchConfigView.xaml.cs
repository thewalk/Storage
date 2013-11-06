using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Storage.DataLogic;
using Storage.Model;
using Storage.ViewModel;

namespace Storage.View
{
    /// <summary>
    /// InOutBatchConfig.xaml 的交互逻辑
    /// </summary>
    public partial class InOutBatchConfigView : Page
    {
        private ModernDialog addWindow;
        public InOutBatchConfigView()
        {
            InitializeComponent();
            this.ViewModel = new BatchViewModel();
            this.batchDataGrid.LoadingRow += batchDataGrid_LoadingRow;
        }

        void batchDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
            e.Row.MouseEnter += Row_MouseEnter;
        }

        void Row_MouseEnter(object sender, MouseEventArgs e)
        {
            DataGridRow row = e.Source as DataGridRow;
            Batch batch = batchDataGrid.Items[row.GetIndex()] as Batch;
            row.ToolTip ="姓名：\t"+batch.Contact.Name+"\n身份证号："+batch.Contact.Identity+"\n电话：\t"+batch.Contact.Phone+"\n地址：\t"+batch.Contact.Address+"\n备注：\t"+batch.Contact.Note;
        }
        public BatchViewModel ViewModel
        {
            get
            {
                return this.DataContext as BatchViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addWindow = getAddBatchWindow();
            addWindow.Show();
        }
        ModernDialog getAddBatchWindow()
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
            nameLabel.Content = "批次名称";
            nameLabel.HorizontalAlignment = HorizontalAlignment.Left;
            nameLabel.Margin = new Thickness(30, 60, 0, 20);
            Label inoutLabel = new Label();
            inoutLabel.Content = "批次出入";
            inoutLabel.HorizontalAlignment = HorizontalAlignment.Left;
            inoutLabel.Margin = new Thickness(30, 0, 0, 20);
            Label noteLabel = new Label();
            noteLabel.Content = "备注";
            noteLabel.HorizontalAlignment = HorizontalAlignment.Left;
            noteLabel.Margin = new Thickness(30, 0, 0, 20);
            Label contactLabel = new Label();
            contactLabel.Content = "联系人";
            contactLabel.HorizontalAlignment = HorizontalAlignment.Left;
            contactLabel.Margin = new Thickness(30, 0, 0, 20);


            TextBox nameBox = new TextBox();
            nameBox.Width = 160;
            nameBox.MaxWidth = 160;
            nameBox.Margin = new Thickness(30, 60, 0, 20);
            StackPanel inoutPanel = new StackPanel();
            inoutPanel.HorizontalAlignment = HorizontalAlignment.Center;
            inoutPanel.Margin = new Thickness(30, 0, 0, 20); 
            inoutPanel.Orientation = Orientation.Horizontal;
            RadioButton inBtn = new RadioButton();
            inBtn.Content = "入库";
            inBtn.Margin = new Thickness(0, 0, 10, 0);
            inBtn.GroupName = "inoutGroup";
            RadioButton outBtn = new RadioButton();
            outBtn.Content = "出库";
            outBtn.Margin = new Thickness(10, 0, 0, 0);
            outBtn.GroupName = "inoutGroup";
            inoutPanel.Children.Add(inBtn);
            inoutPanel.Children.Add(outBtn);
            TextBox noteBox = new TextBox();
            noteBox.Width = 160;
            noteBox.MaxWidth = 160;
            noteBox.Margin = new Thickness(30, 0, 0, 20);
            TextBox contactBox = new TextBox();
            contactBox.Width = 160;
            contactBox.MaxWidth = 160;
            contactBox.Margin = new Thickness(30, 0, 0, 20);
            contactBox.GotFocus += contactBox_GotFocus;

            Button submitBtn = new Button();
            submitBtn.Content = "确认";
            submitBtn.Width = 100;
            Button cancelBtn = new Button();
            cancelBtn.Content = "取消";
            cancelBtn.Width = 100;

            grid.Children.Add(nameLabel);
            grid.Children.Add(nameBox);
            grid.Children.Add(inoutLabel);
            grid.Children.Add(inoutPanel);
            grid.Children.Add(noteLabel);
            grid.Children.Add(noteBox);
            grid.Children.Add(contactLabel);
            grid.Children.Add(contactBox);

            nameLabel.SetValue(Grid.RowProperty, 0);
            nameLabel.SetValue(Grid.ColumnProperty, 0);
            nameBox.SetValue(Grid.RowProperty, 0);
            nameBox.SetValue(Grid.ColumnProperty, 1);
            inoutLabel.SetValue(Grid.RowProperty, 1);
            inoutLabel.SetValue(Grid.ColumnProperty, 0);
            inoutPanel.SetValue(Grid.RowProperty, 1);
            inoutPanel.SetValue(Grid.ColumnProperty, 1);
            noteLabel.SetValue(Grid.RowProperty, 2);
            noteLabel.SetValue(Grid.ColumnProperty, 0);
            noteBox.SetValue(Grid.RowProperty, 2);
            noteBox.SetValue(Grid.ColumnProperty, 1);
            contactLabel.SetValue(Grid.RowProperty, 3);
            contactLabel.SetValue(Grid.ColumnProperty, 0);
            contactBox.SetValue(Grid.RowProperty, 3);
            contactBox.SetValue(Grid.ColumnProperty, 1);

            List<Button> dialogBtns = new List<Button>();
            dialogBtns.Add(submitBtn);
            dialogBtns.Add(cancelBtn);
            ModernDialog wnd = new ModernDialog
            {
                Content = grid,
                Title = "添加新批次",
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

        #region contactBox get focus
        void contactBox_GotFocus(object sender, RoutedEventArgs e)
        {
            List<Button> btns = new List<Button>();
            Button contactSubmitBtn = new Button();
            contactSubmitBtn.Content = "确定";
            contactSubmitBtn.Click += contactSubmitBtn_Click;
            Button contactCancelBtn = new Button();
            contactCancelBtn.Content = "取消";
            contactCancelBtn.Click += contactCancelBtn_Click;
            btns.Add(contactSubmitBtn);
            btns.Add(contactCancelBtn);

            ConfigContactView view = new ConfigContactView();
            view.addBtn.Visibility = Visibility.Hidden;
            view.delBtn.Visibility = Visibility.Hidden;
            view.modBtn.Visibility = Visibility.Hidden;

            ModernDialog dialog = new ModernDialog()
            {
                Title = "选择联系人",
                Content = view,
                Buttons = btns,
            };
            dialog.Show();
        }
        void contactSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button contactSubmitBtn = sender as Button;
            Window window = Window.GetWindow(contactSubmitBtn);
            ConfigContactView contactView = window.Content as ConfigContactView;
            Contact contact = contactView.contactDataGrid.SelectedItem as Contact;

            if (contact == null)
            {
                ModernDialog.ShowMessage("请选择联系人！", "", MessageBoxButton.OK);
                return;
            }
            Grid grid = addWindow.Content as Grid;
            (grid.Children[7] as TextBox).Text = contact.Name;
            (grid.Children[7] as TextBox).Tag = contact.ID;
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }
        void contactCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button contactCancelBtn = sender as Button;
            Window window = Window.GetWindow(contactCancelBtn);
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }
        #endregion

        void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button cancelBtn = sender as Button;
            Window.GetWindow(cancelBtn).Close();
        }
        void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            Batch newBatch = new Batch();
            ModernDialog dialog = (ModernDialog)Window.GetWindow(sender as Button);
            Grid grid = dialog.Content as Grid;
            List<string> info = new List<string>();
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (i == 3)
                {
                    RadioButton inBtn = (grid.Children[3] as StackPanel).Children[0] as RadioButton;
                    RadioButton outBtn = (grid.Children[3] as StackPanel).Children[1] as RadioButton;
                    if ((Boolean)inBtn.IsChecked && !(Boolean)outBtn.IsChecked)
                    {
                        info.Add("true");
                    }
                    else if (!(Boolean)inBtn.IsChecked && (Boolean)outBtn.IsChecked)
                    {
                        info.Add("false");
                    }
                    else
                    {
                        ModernDialog.ShowMessage("请选择出入库类型！", "", MessageBoxButton.OK);
                    }
                    continue;
                }
                if (i == 7)
                {
                    TextBox contactBox = grid.Children[7] as TextBox;
                    string text = contactBox.Tag.ToString(); 
                    info.Add(text);
                    continue;
                }
                if (i % 2 == 1)
                {
                    TextBox currentText = grid.Children[i] as TextBox;
                    info.Add(currentText.Text);
                }
            }
            try
            {
                newBatch.Name = info[0];
                newBatch.InOut = Convert.ToBoolean(info[1]);
                newBatch.Note = info[2];
                newBatch.Size = 0;
                newBatch.ContactID =Convert.ToInt32(info[3]);
            }
            catch
            {
                ModernDialog.ShowMessage("请规范填写！", "", MessageBoxButton.OK);
                return;
            }

            this.ViewModel.BatchList.Add(newBatch);
            ModernDialog.ShowMessage("添加新批次成功！", "", MessageBoxButton.OK);
            dialog.Close();
        }
        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (batchDataGrid.SelectedItems == null || batchDataGrid.SelectedItems.Count == 0)
            {
                ModernDialog.ShowMessage("请先选择需要删除的批次！", "", MessageBoxButton.OK);
            }
            else
            {
                ObservableCollection<Batch> batchList = new ObservableCollection<Batch>();
                foreach(Batch batch in batchDataGrid.SelectedItems)
                {
                    batchList.Add(batch);
                }
                InOutBatchConfigView view = new InOutBatchConfigView();
                view.addBtn.Visibility = Visibility.Hidden;
                view.modBtn.Visibility = Visibility.Hidden;
                view.delBtn.Visibility = Visibility.Hidden;
                view.ViewModel = new BatchViewModel(batchList);
                List<Button> btns = new List<Button>();
                Button deleteSubmitBtn = new Button();
                Button deleteCancelBtn = new Button();
                btns.Add(deleteSubmitBtn);
                btns.Add(deleteCancelBtn);
                deleteSubmitBtn.Content = "确定";
                deleteCancelBtn.Content = "取消";
                deleteCancelBtn.Click += deleteCancelBtn_Click;
                deleteSubmitBtn.Click += deleteSubmitBtn_Click;
                ModernDialog dialog = new ModernDialog()
                {
                    Content = view,
                    Title = "确定删除以下批次？",
                    Buttons = btns,
                };
                dialog.Show();
            }
        }
        void deleteSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button submitBtn = sender as Button;
            Window window = Window.GetWindow(submitBtn);
            InOutBatchConfigView view = window.Content as InOutBatchConfigView;
            for (int i = 0; i < view.ViewModel.BatchList.Count; i++)
            {
                this.ViewModel.BatchList.Remove(view.ViewModel.BatchList[i]);
            }
            window.Close();
        }

        void deleteCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button cancelBtn = sender as Button;
            Window window = Window.GetWindow(cancelBtn);
            window.Close();
        }
        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.modBtn.Content.Equals("修改"))
            {
                this.modBtn.Content = "修改中";
                this.batchDataGrid.IsReadOnly = false;
                this.batchDataGrid.Columns[1].IsReadOnly = true;
                this.batchDataGrid.Columns[3].IsReadOnly = true;
                this.batchDataGrid.PreparingCellForEdit += batchDataGrid_PreparingCellForEdit;
                this.modBtn.Background = Brushes.BlueViolet;
            }
            else
            {
                this.modBtn.Content = "修改";
                this.batchDataGrid.IsReadOnly = true;
                this.modBtn.Background = null;
                this.batchDataGrid.PreparingCellForEdit -= batchDataGrid_PreparingCellForEdit;
                ViewModel.BatchUpd();
            }
        }

        void batchDataGrid_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            ConfigContactView contactView = new ConfigContactView();
            contactView.addBtn.Visibility = Visibility.Hidden;
            contactView.delBtn.Visibility = Visibility.Hidden;
            contactView.modBtn.Visibility = Visibility.Hidden;

            if (e.Column.Equals(this.batchDataGrid.Columns[4]))
            {
                List<Button> dialogBtn = new List<Button>();
                Button submitBtn = new Button();
                submitBtn.Content = "确定";
                submitBtn.Click += contactSelect_Click;
                Button cancelBtn = new Button();
                cancelBtn.Content = "取消";
                cancelBtn.Click += contactCancel_Click;
                dialogBtn.Add(submitBtn);
                dialogBtn.Add(cancelBtn);
                ModernDialog dialog = new ModernDialog
                {
                    Title = "选择联系人",
                    Content = contactView,
                    ResizeMode = ResizeMode.NoResize,
                    Buttons = dialogBtn
                };
                dialog.Show();
            }
        }

        private void contactCancel_Click(object sender, RoutedEventArgs e)
        {
            Button cancelBtn = sender as Button;
            Window.GetWindow(cancelBtn).Close();
            batchDataGrid.Columns[4].IsReadOnly = true;
            batchDataGrid.Columns[4].IsReadOnly = false;
        }

        private void contactSelect_Click(object sender, RoutedEventArgs e)
        {
            Button submitBtn = sender as Button;
            ConfigContactView content =  Window.GetWindow(submitBtn).Content as ConfigContactView;
            if (content.contactDataGrid.SelectedItem == null)
            {
                ModernDialog.ShowMessage("请选择一个联系人","",MessageBoxButton.OK);
            }
            Contact contact = content.contactDataGrid.SelectedItem as Contact;
            (batchDataGrid.SelectedItem as Batch).Contact = contact;
            Window.GetWindow(submitBtn).Close();
            batchDataGrid.Columns[4].IsReadOnly = true;
            batchDataGrid.Columns[4].IsReadOnly = false;
        }
    }
}
