namespace TileMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.TB_North = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TB_South = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TB_West = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TB_East = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.BT_OpenImage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.LB_ImagePath = new MaterialSkin.Controls.MaterialLabel();
            this.LB_ImageInfo = new MaterialSkin.Controls.MaterialLabel();
            this.BT_Compute = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Image
            // 
            this.PB_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Image.Location = new System.Drawing.Point(60, 123);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(803, 404);
            this.PB_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Image.TabIndex = 0;
            this.PB_Image.TabStop = false;
            // 
            // TB_North
            // 
            this.TB_North.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TB_North.Depth = 0;
            this.TB_North.Hint = "North border latitude";
            this.TB_North.Location = new System.Drawing.Point(363, 94);
            this.TB_North.MouseState = MaterialSkin.MouseState.HOVER;
            this.TB_North.Name = "TB_North";
            this.TB_North.PasswordChar = '\0';
            this.TB_North.SelectedText = "";
            this.TB_North.SelectionLength = 0;
            this.TB_North.SelectionStart = 0;
            this.TB_North.Size = new System.Drawing.Size(207, 23);
            this.TB_North.TabIndex = 1;
            this.TB_North.UseSystemPasswordChar = false;
            // 
            // TB_South
            // 
            this.TB_South.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TB_South.Depth = 0;
            this.TB_South.Hint = "South border latitude";
            this.TB_South.Location = new System.Drawing.Point(363, 533);
            this.TB_South.MouseState = MaterialSkin.MouseState.HOVER;
            this.TB_South.Name = "TB_South";
            this.TB_South.PasswordChar = '\0';
            this.TB_South.SelectedText = "";
            this.TB_South.SelectionLength = 0;
            this.TB_South.SelectionStart = 0;
            this.TB_South.Size = new System.Drawing.Size(207, 23);
            this.TB_South.TabIndex = 1;
            this.TB_South.UseSystemPasswordChar = false;
            // 
            // TB_West
            // 
            this.TB_West.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TB_West.Depth = 0;
            this.TB_West.Hint = "West border longitude";
            this.TB_West.Location = new System.Drawing.Point(60, 533);
            this.TB_West.MouseState = MaterialSkin.MouseState.HOVER;
            this.TB_West.Name = "TB_West";
            this.TB_West.PasswordChar = '\0';
            this.TB_West.SelectedText = "";
            this.TB_West.SelectionLength = 0;
            this.TB_West.SelectionStart = 0;
            this.TB_West.Size = new System.Drawing.Size(207, 23);
            this.TB_West.TabIndex = 1;
            this.TB_West.UseSystemPasswordChar = false;
            // 
            // TB_East
            // 
            this.TB_East.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_East.Depth = 0;
            this.TB_East.Hint = "East border longitude";
            this.TB_East.Location = new System.Drawing.Point(656, 533);
            this.TB_East.MouseState = MaterialSkin.MouseState.HOVER;
            this.TB_East.Name = "TB_East";
            this.TB_East.PasswordChar = '\0';
            this.TB_East.SelectedText = "";
            this.TB_East.SelectionLength = 0;
            this.TB_East.SelectionStart = 0;
            this.TB_East.Size = new System.Drawing.Size(207, 23);
            this.TB_East.TabIndex = 1;
            this.TB_East.UseSystemPasswordChar = false;
            // 
            // BT_OpenImage
            // 
            this.BT_OpenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_OpenImage.Depth = 0;
            this.BT_OpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_OpenImage.Location = new System.Drawing.Point(11, 590);
            this.BT_OpenImage.MouseState = MaterialSkin.MouseState.HOVER;
            this.BT_OpenImage.Name = "BT_OpenImage";
            this.BT_OpenImage.Primary = true;
            this.BT_OpenImage.Size = new System.Drawing.Size(98, 32);
            this.BT_OpenImage.TabIndex = 2;
            this.BT_OpenImage.Text = "Open image";
            this.BT_OpenImage.UseVisualStyleBackColor = true;
            this.BT_OpenImage.Click += new System.EventHandler(this.BT_OpenImage_Click);
            // 
            // LB_ImagePath
            // 
            this.LB_ImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_ImagePath.AutoSize = true;
            this.LB_ImagePath.Depth = 0;
            this.LB_ImagePath.Font = new System.Drawing.Font("Roboto", 11F);
            this.LB_ImagePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB_ImagePath.Location = new System.Drawing.Point(115, 596);
            this.LB_ImagePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.LB_ImagePath.Name = "LB_ImagePath";
            this.LB_ImagePath.Size = new System.Drawing.Size(131, 19);
            this.LB_ImagePath.TabIndex = 3;
            this.LB_ImagePath.Text = "No image opened.";
            // 
            // LB_ImageInfo
            // 
            this.LB_ImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_ImageInfo.AutoSize = true;
            this.LB_ImageInfo.Depth = 0;
            this.LB_ImageInfo.Font = new System.Drawing.Font("Roboto", 11F);
            this.LB_ImageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB_ImageInfo.Location = new System.Drawing.Point(12, 629);
            this.LB_ImageInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.LB_ImageInfo.Name = "LB_ImageInfo";
            this.LB_ImageInfo.Size = new System.Drawing.Size(36, 38);
            this.LB_ImageInfo.TabIndex = 4;
            this.LB_ImageInfo.Text = "N/A\r\nN/A";
            this.LB_ImageInfo.Visible = false;
            // 
            // BT_Compute
            // 
            this.BT_Compute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Compute.Depth = 0;
            this.BT_Compute.Location = new System.Drawing.Point(767, 562);
            this.BT_Compute.MouseState = MaterialSkin.MouseState.HOVER;
            this.BT_Compute.Name = "BT_Compute";
            this.BT_Compute.Primary = false;
            this.BT_Compute.Size = new System.Drawing.Size(96, 32);
            this.BT_Compute.TabIndex = 5;
            this.BT_Compute.Text = "Compute";
            this.BT_Compute.UseVisualStyleBackColor = true;
            this.BT_Compute.Click += new System.EventHandler(this.BT_Compute_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 676);
            this.Controls.Add(this.BT_Compute);
            this.Controls.Add(this.LB_ImageInfo);
            this.Controls.Add(this.LB_ImagePath);
            this.Controls.Add(this.BT_OpenImage);
            this.Controls.Add(this.TB_East);
            this.Controls.Add(this.TB_West);
            this.Controls.Add(this.TB_South);
            this.Controls.Add(this.TB_North);
            this.Controls.Add(this.PB_Image);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 666);
            this.Name = "MainForm";
            this.Text = "Tile Maker";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Image;
        private MaterialSkin.Controls.MaterialSingleLineTextField TB_North;
        private MaterialSkin.Controls.MaterialSingleLineTextField TB_South;
        private MaterialSkin.Controls.MaterialSingleLineTextField TB_West;
        private MaterialSkin.Controls.MaterialSingleLineTextField TB_East;
        private MaterialSkin.Controls.MaterialRaisedButton BT_OpenImage;
        private MaterialSkin.Controls.MaterialLabel LB_ImagePath;
        private MaterialSkin.Controls.MaterialLabel LB_ImageInfo;
        private MaterialSkin.Controls.MaterialRaisedButton BT_Compute;
    }
}

