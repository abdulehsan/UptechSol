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
    /// Interaction logic for adminFinance.xaml
    /// </summary>
    public partial class adminFinance : Window
    {
        public adminFinance()
        {
            InitializeComponent();
            string connStr = "server=localhost;user=root;database=uptechsol;port=3306;password=qwerty@123";
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();
                string sql = "SELECT e.idEmployee AS EmployeeID,f.Salary AS Salary, p.P_no AS ProjectID, p.P_name AS ProjectName,p.Budget AS Budget FROM Employee e INNER JOIN Finance f ON e.idEmployee = f.Employee_idEmployee INNER JOIN Employee_has_Project ep ON e.idEmployee = ep.Employee_idEmployee INNER JOIN Project p ON ep.Project_P_no = p.P_no;\r\n";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                conn.Close();
                membersDataGrid.DataContext = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot retrieve a data from database");
            }
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

        private void projectWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            adminProject projectWindow = new adminProject();
            projectWindow.Show();
            this.Close();
        }

        private void clientWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            adminClient clientWindow = new adminClient();
            clientWindow.Show();
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FinanceAdd salaryaddwindow = new FinanceAdd();
            salaryaddwindow.Show();
        }
    }
}
