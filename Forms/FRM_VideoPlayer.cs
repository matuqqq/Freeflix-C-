using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Forms.Integration;
using System.Windows.Controls;
using System.IO;

namespace Freeflix.Forms
{
    /// <summary>
    /// Formulario reproductor de video simple
    /// </summary>
    public partial class FRM_VideoPlayer : Form
    {
        private System.Windows.Forms.Panel PNL_VideoContainer;
        private System.Windows.Forms.Panel PNL_Controls;
        private System.Windows.Forms.Button BTN_Play;
        private System.Windows.Forms.Button BTN_Pause;
        private System.Windows.Forms.Button BTN_Stop;
        private System.Windows.Forms.TrackBar TRK_Progress;
        private System.Windows.Forms.Label LBL_VideoTitle;
        private System.Windows.Forms.Label LBL_Time;
        private System.Windows.Forms.Timer playbackTimer;
        private System.ComponentModel.IContainer components;
        private ElementHost videoHost;
        private MediaElement mediaElement;
        private bool isPlaying = false;
        private TimeSpan totalDuration;

        public FRM_VideoPlayer(string videoUrl, string title)
        {
            InitializeComponent();
            SetupVideoPlayer(title);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            playbackTimer = new System.Windows.Forms.Timer(components);
            PNL_VideoContainer = new System.Windows.Forms.Panel();
            videoHost = new ElementHost();
            mediaElement = new MediaElement();
            PNL_Controls = new System.Windows.Forms.Panel();
            TRK_Progress = new TrackBar();
            LBL_Time = new System.Windows.Forms.Label();
            BTN_Play = new System.Windows.Forms.Button();
            BTN_Pause = new System.Windows.Forms.Button();
            BTN_Stop = new System.Windows.Forms.Button();
            LBL_VideoTitle = new System.Windows.Forms.Label();
            PNL_VideoContainer.SuspendLayout();
            PNL_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TRK_Progress).BeginInit();
            SuspendLayout();

            // Setup MediaElement
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.UnloadedBehavior = MediaState.Manual;
            mediaElement.MediaOpened += MediaElement_MediaOpened;
            mediaElement.MediaEnded += MediaElement_MediaEnded;

            // Setup ElementHost
            videoHost.Child = mediaElement;
            videoHost.Dock = DockStyle.Fill;
            
            // 
            // playbackTimer
            // 
            playbackTimer.Interval = 1000;
            playbackTimer.Tick += TMR_Progress_Tick;
            // 
            // PNL_VideoContainer
            // 
            PNL_VideoContainer.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            PNL_VideoContainer.BorderStyle = BorderStyle.FixedSingle;
            PNL_VideoContainer.Controls.Add(videoHost);
            PNL_VideoContainer.Location = new Point(23, 67);
            PNL_VideoContainer.Margin = new Padding(3, 4, 3, 4);
            PNL_VideoContainer.Name = "PNL_VideoContainer";
            PNL_VideoContainer.Size = new Size(868, 599);
            PNL_VideoContainer.TabIndex = 0;
            // 
            // PNL_Controls
            // 
            PNL_Controls.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            PNL_Controls.Controls.Add(TRK_Progress);
            PNL_Controls.Controls.Add(LBL_Time);
            PNL_Controls.Controls.Add(BTN_Play);
            PNL_Controls.Controls.Add(BTN_Pause);
            PNL_Controls.Controls.Add(BTN_Stop);
            PNL_Controls.Location = new Point(23, 680);
            PNL_Controls.Margin = new Padding(3, 4, 3, 4);
            PNL_Controls.Name = "PNL_Controls";
            PNL_Controls.Size = new Size(869, 107);
            PNL_Controls.TabIndex = 1;
            // 
            // TRK_Progress
            // 
            TRK_Progress.Location = new Point(11, 3);
            TRK_Progress.Margin = new Padding(3, 4, 3, 4);
            TRK_Progress.Maximum = 100;
            TRK_Progress.Name = "TRK_Progress";
            TRK_Progress.Size = new Size(846, 56);
            TRK_Progress.TabIndex = 3;
            TRK_Progress.Scroll += TRK_Progress_Scroll;
            // 
            // LBL_Time
            // 
            LBL_Time.Font = new Font("Arial", 10F);
            LBL_Time.ForeColor = System.Drawing.Color.White;
            LBL_Time.Location = new Point(11, 61);
            LBL_Time.Name = "LBL_Time";
            LBL_Time.Size = new Size(91, 40);
            LBL_Time.TabIndex = 4;
            LBL_Time.Text = "00:00";
            LBL_Time.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BTN_Play
            // 
            BTN_Play.BackColor = System.Drawing.Color.FromArgb(229, 9, 20);
            BTN_Play.Cursor = Cursors.Hand;
            BTN_Play.FlatAppearance.BorderSize = 0;
            BTN_Play.FlatStyle = FlatStyle.Flat;
            BTN_Play.Font = new Font("Arial", 10F, FontStyle.Bold);
            BTN_Play.ForeColor = System.Drawing.Color.White;
            BTN_Play.Location = new Point(114, 58);
            BTN_Play.Margin = new Padding(3, 4, 3, 4);
            BTN_Play.Name = "BTN_Play";
            BTN_Play.Size = new Size(91, 47);
            BTN_Play.TabIndex = 5;
            BTN_Play.Text = "▶ PLAY";
            BTN_Play.UseVisualStyleBackColor = false;
            BTN_Play.Click += BTN_Play_Click;
            // 
            // BTN_Pause
            // 
            BTN_Pause.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            BTN_Pause.Cursor = Cursors.Hand;
            BTN_Pause.Enabled = false;
            BTN_Pause.FlatAppearance.BorderSize = 0;
            BTN_Pause.FlatStyle = FlatStyle.Flat;
            BTN_Pause.Font = new Font("Arial", 10F, FontStyle.Bold);
            BTN_Pause.ForeColor = System.Drawing.Color.White;
            BTN_Pause.Location = new Point(217, 58);
            BTN_Pause.Margin = new Padding(3, 4, 3, 4);
            BTN_Pause.Name = "BTN_Pause";
            BTN_Pause.Size = new Size(91, 47);
            BTN_Pause.TabIndex = 6;
            BTN_Pause.Text = "⏸ PAUSE";
            BTN_Pause.UseVisualStyleBackColor = false;
            BTN_Pause.Click += BTN_Pause_Click;
            // 
            // BTN_Stop
            // 
            BTN_Stop.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            BTN_Stop.Cursor = Cursors.Hand;
            BTN_Stop.Enabled = false;
            BTN_Stop.FlatAppearance.BorderSize = 0;
            BTN_Stop.FlatStyle = FlatStyle.Flat;
            BTN_Stop.Font = new Font("Arial", 10F, FontStyle.Bold);
            BTN_Stop.ForeColor = System.Drawing.Color.White;
            BTN_Stop.Location = new Point(320, 58);
            BTN_Stop.Margin = new Padding(3, 4, 3, 4);
            BTN_Stop.Name = "BTN_Stop";
            BTN_Stop.Size = new Size(91, 47);
            BTN_Stop.TabIndex = 7;
            BTN_Stop.Text = "⏹ STOP";
            BTN_Stop.UseVisualStyleBackColor = false;
            BTN_Stop.Click += BTN_Stop_Click;
            // 
            // LBL_VideoTitle
            // 
            LBL_VideoTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            LBL_VideoTitle.ForeColor = System.Drawing.Color.White;
            LBL_VideoTitle.Location = new Point(23, 13);
            LBL_VideoTitle.Name = "LBL_VideoTitle";
            LBL_VideoTitle.Size = new Size(869, 40);
            LBL_VideoTitle.TabIndex = 2;
            LBL_VideoTitle.Text = "Cargando video...";
            LBL_VideoTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FRM_VideoPlayer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new Size(914, 800);
            Controls.Add(LBL_VideoTitle);
            Controls.Add(PNL_VideoContainer);
            Controls.Add(PNL_Controls);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FRM_VideoPlayer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Freeflix - Reproductor de Video";
            FormClosing += FRM_VideoPlayer_FormClosing;
            KeyDown += FRM_VideoPlayer_KeyDown;
            PNL_VideoContainer.ResumeLayout(false);
            PNL_Controls.ResumeLayout(false);
            PNL_Controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TRK_Progress).EndInit();
            ResumeLayout(false);
        }

        private void SetupVideoPlayer(string title)
        {
            LBL_VideoTitle.Text = $"Reproduciendo: {title}";
            
            // Set the video source to the local file
            string videoPath = Path.Combine(Application.StartupPath, "videoplayback.mp4");
            mediaElement.Source = new Uri(videoPath);
        }

        private void MediaElement_MediaOpened(object sender, EventArgs e)
        {
            totalDuration = mediaElement.NaturalDuration.TimeSpan;
            TRK_Progress.Maximum = (int)totalDuration.TotalSeconds;
            UpdateTimeLabel();
            BTN_Play.Enabled = true;
            BTN_Pause.Enabled = false;
            BTN_Stop.Enabled = false;
        }

        private void MediaElement_MediaEnded(object sender, EventArgs e)
        {
            StopVideo();
            // Auto-replay
            PlayVideo();
        }

        private void BTN_Play_Click(object sender, EventArgs e)
        {
            PlayVideo();
        }

        private void BTN_Pause_Click(object sender, EventArgs e)
        {
            PauseVideo();
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            StopVideo();
        }

        private void PlayVideo()
        {
            mediaElement.Play();
            isPlaying = true;
            playbackTimer.Start();
            BTN_Play.Enabled = false;
            BTN_Pause.Enabled = true;
            BTN_Stop.Enabled = true;
        }

        private void PauseVideo()
        {
            mediaElement.Pause();
            isPlaying = false;
            playbackTimer.Stop();
            BTN_Play.Enabled = true;
            BTN_Pause.Enabled = false;
            BTN_Stop.Enabled = true;
        }

        private void StopVideo()
        {
            mediaElement.Stop();
            isPlaying = false;
            playbackTimer.Stop();
            TRK_Progress.Value = 0;
            UpdateTimeLabel();
            BTN_Play.Enabled = true;
            BTN_Pause.Enabled = false;
            BTN_Stop.Enabled = false;
        }

        private void TMR_Progress_Tick(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                TRK_Progress.Value = (int)mediaElement.Position.TotalSeconds;
                UpdateTimeLabel();
            }
        }

        private void TRK_Progress_Scroll(object sender, EventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(TRK_Progress.Value);
            UpdateTimeLabel();
        }

        private void UpdateTimeLabel()
        {
            TimeSpan currentPosition = mediaElement.Position;
            LBL_Time.Text = $"{currentPosition.Minutes:D2}:{currentPosition.Seconds:D2}";
        }

        private void FRM_VideoPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (isPlaying)
                        PauseVideo();
                    else
                        PlayVideo();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void FRM_VideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopVideo();
            mediaElement.Close();
        }
    }
}