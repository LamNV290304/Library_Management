using Library.Models;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LibraryContext context = new LibraryContext();

        // Properties to pass username and role to the MainWindow after successful login
        public string UserName { get; private set; } = string.Empty;
        public string Role { get; private set; } = string.Empty;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Validate that the inputs are not null or empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username và mật khẩu không được để trống.");
                return;
            }

            // Validate user against the database
            var user = ValidateUser(username, password);

            if (user != null)
            {
                // Set the properties to pass to MainWindow
                UserName = user.Username;
                Role = user.Role;

                // Indicate success and close the login window
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Username hoặc mật khẩu sai.");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Register form as a dialog
            Register registerWindow = new Register();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
        }

        private User? ValidateUser(string username, string password)
        {
            // Replace with actual database check
            return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
