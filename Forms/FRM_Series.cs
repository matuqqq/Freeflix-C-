using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Freeflix.Services;
using Freeflix.Models;

namespace Freeflix.Forms
{
    /// <summary>
    /// Formulario para gestión de series
    /// </summary>
    public partial class FRM_Series : Form
    {
        private DataGridView DGV_Series;
        private TextBox TXT_Search;
        private ComboBox CMB_Genre;
        private Button BTN_Search;
        private Button BTN_Rate;
        private Panel PNL_SeriesDetails;
        private Label LBL_Title;
        private Label LBL_Genre;
        private Label LBL_Description;
        private Label LBL_Rating;
        private Label LBL_Episodes;
        private NumericUpDown NUM_Rating;

        public FRM_Series()
        {
            InitializeComponent();
            LoadSeries();
            LoadGenres();
        }

        private void InitializeComponent()
        {
            DGV_Series = new DataGridView();
            TXT_Search = new TextBox();
            CMB_Genre = new ComboBox();
            BTN_Search = new Button();
            PNL_SeriesDetails = new Panel();
            LBL_Title = new Label();
            LBL_Genre = new Label();
            LBL_Description = new Label();
            LBL_Rating = new Label();
            LBL_Episodes = new Label();
            NUM_Rating = new NumericUpDown();
            BTN_Rate = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Series).BeginInit();
            PNL_SeriesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).BeginInit();
            SuspendLayout();
            // 
            // DGV_Series
            // 
            DGV_Series.AllowUserToAddRows = false;
            DGV_Series.AllowUserToDeleteRows = false;
            DGV_Series.BackgroundColor = Color.FromArgb(35, 35, 35);
            DGV_Series.GridColor = Color.FromArgb(60, 60, 60);
            DGV_Series.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(229, 9, 20),
                SelectionForeColor = Color.White
            };
            DGV_Series.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            DGV_Series.Location = new Point(20, 50);
            DGV_Series.Name = "DGV_Series";
            DGV_Series.ReadOnly = true;
            DGV_Series.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Series.MultiSelect = false;
            DGV_Series.Size = new Size(600, 500);
            DGV_Series.TabIndex = 0;
            DGV_Series.SelectionChanged += DGV_Series_SelectionChanged;
            // 
            // TXT_Search
            // 
            TXT_Search.Location = new Point(20, 20);
            TXT_Search.Name = "TXT_Search";
            TXT_Search.Size = new Size(200, 25);
            TXT_Search.Font = new Font("Arial", 10);
            TXT_Search.BackColor = Color.FromArgb(50, 50, 50);
            TXT_Search.ForeColor = Color.White;
            TXT_Search.BorderStyle = BorderStyle.FixedSingle;
            TXT_Search.TabIndex = 1;
            // 
            // CMB_Genre
            // 
            CMB_Genre.Location = new Point(230, 20);
            CMB_Genre.Name = "CMB_Genre";
            CMB_Genre.Size = new Size(150, 25);
            CMB_Genre.Font = new Font("Arial", 10);
            CMB_Genre.BackColor = Color.FromArgb(50, 50, 50);
            CMB_Genre.ForeColor = Color.White;
            CMB_Genre.DropDownStyle = ComboBoxStyle.DropDownList;
            CMB_Genre.TabIndex = 2;
            // 
            // BTN_Search
            // 
            BTN_Search.Location = new Point(390, 20);
            BTN_Search.Name = "BTN_Search";
            BTN_Search.Size = new Size(100, 25);
            BTN_Search.Text = "BUSCAR";
            BTN_Search.Font = new Font("Arial", 9, FontStyle.Bold);
            BTN_Search.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Search.ForeColor = Color.White;
            BTN_Search.FlatStyle = FlatStyle.Flat;
            BTN_Search.Cursor = Cursors.Hand;
            BTN_Search.FlatAppearance.BorderSize = 0;
            BTN_Search.TabIndex = 3;
            BTN_Search.Click += BTN_Search_Click;
            // 
            // PNL_SeriesDetails
            // 
            PNL_SeriesDetails.Controls.Add(LBL_Title);
            PNL_SeriesDetails.Controls.Add(LBL_Genre);
            PNL_SeriesDetails.Controls.Add(LBL_Description);
            PNL_SeriesDetails.Controls.Add(LBL_Rating);
            PNL_SeriesDetails.Controls.Add(LBL_Episodes);
            PNL_SeriesDetails.Controls.Add(NUM_Rating);
            PNL_SeriesDetails.Controls.Add(BTN_Rate);
            PNL_SeriesDetails.Location = new Point(640, 50);
            PNL_SeriesDetails.Name = "PNL_SeriesDetails";
            PNL_SeriesDetails.Size = new Size(320, 500);
            PNL_SeriesDetails.BackColor = Color.FromArgb(35, 35, 35);
            PNL_SeriesDetails.BorderStyle = BorderStyle.None;
            PNL_SeriesDetails.TabIndex = 4;
            // 
            // LBL_Title
            // 
            LBL_Title.Location = new Point(10, 10);
            LBL_Title.Name = "LBL_Title";
            LBL_Title.Size = new Size(300, 30);
            LBL_Title.Font = new Font("Arial", 14, FontStyle.Bold);
            LBL_Title.ForeColor = Color.White;
            LBL_Title.TextAlign = ContentAlignment.MiddleLeft;
            LBL_Title.TabIndex = 0;
            // 
            // LBL_Genre
            // 
            LBL_Genre.Location = new Point(10, 50);
            LBL_Genre.Name = "LBL_Genre";
            LBL_Genre.Size = new Size(300, 20);
            LBL_Genre.Font = new Font("Arial", 10);
            LBL_Genre.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Genre.TabIndex = 1;
            // 
            // LBL_Description
            // 
            LBL_Description.Location = new Point(10, 80);
            LBL_Description.Name = "LBL_Description";
            LBL_Description.Size = new Size(300, 200);
            LBL_Description.Font = new Font("Arial", 10);
            LBL_Description.ForeColor = Color.White;
            LBL_Description.TabIndex = 2;
            // 
            // LBL_Rating
            // 
            LBL_Rating.Location = new Point(10, 290);
            LBL_Rating.Name = "LBL_Rating";
            LBL_Rating.Size = new Size(300, 20);
            LBL_Rating.Font = new Font("Arial", 10);
            LBL_Rating.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Rating.TabIndex = 3;
            // 
            // LBL_Episodes
            // 
            LBL_Episodes.Location = new Point(10, 320);
            LBL_Episodes.Name = "LBL_Episodes";
            LBL_Episodes.Size = new Size(300, 20);
            LBL_Episodes.Font = new Font("Arial", 10);
            LBL_Episodes.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Episodes.TabIndex = 4;
            // 
            // NUM_Rating
            // 
            NUM_Rating.Location = new Point(10, 350);
            NUM_Rating.Name = "NUM_Rating";
            NUM_Rating.Size = new Size(60, 25);
            NUM_Rating.Font = new Font("Arial", 10);
            NUM_Rating.BackColor = Color.FromArgb(50, 50, 50);
            NUM_Rating.ForeColor = Color.White;
            NUM_Rating.Minimum = 1;
            NUM_Rating.Maximum = 5;
            NUM_Rating.Value = 5;
            NUM_Rating.TabIndex = 5;
            // 
            // BTN_Rate
            // 
            BTN_Rate.Location = new Point(80, 350);
            BTN_Rate.Name = "BTN_Rate";
            BTN_Rate.Size = new Size(100, 25);
            BTN_Rate.Text = "VALORAR";
            BTN_Rate.Font = new Font("Arial", 9, FontStyle.Bold);
            BTN_Rate.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Rate.ForeColor = Color.White;
            BTN_Rate.FlatStyle = FlatStyle.Flat;
            BTN_Rate.Cursor = Cursors.Hand;
            BTN_Rate.FlatAppearance.BorderSize = 0;
            BTN_Rate.TabIndex = 6;
            BTN_Rate.Click += BTN_Rate_Click;
            // 
            // FRM_Series
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(980, 570);
            Controls.Add(TXT_Search);
            Controls.Add(CMB_Genre);
            Controls.Add(BTN_Search);
            Controls.Add(DGV_Series);
            Controls.Add(PNL_SeriesDetails);
            Name = "FRM_Series";
            Text = "Series";
            ((System.ComponentModel.ISupportInitialize)DGV_Series).EndInit();
            PNL_SeriesDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadSeries()
        {
            var contentService = ContentService.GetInstance();
            var series = contentService.GetAllSeries();

            DGV_Series.DataSource = series.Select(s => new
            {
                Id = s.Id,
                Título = s.Title,
                Género = s.Genre,
                Temporadas = s.Seasons,
                Episodios = s.Episodes,
                Valoración = s.Rating.ToString("F1"),
                Estado = s.IsCompleted ? "Finalizada" : "En emisión"
            }).ToList();

            DGV_Series.Columns["Id"].Visible = false;
        }

        private void LoadGenres()
        {
            var contentService = ContentService.GetInstance();
            var genres = contentService.GetAllGenres();
            
            CMB_Genre.Items.Add("Todos");
            foreach (var genre in genres)
            {
                CMB_Genre.Items.Add(genre);
            }
            CMB_Genre.SelectedIndex = 0;
        }

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            SearchSeries();
        }

        private void SearchSeries()
        {
            var contentService = ContentService.GetInstance();
            var series = contentService.GetAllSeries();

            // Filter by search text
            if (!string.IsNullOrWhiteSpace(TXT_Search.Text))
            {
                var searchText = TXT_Search.Text.ToLower();
                series = series.Where(s => 
                    s.Title.ToLower().Contains(searchText) ||
                    s.Genre.ToLower().Contains(searchText)
                ).ToList();
            }

            // Filter by genre
            if (CMB_Genre.SelectedIndex > 0) // 0 is "All"
            {
                var selectedGenre = CMB_Genre.SelectedItem.ToString();
                series = series.Where(s => s.Genre == selectedGenre).ToList();
            }

            DGV_Series.DataSource = series.Select(s => new
            {
                Id = s.Id,
                Título = s.Title,
                Género = s.Genre,
                Temporadas = s.Seasons,
                Episodios = s.Episodes,
                Valoración = s.Rating.ToString("F1"),
                Estado = s.IsCompleted ? "Finalizada" : "En emisión"
            }).ToList();
        }

        private void BTN_Rate_Click(object sender, EventArgs e)
        {
            if (DGV_Series.SelectedRows.Count == 0) return;

            var selectedRow = DGV_Series.SelectedRows[0];
            var seriesId = selectedRow.Cells["Id"].Value.ToString();
            var rating = (int)NUM_Rating.Value;

            var contentService = ContentService.GetInstance();
            var series = contentService.GetContentById(seriesId) as Series;

            if (series != null)
            {
                var authService = AuthService.GetInstance();
                var currentUser = authService.CurrentUser;

                var newRating = new Rating(currentUser.Id, seriesId, rating);
                var ratingService = RatingService.GetInstance();
                
                if (ratingService.AddRating(newRating))
                {
                    MessageBox.Show("Valoración agregada exitosamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSeries();
                    UpdateSeriesDetails(series);
                }
                else
                {
                    MessageBox.Show("Error al agregar la valoración.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DGV_Series_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Series.SelectedRows.Count == 0) return;

            var selectedRow = DGV_Series.SelectedRows[0];
            var seriesId = selectedRow.Cells["Id"].Value.ToString();

            var contentService = ContentService.GetInstance();
            var series = contentService.GetContentById(seriesId) as Series;

            if (series != null)
            {
                UpdateSeriesDetails(series);
            }
        }

        private void UpdateSeriesDetails(Series series)
        {
            LBL_Title.Text = series.Title;
            LBL_Genre.Text = $"Género: {series.Genre}";
            LBL_Description.Text = series.Description;
            LBL_Rating.Text = $"Valoración: {series.Rating:F1} ({series.Ratings.Count} votos)";
            LBL_Episodes.Text = $"Temporadas: {series.Seasons} | Episodios: {series.Episodes}";
        }
    }
}