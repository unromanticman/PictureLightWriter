namespace PictureLight
{
    partial class PictureLight
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureLight));
            this.listView1 = new System.Windows.Forms.ListView();
            this.TagPic = new System.Windows.Forms.ImageList(this.components);
            this.listviewData = new System.Windows.Forms.ListView();
            this.imageListData = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ContentBox = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.edttxt = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(111, 449);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // TagPic
            // 
            this.TagPic.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TagPic.ImageStream")));
            this.TagPic.TransparentColor = System.Drawing.Color.Transparent;
            this.TagPic.Images.SetKeyName(0, "01.PNG");
            // 
            // listviewData
            // 
            this.listviewData.Location = new System.Drawing.Point(141, 40);
            this.listviewData.Name = "listviewData";
            this.listviewData.Size = new System.Drawing.Size(634, 231);
            this.listviewData.TabIndex = 1;
            this.listviewData.UseCompatibleStateImageBehavior = false;
            this.listviewData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listviewData_MouseClick);
            // 
            // imageListData
            // 
            this.imageListData.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListData.ImageSize = new System.Drawing.Size(100, 100);
            this.imageListData.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "個人分類";
            // 
            // ContentBox
            // 
            this.ContentBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContentBox.Location = new System.Drawing.Point(141, 308);
            this.ContentBox.Name = "ContentBox";
            this.ContentBox.Size = new System.Drawing.Size(634, 143);
            this.ContentBox.TabIndex = 3;
            this.ContentBox.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(703, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 31);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // edttxt
            // 
            this.edttxt.AutoSize = true;
            this.edttxt.Location = new System.Drawing.Point(140, 284);
            this.edttxt.Name = "edttxt";
            this.edttxt.Size = new System.Drawing.Size(32, 12);
            this.edttxt.TabIndex = 5;
            this.edttxt.Text = "編輯:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(787, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "狀態:無動作";
            // 
            // PictureLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.edttxt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ContentBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listviewData);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PictureLight";
            this.Text = "PictureLight";
            this.Load += new System.EventHandler(this.PictureLight_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList TagPic;
        private System.Windows.Forms.ListView listviewData;
        private System.Windows.Forms.ImageList imageListData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ContentBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label edttxt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}

