using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UptechSol
{
    /// <summary>
    /// Interaction logic for AttendenceAdd.xaml
    /// </summary>
    public partial class AttendenceAdd : Window
    {
        public AttendenceAdd()
        {
            InitializeComponent();
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string Datee = datee.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            string id = idTxtBox.Text;
            int idd = int.Parse(id);
            try
            {
                string connStr = "server=localhost;user=root;database=uptechsol;password=qwerty@123";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = "INSERT INTO attendance (Date,Status,Employee_idEmployee) VALUES (@date,@status,@empid)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@date", Datee);
                    cmd.Parameters.AddWithValue("@status", statusTxtBx.Text);
                    cmd.Parameters.AddWithValue("@empid", idd);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
