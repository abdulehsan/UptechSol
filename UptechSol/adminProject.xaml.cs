using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace UptechSol
{
    /// <summary>
    /// Interaction logic for adminProject.xaml
    /// </summary>
    public partial class adminProject : Window
    {
        public adminProject()
        {
            InitializeComponent();
            string connStr = "server=localhost;user=root;database=sakila;port=3306;password=qwerty@123";
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();
            string sql = "SELECT customer_id as ID,first_name as FirstName,last_name as LastName,email as Email from customer";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            conn.Close();
            membersDataGrid.DataContext = dt;
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
        */

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        bool menuVisibility = true;
        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (menuVisibility)
            {
                tryy.Visibility = Visibility.Collapsed;
                menuVisibility = false;
                //menu.Height = new GridLength(0);
            }
            else
            {
                //   menu.Height = new GridLength(1);
                tryy.Visibility = Visibility.Visible;
                menuVisibility = true;
            }
        }
        
        private void clientWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            adminClient clientWindow = new adminClient();
            clientWindow.Show();
            this.Close();
        }

        private void financeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            adminFinance financeWindow = new adminFinance();
            financeWindow.Show();
            this.Close();
        }

        private void attendenceWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            adminAttendence attendenceWindow = new adminAttendence();
            attendenceWindow.Show();
            this.Close();
        }

        private void dashboardWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            adminDashboard dashboardWindow = new adminDashboard();
            dashboardWindow.Show();
            this.Close();
        }
    }
}
