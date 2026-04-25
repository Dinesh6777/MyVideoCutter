using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyVideoCutter
{
    public class MainForm : Form
    {
        // ── Controls ──────────────────────────────────────────────
        private Label lblTitle;
        private Label lblVideo;
        private TextBox txtVideoPath;
        private Button btnBrowse;
        private Label lblStart;
        private TextBox txtStart;
        private Label lblEnd;
        private TextBox txtEnd;
        private Button btnCut;
        private ProgressBar progressBar;
        private Label lblStatus;
        private PictureBox picIcon;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────
            this.Text = "My Video Cutter";
            this.Size = new Size(560, 420);
            this.MinimumSize = new Size(560, 420);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(18, 18, 28);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);

            // ── Gradient panel (top bar) ──────────────────────────
            Panel topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(30, 30, 48)
            };

            lblTitle = new Label
            {
                Text = "✂  My Video Cutter",
                ForeColor = Color.FromArgb(120, 200, 255),
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 16)
            };
            topBar.Controls.Add(lblTitle);

            // ── Main container panel ──────────────────────────────
            Panel main = new Panel
            {
                Location = new Point(0, 70),
                Size = new Size(560, 320),
                BackColor = Color.Transparent
            };

            int lx = 30, cx = 30, cw = 420, row1 = 20;

            // ── Video file row ────────────────────────────────────
            lblVideo = MakeLabel("Video File", lx, row1);
            txtVideoPath = MakeTextBox(cx, row1 + 24, 330);
            txtVideoPath.ReadOnly = true;
            txtVideoPath.BackColor = Color.FromArgb(35, 35, 55);
            txtVideoPath.ForeColor = Color.FromArgb(200, 200, 220);

            btnBrowse = new Button
            {
                Text = "Browse…",
                Location = new Point(cx + 336, row1 + 23),
                Size = new Size(90, 28),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 120, 200),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9f)
            };
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.Click += BtnBrowse_Click;

            // ── Time row ─────────────────────────────────────────
            int row2 = row1 + 72;

            lblStart = MakeLabel("Start Time (hh:mm:ss)", lx, row2);
            txtStart = MakeTextBox(cx, row2 + 24, 190);
            txtStart.Text = "00:00:00";
            txtStart.TextAlign = HorizontalAlignment.Center;
            txtStart.Font = new Font("Consolas", 13f, FontStyle.Bold);
            txtStart.ForeColor = Color.FromArgb(120, 230, 150);

            lblEnd = MakeLabel("End Time (hh:mm:ss)", cx + 220, row2);
            txtEnd = MakeTextBox(cx + 220, row2 + 24, 190);
            txtEnd.Text = "00:00:10";
            txtEnd.TextAlign = HorizontalAlignment.Center;
            txtEnd.Font = new Font("Consolas", 13f, FontStyle.Bold);
            txtEnd.ForeColor = Color.FromArgb(255, 160, 100);

            // ── Cut button ────────────────────────────────────────
            int row3 = row2 + 80;

            btnCut = new Button
            {
                Text = "✂  Cut My Video",
                Location = new Point(cx, row3),
                Size = new Size(cw, 46),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(180, 50, 80),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 12f, FontStyle.Bold)
            };
            btnCut.FlatAppearance.BorderSize = 0;
            btnCut.Click += BtnCut_Click;
            StyleButtonHover(btnCut,
                Color.FromArgb(200, 60, 95),
                Color.FromArgb(180, 50, 80));

            // ── Progress bar ──────────────────────────────────────
            int row4 = row3 + 64;

            progressBar = new ProgressBar
            {
                Location = new Point(cx, row4),
                Size = new Size(cw, 10),
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 0,
                BackColor = Color.FromArgb(40, 40, 60)
            };

            lblStatus = new Label
            {
                Text = "Ready.",
                Location = new Point(cx, row4 + 16),
                Size = new Size(cw, 22),
                ForeColor = Color.FromArgb(160, 160, 190),
                Font = new Font("Segoe UI", 8.5f)
            };

            // ── Add controls ──────────────────────────────────────
            main.Controls.AddRange(new Control[] {
                lblVideo, txtVideoPath, btnBrowse,
                lblStart, txtStart,
                lblEnd, txtEnd,
                btnCut,
                progressBar, lblStatus
            });

            this.Controls.Add(topBar);
            this.Controls.Add(main);

            this.ResumeLayout(false);
        }

        // ── Helper factory methods ────────────────────────────────

        private Label MakeLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(160, 170, 200),
                Font = new Font("Segoe UI", 8.5f)
            };
        }

        private TextBox MakeTextBox(int x, int y, int width)
        {
            var tb = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 30),
                BackColor = Color.FromArgb(35, 35, 55),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f)
            };
            return tb;
        }

        private void StyleButtonHover(Button btn, Color hoverColor, Color normalColor)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = normalColor;
        }

        // ── Event handlers ────────────────────────────────────────

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a Video File";
                dlg.Filter =
                    "Video Files|*.mp4;*.mkv;*.avi;*.mov;*.wmv;*.flv;*.webm;*.m4v;*.ts;*.mpeg;*.mpg|All Files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtVideoPath.Text = dlg.FileName;
            }
        }

        private async void BtnCut_Click(object sender, EventArgs e)
        {
            string inputPath = txtVideoPath.Text.Trim();
            string startTime = txtStart.Text.Trim();
            string endTime = txtEnd.Text.Trim();

            // ── Validate ──────────────────────────────────────────
            if (string.IsNullOrEmpty(inputPath) || !File.Exists(inputPath))
            {
                ShowError("Please select a valid video file.");
                return;
            }

            if (!IsValidTime(startTime))
            {
                ShowError("Start time format must be hh:mm:ss  (e.g. 00:01:30)");
                return;
            }

            if (!IsValidTime(endTime))
            {
                ShowError("End time format must be hh:mm:ss  (e.g. 00:02:45)");
                return;
            }

            TimeSpan ts = ParseTime(startTime);
            TimeSpan te = ParseTime(endTime);

            if (te <= ts)
            {
                ShowError("End time must be later than Start time.");
                return;
            }

            // ── Locate ffmpeg ─────────────────────────────────────
            string ffmpegPath = FindFFmpeg();
            if (ffmpegPath == null)
            {
                ShowError(
                    "ffmpeg.exe not found.\n\n" +
                    "Please place ffmpeg.exe in the same folder as MyVideoCutter.exe,\n" +
                    "or add ffmpeg to your system PATH.");
                return;
            }

            // ── Build output path ─────────────────────────────────
            string dir = Path.GetDirectoryName(inputPath);
            string name = Path.GetFileNameWithoutExtension(inputPath);
            string ext = Path.GetExtension(inputPath);
            string outputPath = Path.Combine(dir,
                $"{name}_cut_{startTime.Replace(':', '-')}_to_{endTime.Replace(':', '-')}{ext}");

            // ── Run ffmpeg ────────────────────────────────────────
            SetBusy(true, "Cutting video, please wait…");

            TimeSpan duration = te - ts;
            string args = $"-y -ss {startTime} -i \"{inputPath}\" -t {duration} -c copy \"{outputPath}\"";

            try
            {
                int exitCode = await RunFFmpegAsync(ffmpegPath, args);

                if (exitCode == 0 && File.Exists(outputPath))
                {
                    SetBusy(false, $"Done! Saved: {Path.GetFileName(outputPath)}");
                    var result = MessageBox.Show(
                        $"Video cut successfully!\n\nSaved to:\n{outputPath}\n\nOpen output folder?",
                        "Success ✓",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        Process.Start("explorer.exe", $"/select,\"{outputPath}\"");
                }
                else
                {
                    SetBusy(false, "Error: ffmpeg reported a failure.");
                    ShowError("ffmpeg failed to cut the video.\nCheck that the time range is within the video duration.");
                }
            }
            catch (Exception ex)
            {
                SetBusy(false, "Error.");
                ShowError($"Unexpected error:\n{ex.Message}");
            }
        }

        // ── Helpers ───────────────────────────────────────────────

        private bool IsValidTime(string t)
        {
            return Regex.IsMatch(t, @"^\d{2}:\d{2}:\d{2}$") && TimeSpan.TryParse(t, out _);
        }

        private TimeSpan ParseTime(string t) => TimeSpan.Parse(t);

        private string FindFFmpeg()
        {
            // 1) Same directory as the exe
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string local = Path.Combine(exeDir, "ffmpeg.exe");
            if (File.Exists(local)) return local;

            // 2) System PATH
            string envPath = Environment.GetEnvironmentVariable("PATH") ?? "";
            foreach (string dir in envPath.Split(';'))
            {
                try
                {
                    string candidate = Path.Combine(dir.Trim(), "ffmpeg.exe");
                    if (File.Exists(candidate)) return candidate;
                }
                catch { }
            }
            return null;
        }

        private System.Threading.Tasks.Task<int> RunFFmpegAsync(string ffmpegPath, string args)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<int>();

            var psi = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            var proc = new Process { StartInfo = psi, EnableRaisingEvents = true };
            proc.Exited += (s, e) =>
            {
                tcs.TrySetResult(proc.ExitCode);
                proc.Dispose();
            };
            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            return tcs.Task;
        }

        private void SetBusy(bool busy, string status)
        {
            btnCut.Enabled = !busy;
            btnBrowse.Enabled = !busy;
            progressBar.MarqueeAnimationSpeed = busy ? 30 : 0;
            lblStatus.Text = status;
            lblStatus.ForeColor = busy
                ? Color.FromArgb(120, 200, 255)
                : Color.FromArgb(100, 220, 130);
        }

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
