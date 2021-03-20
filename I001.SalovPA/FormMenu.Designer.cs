namespace I001.SalovPA
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonReadUser = new System.Windows.Forms.Button();
            this.buttonDelUser = new System.Windows.Forms.Button();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReadUser
            // 
            this.buttonReadUser.Location = new System.Drawing.Point(191, 67);
            this.buttonReadUser.Name = "buttonReadUser";
            this.buttonReadUser.Size = new System.Drawing.Size(127, 51);
            this.buttonReadUser.TabIndex = 0;
            this.buttonReadUser.Text = "Просмотреть пользователей";
            this.buttonReadUser.UseVisualStyleBackColor = true;
            this.buttonReadUser.Click += new System.EventHandler(this.buttonReadUser_Click);
            // 
            // buttonDelUser
            // 
            this.buttonDelUser.Location = new System.Drawing.Point(191, 319);
            this.buttonDelUser.Name = "buttonDelUser";
            this.buttonDelUser.Size = new System.Drawing.Size(127, 51);
            this.buttonDelUser.TabIndex = 1;
            this.buttonDelUser.Text = "Удалить пользователя";
            this.buttonDelUser.UseVisualStyleBackColor = true;
            this.buttonDelUser.Click += new System.EventHandler(this.buttonDelUser_Click);
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(191, 150);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(127, 51);
            this.buttonCreateUser.TabIndex = 2;
            this.buttonCreateUser.Text = "Добавить пользователя";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "Изменить данные пользователя";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.buttonDelUser);
            this.Controls.Add(this.buttonReadUser);
            this.Name = "FormMenu";
            this.Text = "Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadUser;
        private System.Windows.Forms.Button buttonDelUser;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.Button button1;
    }
}

