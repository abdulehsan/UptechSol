using MySql.Data.MySqlClient;
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


        private bool AuthenticateUser(string id, string password)
        {
            bool isAuthenticated = false;
            string connectionString = "server=localhost;user=root;database=sakila;port=3306;password=qwerty@123"; // Replace with your actual connection string

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT 1 FROM customer WHERE customer_id = @Id AND first_name = @Password LIMIT 1"; // Replace with your actual query
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Password", password);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isAuthenticated = true;
                }
            }

            return isAuthenticated;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string id = idTxtBox.Text;
            string password = passTxtBox.Password;           
           
            
            if((id == "admin")&&(password =="admin"))
            {
                adminDashboard adminDashboardWindow = new adminDashboard();
                adminDashboardWindow.Show();
                this.Close();
            }

            else if (AuthenticateUser(id, password))
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
        /*
        private bool IsMaximize = false;
        
         private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
         {
             if (e.ClickCount == 2)
             {
                 if (IsMaximize)
                 {
                     this.WindowState = WindowState.Normal;
                     this.Width = 300;
                     this.Height = 300;

                     IsMaximize = false;
                 }
                 else
                 {
                     this.WindowState = WindowState.Normal;

                     IsMaximize = true;
                 }
             }
         }
        */
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