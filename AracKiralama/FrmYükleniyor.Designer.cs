namespace AracKiralama
{
    partial class FrmYükleniyor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYükleniyor));
            this.labelYukleniyor = new System.Windows.Forms.Label();
            this.timerYukleniyor = new System.Windows.Forms.Timer(this.components);
            this.progressBarYukleniyor = new System.Windows.Forms.ProgressBar();
            this.labelYuzde = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelYukleniyor
            // 
            this.labelYukleniyor.AutoSize = true;
            this.labelYukleniyor.BackColor = System.Drawing.Color.Transparent;
            this.labelYukleniyor.Font = new System.Drawing.Font("Barlow", 47.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelYukleniyor.ForeColor = System.Drawing.Color.Turquoise;
            this.labelYukleniyor.Location = new System.Drawing.Point(145, 149);
            this.labelYukleniyor.Name = "labelYukleniyor";
            this.labelYukleniyor.Size = new System.Drawing.Size(371, 80);
            this.labelYukleniyor.TabIndex = 0;
            this.labelYukleniyor.Text = "Yükleniyor...";
            // 
            // timerYukleniyor
            // 
            this.timerYukleniyor.Interval = 300;
            this.timerYukleniyor.Tick += new System.EventHandler(this.timerYukleniyor_Tick);
            // 
            // progressBarYukleniyor
            // 
            this.progressBarYukleniyor.BackColor = System.Drawing.Color.LightSeaGreen;
            this.progressBarYukleniyor.Location = new System.Drawing.Point(159, 252);
            this.progressBarYukleniyor.Name = "progressBarYukleniyor";
            this.progressBarYukleniyor.Size = new System.Drawing.Size(327, 39);
            this.progressBarYukleniyor.TabIndex = 1;
            // 
            // labelYuzde
            // 
            this.labelYuzde.AutoSize = true;
            this.labelYuzde.BackColor = System.Drawing.Color.Transparent;
            this.labelYuzde.Font = new System.Drawing.Font("Barlow", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelYuzde.ForeColor = System.Drawing.Color.Turquoise;
            this.labelYuzde.Location = new System.Drawing.Point(305, 294);
            this.labelYuzde.Name = "labelYuzde";
            this.labelYuzde.Size = new System.Drawing.Size(28, 33);
            this.labelYuzde.TabIndex = 2;
            this.labelYuzde.Text = "s";
            // 
            // FrmYükleniyor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(679, 419);
            this.Controls.Add(this.labelYuzde);
            this.Controls.Add(this.progressBarYukleniyor);
            this.Controls.Add(this.labelYukleniyor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmYükleniyor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracKiralamaOtomasyonu";
            this.Load += new System.EventHandler(this.FrmYükleniyor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelYukleniyor;
        private System.Windows.Forms.Timer timerYukleniyor;
        private System.Windows.Forms.ProgressBar progressBarYukleniyor;
        private System.Windows.Forms.Label labelYuzde;
    }
}