using MySql;
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

namespace UptechSol
{
    /// <summary>
    /// Interaction logic for employeeAdd.xaml
    /// </summary>
    public partial class employeeAdd : Window
    {
        public employeeAdd()
        {
            InitializeComponent();
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void empAddBtn_Click(object sender, RoutedEventArgs e)
        {
            string Datee = bdate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            MessageBox.Show(Datee);
                string connStr = "server=localhost;user=root;database=demodb;password=qwerty@123";
            try {
                MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
                string sql = "INSERT INTO employee (emp_fname,emp_lname,emp_dob) VALUES (@fname,@lname,@dob)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fname", nameTxtBox.Text);
                    cmd.Parameters.AddWithValue("@lname", nameTxtBox.Text);
                    cmd.Parameters.AddWithValue("@dob", Datee);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                } }
            catch(Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            }
    }
}
        

