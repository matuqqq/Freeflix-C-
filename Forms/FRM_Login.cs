using System;
using System.Drawing;
using System.Windows.Forms;
using Freeflix.Services;

namespace Freeflix.Forms
{
    /// <summary>
    /// Formulario de login con diseño tipo Netflix
    /// </summary>
    public partial class FRM_Login : Form
    {
        private Panel PNL_LoginContainer;
        private TextBox TXT_Username;
        private TextBox TXT_Password;
        private Button BTN_Login;
        private Button BTN_Register;
        private Label LBL_Title;
        private Label LBL_Username;
        private Label LBL_Password;
        private Label LBL_Error;
        private PictureBox PIC_Logo;

        public FRM_Login()
        {
            InitializeComponent();
            SetupNetflixDesign();
        }

        private void InitializeComponent()
        {
            PNL_LoginContainer = new Panel();
            PIC_Logo = new PictureBox();
            LBL_Title = new Label();
            LBL_Username = new Label();
            TXT_Username = new TextBox();
            LBL_Password = new Label();
            TXT_Password = new TextBox();
            BTN_Login = new Button();
            BTN_Register = new Button();
            LBL_Error = new Label();
            PNL_LoginContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PIC_Logo).BeginInit();
            SuspendLayout();
            // 
            // PNL_LoginContainer
            // 
            PNL_LoginContainer.Controls.Add(PIC_Logo);
            PNL_LoginContainer.Controls.Add(LBL_Title);
            PNL_LoginContainer.Controls.Add(LBL_Username);
            PNL_LoginContainer.Controls.Add(TXT_Username);
            PNL_LoginContainer.Controls.Add(LBL_Password);
            PNL_LoginContainer.Controls.Add(TXT_Password);
            PNL_LoginContainer.Controls.Add(BTN_Login);
            PNL_LoginContainer.Controls.Add(BTN_Register);
            PNL_LoginContainer.Controls.Add(LBL_Error);
            PNL_LoginContainer.Location = new Point(40, 50);
            PNL_LoginContainer.Name = "PNL_LoginContainer";
            PNL_LoginContainer.Size = new Size(320, 450);
            PNL_LoginContainer.BackColor = Color.FromArgb(35, 35, 35);
            PNL_LoginContainer.BorderStyle = BorderStyle.None;
            PNL_LoginContainer.TabIndex = 0;
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
            LBL_Title.Text = "FREEFLIX";
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
            // LBL_Password
            // 
            LBL_Password.Location = new Point(20, 200);
            LBL_Password.Name = "LBL_Password";
            LBL_Password.Size = new Size(280, 20);
            LBL_Password.Text = "Contraseña:";
            LBL_Password.Font = new Font("Arial", 10, FontStyle.Regular);
            LBL_Password.ForeColor = Color.White;
            LBL_Password.TabIndex = 4;
            // 
            // TXT_Password
            // 
            TXT_Password.Location = new Point(20, 225);
            TXT_Password.Name = "TXT_Password";
            TXT_Password.Size = new Size(280, 30);
            TXT_Password.Font = new Font("Arial", 12);
            TXT_Password.BackColor = Color.FromArgb(50, 50, 50);
            TXT_Password.ForeColor = Color.White;
            TXT_Password.BorderStyle = BorderStyle.FixedSingle;
            TXT_Password.UseSystemPasswordChar = true;
            TXT_Password.TabIndex = 5;
            TXT_Password.KeyPress += TXT_Password_KeyPress;
            // 
            // BTN_Login
            // 
            BTN_Login.Location = new Point(20, 280);
            BTN_Login.Name = "BTN_Login";
            BTN_Login.Size = new Size(280, 40);
            BTN_Login.Text = "INICIAR SESIÓN";
            BTN_Login.Font = new Font("Arial", 12, FontStyle.Bold);
            BTN_Login.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Login.ForeColor = Color.White;
            BTN_Login.FlatStyle = FlatStyle.Flat;
            BTN_Login.Cursor = Cursors.Hand;
            BTN_Login.FlatAppearance.BorderSize = 0;
            BTN_Login.TabIndex = 6;
            BTN_Login.Click += BTN_Login_Click;
            // 
            // BTN_Register
            // 
            BTN_Register.Location = new Point(20, 330);
            BTN_Register.Name = "BTN_Register";
            BTN_Register.Size = new Size(280, 40);
            BTN_Register.Text = "REGISTRARSE";
            BTN_Register.Font = new Font("Arial", 12, FontStyle.Bold);
            BTN_Register.BackColor = Color.FromArgb(50, 50, 50);
            BTN_Register.ForeColor = Color.White;
            BTN_Register.FlatStyle = FlatStyle.Flat;
            BTN_Register.Cursor = Cursors.Hand;
            BTN_Register.FlatAppearance.BorderSize = 0;
            BTN_Register.TabIndex = 7;
            BTN_Register.Click += BTN_Register_Click;
            // 
            // LBL_Error
            // 
            LBL_Error.Location = new Point(20, 380);
            LBL_Error.Name = "LBL_Error";
            LBL_Error.Size = new Size(280, 40);
            LBL_Error.Text = "";
            LBL_Error.Font = new Font("Arial", 9, FontStyle.Regular);
            LBL_Error.ForeColor = Color.FromArgb(255, 100, 100);
            LBL_Error.TextAlign = ContentAlignment.MiddleCenter;
            LBL_Error.Visible = false;
            LBL_Error.TabIndex = 8;
            // 
            // FRM_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(400, 550);
            Controls.Add(PNL_LoginContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FRM_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Freeflix - Iniciar Sesión";
            PNL_LoginContainer.ResumeLayout(false);
            PNL_LoginContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PIC_Logo).EndInit();
            ResumeLayout(false);
        }

        private void SetupNetflixDesign()
        {
            // Add rounded corners effect to container
            PNL_LoginContainer.Paint += (sender, e) =>
            {
                var rect = PNL_LoginContainer.ClientRectangle;
                using (var brush = new SolidBrush(Color.FromArgb(35, 35, 35)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            // Add hover effects to buttons
            BTN_Login.MouseEnter += (sender, e) =>
            {
                BTN_Login.BackColor = Color.FromArgb(200, 9, 20);
            };

            BTN_Login.MouseLeave += (sender, e) =>
            {
                BTN_Login.BackColor = Color.FromArgb(229, 9, 20);
            };

            BTN_Register.MouseEnter += (sender, e) =>
            {
                BTN_Register.BackColor = Color.FromArgb(60, 60, 60);
            };

            BTN_Register.MouseLeave += (sender, e) =>
            {
                BTN_Register.BackColor = Color.FromArgb(50, 50, 50);
            };

            // Set default values for testing
            TXT_Username.Text = "admin";
            TXT_Password.Text = "admin123";
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void BTN_Register_Click(object sender, EventArgs e)
        {
            var registerForm = new FRM_Register();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                // Si el registro fue exitoso, limpiar los campos
                TXT_Username.Clear();
                TXT_Password.Clear();
                TXT_Username.Focus();
            }
        }

        private void TXT_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateLogin();
            }
        }

        private void ValidateLogin()
        {
            string username = TXT_Username.Text.Trim();
            string password = TXT_Password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Por favor, complete todos los campos.");
                return;
            }

            var authService = AuthService.GetInstance();
            var user = authService.Authenticate(username, password);

            if (user != null)
            {
                ShowMainForm();
            }
            else
            {
                ShowError("Usuario o contraseña incorrectos.");
                TXT_Password.Clear();
                TXT_Password.Focus();
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

        private void ShowMainForm()
        {
            var mainForm = new FRM_Main();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
            this.Hide();
        }
    }
}