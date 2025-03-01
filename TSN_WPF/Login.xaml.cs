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

    }
}
