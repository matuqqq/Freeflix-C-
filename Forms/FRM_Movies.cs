using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Freeflix.Services;
using Freeflix.Models;

namespace Freeflix.Forms
{
    /// <summary>
    /// Formulario para gestión de películas
    /// </summary>
    public partial class FRM_Movies : Form
    {
        private DataGridView DGV_Movies;
        private TextBox TXT_Search;
        private ComboBox CMB_Genre;
        private Button BTN_Search;
        private Button BTN_Rate;
        private Button BTN_PlayVideo;
        private Panel PNL_MovieDetails;
        private Label LBL_Title;
        private Label LBL_Genre;
        private Label LBL_Description;
        private Label LBL_Rating;
        private NumericUpDown NUM_Rating;

        public FRM_Movies()
        {
            InitializeComponent();
            LoadMovies();
            LoadGenres();
        }

        private void InitializeComponent()
        {
            DGV_Movies = new DataGridView();
            TXT_Search = new TextBox();
            CMB_Genre = new ComboBox();
            BTN_Search = new Button();
            PNL_MovieDetails = new Panel();
            LBL_Title = new Label();
            LBL_Genre = new Label();
            LBL_Description = new Label();
            LBL_Rating = new Label();
            NUM_Rating = new NumericUpDown();
            BTN_Rate = new Button();
            BTN_PlayVideo = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Movies).BeginInit();
            PNL_MovieDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).BeginInit();
            SuspendLayout();
            // 
            // DGV_Movies
            // 
            DGV_Movies.AllowUserToAddRows = false;
            DGV_Movies.AllowUserToDeleteRows = false;
            DGV_Movies.BackgroundColor = Color.FromArgb(35, 35, 35);
            DGV_Movies.GridColor = Color.FromArgb(60, 60, 60);
            DGV_Movies.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(229, 9, 20),
                SelectionForeColor = Color.White
            };
            DGV_Movies.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            DGV_Movies.Location = new Point(20, 50);
            DGV_Movies.Name = "DGV_Movies";
            DGV_Movies.ReadOnly = true;
            DGV_Movies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Movies.MultiSelect = false;
            DGV_Movies.Size = new Size(600, 500);
            DGV_Movies.TabIndex = 0;
            DGV_Movies.SelectionChanged += DGV_Movies_SelectionChanged;
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
            // PNL_MovieDetails
            // 
            PNL_MovieDetails.Controls.Add(LBL_Title);
            PNL_MovieDetails.Controls.Add(LBL_Genre);
            PNL_MovieDetails.Controls.Add(LBL_Description);
            PNL_MovieDetails.Controls.Add(LBL_Rating);
            PNL_MovieDetails.Controls.Add(NUM_Rating);
            PNL_MovieDetails.Controls.Add(BTN_Rate);
            PNL_MovieDetails.Controls.Add(BTN_PlayVideo);
            PNL_MovieDetails.Location = new Point(640, 50);
            PNL_MovieDetails.Name = "PNL_MovieDetails";
            PNL_MovieDetails.Size = new Size(320, 500);
            PNL_MovieDetails.BackColor = Color.FromArgb(35, 35, 35);
            PNL_MovieDetails.BorderStyle = BorderStyle.None;
            PNL_MovieDetails.TabIndex = 4;
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
            // NUM_Rating
            // 
            NUM_Rating.Location = new Point(10, 320);
            NUM_Rating.Name = "NUM_Rating";
            NUM_Rating.Size = new Size(60, 25);
            NUM_Rating.Font = new Font("Arial", 10);
            NUM_Rating.BackColor = Color.FromArgb(50, 50, 50);
            NUM_Rating.ForeColor = Color.White;
            NUM_Rating.Minimum = 1;
            NUM_Rating.Maximum = 5;
            NUM_Rating.Value = 5;
            NUM_Rating.TabIndex = 4;
            // 
            // BTN_Rate
            // 
            BTN_Rate.Location = new Point(80, 320);
            BTN_Rate.Name = "BTN_Rate";
            BTN_Rate.Size = new Size(100, 25);
            BTN_Rate.Text = "VALORAR";
            BTN_Rate.Font = new Font("Arial", 9, FontStyle.Bold);
            BTN_Rate.BackColor = Color.FromArgb(229, 9, 20);
            BTN_Rate.ForeColor = Color.White;
            BTN_Rate.FlatStyle = FlatStyle.Flat;
            BTN_Rate.Cursor = Cursors.Hand;
            BTN_Rate.FlatAppearance.BorderSize = 0;
            BTN_Rate.TabIndex = 5;
            BTN_Rate.Click += BTN_Rate_Click;
            // 
            // BTN_PlayVideo
            // 
            BTN_PlayVideo.Location = new Point(10, 360);
            BTN_PlayVideo.Name = "BTN_PlayVideo";
            BTN_PlayVideo.Size = new Size(300, 40);
            BTN_PlayVideo.Text = "REPRODUCIR";
            BTN_PlayVideo.Font = new Font("Arial", 12, FontStyle.Bold);
            BTN_PlayVideo.BackColor = Color.FromArgb(229, 9, 20);
            BTN_PlayVideo.ForeColor = Color.White;
            BTN_PlayVideo.FlatStyle = FlatStyle.Flat;
            BTN_PlayVideo.Cursor = Cursors.Hand;
            BTN_PlayVideo.FlatAppearance.BorderSize = 0;
            BTN_PlayVideo.TabIndex = 6;
            BTN_PlayVideo.Click += BTN_PlayVideo_Click;
            // 
            // FRM_Movies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(980, 570);
            Controls.Add(TXT_Search);
            Controls.Add(CMB_Genre);
            Controls.Add(BTN_Search);
            Controls.Add(DGV_Movies);
            Controls.Add(PNL_MovieDetails);
            Name = "FRM_Movies";
            Text = "Películas";
            ((System.ComponentModel.ISupportInitialize)DGV_Movies).EndInit();
            PNL_MovieDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadMovies()
        {
            var contentService = ContentService.GetInstance();
            var movies = contentService.GetAllMovies();

            DGV_Movies.DataSource = movies.Select(m => new
            {
                Id = m.Id,
                Título = m.Title,
                Género = m.Genre,
                Duración = m.GetDurationFormatted(),
                Valoración = m.Rating.ToString("F1"),
                Director = m.Director
            }).ToList();

            DGV_Movies.Columns["Id"].Visible = false;
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
            SearchMovies();
        }

        private void SearchMovies()
        {
            var contentService = ContentService.GetInstance();
            var movies = contentService.GetAllMovies();

            // Filter by search text
            if (!string.IsNullOrWhiteSpace(TXT_Search.Text))
            {
                var searchText = TXT_Search.Text.ToLower();
                movies = movies.Where(m => 
                    m.Title.ToLower().Contains(searchText) ||
                    m.Genre.ToLower().Contains(searchText) ||
                    m.Director.ToLower().Contains(searchText)
                ).ToList();
            }

            // Filter by genre
            if (CMB_Genre.SelectedIndex > 0) // 0 is "All"
            {
                var selectedGenre = CMB_Genre.SelectedItem.ToString();
                movies = movies.Where(m => m.Genre == selectedGenre).ToList();
            }

            DGV_Movies.DataSource = movies.Select(m => new
            {
                Id = m.Id,
                Título = m.Title,
                Género = m.Genre,
                Duración = m.GetDurationFormatted(),
                Valoración = m.Rating.ToString("F1"),
                Director = m.Director
            }).ToList();
        }

        private void BTN_Rate_Click(object sender, EventArgs e)
        {
            if (DGV_Movies.SelectedRows.Count == 0) return;

            var selectedRow = DGV_Movies.SelectedRows[0];
            var movieId = selectedRow.Cells["Id"].Value.ToString();
            var rating = (int)NUM_Rating.Value;

            var contentService = ContentService.GetInstance();
            var movie = contentService.GetContentById(movieId) as Movie;

            if (movie != null)
            {
                var authService = AuthService.GetInstance();
                var currentUser = authService.CurrentUser;

                var newRating = new Rating(currentUser.Id, movieId, rating);
                var ratingService = RatingService.GetInstance();
                
                if (ratingService.AddRating(newRating))
                {
                    MessageBox.Show("Valoración agregada exitosamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMovies();
                    UpdateMovieDetails(movie);
                }
                else
                {
                    MessageBox.Show("Error al agregar la valoración.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_PlayVideo_Click(object sender, EventArgs e)
        {
            if (DGV_Movies.SelectedRows.Count == 0) return;

            var selectedRow = DGV_Movies.SelectedRows[0];
            var movieId = selectedRow.Cells["Id"].Value.ToString();

            var contentService = ContentService.GetInstance();
            var movie = contentService.GetContentById(movieId) as Movie;

            if (movie != null)
            {
                var videoPlayer = new FRM_VideoPlayer(movie.VideoUrl, movie.Title);
                videoPlayer.ShowDialog();
            }
        }

        private void DGV_Movies_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Movies.SelectedRows.Count == 0) return;

            var selectedRow = DGV_Movies.SelectedRows[0];
            var movieId = selectedRow.Cells["Id"].Value.ToString();

            var contentService = ContentService.GetInstance();
            var movie = contentService.GetContentById(movieId) as Movie;

            if (movie != null)
            {
                UpdateMovieDetails(movie);
            }
        }

        private void UpdateMovieDetails(Movie movie)
        {
            LBL_Title.Text = movie.Title;
            LBL_Genre.Text = $"Género: {movie.Genre}";
            LBL_Description.Text = movie.Description;
            LBL_Rating.Text = $"Valoración: {movie.Rating:F1} ({movie.Ratings.Count} votos)";
        }
    }
}