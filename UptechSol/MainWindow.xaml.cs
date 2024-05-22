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

namespace UptechSol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if((idTxtBox.Text == "admin")&&(passTxtBox.Password =="admin"))
            {
                adminDashboard adminDashboardWindow = new adminDashboard();
                adminDashboardWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password or ID");
            }

            }
        private void closeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool IsMaximize = false;
        
         private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
         {
             if (e.ClickCount == 2)
             {
                 if (IsMaximize)
                 {
                     this.WindowState = WindowState.Normal;
                     this.Width = 1080;
                     this.Height = 720;

                     IsMaximize = false;
                 }
                 else
                 {
                     this.WindowState = WindowState.Maximized;

                     IsMaximize = true;
                 }
             }
         }
        
        
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}