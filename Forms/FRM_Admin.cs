using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Freeflix.Services;
using Freeflix.Models;

namespace Freeflix.Forms
{
    /// <summary>
    /// Formulario de administración para moderadores
    /// </summary>
    public partial class FRM_Admin : Form
    {
        private DataGridView DGV_Content;
        private TextBox TXT_Title;
        private TextBox TXT_Genre;
        private TextBox TXT_Description;
        private TextBox TXT_Director;
        private TextBox TXT_ImageUrl;
        private NumericUpDown NUM_Duration;
        private NumericUpDown NUM_Seasons;
        private NumericUpDown NUM_Episodes;
        private ComboBox CMB_Type;
        private Button BTN_Add;
        private Button BTN_Update;
        private Button BTN_Delete;
        private Button BTN_Clear;
        private Panel PNL_MovieFields;
        private Panel PNL_SeriesFields;
        private Label LBL_Title;

        public FRM_Admin()
        {
            InitializeComponent();
            LoadContent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(20, 20, 20);

            // Title label
            LBL_Title = new Label
            {
                Text = "PANEL DE ADMINISTRACIÓN",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(229, 9, 20),
                Size = new Size(400, 30),
                Location = new Point(20, 10)
            };

            // Content DataGridView
            DGV_Content = new DataGridView
            {
                Size = new Size(600, 500),
                Location = new Point(20, 50),
                BackgroundColor = Color.FromArgb(35, 35, 35),
                GridColor = Color.FromArgb(60, 60, 60),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(35, 35, 35),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(229, 9, 20),
                    SelectionForeColor = Color.White
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(60, 60, 60),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                },
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            // Form fields
            var yPos = 50;
            var xPos = 640;

            // Title field
            var lblTitle = new Label
            {
                Text = "Título:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(xPos, yPos)
            };
            TXT_Title = new TextBox
            {
                Size = new Size(200, 25),
                Location = new Point(xPos + 110, yPos),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            yPos += 35;

            // Genre field
            var lblGenre = new Label
            {
                Text = "Género:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(xPos, yPos)
            };
            TXT_Genre = new TextBox
            {
                Size = new Size(200, 25),
                Location = new Point(xPos + 110, yPos),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            yPos += 35;

            // Type field
            var lblType = new Label
            {
                Text = "Tipo:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(xPos, yPos)
            };
            CMB_Type = new ComboBox
            {
                Size = new Size(200, 25),
                Location = new Point(xPos + 110, yPos),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            CMB_Type.Items.AddRange(new[] { "Movie", "Series" });

            yPos += 35;

            // Description field
            var lblDescription = new Label
            {
                Text = "Descripción:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(xPos, yPos)
            };
            TXT_Description = new TextBox
            {
                Size = new Size(200, 60),
                Location = new Point(xPos + 110, yPos),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true
            };

            yPos += 75;

            // Image URL field
            var lblImageUrl = new Label
            {
                Text = "URL Imagen:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(xPos, yPos)
            };
            TXT_ImageUrl = new TextBox
            {
                Size = new Size(200, 25),
                Location = new Point(xPos + 110, yPos),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            yPos += 35;

            // Movie specific fields panel
            PNL_MovieFields = new Panel
            {
                Size = new Size(320, 100),
                Location = new Point(xPos, yPos),
                BackColor = Color.Transparent,
                Visible = false
            };

            var lblDuration = new Label
            {
                Text = "Duración (min):",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(0, 0)
            };
            NUM_Duration = new NumericUpDown
            {
                Size = new Size(80, 25),
                Location = new Point(110, 0),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                Minimum = 1,
                Maximum = 500,
                Value = 90
            };

            var lblDirector = new Label
            {
                Text = "Director:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(0, 35)
            };
            TXT_Director = new TextBox
            {
                Size = new Size(200, 25),
                Location = new Point(110, 35),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            PNL_MovieFields.Controls.Add(lblDuration);
            PNL_MovieFields.Controls.Add(NUM_Duration);
            PNL_MovieFields.Controls.Add(lblDirector);
            PNL_MovieFields.Controls.Add(TXT_Director);

            // Series specific fields panel
            PNL_SeriesFields = new Panel
            {
                Size = new Size(320, 100),
                Location = new Point(xPos, yPos),
                BackColor = Color.Transparent,
                Visible = false
            };

            var lblSeasons = new Label
            {
                Text = "Temporadas:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(0, 0)
            };
            NUM_Seasons = new NumericUpDown
            {
                Size = new Size(80, 25),
                Location = new Point(110, 0),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                Minimum = 1,
                Maximum = 50,
                Value = 1
            };

            var lblEpisodes = new Label
            {
                Text = "Episodios:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 20),
                Location = new Point(0, 35)
            };
            NUM_Episodes = new NumericUpDown
            {
                Size = new Size(80, 25),
                Location = new Point(110, 35),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                Minimum = 1,
                Maximum = 1000,
                Value = 10
            };

            PNL_SeriesFields.Controls.Add(lblSeasons);
            PNL_SeriesFields.Controls.Add(NUM_Seasons);
            PNL_SeriesFields.Controls.Add(lblEpisodes);
            PNL_SeriesFields.Controls.Add(NUM_Episodes);

            yPos += 110;

            // Buttons
            BTN_Add = new Button
            {
                Text = "AGREGAR",
                Size = new Size(75, 30),
                Location = new Point(xPos, yPos),
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 150, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            BTN_Add.FlatAppearance.BorderSize = 0;

            BTN_Update = new Button
            {
                Text = "ACTUALIZAR",
                Size = new Size(85, 30),
                Location = new Point(xPos + 85, yPos),
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(229, 9, 20),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            BTN_Update.FlatAppearance.BorderSize = 0;

            BTN_Delete = new Button
            {
                Text = "ELIMINAR",
                Size = new Size(75, 30),
                Location = new Point(xPos + 180, yPos),
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(150, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            BTN_Delete.FlatAppearance.BorderSize = 0;

            BTN_Clear = new Button
            {
                Text = "LIMPIAR",
                Size = new Size(75, 30),
                Location = new Point(xPos + 265, yPos),
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 100, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            BTN_Clear.FlatAppearance.BorderSize = 0;

            // Add controls to form
            this.Controls.Add(LBL_Title);
            this.Controls.Add(DGV_Content);
            this.Controls.Add(lblTitle);
            this.Controls.Add(TXT_Title);
            this.Controls.Add(lblGenre);
            this.Controls.Add(TXT_Genre);
            this.Controls.Add(lblType);
            this.Controls.Add(CMB_Type);
            this.Controls.Add(lblDescription);
            this.Controls.Add(TXT_Description);
            this.Controls.Add(lblImageUrl);
            this.Controls.Add(TXT_ImageUrl);
            this.Controls.Add(PNL_MovieFields);
            this.Controls.Add(PNL_SeriesFields);
            this.Controls.Add(BTN_Add);
            this.Controls.Add(BTN_Update);
            this.Controls.Add(BTN_Delete);
            this.Controls.Add(BTN_Clear);

            // Event handlers
            CMB_Type.SelectedIndexChanged += CMB_Type_SelectedIndexChanged;
            BTN_Add.Click += BTN_Add_Click;
            BTN_Update.Click += BTN_Update_Click;
            BTN_Delete.Click += BTN_Delete_Click;
            BTN_Clear.Click += BTN_Clear_Click;
            DGV_Content.SelectionChanged += DGV_Content_SelectionChanged;

            this.ResumeLayout(false);
        }

        private void LoadContent()
        {
            var contentService = ContentService.GetInstance();
            var content = contentService.GetAllContent();

            DGV_Content.DataSource = content.Select(c => new
            {
                Id = c.Id,
                Título = c.Title,
                Tipo = c.Type.ToString(),
                Género = c.Genre,
                Valoración = c.Rating.ToString("F1"),
                Votos = c.Ratings.Count
            }).ToList();

            DGV_Content.Columns["Id"].Visible = false;
        }

        private void CMB_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMB_Type.SelectedItem?.ToString() == "Movie")
            {
                PNL_MovieFields.Visible = true;
                PNL_SeriesFields.Visible = false;
            }
            else if (CMB_Type.SelectedItem?.ToString() == "Series")
            {
                PNL_MovieFields.Visible = false;
                PNL_SeriesFields.Visible = true;
            }
            else
            {
                PNL_MovieFields.Visible = false;
                PNL_SeriesFields.Visible = false;
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AddContent();
        }

        private void BTN_Update_Click(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            DeleteContent();
        }

        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void DGV_Content_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Content.SelectedRows.Count > 0)
            {
                var selectedRow = DGV_Content.SelectedRows[0];
                var contentId = selectedRow.Cells["Id"].Value.ToString();
                
                var contentService = ContentService.GetInstance();
                var content = contentService.GetContentById(contentId);

                if (content != null)
                {
                    TXT_Title.Text = content.Title;
                    TXT_Genre.Text = content.Genre;
                    TXT_Description.Text = content.ShortDescription;
                    TXT_ImageUrl.Text = content.ImageUrl;
                    CMB_Type.SelectedItem = content.Type.ToString();

                    if (content is Movie movie)
                    {
                        NUM_Duration.Value = movie.Duration;
                        TXT_Director.Text = movie.Director;
                    }
                    else if (content is Series series)
                    {
                        NUM_Seasons.Value = series.Seasons;
                        NUM_Episodes.Value = series.Episodes;
                    }
                }
            }
        }

        private void AddContent()
        {
            if (!ValidateFields()) return;

            var contentService = ContentService.GetInstance();
            BaseAudiovisual newContent = null;

            if (CMB_Type.SelectedItem?.ToString() == "Movie")
            {
                newContent = new Movie(
                    TXT_Title.Text,
                    TXT_Genre.Text,
                    TXT_Description.Text,
                    (int)NUM_Duration.Value,
                    TXT_Director.Text,
                    DateTime.Now
                );
            }
            else if (CMB_Type.SelectedItem?.ToString() == "Series")
            {
                newContent = new Series(
                    TXT_Title.Text,
                    TXT_Genre.Text,
                    TXT_Description.Text,
                    (int)NUM_Episodes.Value,
                    (int)NUM_Seasons.Value,
                    45
                );
            }

            if (newContent != null)
            {
                newContent.ImageUrl = TXT_ImageUrl.Text;
                
                if (contentService.AddContent(newContent))
                {
                    MessageBox.Show("Contenido agregado exitosamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContent();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error al agregar el contenido.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateContent()
        {
            if (DGV_Content.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un elemento para actualizar.", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateFields()) return;

            var selectedRow = DGV_Content.SelectedRows[0];
            var contentId = selectedRow.Cells["Id"].Value.ToString();
            
            var contentService = ContentService.GetInstance();
            var existingContent = contentService.GetContentById(contentId);

            if (existingContent != null)
            {
                BaseAudiovisual updatedContent = null;

                if (CMB_Type.SelectedItem?.ToString() == "Movie")
                {
                    updatedContent = new Movie(
                        TXT_Title.Text,
                        TXT_Genre.Text,
                        TXT_Description.Text,
                        (int)NUM_Duration.Value,
                        TXT_Director.Text,
                        DateTime.Now
                    );
                }
                else if (CMB_Type.SelectedItem?.ToString() == "Series")
                {
                    updatedContent = new Series(
                        TXT_Title.Text,
                        TXT_Genre.Text,
                        TXT_Description.Text,
                        (int)NUM_Episodes.Value,
                        (int)NUM_Seasons.Value,
                        45
                    );
                }

                if (updatedContent != null)
                {
                    updatedContent.ImageUrl = TXT_ImageUrl.Text;
                    
                    if (contentService.UpdateContent(contentId, updatedContent))
                    {
                        MessageBox.Show("Contenido actualizado exitosamente.", "Éxito", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContent();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el contenido.", "Error", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteContent()
        {
            if (DGV_Content.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un elemento para eliminar.", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Está seguro de que desea eliminar este contenido?", 
                                       "Confirmar eliminación", MessageBoxButtons.YesNo, 
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedRow = DGV_Content.SelectedRows[0];
                var contentId = selectedRow.Cells["Id"].Value.ToString();
                
                var contentService = ContentService.GetInstance();
                
                if (contentService.DeleteContent(contentId))
                {
                    MessageBox.Show("Contenido eliminado exitosamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContent();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el contenido.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            TXT_Title.Clear();
            TXT_Genre.Clear();
            TXT_Description.Clear();
            TXT_ImageUrl.Clear();
            TXT_Director.Clear();
            NUM_Duration.Value = 90;
            NUM_Seasons.Value = 1;
            NUM_Episodes.Value = 10;
            CMB_Type.SelectedIndex = -1;
            PNL_MovieFields.Visible = false;
            PNL_SeriesFields.Visible = false;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(TXT_Title.Text) ||
                string.IsNullOrWhiteSpace(TXT_Genre.Text) ||
                string.IsNullOrWhiteSpace(TXT_Description.Text) ||
                CMB_Type.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}