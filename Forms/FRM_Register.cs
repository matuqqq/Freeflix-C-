using System;
using System.Drawing;
using System.Windows.Forms;
using Freeflix.Services;
using Freeflix.Models;

namespace Freeflix.Forms
{
    public partial class FRM_Register : Form
    {
        private System.Windows.Forms.Panel PNL_RegisterContainer;
        private System.Windows.Forms.TextBox TXT_Username;
        private System.Windows.Forms.TextBox TXT_Email;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.TextBox TXT_ConfirmPassword;
        private System.Windows.Forms.Button BTN_Register;
        private System.Windows.Forms.Button BTN_BackToLogin;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Label LBL_Username;
        private System.Windows.Forms.Label LBL_Email;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.Label LBL_ConfirmPassword;
        private System.Windows.Forms.Label LBL_Error;
        private System.Windows.Forms.PictureBox PIC_Logo;

        public FRM_Register()
        {
            InitializeComponent();
            SetupNetflixDesign();
        }

        private void InitializeComponent()
        {
            PNL_RegisterContainer = new System.Windows.Forms.Panel();
            PIC_Logo = new System.Windows.Forms.PictureBox();
            LBL_Title = new System.Windows.Forms.Label();
            LBL_Username = new System.Windows.Forms.Label();
            TXT_Username = new System.Windows.Forms.TextBox();
            LBL_Email = new System.Windows.Forms.Label();
            TXT_Email = new System.Windows.Forms.TextBox();
            LBL_Password = new System.Windows.Forms.Label();
            TXT_Password = new System.Windows.Forms.TextBox();
            LBL_ConfirmPassword = new System.Windows.Forms.Label();
            TXT_ConfirmPassword = new System.Windows.Forms.TextBox();
            BTN_Register = new System.Windows.Forms.Button();
            BTN_BackToLogin = new System.Windows.Forms.Button();
            LBL_Error = new System.Windows.Forms.Label();
            PNL_RegisterContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PIC_Logo).BeginInit();
            SuspendLayout();
            // 
            // PNL_RegisterContainer
            // 
            PNL_RegisterContainer.Controls.Add(PIC_Logo);
            PNL_RegisterContainer.Controls.Add(LBL_Title);
            PNL_RegisterContainer.Controls.Add(LBL_Username);
            PNL_RegisterContainer.Controls.Add(TXT_Username);
            PNL_RegisterContainer.Controls.Add(LBL_Email);
            PNL_RegisterContainer.Controls.Add(TXT_Email);
            PNL_RegisterContainer.Controls.Add(LBL_Password);
            PNL_RegisterContainer.Controls.Add(TXT_Password);
            PNL_RegisterContainer.Controls.Add(LBL_ConfirmPassword);
            PNL_RegisterContainer.Controls.Add(TXT_ConfirmPassword);
            PNL_RegisterContainer.Controls.Add(BTN_Register);
            PNL_RegisterContainer.Controls.Add(BTN_BackToLogin);
            PNL_RegisterContainer.Controls.Add(LBL_Error);
            PNL_RegisterContainer.Location = new Point(40, 50);
            PNL_RegisterContainer.Name = "PNL_RegisterContainer";
            PNL_RegisterContainer.Size = new Size(320, 500);
            PNL_RegisterContainer.BackColor = Color.FromArgb(35, 35, 35);
            PNL_RegisterContainer.BorderStyle = BorderStyle.None;
            PNL_RegisterContainer.TabIndex = 0;
            // 
            // PIC_Logo
            // 
            PIC_Logo.Location = new Point(110, 20);
            PIC_Logo.Name = "PIC_Logo";
            PIC_Logo.Size = new Size(100, 40);
            PIC_Logo.BackColor = Color.Transparent;
            PIC_Logo.SizeMode = PictureBoxSizeMode.CenterImage;
            PIC_Logo.TabIndex = 0;
            PIC_Logo.TabStop = false;
            // 
            // LBL_Title
            // 
            LBL_Title.Location = new Point(10, 70);
            LBL_Title.Name = "LBL_Title";
            LBL_Title.Size = new Size(300, 40);
            LBL_Title.Text = "REGISTRO";
            LBL_Title.Font = new Font("Arial", 24, FontStyle.Bold);
            LBL_Title.ForeColor = Color.FromArgb(229, 9, 20);
            LBL_Title.TextAlign = ContentAlignment.MiddleCenter;
            LBL_Title.TabIndex = 1;
            // 
            // LBL_Username
            // 
            LBL_Username.Location = new Point(20, 130);
            LBL_Username.Name = "LBL_Username";
            LBL_Username.Size = new Size(280, 20);
            LBL_Username.Text = "Usuario:";
            LBL_Username.Font = new Font("Arial", 10, FontStyle.Regular);
            LBL_Username.ForeColor = Color.White;
            LBL_Username.TabIndex = 2;
            // 
            // TXT_Username
            // 
            TXT_Username.Location = new Point(20, 155);
            TXT_Username.Name = "TXT_Username";
            TXT_Username.Size = new Size(280, 30);
            TXT_Username.Font = new Font("Arial", 12);
            TXT_Username.BackColor = Color.FromArgb(50, 50, 50);
            TXT_Username.ForeColor = Color.White;
            TXT_Username.BorderStyle = BorderStyle.FixedSingle;
            TXT_Username.TabIndex = 3;
            // 
            // LBL_Email
            // 
            LBL_Email.Location = new Point(20, 190);
            LBL_Email.Name = "LBL_Email";
            LBL_Email.Size = new Size(280, 20);
            LBL_Email.Text = "Email:";
            LBL_Email.Font = new Font("Arial", 10, FontStyle.Regular);
            LBL_Email.ForeColor = Color.White;
            LBL_Email.TabIndex = 4;
            // 
            // TXT_Email
            // 
            TXT_Email.Location = new Point(20, 215);
            TXT_Email.Name = "TXT_Email";
            TXT_Email.Size = new Size(280, 30);
            TXT_Email.Font = new Font("Arial", 12);
            TXT_Email.BackColor = Color.FromArgb(50, 50, 50);
            TXT_Email.ForeColor = Color.White;
            TXT_Email.BorderStyle = BorderStyle.FixedSingle;
            TXT_Email.TabIndex = 5;
            // 
            // LBL_Password
            // 
            LBL_Password.Location = new Point(20, 250);
            LBL_Password.Name = "LBL_Password";
            LBL_Password.Size = new Size(280, 20);
            LBL_Password.Text = "Contraseña:";
            LBL_Password.Font = new Font("Arial", 10, FontStyle.Regular);
            LBL_Password.ForeColor = Color.White;
            LBL_Password.TabIndex = 6;
            // 
            // TXT_Password
            // 
            TXT_Password.Location = new Point(20, 275);
            TXT_Password.Name = "TXT_Password";
            TXT_Password.Size = new Size(280, 30);
            TXT_Password.Font = new Font("Arial", 12);
            TXT_Password.BackColor = Color.FromArgb(50, 50, 50);
            TXT_Password.ForeColor = Color.White;
            TXT_Password.BorderStyle = BorderStyle.FixedSingle;
            TXT_Password.UseSystemPasswordChar = true;
            TXT_Password.TabIndex = 7;
            // 
            // LBL_ConfirmPassword
            // 
            LBL_ConfirmPassword.Location = new Point(20, 310);
            LBL_ConfirmPassword.Name = "LBL_ConfirmPassword";
            LBL_ConfirmPassword.Size = new Size(280, 20);
            LBL_ConfirmPassword.Text = "Confirmar Contraseña:";
            LBL_ConfirmPassword.Font = new Font("Arial", 10, FontStyle.Regular);
            LBL_ConfirmPassword.ForeColor = Color.White;
            LBL_ConfirmPassword.TabIndex = 8;
            // 
            // TXT_ConfirmPassword
            // 
            TXT_ConfirmPassword.Location = new Point(20, 335);
            TXT_ConfirmPassword.Name = "TXT_ConfirmPassword";
            TXT_ConfirmPassword.Size = new Size(280, 30);
            TXT_ConfirmPassword.Font = new Font("Arial", 12);
            TXT_ConfirmPassword.BackColor = Color.FromArgb(50, 50, 50);
            TXT_ConfirmPassword.ForeColor = Color.White;
            TXT_ConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            TXT_ConfirmPassword.UseSystemPasswordChar = true;
            TXT_ConfirmPassword.TabIndex = 9;
            // 
            // BTN_Register
            // 
            BTN_Register.Location = new Point(20, 385);
            BTN_Register.Name = "BTN_Register";
            BTN_Register.Size = new Size(280, 40);
            BTN_Register.Text = "REGISTRARSE";
            BTN_Register.Font = new Font("Arial", 12, FontStyle.Bold);
            BTN_Register.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Register.ForeColor = Color.White;
            BTN_Register.FlatStyle = FlatStyle.Flat;
            BTN_Register.Cursor = Cursors.Hand;
            BTN_Register.FlatAppearance.BorderSize = 0;
            BTN_Register.TabIndex = 10;
            BTN_Register.Click += BTN_Register_Click;
            // 
            // BTN_BackToLogin
            // 
            BTN_BackToLogin.Location = new Point(20, 435);
            BTN_BackToLogin.Name = "BTN_BackToLogin";
            BTN_BackToLogin.Size = new Size(280, 40);
            BTN_BackToLogin.Text = "VOLVER AL LOGIN";
            BTN_BackToLogin.Font = new Font("Arial", 12, FontStyle.Bold);
            BTN_BackToLogin.BackColor = Color.FromArgb(50, 50, 50);
            BTN_BackToLogin.ForeColor = Color.White;
            BTN_BackToLogin.FlatStyle = FlatStyle.Flat;
            BTN_BackToLogin.Cursor = Cursors.Hand;
            BTN_BackToLogin.FlatAppearance.BorderSize = 0;
            BTN_BackToLogin.TabIndex = 11;
            BTN_BackToLogin.Click += BTN_BackToLogin_Click;
            // 
            // LBL_Error
            // 
            LBL_Error.Location = new Point(20, 485);
            LBL_Error.Name = "LBL_Error";
            LBL_Error.Size = new Size(280, 40);
            LBL_Error.Text = "";
            LBL_Error.Font = new Font("Arial", 9, FontStyle.Regular);
            LBL_Error.ForeColor = Color.FromArgb(255, 100, 100);
            LBL_Error.TextAlign = ContentAlignment.MiddleCenter;
            LBL_Error.Visible = false;
            LBL_Error.TabIndex = 12;
            // 
            // FRM_Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(400, 600);
            Controls.Add(PNL_RegisterContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FRM_Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Freeflix - Registro";
            PNL_RegisterContainer.ResumeLayout(false);
            PNL_RegisterContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PIC_Logo).EndInit();
            ResumeLayout(false);
        }

        private void SetupNetflixDesign()
        {
            // Add rounded corners effect to container
            PNL_RegisterContainer.Paint += (sender, e) =>
            {
                var rect = PNL_RegisterContainer.ClientRectangle;
                using (var brush = new SolidBrush(Color.FromArgb(35, 35, 35)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            // Add hover effects to buttons
            BTN_Register.MouseEnter += (sender, e) =>
            {
                BTN_Register.BackColor = Color.FromArgb(200, 9, 20);
            };

            BTN_Register.MouseLeave += (sender, e) =>
            {
                BTN_Register.BackColor = Color.FromArgb(229, 9, 20);
            };

            BTN_BackToLogin.MouseEnter += (sender, e) =>
            {
                BTN_BackToLogin.BackColor = Color.FromArgb(60, 60, 60);
            };

            BTN_BackToLogin.MouseLeave += (sender, e) =>
            {
                BTN_BackToLogin.BackColor = Color.FromArgb(50, 50, 50);
            };
        }

        private void BTN_Register_Click(object sender, EventArgs e)
        {
            ValidateAndRegister();
        }

        private void BTN_BackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ValidateAndRegister()
        {
            string username = TXT_Username.Text.Trim();
            string email = TXT_Email.Text.Trim();
            string password = TXT_Password.Text;
            string confirmPassword = TXT_ConfirmPassword.Text;

            // Validaciones básicas
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ShowError("Por favor, complete todos los campos.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowError("Por favor, ingrese un email válido.");
                return;
            }

            if (password != confirmPassword)
            {
                ShowError("Las contraseñas no coinciden.");
                TXT_Password.Clear();
                TXT_ConfirmPassword.Clear();
                TXT_Password.Focus();
                return;
            }

            if (password.Length < 6)
            {
                ShowError("La contraseña debe tener al menos 6 caracteres.");
                TXT_Password.Clear();
                TXT_ConfirmPassword.Clear();
                TXT_Password.Focus();
                return;
            }

            // Intentar registrar el usuario
            var authService = AuthService.GetInstance();
            var newUser = new User(username, email, password);

            if (authService.RegisterUser(newUser))
            {
                MessageBox.Show("¡Registro exitoso! Ahora puede iniciar sesión.", 
                              "Registro Completado", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowError("El usuario o email ya existe.");
                TXT_Username.Focus();
            }
        }

        private void ShowError(string message)
        {
            LBL_Error.Text = message;
            LBL_Error.Visible = true;

            // Hide error after 3 seconds
            var timer = new System.Windows.Forms.Timer { Interval = 3000 };
            timer.Tick += (sender, e) =>
            {
                LBL_Error.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
} 