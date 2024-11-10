using System.Windows;
using Library;
using Library.Models;   

namespace Library
{
    public partial class MainWindow : Window
    {
       
        private bool isLoggedIn = false;
        private User? _loggedInUser;

        public MainWindow()
        {
            InitializeComponent();
            UpdateButtonVisibility();
        }

        // Handles login event
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Open login window
            Login loginWindow = new Login();
            loginWindow.Owner = this;
            loginWindow.ShowDialog();

            // Check if the user logged in successfully
            if (loginWindow.DialogResult == true && loginWindow.LoggedInUser != null)
            {
                _loggedInUser = loginWindow.LoggedInUser; // Store the entire User object
                UpdateButtonVisibility(); // Update UI based on logged-in user

                // Navigate based on the role of the logged-in user
                if (_loggedInUser.Role == "User")
                {
                    MainContentFrame.Navigate(new SearchBook());
                }
                else
                {
                    // Admin or other roles can have management buttons visible
                    btnManageBook.Visibility = Visibility.Visible;
                    btnManageLoan.Visibility = Visibility.Visible;
                    btnManageReservation.Visibility = Visibility.Visible;
                    btnManageUser.Visibility = Visibility.Visible;
                }
            }
        }

        private void UpdateButtonVisibility()
        {
            if (_loggedInUser != null) // Check if user is logged in
            {
                btnLogin.Visibility = Visibility.Collapsed;
                btnRegister.Visibility = Visibility.Collapsed;
                btnLogout.Visibility = Visibility.Visible;
                WelcomeTextBlock.Text = $"Welcome, {_loggedInUser.Username}!";

                if (_loggedInUser.Role == "User")
                {
                    // Hide management buttons for regular users
                    btnManageBook.Visibility = Visibility.Collapsed;
                    btnManageLoan.Visibility = Visibility.Collapsed;
                    btnManageReservation.Visibility = Visibility.Collapsed;
                    btnManageUser.Visibility = Visibility.Collapsed;
                }
                else
                {
                    // Admin or other roles can have management buttons visible
                    btnManageBook.Visibility = Visibility.Visible;
                    btnManageLoan.Visibility = Visibility.Visible;
                    btnManageReservation.Visibility = Visibility.Visible;
                    btnManageUser.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // If not logged in, show login/register buttons
                btnLogin.Visibility = Visibility.Visible;
                btnRegister.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Collapsed;
                WelcomeTextBlock.Text = "Welcome, Guest!";
                MainContentFrame.Content = null; // Clear the frame when logged out
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
        }




        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;
            UpdateButtonVisibility();
        }

        // Navigate to ManageLoan when clicked
        private void btnManageLoan_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                // Pass the UserId to ManageLoan page
                ManageLoan manageLoanPage = new ManageLoan(_loggedInUser);
                MainContentFrame.Navigate(manageLoanPage);  // Navigate to the ManageLoan page
            }
            else
            {
                MessageBox.Show("You must be logged in to manage loans.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

