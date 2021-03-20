using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I001.SalovPA
{
    public partial class FormView : Form
    {
        public FormView()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form back = Application.OpenForms[0];
            back.Show();
            this.Close();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    string connectString = @"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd";

                    SqlConnection myConnection = new SqlConnection(connectString);

                    myConnection.Open();

                    string query = "SELECT * FROM users";

                    SqlCommand command = new SqlCommand(query, myConnection);

                    SqlDataReader reader = command.ExecuteReader();

                    List<string[]> data = new List<string[]>();

                    while (reader.Read())
                    {
                        data.Add(new string[5]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();
                    }

                    reader.Close();

                    myConnection.Close();

                    foreach (string[] s in data)
                        dataGridView1.Rows.Add(s);
                }
                catch (SqlException)
                {
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
