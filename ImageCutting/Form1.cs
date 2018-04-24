using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCutting
{
    public partial class Form1 : Form
    {
        private string[] files;
        private int ImageIndex = 0;
        private string pathRoot;
        private string currentImgName;
        private Graphics g;
        private Point mouseDown;
        Point[] rectangle = new Point[4];
        private string[] path = { "processed\\strobile\\",
                                "processed\\spice\\",
                                "processed\\smoke\\",
                                "processed\\powder\\",
                                "processed\\pill\\",
                                "processed\\mark\\",
                                "processed\\injector\\",
                                "processed\\inhalant\\",
                                "processed\\crystal\\",
                                "processed\\cocaine\\",
                                "processed\\cigarette\\",
                                "processed\\cannibisSign\\",
                                "processed\\cannibis\\",
                                "processed\\bong\\"};

        public Form1()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            g = pictureBox.CreateGraphics();
            files = Directory.GetFiles("D:\\drugs_twitter\\drugs_twitter");
        }

        private void checkOrCreatePath()
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (!Directory.Exists(pathRoot + path[i]))
                {
                    Directory.CreateDirectory(pathRoot + path[i]);
                }
            }
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pathRoot = Directory.GetDirectoryRoot(fbd.SelectedPath);
                    files = Directory.GetFiles(fbd.SelectedPath);
                    MessageBox.Show("Количество файлов: " + files.Length.ToString(), "Message");
                }
            }
            checkOrCreatePath();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            prev();
        }

        private void prev()
        {
            g.Clear(Color.AliceBlue);
            try
            {
                g = pictureBox.CreateGraphics();
                if (ImageIndex > 0)
                {
                    ImageIndex--;
                    loadImg();
                }
            }
            catch (Exception)
            {

            }
        }

        private void nextImgButton_Click(object sender, EventArgs e)
        {
            next();
        }

        private void next()
        {
            g.Clear(Color.AliceBlue);
            try
            {
                if (ImageIndex < files.Length - 1)
                {
                    ImageIndex++;
                    loadImg();
                }
            }
            catch (Exception)
            {

            }
        }

        private void loadImg()
        {
            try
            {
                ImgNameTextBox.Text = files[ImageIndex];
                currentImgName = Path.GetFileName(files[ImageIndex]);

                Bitmap image = new Bitmap(files[ImageIndex]);
                int w = pictureBox.Width - image.Width;
                int h = pictureBox.Height - image.Height;
                if (w < 0 || h < 0)
                {
                    if (w < h)
                    {
                        image = new Bitmap(image, image.Width + w, image.Height + w);
                    }
                    else
                    {
                        image = new Bitmap(image, image.Width + h, image.Height + h);
                    }
                }

                pictureBox.Image = image;
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }

        private void strobileButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\strobile\\" + currentImgName;
            save(imgToSave);
        }

        private void spoonfulButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\spoonful\\" + currentImgName;
            save(imgToSave);
        }

        private void spiceButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\spice\\" + currentImgName;
            save(imgToSave);
        }

        private void smokeButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\smoke\\" + currentImgName;
            save(imgToSave);
        }

        private void powderButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\powder\\" + currentImgName;
            save(imgToSave);
        }

        private void pillButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\pill\\" + currentImgName;
            save(imgToSave);
        }

        private void markButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\mark\\" + currentImgName;
            save(imgToSave);
        }

        private void injectorButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\injector\\" + currentImgName;
            save(imgToSave);
        }

        private void inhalantButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\inhalant\\" + currentImgName;
            save(imgToSave);
        }

        private void crystalButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\crystal\\" + currentImgName;
            save(imgToSave);
        }

        private void cocaineButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\cocaine\\" + currentImgName;
            save(imgToSave);
        }

        private void cigaretteButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\cigarette\\" + currentImgName;
            save(imgToSave);
        }

        private void cannibisSignButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\cannibisSign\\" + currentImgName;
            save(imgToSave);
        }

        private void cannibisButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\cannibis\\" + currentImgName;
            save(imgToSave);
        }

        private void bongButton_Click(object sender, EventArgs e)
        {
            string imgToSave = pathRoot + "processed\\bong\\" + currentImgName;
            save(imgToSave);
        }

        private void save(string imgToSave)
        {
            savedToTextBox.Text = imgToSave;
            int realW = ((pictureBox.Width) - (pictureBox.Image.Width)) / 2;
            int realH = ((pictureBox.Height) - (pictureBox.Image.Height)) / 2;
            Rectangle r = new Rectangle(
                (rectangle[0].X - realW),
                (rectangle[0].Y - realH),
               ((rectangle[1].X - realW) - (rectangle[0].X - realW)),
               ((rectangle[3].Y - realH) - (rectangle[0].Y - realH)));
            
            Image toSave = Copy(pictureBox.Image, r);
            toSave.Save(imgToSave);
            pictureBox.Image = toSave;
            next();
        }

        public Image Copy(Image srcBitmap, Rectangle cropArea)
        {
            Bitmap nb = new Bitmap(cropArea.Width, cropArea.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(srcBitmap, -cropArea.X, -cropArea.Y);
            return nb;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = new Point(e.X, e.Y);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            rectangle[0] = mouseDown;
            rectangle[1] = new Point(e.X, mouseDown.Y);
            rectangle[2] = new Point(e.X, e.Y);
            rectangle[3] = new Point(mouseDown.X, e.Y);
            g.DrawPolygon(Pens.Red, rectangle);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox.CreateGraphics();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            g = pictureBox.CreateGraphics();
        }
    }
}
