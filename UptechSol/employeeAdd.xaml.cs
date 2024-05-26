using MySql;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
            string bDatee = bdate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            string ID = idTxtBox.Text;
            int empID = int.Parse(ID);
            string jDatee = bdate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            
            try {
                string connStr = "server=localhost;user=root;database=demodb;password=qwerty@123";
                MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
                string sql = "INSERT INTO UptechSol.Employee (idEmployee, Name, Gender, DOJ, DOB, Address) VALUES (@ID,@name,@Gender,@doj,@dob,@address)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", empID);
                    cmd.Parameters.AddWithValue("@name", nameTxtBox.Text);
                    cmd.Parameters.AddWithValue("@Gender", genderBox.Text);
                    cmd.Parameters.AddWithValue("@doj", jDatee);
                    cmd.Parameters.AddWithValue("@dob", bDatee);
                    cmd.Parameters.AddWithValue("@address", addressTxtBox.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Added");
                    this.Close();
                } 
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
        

