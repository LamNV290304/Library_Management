using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username = string.Empty;
        private string _role = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            UpdateButtonVisibility();
        }
        private bool isLoggedIn = false; // You should replace this with your actual login status check


        private void UpdateButtonVisibility()
        {
            if (isLoggedIn)
            {
                btnManageBook.Visibility = Visibility.Visible;
                btnManageLoan.Visibility = Visibility.Visible;
                btnManageReservation.Visibility = Visibility.Visible;
                btnManageUser.Visibility = Visibility.Visible;
                btnLogin.Visibility = Visibility.Collapsed;
                btnRegister.Visibility = Visibility.Collapsed;
                btnLogout.Visibility = Visibility.Visible;
                WelcomeTextBlock.Text = "Xin chao, User!"; // Update welcome text
            }
            else
            {
                btnManageBook.Visibility = Visibility.Collapsed;
                btnManageLoan.Visibility = Visibility.Collapsed;
                btnManageReservation.Visibility = Visibility.Collapsed;
                btnManageUser.Visibility = Visibility.Collapsed;
                btnLogin.Visibility = Visibility.Visible;
                btnRegister.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Collapsed;
                WelcomeTextBlock.Text = "Xin chao!"; // Update welcome text
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Open the Login form as a dialog
            Login loginWindow = new Login();
            loginWindow.Owner = this;
            loginWindow.ShowDialog();

            // Check if the login was successful
            if (loginWindow.DialogResult == true)
            {
                isLoggedIn = true; // Set this based on actual login result
                UpdateButtonVisibility();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Open the Register form as a dialog
            Register registerWindow = new Register();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            isLoggedIn = false;
            UpdateButtonVisibility();
        }
    }
}
