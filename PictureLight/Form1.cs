using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PictureLight
{
    public partial class PictureLight : Form
    {

        public string selectTagName;
        public string fileName;

        public ImageList showImageListData;
   
        //初始化資料夾
        void initizeTag()
        {
            string path = System.Environment.CurrentDirectory + "\\PictureLightFile\\Tag\\";
            string[] dirs = Directory.GetDirectories(path);/*目錄(含路徑)的陣列*/
            ArrayList dirlist = new System.Collections.ArrayList();/*用來儲存只有目錄名的集合*/
            foreach (string item in dirs)
            {
                dirlist.Add(Path.GetFileNameWithoutExtension(item));//走訪每個元素只取得目錄名稱(不含路徑)並加入dirlist集合中
            }
            foreach (var item in dirlist)
            {//顯示目錄名稱(不含路徑)
                ListViewItem items = new ListViewItem(item.ToString());
                items.ImageIndex = 0;
                listView1.Items.AddRange(new ListViewItem[] { items });
            }

        }


        public PictureLight()
        {
            InitializeComponent();
      
        }

        private void PictureLight_Load(object sender, EventArgs e)
        {
            this.listView1.LargeImageList = TagPic;
            initizeTag();
            //開啟時修正xml錯誤檔案
            XMLRemove();
        }
        private void AddImageToImageList(ImageList iml, Bitmap bm, string key, float wid, float hgt)
        {
            // Make the bitmap.
            Bitmap iml_bm = new Bitmap(
            iml.ImageSize.Width,
            iml.ImageSize.Height);
            using (Graphics gr = Graphics.FromImage(iml_bm))
            {
                gr.Clear(Color.Transparent);
                gr.InterpolationMode = InterpolationMode.High;
                // See where we need to draw the image to scale it properly.
                RectangleF source_rect = new RectangleF(
                0, 0, bm.Width, bm.Height);
                RectangleF dest_rect = new RectangleF(
                0, 0, iml_bm.Width, iml_bm.Height);
                dest_rect = ScaleRect(source_rect, dest_rect);
                // Draw the image.
                gr.DrawImage(bm, dest_rect, source_rect,
                GraphicsUnit.Pixel);
            }
            // Add the image to the ImageList.
            iml.Images.Add(key, iml_bm);
        }
        private RectangleF ScaleRect(RectangleF source_rect, RectangleF dest_rect)
        {
            float source_aspect =
            source_rect.Width / source_rect.Height;
            float wid = dest_rect.Width;
            float hgt = dest_rect.Height;
            float dest_aspect = wid / hgt;
            if (source_aspect > dest_aspect)
            {
                // The source is relatively short and wide.
                // Use all of the available width.
                hgt = wid / source_aspect;
            }
            else
            {
                // The source is relatively tall and thin.
                // Use all of the available height.
                wid = hgt * source_aspect;
            }
            // Center it.
            float x = dest_rect.Left + (dest_rect.Width - wid) / 2;
            float y = dest_rect.Top + (dest_rect.Height - hgt) / 2;
            return new RectangleF(x, y, wid, hgt);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listviewData.Items.Clear();
            selectTagName = ((ListView)sender).FocusedItem.Text.ToString();
            changeToShowPicture(selectTagName);
        }
        public void changeToShowPicture(string tagName)
        {

            showImageListData = new ImageList();
            this.listviewData.LargeImageList = showImageListData;
            showImageListData.ImageSize = new Size(100, 100);
            showImageListData.ColorDepth = ColorDepth.Depth16Bit;

            //資料夾名稱+完整路徑
            string path = System.Environment.CurrentDirectory + "\\PictureLightFile\\Tag\\" + tagName + "\\";
            //取得裡面所有圖片暫存到imageList
            foreach (string url in System.IO.Directory.GetFileSystemEntries(path))
            {
                string fileName = url.Replace(path, "");
                // Get the image.
                Bitmap bm = new Bitmap(url);

                float source_aspect = bm.Width / (float)bm.Height;
                // Make the large image.
                AddImageToImageList(showImageListData,
                bm, fileName,
                showImageListData.ImageSize.Width,
                showImageListData.ImageSize.Height);
            }

            //加入到List裡面顯示出來
            for (int i = 0; i < showImageListData.Images.Keys.Count; i++)
            {
                ListViewItem items = new ListViewItem(showImageListData.Images.Keys[i].ToString());
                items.ImageIndex = i;
                listviewData.Items.AddRange(new ListViewItem[] { items });
            }
            GC.Collect();
        }


        string XMLGet(string tag, string name)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(".\\PictureLightFile\\Config.xml");
                XmlNode root = doc.SelectSingleNode("/PictureLight/Picture");
                foreach (XmlElement elm in root)
                {
                    if (elm.GetAttribute("Tag") == tag && elm.GetAttribute("FileName") == name)
                    {
                        return elm.GetAttribute("FileContent");
                    }

                }
            }
            catch (Exception e)
            {

            }
            return "";
        }

        void XMLInsert(string tag, string name, string content)
        {
            if (XMLGet(tag, name) == "")
            {
                //並沒有此筆資料，所以用插入
                XmlDocument doc = new XmlDocument();
                doc.Load(".\\PictureLightFile\\Config.xml");
                XmlNode root = doc.SelectSingleNode("/PictureLight/Picture");
                XmlElement info = doc.CreateElement("Information");
                info.SetAttribute("Tag", tag);
                info.SetAttribute("FileName", name);
                info.SetAttribute("FileContent", content);
                root.AppendChild(info);
                doc.Save(".\\PictureLightFile\\Config.xml");
            }
            else if (XMLGet(tag, name) != "")
            {
                //找到，此筆資料，使用修改
                XmlDocument doc = new XmlDocument();
                doc.Load(".\\PictureLightFile\\Config.xml");
                XmlNode root = doc.SelectSingleNode("/PictureLight/Picture");
                foreach (XmlElement elm in root)
                {
                    if (elm.GetAttribute("Tag") == tag && elm.GetAttribute("FileName") == name)
                    {
                        elm.SetAttribute("FileContent", content);
                    }
                }
                doc.Save(".\\PictureLightFile\\Config.xml");
            }

        }

        void XMLRemove()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(".\\PictureLightFile\\Config.xml");
            XmlNodeList root = doc.SelectSingleNode("/PictureLight/Picture").ChildNodes;

            for (int j = 0; j <= root.Count;j++ )
            {
                foreach (XmlNode xn in root)
                {
                    XmlElement xe = (XmlElement)xn;
                    int isExist = 0;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (xe.GetAttribute("Tag") == listView1.Items[i].Text)
                        {
                            isExist = 1;
                        }
                    }
                    if (isExist == 0)
                    {
                        doc.SelectSingleNode("/PictureLight/Picture").RemoveChild(xe);

                    }
                }
            }


            doc.Save(".\\PictureLightFile\\Config.xml");
        }

        private void listviewData_MouseClick(object sender, MouseEventArgs e)
        {
            fileName = ((ListView)sender).FocusedItem.Text.ToString();
            edttxt.Text = "正在編輯: " + selectTagName + " ->" + fileName;
            toolStripStatusLabel1.Text = "正在編輯: "+selectTagName+" ->" + fileName;
            toolStripStatusLabel1.ForeColor = Color.Green;
            ContentBox.Text = XMLGet(selectTagName, fileName);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XMLInsert(selectTagName, fileName, ContentBox.Text);
            toolStripStatusLabel1.Text =DateTime.Now.ToString("HH:mm:ss")+ "成功修改:" + fileName ;
            toolStripStatusLabel1.ForeColor = Color.Red;
        }

    }


}
