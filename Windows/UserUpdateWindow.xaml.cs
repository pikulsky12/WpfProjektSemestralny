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
using System.Windows.Shapes;
using WpfProjektSemestralny.Data;
using WpfProjektSemestralny.Scripts;

namespace WpfProjektSemestralny.Windows
{
    /// <summary>
    /// Interaction logic for UserUpdateWindow.xaml
    /// </summary>
    public partial class UserUpdateWindow : Window
    {
        User userControl = new User();
        private int id;
        public UserUpdateWindow(Users _user)
        {
            InitializeComponent();
            id = _user.UserID;
            textBoxUserName.Text = _user.UserName;
            textBoxPassword.Text = _user.Password;
            textBoxPhoneNumber.Text = _user.PhoneNumber;
            textBoxBankName.Text = _user.BankName; 
            textBoxBankAccountNumber.Text = _user.BankAccountNumber;
        }

        private bool Save()
        {
            if (Validation() == true)
            {
                Users user = new Users()
                {
                    UserID = id,
                    UserName = textBoxUserName.Text,
                    Password = textBoxPassword.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    BankName = textBoxBankName.Text,
                    BankAccountNumber = textBoxBankAccountNumber.Text
                };

                userControl.Update(user);
                return true;
            }
            return false;
        }
        private bool Validation()
        {
            if (String.IsNullOrEmpty(textBoxUserName.Text))
            {
                if (MessageBox.Show("No name!", "Name", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                if (MessageBox.Show("No password!", "Password", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!AtLeastOneDigit(textBoxPassword.Text))
            {
                if (MessageBox.Show("Add numbers to boost password security", "Password", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (IsDigitsOnly(textBoxPassword.Text))
            {
                if (MessageBox.Show("Password is too weak!", "Password", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxPassword.Text.Length < 8)
            {
                if (MessageBox.Show("Password is too short!", "Password", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                if (MessageBox.Show("No Phone Number!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!IsDigitsOnly(textBoxPhoneNumber.Text))
            {
                if (MessageBox.Show("Phone number contains 9 digits. Enter correct data!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxPhoneNumber.Text.Length != 9)
            {
                if (MessageBox.Show("Phone number contains 9 digits. Enter correct data!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxBankName.Text))
            {
                if (MessageBox.Show("No Bank Name!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxBankAccountNumber.Text))
            {
                if (MessageBox.Show("No Bank Account Number!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!IsDigitsOnly(textBoxBankAccountNumber.Text))
            {
                if (MessageBox.Show("Bank Account contains 26 digits. Enter correct data!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxBankAccountNumber.Text.Length != 26)
            {
                if (MessageBox.Show("Bank Account contains 26 digits. Enter correct data!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            return true;
        }

        public bool IsDigitsOnly(string dane)
        {
            foreach (char c in dane)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool AtLeastOneDigit(string dane)
        {
            foreach (char c in dane)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (Save() == true)
            {
                this.Close();
            }
        }
    }
}
