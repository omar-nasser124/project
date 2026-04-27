namespace WindowsFormsApplication1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            

            this.getMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizedImageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizedHistogramItem = new System.Windows.Forms.ToolStripMenuItem();

            this.filtersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.motionBlurItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeFilterItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossFilterItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianFilterItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastAdjustmentItem = new System.Windows.Forms.ToolStripMenuItem();

            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.editToolStripMenuItem,
            this.getMenu,
            this.grayscaleToolStripMenuItem,
            this.histToolStripMenuItem,
            
            this.filtersMenu});
            
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            // File & Open
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openToolStripMenuItem1 });
            this.openToolStripMenuItem.Text = "File";
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            //
            // Edit Menu
            //
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.darkenToolStripMenuItem,
            this.brightenToolStripMenuItem });

            this.editToolStripMenuItem.Text = "Edit";

            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);

            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);

            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);

            this.darkenToolStripMenuItem.Text = "Darken";
            this.darkenToolStripMenuItem.Click += new System.EventHandler(this.darkenToolStripMenuItem_Click);

            this.brightenToolStripMenuItem.Text = "Brighten";
            this.brightenToolStripMenuItem.Click += new System.EventHandler(this.brightenToolStripMenuItem_Click);

            // Get Menu (اللي في الصورة التانية)
            this.getMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.histogramItem,
                this.equalizedImageItem,
                this.equalizedHistogramItem});

            this.getMenu.Text = "get";
            this.histogramItem.Text = "histogram";
            this.histogramItem.Click += new System.EventHandler(this.histToolStripMenuItem_Click);

            this.equalizedImageItem.Text = "equalized image";
            this.equalizedImageItem.Click += new System.EventHandler(this.equalizedImageToolStripMenuItem_Click);

            this.equalizedHistogramItem.Text = "equalized histogram";
            this.equalizedHistogramItem.Click += new System.EventHandler(this.equalizedHistogramToolStripMenuItem_Click);
         
            // Others
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);

            this.histToolStripMenuItem.Text = "Histogram";
            this.histToolStripMenuItem.Click += new System.EventHandler(this.histToolStripMenuItem_Click);

            
            // 
            // filtersMenu
            // 
            this.filtersMenu.Text = "Filters";
            this.filtersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.motionBlurItem,
            this.negativeFilterItem,
            this.embossFilterItem,
            this.laplacianFilterItem,
            this.contrastAdjustmentItem
        });

            // 
            // motionBlurItem
            // 
            this.motionBlurItem.Text = "Motion Blur";
            this.motionBlurItem.Click += new System.EventHandler(this.motionBlurItem_Click);
          
            this.negativeFilterItem.Text = "Negative Filter";
            this.negativeFilterItem.Click += new System.EventHandler(this.negativeFilterItem_Click);

            this.embossFilterItem.Text = "Emboss Filter";
            this.embossFilterItem.Click += new System.EventHandler(this.embossFilterItem_Click);

            
            this.laplacianFilterItem.Text = "Laplacian Filter";
            this.laplacianFilterItem.Click += new System.EventHandler(this.laplacianFilterItem_Click);

            this.contrastAdjustmentItem.Text = "Contrast Adjustment";
            this.contrastAdjustmentItem.Click += new System.EventHandler(this.contrastAdjustmentItem_Click);
            // PictureBoxes
            // PictureBoxes - ترتيب الصور (Original & Result)
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Size = new System.Drawing.Size(380, 280);
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.pictureBox2.Location = new System.Drawing.Point(410, 40);
            this.pictureBox2.Size = new System.Drawing.Size(380, 280);
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // PictureBoxes - ترتيب الهيستوجرام (Original Hist & Equalized Hist)
            this.pictureBox3.Location = new System.Drawing.Point(12, 330);
            this.pictureBox3.Size = new System.Drawing.Size(380, 200);
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.pictureBox4.Location = new System.Drawing.Point(410, 330);
            this.pictureBox4.Size = new System.Drawing.Size(380, 200);
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // Form
            this.ClientSize = new System.Drawing.Size(810, 580);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Image Processor - OpenCV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getMenu;
        private System.Windows.Forms.ToolStripMenuItem histogramItem;
        private System.Windows.Forms.ToolStripMenuItem equalizedImageItem;
        private System.Windows.Forms.ToolStripMenuItem equalizedHistogramItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem filtersMenu;
        private System.Windows.Forms.ToolStripMenuItem motionBlurItem;
        private System.Windows.Forms.ToolStripMenuItem negativeFilterItem;
        private System.Windows.Forms.ToolStripMenuItem embossFilterItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianFilterItem;
        private System.Windows.Forms.ToolStripMenuItem contrastAdjustmentItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}