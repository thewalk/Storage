﻿using System;
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
    /// InOutImportView.xaml 的交互逻辑
    /// </summary>
    public partial class InOutImportView : Page
    {
        private ModernDialog addWindow;
        public InOutImportView()
        {
            InitializeComponent();
            ViewModel = new ImportViewModel();
            this.importDataGrid.LoadingRow += importDataGrid_LoadingRow;
        }

        void importDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        public ImportViewModel ViewModel
        {
            get
            {
                return this.DataContext as ImportViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addWindow = getAddImportWindow();
            addWindow.Show();
        }
        ModernDialog getAddImportWindow()
        {
            Grid grid = new Grid();
            grid.Width = 300;
            grid.Height = 400;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Label contactLabel = new Label();
            contactLabel.Content = "联系人";
            contactLabel.HorizontalAlignment = HorizontalAlignment.Left;
            contactLabel.Margin = new Thickness(30, 60, 0, 20);
            Label batchLabel = new Label();
            batchLabel.Content = "批次名称";
            batchLabel.HorizontalAlignment = HorizontalAlignment.Left;
            batchLabel.Margin = new Thickness(30, 0, 0, 20);
            Label pitLabel = new Label();
            pitLabel.Content = "储窖名称";
            pitLabel.HorizontalAlignment = HorizontalAlignment.Left;
            pitLabel.Margin = new Thickness(30, 0, 0, 20);
            Label kindLabel = new Label();
            kindLabel.Content = "品种名称";
            kindLabel.HorizontalAlignment = HorizontalAlignment.Left;
            kindLabel.Margin = new Thickness(30, 0, 0, 20);
            Label sizeLabel = new Label();
            sizeLabel.Content = "大小(吨)";
            sizeLabel.HorizontalAlignment = HorizontalAlignment.Left;
            sizeLabel.Margin = new Thickness(30, 0, 0, 20);
            Label timeLabel = new Label();
            timeLabel.Content = "入库时间";
            timeLabel.HorizontalAlignment = HorizontalAlignment.Left;
            timeLabel.Margin = new Thickness(30, 0, 0, 20);
            Label noteLabel = new Label();
            noteLabel.Content = "备注";
            noteLabel.HorizontalAlignment = HorizontalAlignment.Left;
            noteLabel.Margin = new Thickness(30, 0, 60, 20);

            TextBox contactBox = new TextBox();
            contactBox.Width = 160;
            contactBox.MaxWidth = 160;
            contactBox.Margin = new Thickness(30, 60, 0, 20);
            contactBox.GotFocus += contactBox_GotFocus;
            TextBox batchBox = new TextBox();
            batchBox.Width = 160;
            batchBox.MaxWidth = 160;
            batchBox.Margin = new Thickness(30, 0, 0, 20);
            batchBox.GotFocus += batchBox_GotFocus;
            TextBox pitBox = new TextBox();
            pitBox.Width = 160;
            pitBox.MaxWidth = 160;
            pitBox.Margin = new Thickness(30, 0, 0, 20);
            pitBox.GotFocus += pitBox_GotFocus;
            TextBox kindBox = new TextBox();
            kindBox.Width = 160;
            kindBox.MaxWidth = 160;
            kindBox.Margin = new Thickness(30, 0, 0, 20);
            kindBox.GotFocus += kindBox_GotFocus;
            TextBox sizeBox = new TextBox();
            sizeBox.Width = 160;
            sizeBox.MaxWidth = 160;
            sizeBox.Margin = new Thickness(30, 0, 0, 20);
            DatePicker timeBox = new DatePicker();
            timeBox.Text = DateTime.Now.Date.ToString();
            timeBox.Width = 160;
            timeBox.MaxWidth = 160;
            timeBox.Margin = new Thickness(30, 0, 0, 20);

            StackPanel timePanel = new StackPanel();
            timePanel.Margin =  new Thickness(85, 0, 0, 20);
            Label hourLabel = new Label();
            hourLabel.Content = "时";
            Label minLabel = new Label();
            minLabel.Content = "分";
            ComboBox hourComb = new ComboBox();
            ComboBox minComb = new ComboBox();
            hourComb.Width = 70;
            minComb.Width = 70;
            for (int i = 0; i < 24; i++)
            {
                hourComb.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                minComb.Items.Add(i);
            }
            hourComb.Text = DateTime.Now.Hour.ToString();
            minComb.Text = DateTime.Now.Minute.ToString();
            timePanel.Orientation = Orientation.Horizontal;
            timePanel.Children.Add(hourComb);
            timePanel.Children.Add(hourLabel);
            timePanel.Children.Add(minComb);
            timePanel.Children.Add(minLabel);
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

            grid.Children.Add(contactLabel);
            grid.Children.Add(contactBox);
            grid.Children.Add(batchLabel);
            grid.Children.Add(batchBox);
            grid.Children.Add(pitLabel);
            grid.Children.Add(pitBox);
            grid.Children.Add(kindLabel);
            grid.Children.Add(kindBox);
            grid.Children.Add(sizeLabel);
            grid.Children.Add(sizeBox);
            grid.Children.Add(timeLabel);
            grid.Children.Add(timeBox);
            grid.Children.Add(timePanel);
            grid.Children.Add(noteLabel);
            grid.Children.Add(noteBox);

            contactLabel.SetValue(Grid.RowProperty, 0);
            contactLabel.SetValue(Grid.ColumnProperty, 0);
            contactBox.SetValue(Grid.RowProperty, 0);
            contactBox.SetValue(Grid.ColumnProperty, 1);
            batchLabel.SetValue(Grid.RowProperty, 1);
            batchLabel.SetValue(Grid.ColumnProperty, 0);
            batchBox.SetValue(Grid.RowProperty,1);
            batchBox.SetValue(Grid.ColumnProperty, 1);
            pitLabel.SetValue(Grid.RowProperty, 2);
            pitLabel.SetValue(Grid.ColumnProperty, 0);
            pitBox.SetValue(Grid.RowProperty, 2);
            pitBox.SetValue(Grid.ColumnProperty, 1);
            kindLabel.SetValue(Grid.RowProperty, 3);
            kindLabel.SetValue(Grid.ColumnProperty, 0);
            kindBox.SetValue(Grid.RowProperty, 3);
            kindBox.SetValue(Grid.ColumnProperty, 1);
            sizeLabel.SetValue(Grid.RowProperty, 4);
            sizeLabel.SetValue(Grid.ColumnProperty, 0);
            sizeBox.SetValue(Grid.RowProperty, 4);
            sizeBox.SetValue(Grid.ColumnProperty, 1);
            timeLabel.SetValue(Grid.RowProperty, 5);
            timeLabel.SetValue(Grid.ColumnProperty, 0);
            timeBox.SetValue(Grid.RowProperty, 5);
            timeBox.SetValue(Grid.ColumnProperty, 1);
            timePanel.SetValue(Grid.RowProperty, 6);
            timePanel.SetValue(Grid.ColumnProperty, 1);
            noteLabel.SetValue(Grid.RowProperty, 7);
            noteLabel.SetValue(Grid.ColumnProperty, 0);
            noteBox.SetValue(Grid.RowProperty, 7);
            noteBox.SetValue(Grid.ColumnProperty, 1);

            List<Button> dialogBtns = new List<Button>();
            dialogBtns.Add(submitBtn);
            dialogBtns.Add(cancelBtn);
            ModernDialog wnd = new ModernDialog
            {
                Content = grid,
                Title = "添加入库",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                Buttons = dialogBtns,
            };
            submitBtn.Click += submitBtn_Click;
            cancelBtn.Click += cancelBtn_Click;
            wnd.Height = 400;
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
                Buttons=btns,
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
            (grid.Children[1] as TextBox).Text = contact.Name;
            (grid.Children[1] as TextBox).Tag = contact.ID;
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

        #region batchBox get focus
        void batchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            List<Button> btns = new List<Button>();
            Button batchSubmitBtn = new Button();
            batchSubmitBtn.Content = "确定";
            batchSubmitBtn.Click += batchSubmitBtn_Click;
            Button batchCancelBtn = new Button();
            batchCancelBtn.Content = "取消";
            batchCancelBtn.Click += batchCancelBtn_Click;
            btns.Add(batchSubmitBtn);
            btns.Add(batchCancelBtn);

            InOutBatchConfigView view = new InOutBatchConfigView();
            view.ViewModel = new BatchViewModel(InOutLogic.getImportBatch());
            view.addBtn.Visibility = Visibility.Hidden;
            view.delBtn.Visibility = Visibility.Hidden;
            view.modBtn.Visibility = Visibility.Hidden;

            ModernDialog dialog = new ModernDialog()
            {
                Title = "选择批次",
                Content = view,
                Buttons = btns,
            };
            dialog.Show();
        }

        void batchSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button batchSubmitBtn = sender as Button;
            Window window = Window.GetWindow(batchSubmitBtn);
            InOutBatchConfigView batchView = window.Content as InOutBatchConfigView;
            Batch batch = batchView.batchDataGrid.SelectedItem as Batch;

            if (batch == null)
            {
                ModernDialog.ShowMessage("请选择批次！", "", MessageBoxButton.OK);
                return;
            }
            Grid grid = addWindow.Content as Grid;
            (grid.Children[3] as TextBox).Text = batch.Name;
            (grid.Children[3] as TextBox).Tag = batch.ID;
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }

        void batchCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button batchCancelBtn = sender as Button;
            Window window = Window.GetWindow(batchCancelBtn);
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }
        #endregion

        #region pitBox get focus
        void pitBox_GotFocus(object sender, RoutedEventArgs e)
        {
            List<Button> btns = new List<Button>();
            Button pitSubmitBtn = new Button();
            pitSubmitBtn.Content = "确定";
            pitSubmitBtn.Click += pitSubmitBtn_Click;
            Button pitCancelBtn = new Button();
            pitCancelBtn.Content = "取消";
            pitCancelBtn.Click += pitCancelBtn_Click;
            btns.Add(pitSubmitBtn);
            btns.Add(pitCancelBtn);

            ConfigPitView view = new ConfigPitView();
            view.addBtn.Visibility = Visibility.Hidden;
            view.delBtn.Visibility = Visibility.Hidden;
            view.modBtn.Visibility = Visibility.Hidden;

            ModernDialog dialog = new ModernDialog()
            {
                Title = "选择储窖",
                Content = view,
                Buttons = btns,
            };
            dialog.Show();
        }

        void pitSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button pitSubmitBtn = sender as Button;
            Window window = Window.GetWindow(pitSubmitBtn);
            ConfigPitView pitView = window.Content as ConfigPitView;
            Pit pit = pitView.pitDataGrid.SelectedItem as Pit;

            if (pit == null)
            {
                ModernDialog.ShowMessage("请选择储窖！","",MessageBoxButton.OK);
                return;
            }
            Grid grid = addWindow.Content as Grid;
            (grid.Children[5] as TextBox).Text = pit.Name;
            (grid.Children[5] as TextBox).Tag = pit.ID;
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }
        void pitCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button pitCancelBtn = sender as Button;
            Window window = Window.GetWindow(pitCancelBtn);
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }
        #endregion

        #region kindBox get focus
        void kindBox_GotFocus(object sender, RoutedEventArgs e)
        {
            List<Button> btns = new List<Button>();
            Button kindSubmitBtn = new Button();
            kindSubmitBtn.Content = "确定";
            kindSubmitBtn.Click += kindSubmitBtn_Click;
            Button kindCancelBtn = new Button();
            kindCancelBtn.Content = "取消";
            kindCancelBtn.Click += kindCancelBtn_Click;
            btns.Add(kindSubmitBtn);
            btns.Add(kindCancelBtn);

            ConfigKindView view = new ConfigKindView();
            view.addBtn.Visibility = Visibility.Hidden;
            view.delBtn.Visibility = Visibility.Hidden;
            view.modBtn.Visibility = Visibility.Hidden;

            ModernDialog dialog = new ModernDialog()
            {
                Title = "选择品种",
                Content = view,
                Buttons = btns,
            };
            dialog.Show();
        }
        void kindSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button kindSubmitBtn = sender as Button;
            Window window = Window.GetWindow(kindSubmitBtn);
            ConfigKindView kindView = window.Content as ConfigKindView;
            Kind kind = kindView.kindDataGrid.SelectedItem as Kind;

            if (kind == null)
            {
                ModernDialog.ShowMessage("请选择品种！", "", MessageBoxButton.OK);
                return;
            }
            Grid grid = addWindow.Content as Grid;
            (grid.Children[7] as TextBox).Text = kind.Name;
            (grid.Children[7] as TextBox).Tag = kind.ID;
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }

        void kindCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Button kindCancelBtn = sender as Button;
            Window window = Window.GetWindow(kindCancelBtn);
            addWindow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            window.Close();
        }
        #endregion



        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            addWindow.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            Import import = new Import();
            Grid content = addWindow.Content as Grid;
            import.ContactID = Convert.ToInt32((content.Children[1] as TextBox).Tag);
            import.BatchID = Convert.ToInt32((content.Children[3] as TextBox).Tag);
            import.PitID = Convert.ToInt32((content.Children[5] as TextBox).Tag);
            import.KindID = Convert.ToInt32((content.Children[7] as TextBox).Tag);
            import.Size = Convert.ToDouble((content.Children[9] as TextBox).Text);
            import.Note = Convert.ToString((content.Children[14] as TextBox).Text);
            
            DatePicker datePicker =  content.Children[11] as DatePicker;
            DateTime time = datePicker.SelectedDate.Value;
            time = time.AddHours(Convert.ToDouble(((content.Children[12] as StackPanel).Children[0] as ComboBox).Text));
            time = time.AddMinutes(Convert.ToDouble(((content.Children[12] as StackPanel).Children[2] as ComboBox).Text));
            import.Time = time;
            this.ViewModel.ImportList.Add(import);

            addWindow.Close();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (importDataGrid.SelectedItems == null || importDataGrid.SelectedItems.Count == 0)
            {
                ModernDialog.ShowMessage("请先选择需要删除的入库记录！", "", MessageBoxButton.OK);
            }
            else
            {
                ObservableCollection<Import> importList = new ObservableCollection<Import>();
                foreach (Import import in importDataGrid.SelectedItems)
                {
                    importList.Add(import);
                }
                InOutImportView view = new InOutImportView();
                view.addBtn.Visibility = Visibility.Hidden;
                view.modBtn.Visibility = Visibility.Hidden;
                view.delBtn.Visibility = Visibility.Hidden;
                view.ViewModel = new ImportViewModel(importList);
                List<Button> btns = new List<Button>();
                Button deleteSubmitBtn = new Button();
                Button deleteCancelBtn = new Button();
                deleteCancelBtn.Click += deleteCancelBtn_Click;
                deleteSubmitBtn.Click += deleteSubmitBtn_Click;
                ModernDialog dialog = new ModernDialog()
                {
                    Content = view,
                    Title = "确定删除以下入库记录？",
                    Buttons = btns,
                };
            }
        }

        void deleteSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button submitBtn = sender as Button;
            Window window = Window.GetWindow(submitBtn);
            InOutImportView view = window.Content as InOutImportView;
            for (int i = 0; i < view.ViewModel.ImportList.Count; i++)
            {
                this.ViewModel.ImportList.Remove(view.ViewModel.ImportList[i]);
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
                this.importDataGrid.IsReadOnly = false;
                this.importDataGrid.Columns[1].IsReadOnly = true;
                this.importDataGrid.Columns[3].IsReadOnly = true;
                //this.importDataGrid.PreparingCellForEdit += batchDataGrid_PreparingCellForEdit;
                this.modBtn.Background = Brushes.BlueViolet;
            }
            else
            {
                this.modBtn.Content = "修改";
                this.importDataGrid.IsReadOnly = true;
                this.modBtn.Background = null;
                //this.importDataGrid.PreparingCellForEdit -= batchDataGrid_PreparingCellForEdit;
                ViewModel.ImportUpd();
            }
        }
    }
}