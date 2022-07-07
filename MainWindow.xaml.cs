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
using WpfProjektSemestralny.Windows;
using WpfProjektSemestralny.Data;
using WpfProjektSemestralny.Scripts;


namespace WpfProjektSemestralny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StoreEntities db = new StoreEntities();
        User userControl = new User();

        public MainWindow()
        {
            InitializeComponent();
            userGridControl.ItemsSource = db.Users.ToList();
        }

        private void btnAddUserWindow_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();
        }
        private void userGridControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = userGridControl.SelectedItem as Users;
            UserUpdateWindow userUpdateWindow = new UserUpdateWindow(selectedItem);
            userUpdateWindow.ShowDialog();
        }

        private void btnRemoveUserWindow_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = userGridControl.SelectedItem as Users;

            if(selectedItem != null)
            {
                userControl.Delete(selectedItem.UserID);
                userGridControl.ItemsSource = db.Users.ToList();
                userGridControl.Items.Refresh();
            }
        }

        private void btnRefreshUser_Click(object sender, RoutedEventArgs e)
        {
            userGridControl.ItemsSource = db.Users.ToList();
            userGridControl.Items.Refresh();
        }

       
    }
}
