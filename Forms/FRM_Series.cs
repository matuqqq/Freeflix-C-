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
        private PictureBox pictureBox1;
        private NumericUpDown NUM_Rating;

        public FRM_Series()
        {
            InitializeComponent();
            LoadSeries();
            LoadGenres();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DGV_Series).BeginInit();
            PNL_SeriesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // DGV_Series
            // 
            DGV_Series.AllowUserToAddRows = false;
            DGV_Series.AllowUserToDeleteRows = false;
            DGV_Series.BackgroundColor = Color.FromArgb(35, 35, 35);
            DGV_Series.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGV_Series.ColumnHeadersHeight = 29;
            DGV_Series.GridColor = Color.FromArgb(60, 60, 60);
            DGV_Series.Location = new Point(23, 67);
            DGV_Series.Margin = new Padding(3, 4, 3, 4);
            DGV_Series.MultiSelect = false;
            DGV_Series.Name = "DGV_Series";
            DGV_Series.ReadOnly = true;
            DGV_Series.RowHeadersWidth = 51;
            DGV_Series.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Series.Size = new Size(686, 667);
            DGV_Series.TabIndex = 0;
            DGV_Series.SelectionChanged += DGV_Series_SelectionChanged;
            // 
            // TXT_Search
            // 
            TXT_Search.BackColor = Color.FromArgb(50, 50, 50);
            TXT_Search.BorderStyle = BorderStyle.FixedSingle;
            TXT_Search.Font = new Font("Arial", 10F);
            TXT_Search.ForeColor = Color.White;
            TXT_Search.Location = new Point(23, 27);
            TXT_Search.Margin = new Padding(3, 4, 3, 4);
            TXT_Search.Name = "TXT_Search";
            TXT_Search.Size = new Size(228, 27);
            TXT_Search.TabIndex = 1;
            // 
            // CMB_Genre
            // 
            CMB_Genre.BackColor = Color.FromArgb(50, 50, 50);
            CMB_Genre.DropDownStyle = ComboBoxStyle.DropDownList;
            CMB_Genre.Font = new Font("Arial", 10F);
            CMB_Genre.ForeColor = Color.White;
            CMB_Genre.Location = new Point(263, 27);
            CMB_Genre.Margin = new Padding(3, 4, 3, 4);
            CMB_Genre.Name = "CMB_Genre";
            CMB_Genre.Size = new Size(171, 27);
            CMB_Genre.TabIndex = 2;
            // 
            // BTN_Search
            // 
            BTN_Search.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Search.Cursor = Cursors.Hand;
            BTN_Search.FlatAppearance.BorderSize = 0;
            BTN_Search.FlatStyle = FlatStyle.Flat;
            BTN_Search.Font = new Font("Arial", 9F, FontStyle.Bold);
            BTN_Search.ForeColor = Color.White;
            BTN_Search.Location = new Point(446, 27);
            BTN_Search.Margin = new Padding(3, 4, 3, 4);
            BTN_Search.Name = "BTN_Search";
            BTN_Search.Size = new Size(114, 33);
            BTN_Search.TabIndex = 3;
            BTN_Search.Text = "BUSCAR";
            BTN_Search.UseVisualStyleBackColor = false;
            BTN_Search.Click += BTN_Search_Click;
            // 
            // PNL_SeriesDetails
            // 
            PNL_SeriesDetails.BackColor = Color.FromArgb(35, 35, 35);
            PNL_SeriesDetails.Controls.Add(pictureBox1);
            PNL_SeriesDetails.Controls.Add(LBL_Title);
            PNL_SeriesDetails.Controls.Add(LBL_Genre);
            PNL_SeriesDetails.Controls.Add(LBL_Description);
            PNL_SeriesDetails.Controls.Add(LBL_Rating);
            PNL_SeriesDetails.Controls.Add(LBL_Episodes);
            PNL_SeriesDetails.Controls.Add(NUM_Rating);
            PNL_SeriesDetails.Controls.Add(BTN_Rate);
            PNL_SeriesDetails.Location = new Point(731, 67);
            PNL_SeriesDetails.Margin = new Padding(3, 4, 3, 4);
            PNL_SeriesDetails.Name = "PNL_SeriesDetails";
            PNL_SeriesDetails.Size = new Size(366, 667);
            PNL_SeriesDetails.TabIndex = 4;
            // 
            // LBL_Title
            // 
            LBL_Title.Font = new Font("Arial", 14F, FontStyle.Bold);
            LBL_Title.ForeColor = Color.White;
            LBL_Title.Location = new Point(11, 13);
            LBL_Title.Name = "LBL_Title";
            LBL_Title.Size = new Size(343, 40);
            LBL_Title.TabIndex = 0;
            LBL_Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LBL_Genre
            // 
            LBL_Genre.Font = new Font("Arial", 10F);
            LBL_Genre.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Genre.Location = new Point(11, 67);
            LBL_Genre.Name = "LBL_Genre";
            LBL_Genre.Size = new Size(343, 27);
            LBL_Genre.TabIndex = 1;
            // 
            // LBL_Description
            // 
            LBL_Description.BackColor = Color.FromArgb(35, 35, 35);
            LBL_Description.Font = new Font("Arial", 10F);
            LBL_Description.ForeColor = Color.White;
            LBL_Description.Location = new Point(11, 107);
            LBL_Description.Name = "LBL_Description";
            LBL_Description.Size = new Size(343, 82);
            LBL_Description.TabIndex = 2;
            // 
            // LBL_Rating
            // 
            LBL_Rating.Font = new Font("Arial", 10F);
            LBL_Rating.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Rating.Location = new Point(11, 387);
            LBL_Rating.Name = "LBL_Rating";
            LBL_Rating.Size = new Size(343, 27);
            LBL_Rating.TabIndex = 3;
            // 
            // LBL_Episodes
            // 
            LBL_Episodes.Font = new Font("Arial", 10F);
            LBL_Episodes.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Episodes.Location = new Point(11, 427);
            LBL_Episodes.Name = "LBL_Episodes";
            LBL_Episodes.Size = new Size(343, 27);
            LBL_Episodes.TabIndex = 4;
            // 
            // NUM_Rating
            // 
            NUM_Rating.BackColor = Color.FromArgb(50, 50, 50);
            NUM_Rating.Font = new Font("Arial", 10F);
            NUM_Rating.ForeColor = Color.White;
            NUM_Rating.Location = new Point(11, 467);
            NUM_Rating.Margin = new Padding(3, 4, 3, 4);
            NUM_Rating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            NUM_Rating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUM_Rating.Name = "NUM_Rating";
            NUM_Rating.Size = new Size(69, 27);
            NUM_Rating.TabIndex = 5;
            NUM_Rating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // BTN_Rate
            // 
            BTN_Rate.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Rate.Cursor = Cursors.Hand;
            BTN_Rate.FlatAppearance.BorderSize = 0;
            BTN_Rate.FlatStyle = FlatStyle.Flat;
            BTN_Rate.Font = new Font("Arial", 9F, FontStyle.Bold);
            BTN_Rate.ForeColor = Color.White;
            BTN_Rate.Location = new Point(91, 467);
            BTN_Rate.Margin = new Padding(3, 4, 3, 4);
            BTN_Rate.Name = "BTN_Rate";
            BTN_Rate.Size = new Size(114, 33);
            BTN_Rate.TabIndex = 6;
            BTN_Rate.Text = "VALORAR";
            BTN_Rate.UseVisualStyleBackColor = false;
            BTN_Rate.Click += BTN_Rate_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Freeflix_WinForms.Properties.Resources.placeholderSerie;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(11, 209);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(343, 205);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FRM_Series
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1120, 760);
            Controls.Add(TXT_Search);
            Controls.Add(CMB_Genre);
            Controls.Add(BTN_Search);
            Controls.Add(DGV_Series);
            Controls.Add(PNL_SeriesDetails);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FRM_Series";
            Text = "Series";
            ((System.ComponentModel.ISupportInitialize)DGV_Series).EndInit();
            PNL_SeriesDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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