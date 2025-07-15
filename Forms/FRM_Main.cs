using System;
using System.Drawing;
using System.Windows.Forms;
using Freeflix.Services;
using Freeflix.Models;

namespace Freeflix.Forms
{
    /// <summary>
    /// Formulario principal con navegación tipo Netflix
    /// </summary>
    public partial class FRM_Main : Form
    {
        private Panel PNL_Navigation;
        private Panel PNL_Content;
        private Button BTN_Movies;
        private Button BTN_Series;
        private Button BTN_Admin;
        private Button BTN_Logout;
        private Label LBL_Welcome;
        private BaseUser currentUser;

        public FRM_Main()
        {
            InitializeComponent();
            LoadUserInterface();
        }

        private void InitializeComponent()
        {
            PNL_Navigation = new Panel();
            LBL_Welcome = new Label();
            BTN_Movies = new Button();
            BTN_Series = new Button();
            BTN_Admin = new Button();
            BTN_Logout = new Button();
            PNL_Content = new Panel();
            PNL_Navigation.SuspendLayout();
            SuspendLayout();
            // 
            // PNL_Navigation
            // 
            PNL_Navigation.Controls.Add(LBL_Welcome);
            PNL_Navigation.Controls.Add(BTN_Movies);
            PNL_Navigation.Controls.Add(BTN_Series);
            PNL_Navigation.Controls.Add(BTN_Admin);
            PNL_Navigation.Controls.Add(BTN_Logout);
            PNL_Navigation.Dock = DockStyle.Left;
            PNL_Navigation.Location = new Point(0, 0);
            PNL_Navigation.Name = "PNL_Navigation";
            PNL_Navigation.Size = new Size(200, 800);
            PNL_Navigation.BackColor = Color.FromArgb(35, 35, 35);
            PNL_Navigation.TabIndex = 0;
            // 
            // LBL_Welcome
            // 
            LBL_Welcome.Location = new Point(10, 20);
            LBL_Welcome.Name = "LBL_Welcome";
            LBL_Welcome.Size = new Size(180, 50);
            LBL_Welcome.Text = "Bienvenido";
            LBL_Welcome.Font = new Font("Arial", 12, FontStyle.Bold);
            LBL_Welcome.ForeColor = Color.White;
            LBL_Welcome.TextAlign = ContentAlignment.MiddleCenter;
            LBL_Welcome.TabIndex = 0;
            // 
            // BTN_Movies
            // 
            BTN_Movies.Location = new Point(10, 100);
            BTN_Movies.Name = "BTN_Movies";
            BTN_Movies.Size = new Size(180, 40);
            BTN_Movies.Text = "PELÍCULAS";
            BTN_Movies.Font = new Font("Arial", 10, FontStyle.Bold);
            BTN_Movies.BackColor = Color.FromArgb(60, 60, 60);
            BTN_Movies.ForeColor = Color.White;
            BTN_Movies.FlatStyle = FlatStyle.Flat;
            BTN_Movies.Cursor = Cursors.Hand;
            BTN_Movies.FlatAppearance.BorderSize = 0;
            BTN_Movies.TabIndex = 1;
            BTN_Movies.Click += BTN_Movies_Click;
            // 
            // BTN_Series
            // 
            BTN_Series.Location = new Point(10, 150);
            BTN_Series.Name = "BTN_Series";
            BTN_Series.Size = new Size(180, 40);
            BTN_Series.Text = "SERIES";
            BTN_Series.Font = new Font("Arial", 10, FontStyle.Bold);
            BTN_Series.BackColor = Color.FromArgb(60, 60, 60);
            BTN_Series.ForeColor = Color.White;
            BTN_Series.FlatStyle = FlatStyle.Flat;
            BTN_Series.Cursor = Cursors.Hand;
            BTN_Series.FlatAppearance.BorderSize = 0;
            BTN_Series.TabIndex = 2;
            BTN_Series.Click += BTN_Series_Click;
            // 
            // BTN_Admin
            // 
            BTN_Admin.Location = new Point(10, 200);
            BTN_Admin.Name = "BTN_Admin";
            BTN_Admin.Size = new Size(180, 40);
            BTN_Admin.Text = "ADMINISTRACIÓN";
            BTN_Admin.Font = new Font("Arial", 10, FontStyle.Bold);
            BTN_Admin.BackColor = Color.FromArgb(60, 60, 60);
            BTN_Admin.ForeColor = Color.White;
            BTN_Admin.FlatStyle = FlatStyle.Flat;
            BTN_Admin.Cursor = Cursors.Hand;
            BTN_Admin.FlatAppearance.BorderSize = 0;
            BTN_Admin.Visible = false;
            BTN_Admin.TabIndex = 3;
            BTN_Admin.Click += BTN_Admin_Click;
            // 
            // BTN_Logout
            // 
            BTN_Logout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BTN_Logout.Location = new Point(10, 700);
            BTN_Logout.Name = "BTN_Logout";
            BTN_Logout.Size = new Size(180, 40);
            BTN_Logout.Text = "CERRAR SESIÓN";
            BTN_Logout.Font = new Font("Arial", 10, FontStyle.Bold);
            BTN_Logout.BackColor = Color.FromArgb(60, 60, 60);
            BTN_Logout.ForeColor = Color.White;
            BTN_Logout.FlatStyle = FlatStyle.Flat;
            BTN_Logout.Cursor = Cursors.Hand;
            BTN_Logout.FlatAppearance.BorderSize = 0;
            BTN_Logout.TabIndex = 4;
            BTN_Logout.Click += BTN_Logout_Click;
            // 
            // PNL_Content
            // 
            PNL_Content.Dock = DockStyle.Fill;
            PNL_Content.Location = new Point(200, 0);
            PNL_Content.Name = "PNL_Content";
            PNL_Content.Size = new Size(1000, 800);
            PNL_Content.BackColor = Color.FromArgb(20, 20, 20);
            PNL_Content.TabIndex = 1;
            // 
            // FRM_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1200, 800);
            Controls.Add(PNL_Content);
            Controls.Add(PNL_Navigation);
            Name = "FRM_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Freeflix - Sistema de Gestión";
            WindowState = FormWindowState.Maximized;
            PNL_Navigation.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void LoadUserInterface()
        {
            var authService = AuthService.GetInstance();
            currentUser = authService.CurrentUser;

            if (currentUser != null)
            {
                LBL_Welcome.Text = $"Bienvenido\n{currentUser.Username}";
                CheckPermissions();
            }
        }

        private void CheckPermissions()
        {
            if (currentUser is Moderator)
            {
                BTN_Admin.Visible = true;
                BTN_Admin.BackColor = Color.FromArgb(229, 9, 20);
            }
            else
            {
                BTN_Admin.Visible = false;
            }
        }

        private void BTN_Movies_Click(object sender, EventArgs e)
        {
            LoadMoviesForm();
        }

        private void BTN_Series_Click(object sender, EventArgs e)
        {
            LoadSeriesForm();
        }

        private void BTN_Admin_Click(object sender, EventArgs e)
        {
            if (currentUser is Moderator)
            {
                LoadAdminForm();
            }
        }

        private void BTN_Logout_Click(object sender, EventArgs e)
        {
            var authService = AuthService.GetInstance();
            authService.Logout();
            
            this.Hide();
            var loginForm = new FRM_Login();
            loginForm.Show();
        }

        private void LoadMoviesForm()
        {
            PNL_Content.Controls.Clear();
            var moviesForm = new FRM_Movies { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };
            PNL_Content.Controls.Add(moviesForm);
            moviesForm.Show();
        }

        private void LoadSeriesForm()
        {
            PNL_Content.Controls.Clear();
            var seriesForm = new FRM_Series { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };
            PNL_Content.Controls.Add(seriesForm);
            seriesForm.Show();
        }

        private void LoadAdminForm()
        {
            PNL_Content.Controls.Clear();
            var adminForm = new FRM_Admin { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };
            PNL_Content.Controls.Add(adminForm);
            adminForm.Show();
        }
    }
}