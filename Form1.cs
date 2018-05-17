using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GifCreator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private List<Mage> listMage = new List<Mage>();
        private int indexer = 0;
        private string ArchiveName = "";
        private string fastDirectory = "";

        private Image loadImage(string path) {
            string ext = path.Split('.').Last().ToLower();
            ImageFormat imgFormat = ImageFormat.Jpeg;


            var f = new FileInfo(path);
            //ArchiveName = f.Directory.Name;
            ArchiveName = f.Name.Replace(f.Extension, "");
            fastDirectory = f.DirectoryName;
            //ArchiveName = ArchiveName.Remove(0, 5);

            switch (ext) {
                case "gif":
                    imgFormat = ImageFormat.Gif;
                    break;
                case "bmp":
                    imgFormat = ImageFormat.Bmp;
                    break;
                case "ico":
                    imgFormat = ImageFormat.Icon;
                    break;
                case "png":
                    imgFormat = ImageFormat.Png;
                    break;
                case "tiff":
                    imgFormat = ImageFormat.Tiff;
                    break;
                default:
                    imgFormat = ImageFormat.Jpeg;
                    break;
            }

            MemoryStream mS = new MemoryStream();
            using (Image i = Image.FromFile(path)) {
                i.Save(mS, imgFormat);
            }

            return Image.FromStream(mS);
        }
        private Image ResizeImage(Image img, int width, int height) {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destBitmap = new Bitmap(width, height);

            destBitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics graph = Graphics.FromImage(destBitmap)) {
                graph.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                graph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

                using (ImageAttributes wrap = new ImageAttributes()) {
                    wrap.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graph.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrap);
                }
            }

            return destBitmap;
        }

        private MemoryStream GenerateGif() {
            int frameDelay = 500;
            if (!string.IsNullOrEmpty(tbFrameDelay.Text)) {
                frameDelay = Convert.ToInt32(tbFrameDelay.Text);
            }

            MemoryStream mS = new MemoryStream();
            GifWriter gifWriter = new GifWriter(mS, frameDelay);
            for (int i = 0; i < listMage.Count(); i++) {
                gifWriter.WriteFrame(listMage[i].image);
            }

            if (cB_Forward.Checked) {
                for (int i = listMage.Count() - 2; i > 0; i--) {
                    gifWriter.WriteFrame(listMage[i].image);
                }
            }

            return mS;
        }
        public class Mage {
            public int id { get; set; }
            public Image image { get; set; }
            public string Path { get; set; }

            public PictureBox pictureBox { get; set; }
            public Button btnBackward { get; set; }
            public Button btnForward { get; set; }
            public Button btnRemove { get; set; }
        }

        #region Buttons and Icons
        private void Form1_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files) {
                listMage.Add(createMage(file));
            }
        }

        private void pnlDrop_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void pnlDrop_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files) {
                listMage.Add(createMage(file));
            }
        }

        private void btnBackward_Click(object sender, EventArgs e) {
            int posX = listMage.IndexOf(listMage.Where(p => p.btnBackward.Name == ((Button)sender).Name).FirstOrDefault());
            int id = listMage[posX].id;

            if (id == 0) {
                return; // Already at the start
            }

            int posY = listMage.IndexOf(listMage.Where(p => p.id == id - 1).FirstOrDefault());

            listMage[posX].id = id - 1;
            listMage[posY].id = id;

            reorganizeThumbs();
        }

        private void btnForward_Click(object sender, EventArgs e) {
            int posX = listMage.IndexOf(listMage.Where(p => p.btnForward.Name == ((Button)sender).Name).FirstOrDefault());
            int id = listMage[posX].id;

            if (id == listMage.Count() - 1) {
                return; // Already at the end
            }

            int posY = listMage.IndexOf(listMage.Where(p => p.id == id + 1).FirstOrDefault());

            listMage[posX].id = id + 1;
            listMage[posY].id = id;

            reorganizeThumbs();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            int posX = listMage.IndexOf(listMage.Where(p => p.btnRemove.Name == ((Button)sender).Name).FirstOrDefault());

            listMage[posX].pictureBox.Dispose();
            listMage[posX].btnBackward.Dispose();
            listMage[posX].btnForward.Dispose();
            listMage[posX].btnRemove.Dispose();

            listMage.RemoveAt(posX);

            reorganizeThumbs();
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            picMain.Image = Image.FromStream(GenerateGif());

            decimal diffWidth = (decimal)pnlMain.Width / picMain.Image.Width;
            decimal diffHeight = (decimal)pnlMain.Height / picMain.Image.Height;

            decimal min = diffWidth > diffHeight ? diffHeight : diffWidth;

            if (min < 1) {
                picMain.Height = (int)(picMain.Image.Height * min);
                picMain.Width = (int)(picMain.Image.Width * min);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Image img = Image.FromStream(GenerateGif());

            saveFileDialog.FileName = ArchiveName;

            saveFileDialog.ShowDialog();
            string savePath = saveFileDialog.FileName;

            img.Save(savePath, ImageFormat.Gif);
        }

        private void btnFastSave_Click(object sender, EventArgs e) {
            Image img = Image.FromStream(GenerateGif());

            string fullPath =  fastDirectory + "\\" + ArchiveName + ".gif";
            img.Save(fullPath, ImageFormat.Gif);

            if (cBremoveStatic.Checked) {
                    foreach (var mage in listMage) {
                    File.Delete(mage.Path);
                }
            }

            Clear();
        }
        #endregion

        #region Create and Manange Thumbs
        private Mage createMage(string path) {
            Image img = loadImage(path);

            PictureBox pictureBox = new PictureBox();
            Button btnBackward = new Button();
            Button btnForward = new Button();
            Button btnRemove = new Button();

            pictureBox.Location = new Point(12 + (106 * listMage.Count()), 5);
            pictureBox.Name = "picImageThumb_" + indexer;
            pictureBox.Size = new Size(100, 66);
            pictureBox.Image = ResizeImage(img, 100, 66);

            btnBackward.Location = new Point(12 + (106 * listMage.Count()), 76);
            btnBackward.Name = "btnBackward_" + indexer;
            btnBackward.Size = new Size(27, 23);
            btnBackward.Text = "<";
            btnBackward.UseVisualStyleBackColor = true;
            btnBackward.Click += new EventHandler(this.btnBackward_Click);

            btnForward.Location = new Point(38 + (106 * listMage.Count()), 76);
            btnForward.Name = "btnForward_" + indexer;
            btnForward.Size = new Size(27, 23);
            btnForward.Text = ">";
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += new EventHandler(this.btnForward_Click);

            btnRemove.Location = new Point(77 + (106 * listMage.Count()), 76);
            btnRemove.Name = "btnRemove_" + indexer;
            btnRemove.Size = new Size(35, 23);
            btnRemove.Text = "X";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += new EventHandler(this.btnRemove_Click);

            pnlImages.Controls.Add(pictureBox);
            pnlImages.Controls.Add(btnBackward);
            pnlImages.Controls.Add(btnForward);
            pnlImages.Controls.Add(btnRemove);

            indexer++;

            return new Mage() {
                id = listMage.Count(),
                Path = path,
                image = img,
                pictureBox = pictureBox,
                btnBackward = btnBackward,
                btnForward = btnForward,
                btnRemove = btnRemove
            };
        }

        private void reorganizeThumbs() {
            listMage = listMage.OrderBy(p => p.id).ToList();

            for (int i = 0; i < listMage.Count(); i++) {
                listMage[i].id = i;

                listMage[i].pictureBox.Location = new Point(12 + (106 * i), 5);
                listMage[i].btnBackward.Location = new Point(12 + (106 * i), 76);
                listMage[i].btnForward.Location = new Point(38 + (106 * i), 76);
                listMage[i].btnRemove.Location = new Point(77 + (106 * i), 76);
            }
        }

        private void Clear() {
            while (listMage.Count() > 0) {
                listMage[0].pictureBox.Dispose();
                listMage[0].btnBackward.Dispose();
                listMage[0].btnForward.Dispose();
                listMage[0].btnRemove.Dispose();

                listMage.RemoveAt(0);
            }

            //reorganizeThumbs();
        }
        #endregion
    }
}
