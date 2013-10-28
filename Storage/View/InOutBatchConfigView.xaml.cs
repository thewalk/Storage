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
            ModernDialog addWindow = getAddBatchWindow();
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
            ComboBox contactBox = new ComboBox();
            contactBox.Width = 160;
            contactBox.MaxWidth = 160;
            contactBox.Margin = new Thickness(30 ,0 ,0 ,20);

            foreach (Contact contact in ConfigLogic.getAllContact())
            {
                contactBox.Items.Add(contact.ID+":"+contact.Name);
            }

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
                Title = "添加新储窖",
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
                    ComboBox contactBox = grid.Children[7] as ComboBox;
                    string text = contactBox.Text; 
                    info.Add(text.Substring(0,text.IndexOf(':')));
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
                string msg = "";
                msg += "确定删除以下储窖？\n删除批次后，相关联的出入库记录也将被删除！\n";
                List<Batch> batchList = new List<Batch>();
                foreach (Batch batch in batchDataGrid.SelectedItems)
                {
                    batchList.Add(batch);
                    msg += "\t" + batch.Name;
                }
                if (ModernDialog.ShowMessage(msg, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    for (int i = 0; i < batchList.Count; i++)
                    {
                        this.ViewModel.BatchList.Remove(batchList[i]);
                    }
                }

            }
        }
        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.modBtn.Content.Equals("修改"))
            {
                this.modBtn.Content = "修改中";
                this.batchDataGrid.IsReadOnly = false;
                this.batchDataGrid.Columns[1].IsReadOnly = true;
                this.batchDataGrid.Columns[3].IsReadOnly = true;
                this.modBtn.Background = Brushes.BlueViolet;
            }
            else
            {
                this.modBtn.Content = "修改";
                this.batchDataGrid.IsReadOnly = true;
                this.modBtn.Background = null;
                ViewModel.BatchUpd();
            }
        }
    }
}
