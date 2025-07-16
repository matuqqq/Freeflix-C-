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
        private PictureBox pictureBox1;
        private NumericUpDown NUM_Rating;

        public FRM_Movies()
        {
            InitializeComponent();
            LoadMovies();
            LoadGenres();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Movies));
            DGV_Movies = new DataGridView();
            TXT_Search = new TextBox();
            CMB_Genre = new ComboBox();
            BTN_Search = new Button();
            PNL_MovieDetails = new Panel();
            pictureBox1 = new PictureBox();
            LBL_Description = new Label();
            LBL_Title = new Label();
            LBL_Genre = new Label();
            LBL_Rating = new Label();
            NUM_Rating = new NumericUpDown();
            BTN_Rate = new Button();
            BTN_PlayVideo = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Movies).BeginInit();
            PNL_MovieDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUM_Rating).BeginInit();
            SuspendLayout();
            // 
            // DGV_Movies
            // 
            DGV_Movies.AllowUserToAddRows = false;
            DGV_Movies.AllowUserToDeleteRows = false;
            DGV_Movies.BackgroundColor = Color.FromArgb(35, 35, 35);
            DGV_Movies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGV_Movies.ColumnHeadersHeight = 29;
            DGV_Movies.GridColor = Color.FromArgb(60, 60, 60);
            DGV_Movies.Location = new Point(23, 67);
            DGV_Movies.Margin = new Padding(3, 4, 3, 4);
            DGV_Movies.MultiSelect = false;
            DGV_Movies.Name = "DGV_Movies";
            DGV_Movies.ReadOnly = true;
            DGV_Movies.RowHeadersWidth = 51;
            DGV_Movies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Movies.Size = new Size(686, 667);
            DGV_Movies.TabIndex = 0;
            DGV_Movies.SelectionChanged += DGV_Movies_SelectionChanged;
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
            // PNL_MovieDetails
            // 
            PNL_MovieDetails.BackColor = Color.FromArgb(35, 35, 35);
            PNL_MovieDetails.Controls.Add(pictureBox1);
            PNL_MovieDetails.Controls.Add(LBL_Description);
            PNL_MovieDetails.Controls.Add(LBL_Title);
            PNL_MovieDetails.Controls.Add(LBL_Genre);
            PNL_MovieDetails.Controls.Add(LBL_Rating);
            PNL_MovieDetails.Controls.Add(NUM_Rating);
            PNL_MovieDetails.Controls.Add(BTN_Rate);
            PNL_MovieDetails.Controls.Add(BTN_PlayVideo);
            PNL_MovieDetails.Location = new Point(731, 67);
            PNL_MovieDetails.Margin = new Padding(3, 4, 3, 4);
            PNL_MovieDetails.Name = "PNL_MovieDetails";
            PNL_MovieDetails.Size = new Size(366, 667);
            PNL_MovieDetails.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(11, 190);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(343, 224);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // LBL_Description
            // 
            LBL_Description.BackColor = Color.FromArgb(35, 35, 35);
            LBL_Description.Font = new Font("Arial", 10F);
            LBL_Description.ForeColor = Color.White;
            LBL_Description.Location = new Point(11, 100);
            LBL_Description.Name = "LBL_Description";
            LBL_Description.Size = new Size(343, 76);
            LBL_Description.TabIndex = 2;
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
            // LBL_Rating
            // 
            LBL_Rating.Font = new Font("Arial", 10F);
            LBL_Rating.ForeColor = Color.FromArgb(180, 180, 180);
            LBL_Rating.Location = new Point(11, 387);
            LBL_Rating.Name = "LBL_Rating";
            LBL_Rating.Size = new Size(343, 27);
            LBL_Rating.TabIndex = 3;
            // 
            // NUM_Rating
            // 
            NUM_Rating.BackColor = Color.FromArgb(50, 50, 50);
            NUM_Rating.Font = new Font("Arial", 10F);
            NUM_Rating.ForeColor = Color.White;
            NUM_Rating.Location = new Point(11, 427);
            NUM_Rating.Margin = new Padding(3, 4, 3, 4);
            NUM_Rating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            NUM_Rating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUM_Rating.Name = "NUM_Rating";
            NUM_Rating.Size = new Size(69, 27);
            NUM_Rating.TabIndex = 4;
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
            BTN_Rate.Location = new Point(91, 427);
            BTN_Rate.Margin = new Padding(3, 4, 3, 4);
            BTN_Rate.Name = "BTN_Rate";
            BTN_Rate.Size = new Size(114, 33);
            BTN_Rate.TabIndex = 5;
            BTN_Rate.Text = "VALORAR";
            BTN_Rate.UseVisualStyleBackColor = false;
            BTN_Rate.Click += BTN_Rate_Click;
            // 
            // BTN_PlayVideo
            // 
            BTN_PlayVideo.BackColor = Color.FromArgb(229, 9, 20);
            BTN_PlayVideo.Cursor = Cursors.Hand;
            BTN_PlayVideo.FlatAppearance.BorderSize = 0;
            BTN_PlayVideo.FlatStyle = FlatStyle.Flat;
            BTN_PlayVideo.Font = new Font("Arial", 12F, FontStyle.Bold);
            BTN_PlayVideo.ForeColor = Color.White;
            BTN_PlayVideo.Location = new Point(11, 480);
            BTN_PlayVideo.Margin = new Padding(3, 4, 3, 4);
            BTN_PlayVideo.Name = "BTN_PlayVideo";
            BTN_PlayVideo.Size = new Size(343, 53);
            BTN_PlayVideo.TabIndex = 6;
            BTN_PlayVideo.Text = "REPRODUCIR";
            BTN_PlayVideo.UseVisualStyleBackColor = false;
            BTN_PlayVideo.Click += BTN_PlayVideo_Click;
            // 
            // FRM_Movies
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1120, 760);
            Controls.Add(TXT_Search);
            Controls.Add(CMB_Genre);
            Controls.Add(BTN_Search);
            Controls.Add(DGV_Movies);
            Controls.Add(PNL_MovieDetails);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FRM_Movies";
            Text = "Películas";
            ((System.ComponentModel.ISupportInitialize)DGV_Movies).EndInit();
            PNL_MovieDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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