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
    public partial class FormDell : Form
    {
        public FormDell()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form back = Application.OpenForms[0];
            back.Show();
            this.Close();
        }

        private void buttonView_Click(object sender, EventArgs e)
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

                    dataGridView1.Rows.Clear();

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

        private void buttonDell_Click(object sender, EventArgs e)
        {
            //Проверка на ввод ID мастера
            if (textBoxEnterID.Text == "")
            {
                DialogResult result = MessageBox.Show("Введите ID пользователя которого хотите удалить", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                    textBoxEnterID.Focus();
            }
            //Выполнение удаления мастера, если он введен
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
                {
                    try
                    {
                        int IdUser = Convert.ToInt32(textBoxEnterID.Text);
                        con.Open();
                        SqlCommand cmdUsers = con.CreateCommand();
                        //Удаление данных мастера
                        cmdUsers.CommandText = "DELETE users where id = " + IdUser;
                        //Подверждение удаления мастера
                        DialogResult result = MessageBox.Show("Удалить пользователя?", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        if (result == DialogResult.Yes)
                        {
                            cmdUsers.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Convert.ToString(ex));
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        private void textBoxEnterID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
