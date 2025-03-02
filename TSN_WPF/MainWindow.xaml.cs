using System.Collections.ObjectModel;
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

namespace TSN_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ChatMessage> Messages { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Messages = new ObservableCollection<ChatMessage>();
            lstMessages.ItemsSource = Messages;
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                Messages.Add(new ChatMessage
                {
                    Message = txtMessage.Text,
                    Time = DateTime.Now.ToString("hh:mm tt") // Format time as "12:30 PM"
                });

                txtMessage.Clear();
                lstMessages.ScrollIntoView(Messages[Messages.Count - 1]); // Auto-scroll
            }
        }
    }

    public class ChatMessage
    {
        public string Message { get; set; }
        public string Time { get; set; }
    }
}