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
    public partial class FormUpdate : Form
    {
        public string pass;
        public FormUpdate()
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                if (textBoxEnterID.Text == "")
                {
                    MessageBox.Show("Введите ID пользователя у которого хотите изменить данные");
                }
                else
                {
                    if (textBoxName.Text == "" || textBoxLogin.Text == "" || textBoxPassword.Text == "")
                    {
                        MessageBox.Show("Заполните все данные");
                    }
                    if (comboBoxTypeUser.Text == "Админ" || comboBoxTypeUser.Text == "Пользователь")
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmdName = con.CreateCommand();
                            SqlCommand cmdPassword = con.CreateCommand();
                            SqlCommand cmdlogin = con.CreateCommand();
                            SqlCommand cmdisadmin = con.CreateCommand();
                            int IdUser = Convert.ToInt32(textBoxEnterID.Text);
                            cmdName.CommandText = "update users Set name ='" + textBoxName.Text + "'where id = '" + IdUser + "'";
                            cmdlogin.CommandText = "update users Set login ='" + textBoxLogin.Text + "'where id ='" + IdUser + "'";
                            cmdPassword.CommandText = "update users Set password ='" + textBoxPassword.Text + "'where id ='" + IdUser + "'";
                            cmdisadmin.CommandText = "update users Set isadmin ='" + comboBoxTypeUser.SelectedIndex + "'where id ='" + IdUser + "'";
                            // Подверждение изменения данных
                            DialogResult result = MessageBox.Show("Изменить данные?", "Изменение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.Yes)
                            {
                                cmdName.ExecuteNonQuery();
                                cmdlogin.ExecuteNonQuery();
                                cmdPassword.ExecuteNonQuery();
                                cmdisadmin.ExecuteNonQuery();
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
                    else
                    {
                        MessageBox.Show("Введен неверный тип пользователя");
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
