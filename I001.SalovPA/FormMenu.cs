using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I001.SalovPA
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void buttonDelUser_Click(object sender, EventArgs e)
        {
            FormDell formdell = new FormDell();
            formdell.Show();
            this.Hide();
        }

        private void buttonReadUser_Click(object sender, EventArgs e)
        {
            FormView formView = new FormView();
            formView.Show();
            this.Hide();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            FormCreate formCreate = new FormCreate();
            formCreate.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUpdate formUpdate = new FormUpdate();
            formUpdate.Show();
            this.Hide();
        }
    }
}
