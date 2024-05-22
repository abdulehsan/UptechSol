using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MySql;
using MySql.Data.MySqlClient;

namespace UptechSol
{
    /// <summary>
    /// Interaction logic for adminDashboard.xaml
    /// </summary>
    public partial class adminDashboard : Window
    {
        public adminDashboard()
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
    }
    }
