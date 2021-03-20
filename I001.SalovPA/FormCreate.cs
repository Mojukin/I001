using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I001.SalovPA
{
    public partial class FormCreate : Form
    {
        public FormCreate()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form back = Application.OpenForms[0];
            back.Show();
            this.Close();
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != "" || textBoxName.Text != "" || textBoxPassword.Text != "")
            {
                if (comboBoxTypeUser.Text == "Админ" || comboBoxTypeUser.Text == "Пользователь")
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmdUsers = con.CreateCommand();
                            cmdUsers.CommandText = "insert into [users] values ('" + textBoxName.Text + "','" + textBoxLogin.Text + "','" + textBoxPassword.Text + "','" + comboBoxTypeUser.SelectedIndex + "')";
                            cmdUsers.ExecuteNonQuery();
                            MessageBox.Show("Пользователь успешно добавлен");

                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Данный логин уже существует");
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введен неверный тип пользователя");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
           
        }

        private void textBoxPassword_Validated(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxPassword.Text, @"(?=^.{6,}$)((?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$)"))
            {
                MessageBox.Show("Не верно введен пароль!\nПароль должен содежать более: 6 символов, минимум 1 строчную, минимум 1 прописную, минимум 1 цифру");
            }
        }
    }
}
