using System;
using System.Windows;
using System.Windows.Media;
using TSN_WPF;

namespace TSN_Wpf
{
    public partial class Login : Window
    {
        private FirebaseAuthService authService = new FirebaseAuthService();

        public Login()
        {
            InitializeComponent();

            // Set username placeholder
            txtUsername.Foreground = Brushes.Gray;
            txtPassword.Foreground = Brushes.Gray;
            txtUsername.Text = "Insert Username";
            txtPassword.Password = "Insert Password";

            txtUsername.GotFocus += (s, e) =>
            {
                if (txtUsername.Text == "Insert Username")
                {
                    txtUsername.Text = "";
                    txtUsername.Foreground = Brushes.Black;
                }
            };
            txtPassword.GotFocus += (s, e) =>
            {
                if (txtPassword.Password == "Insert Password")
                {
                    txtPassword.Password = "";
                    txtPassword.Foreground = Brushes.Black;
                }
            };
            txtUsername.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Text = "Insert Username";
                    txtUsername.Foreground = Brushes.Gray;
                }
            };
            txtPassword.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    txtPassword.Password = "Insert Password";
                    txtPassword.Foreground = Brushes.Gray;
                }
            };
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUsername.Text;
            string password = txtPassword.Password;

            string result = await authService.RegisterUserAsync(email, password);

            if (result.StartsWith("Error"))
            {
                this.lblMessage.Foreground = Brushes.Red;
                lblMessage.Text = "Registration Failed: " + result;
            }
            else
            {
                this.lblMessage.Foreground = Brushes.Green;
                lblMessage.Text = "Registration Successful!";
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            FirebaseAuthService authService = new FirebaseAuthService();
            string result = await authService.LoginUserAsync(txtUsername.Text, txtPassword.Password);

            if (!result.StartsWith("Error"))
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();   
                // Navigate to dashboard
            }
            else
            {
                MessageBox.Show(result); // Show error message
            }
        }

        private async void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string result = await authService.SendPasswordResetEmailAsync(email);

            if (result.StartsWith("Error"))
            {
                MessageBox.Show("Failed to send password reset email: " + result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("A password reset link has been sent to your email.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool isPasswordVisible = false;

        private void btnShowHidePassword_Click(object sender, RoutedEventArgs e)
        {
            if (isPasswordVisible)
            {
                // Show PasswordBox, Hide TextBox
                txtPassword.Visibility = Visibility.Visible;
                txtVisiblePassword.Visibility = Visibility.Collapsed;
                txtPassword.Password = txtVisiblePassword.Text;
            }
            else
            {
                // Show TextBox, Hide PasswordBox
                txtPassword.Visibility = Visibility.Collapsed;
                txtVisiblePassword.Visibility = Visibility.Visible;
                txtVisiblePassword.Text = txtPassword.Password;
            }

            isPasswordVisible = !isPasswordVisible;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtVisiblePassword.Text = txtPassword.Password;
        }

        private async Task ForotPassword_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string result = await authService.SendPasswordResetEmailAsync(email);

            if (result.StartsWith("Error"))
            {
                MessageBox.Show("Failed to send password reset email: " + result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("A password reset link has been sent to your email.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
