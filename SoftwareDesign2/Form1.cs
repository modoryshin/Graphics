using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SoftwareDesign2
{
    public partial class frmMain : Form
    {
        public string extra = "pen";
        public Pen p = new Pen(Color.Black, 10);
        int forname = 1;
        public Size cur=new Size(0,0);
        public bool todel = false;
        public string Filename=null;
        Bitmap bmap;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frm = new frmChild();
            frm.MdiParent = this;
            frm.Text = (forname).ToString();
            frm.Show();
            forname++;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            sfd.Title = "Saving Image";
            sfd.ShowHelp = true;
            frmChild child = this.ActiveMdiChild as frmChild;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    child.Save(sfd.FileName);
                    child.changed = false;
                }
                catch
                {
                    MessageBox.Show("Unable to save the image", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //че нажали в окне

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    frmChild frm = new frmChild();
                    frm.MdiParent = this;
                    frm.Text = (forname).ToString();
                    frm.Show();
                    Bitmap image = new Bitmap(ofd.FileName);
                    frm.pictureBox1.Size = image.Size;
                    frm.pictureBox1.Image = image;
                    frm.pictureBox1.Invalidate();
                    Filename = ofd.FileName;
                    forname++;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Unable to open the image",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Random rn = new Random();
            frmChild child = this.ActiveMdiChild as frmChild;
            if (child.changed)
            {
                DialogResult tr = MessageBox.Show("Сохранить изображение перед закрытием?", this.Text, MessageBoxButtons.YesNo);

                if (tr == DialogResult.Yes)
                {
                    if (Filename != null)
                    {
                        child.Save(@"D:\\Pictures\\" + rn.Next(0, 100000) + ".BMP");
                    }
                    else // сохранение нового файла
                    {
                        child.Save(@"D:\\Pictures\\" + rn.Next(0, 100000) + ".BMP");
                    }
                }
            }
                this.Close();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "pen";
                toolStripButton1.BackColor=Color.Maroon;
                toolStripDropDownButton1.BackColor = Color.Gainsboro;
                toolStripButton2.BackColor = Color.Gainsboro;
                toolStripButton3.BackColor = Color.Gainsboro;
                toolStripButton4.BackColor = Color.Gainsboro;
                toolStripDropDownButton2.BackColor = Color.Gainsboro;
            }
            catch { }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                if (Filename != null)
                {
                    child.pictureBox1.Image.Save(Filename);
                }
                else
                {
                    Random rn = new Random();
                    child.pictureBox1.Image.Save(@"D:\\Pictures\\" + rn.Next(0, 100000) + ".BMP");
                }
            }
            catch
            {
                MessageBox.Show("Unable to save the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.fc.Close();
            frmChild frm = new frmChild();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Width = 5.0F;
                toolStripMenuItem3.BackColor = Color.Maroon;
                toolStripMenuItem4.BackColor = Color.Gainsboro;
                toolStripMenuItem5.BackColor = Color.Gainsboro;
                toolStripMenuItem6.BackColor = Color.Gainsboro;
                toolStripMenuItem7.BackColor = Color.Gainsboro;
            }
            catch
            {

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Width = 7.5F;
                toolStripMenuItem3.BackColor = Color.Gainsboro;
                toolStripMenuItem4.BackColor = Color.Maroon;
                toolStripMenuItem5.BackColor = Color.Gainsboro;
                toolStripMenuItem6.BackColor = Color.Gainsboro;
                toolStripMenuItem7.BackColor = Color.Gainsboro;
            }
            catch
            {

            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
               p.Width = 10F;
                toolStripMenuItem3.BackColor = Color.Gainsboro;
                toolStripMenuItem4.BackColor = Color.Gainsboro;
                toolStripMenuItem5.BackColor = Color.Maroon;
                toolStripMenuItem6.BackColor = Color.Gainsboro;
                toolStripMenuItem7.BackColor = Color.Gainsboro;
            }
            catch
            {

            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
               p.Width = 12.5F;
                toolStripMenuItem3.BackColor = Color.Gainsboro;
                toolStripMenuItem4.BackColor = Color.Gainsboro;
                toolStripMenuItem5.BackColor = Color.Gainsboro;
                toolStripMenuItem6.BackColor = Color.Maroon;
                toolStripMenuItem7.BackColor = Color.Gainsboro;
            }
            catch
            {

            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Width = 15.5F;
                toolStripMenuItem3.BackColor = Color.Gainsboro;
                toolStripMenuItem4.BackColor = Color.Gainsboro;
                toolStripMenuItem5.BackColor = Color.Gainsboro;
                toolStripMenuItem6.BackColor = Color.Gainsboro;
                toolStripMenuItem7.BackColor = Color.Maroon;
            }
            catch
            {

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "eraser";
                toolStripButton1.BackColor = Color.Gainsboro;
                toolStripDropDownButton1.BackColor = Color.Gainsboro;
                toolStripButton2.BackColor = Color.Maroon;
                toolStripButton3.BackColor = Color.Gainsboro;
                toolStripButton4.BackColor = Color.Gainsboro;
                toolStripDropDownButton2.BackColor = Color.Gainsboro;
            }
            catch { }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "star";
                toolStripButton1.BackColor = Color.Gainsboro;
                toolStripDropDownButton1.BackColor = Color.Gainsboro;
                toolStripButton2.BackColor = Color.Gainsboro;
                toolStripButton3.BackColor = Color.Maroon;
                toolStripButton4.BackColor = Color.Gainsboro;
                toolStripDropDownButton2.BackColor = Color.Gainsboro;
            }
            catch { }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "line";
            }
            catch { }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch { }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "ellipse";
            }
            catch { }
        }

        private void leftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.LayoutMdi(MdiLayout.TileVertical);
            }
            catch { }
        }

        private void topToBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }
            catch { }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.LayoutMdi(MdiLayout.Cascade);
            }
            catch { }
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.LayoutMdi(MdiLayout.ArrangeIcons);
            }
            catch { }
        }

        private void e1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                bmap = new Bitmap(child.pictureBox1.Image);
                child.pictureBox1.Image = bmap;
                Bitmap tmp = new Bitmap(child.pictureBox1.Image);
                int DX = 1;
                int DY = 1;
                int red, green, blue;
                int i, j;
                for (i = 0; i < tmp.Height - 2; i++)
                {
                    for (j = 0; j < tmp.Width - 2; j++)
                    {
                        System.Drawing.Color pixel1;
                        System.Drawing.Color pixel2;
                        pixel1 = tmp.GetPixel(j, i);
                        pixel2 = tmp.GetPixel(DX + j, DY + i);
                        red = Math.Min(Math.Abs((int)(pixel1.R) - (int)(pixel2.R)) + 128, 255);
                        green = Math.Min(Math.Abs((int)(pixel1.G) - (int)(pixel2.G)) + 128, 255);
                        blue = Math.Min(Math.Abs((int)(pixel1.B) - (int)(pixel2.B)) + 128, 255);
                        bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                    }
                    if (i % 10 == 0)
                    {
                        child.pictureBox1.Invalidate();
                        child.pictureBox1.Refresh();
                        child.Text = ((int)(100 * i / (child.pictureBox1.Image.Height - 2))).ToString() + "%";
                    }
                }
                child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void e2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                bmap = new Bitmap(child.pictureBox1.Image);
                child.pictureBox1.Image = bmap;
                Bitmap tmp = new Bitmap(child.pictureBox1.Image);
                int DX = 1;
                int DY = 1;
                double red, green, blue;
                int i, j;
                for (i = DX; i < child.pictureBox1.Image.Height - DX - 1; i++)
                {
                    for (j = DY; j < child.pictureBox1.Image.Width - DY - 1; j++)
                    {
                        red = (double)(tmp.GetPixel(j, i).R) + 0.5 * (double)(tmp.GetPixel(j, i).R) - (int)(tmp.GetPixel(j - DX, i - DY).R);
                        green = (double)(tmp.GetPixel(j, i).G) + 0.7 * (double)(tmp.GetPixel(j, i).G) - (int)(tmp.GetPixel(j - DX, i - DY).G);
                        blue = (double)(tmp.GetPixel(j, i).B) + 0.5 * (double)(tmp.GetPixel(j, i).B) - (int)(tmp.GetPixel(j - DX, i - DY).B);
                        red = Math.Min(Math.Max(red, 0), 255);
                        green = Math.Min(Math.Max(green, 0), 255);
                        blue = Math.Min(Math.Max(blue, 0), 255);
                        bmap.SetPixel(j, i, Color.FromArgb((int)red, (int)green, (int)blue));

                    }
                    if (i % 10 == 0)
                    {
                        child.pictureBox1.Invalidate();
                        child.Text = ((int)(100 * i / (child.pictureBox1.Image.Height - 2))).ToString() + "%";
                    }
                }
               child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch{ }
        }

        private void e3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                bmap = new Bitmap(child.pictureBox1.Image);
                child.pictureBox1.Image = bmap;
                Bitmap tmp = new Bitmap(child.pictureBox1.Image);
                int DX = 1;
                int DY = 1;
                double red, green, blue;
                int i, j;
                for (i = DX; i < child.pictureBox1.Image.Height - DX - 1; i++)
                {
                    for (j = DY; j < child.pictureBox1.Image.Width - DY - 1; j++)
                    {
                        red = (double)(((int)(tmp.GetPixel(j - 1, i - 1).R) + (int)(tmp.GetPixel(j - 1, i).R) + (int)(tmp.GetPixel(j - 1, i + 1).R) + (int)(tmp.GetPixel(j, i - 1).R) + (int)(tmp.GetPixel(j, i).R) + (int)(tmp.GetPixel(j, i + 1).R) + (int)(tmp.GetPixel(j + 1, i - 1).R) + (int)(tmp.GetPixel(j + 1, i).R) + (int)(tmp.GetPixel(j + 1, i + 1).R)) / 9);
                        green = (double)(((int)(tmp.GetPixel(j - 1, i - 1).G) + (int)(tmp.GetPixel(j - 1, i).G) + (int)(tmp.GetPixel(j - 1, i + 1).G) + (int)(tmp.GetPixel(j, i - 1).G) + (int)(tmp.GetPixel(j, i).G) + (int)(tmp.GetPixel(j, i + 1).G) + (int)(tmp.GetPixel(j + 1, i - 1).G) + (int)(tmp.GetPixel(j + 1, i).G) + (int)(tmp.GetPixel(j + 1, i + 1).G)) / 9);
                        blue = (double)(((int)(tmp.GetPixel(j - 1, i - 1).B) + (int)(tmp.GetPixel(j - 1, i).B) + (int)(tmp.GetPixel(j - 1, i + 1).B) + (int)(tmp.GetPixel(j, i - 1).B) + (int)(tmp.GetPixel(j, i).B) + (int)(tmp.GetPixel(j, i + 1).B) + (int)(tmp.GetPixel(j + 1, i - 1).B) + (int)(tmp.GetPixel(j + 1, i).B) + (int)(tmp.GetPixel(j + 1, i + 1).B)) / 9);
                        red = Math.Min(Math.Max(red, 0), 255);
                        green = Math.Min(Math.Max(green, 0), 255);
                        blue = Math.Min(Math.Max(blue, 0), 255);
                        bmap.SetPixel(j, i, Color.FromArgb((int)red, (int)green, (int)blue));

                    }
                    if (i % 10 == 0)
                    {
                        child.pictureBox1.Invalidate();
                       child.pictureBox1.Refresh();
                       child.Text = ((int)(100 * i / (child.pictureBox1.Image.Height - 2))).ToString() + "%";
                    }
                }
               child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void e4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                if (cur.Width != 0 && cur.Height != 0)
                {
                    Size newSize = new Size(cur.Width, cur.Height);
                    Bitmap mbmp = new Bitmap(child.ns, newSize);
                    child.pictureBox1.Image = mbmp;
                    child.pictureBox1.Refresh();
                    child.ns = new Bitmap(child.pictureBox1.Image);
                }
            }
            catch { }
        }

        private void e5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                Bitmap originalBitmap = new Bitmap(child.pictureBox1.Image);
                if (cur.Width == 0 && cur.Height == 0)
                {
                    cur = new Size(originalBitmap.Width, originalBitmap.Height);
                }
                Size newSize = new Size((int)(originalBitmap.Width * 2), (int)(originalBitmap.Height * 2));
                Bitmap bmp = new Bitmap(originalBitmap, newSize);
                child.pictureBox1.Image = bmp;
            }
            catch { }
        }

        private void e6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                Bitmap originalBitmap = new Bitmap(child.pictureBox1.Image);
                if (cur.Width == 0 && cur.Height == 0)
                {
                    cur = new Size(originalBitmap.Width, originalBitmap.Height);
                }
                Size newSize = new Size((int)(originalBitmap.Width / 2), (int)(originalBitmap.Height / 2));
                Bitmap bmp = new Bitmap(originalBitmap, newSize);
                child.pictureBox1.Image = bmp;
            }
            catch { }
        }

        private void e7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                Random rnd = new Random();
                bmap = new Bitmap(child.pictureBox1.Image);
                child.pictureBox1.Image = bmap;
                Bitmap tmp = new Bitmap(child.pictureBox1.Image);
                int DX = 1;
                int DY = 1;
                double red, green, blue;
                int i, j;
                for (i = 3; i < tmp.Height - 3; i++)
                {
                    for (j = 3; j < tmp.Width-3; j++)
                    {
                        DX = rnd.Next(2) * 4 - 2;
                        DY = rnd.Next(2) * 4 - 2;
                        red = tmp.GetPixel(j + DX, i + DY).R;
                        green = tmp.GetPixel(j + DX, i + DY).G;
                        blue = tmp.GetPixel(j + DX, i + DY).B;
                        bmap.SetPixel(j, i, Color.FromArgb((int)red, (int)green, (int)blue));
                    }
                    child.Text = ((int)(100 * i / (tmp.Height - 2))).ToString() + "%";
                    if (i % 10 == 0)
                    {
                        child.pictureBox1.Invalidate();
                        child.pictureBox1.Refresh();
                    }
                    child.Text = ((int)(100 * i / (child.pictureBox1.Height - 2))).ToString() + "%";
                }
                child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void e11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                child.pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void e10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                child.pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void e9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                child.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
               child.pictureBox1.Width = child.pictureBox1.Height * child.pictureBox1.Width / child.pictureBox1.Height;
                child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void e8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                child.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                child.pictureBox1.Width = child.pictureBox1.Height * child.pictureBox1.Width / child.pictureBox1.Height;
                child.pictureBox1.Refresh();
                child.ns = new Bitmap(child.pictureBox1.Image);
            }
            catch { }
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "ellipse";
                toolStripButton1.BackColor = Color.Gainsboro;
                toolStripDropDownButton1.BackColor = Color.Gainsboro;
                toolStripButton2.BackColor = Color.Gainsboro;
                toolStripButton3.BackColor = Color.Gainsboro;
                toolStripButton4.BackColor = Color.Gainsboro;
                toolStripDropDownButton2.BackColor = Color.Maroon;
            }
            catch { }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                extra = "line";
                toolStripButton1.BackColor = Color.Gainsboro;
                toolStripDropDownButton1.BackColor = Color.Gainsboro;
                toolStripButton2.BackColor = Color.Gainsboro;
                toolStripButton3.BackColor = Color.Gainsboro;
                toolStripButton4.BackColor = Color.Maroon;
                toolStripDropDownButton2.BackColor = Color.Gainsboro;
            }
            catch { }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.BackColor = Color.Gainsboro;
            toolStripDropDownButton1.BackColor = Color.Maroon;
            toolStripButton2.BackColor = Color.Gainsboro;
            toolStripButton3.BackColor = Color.Gainsboro;
            toolStripButton4.BackColor = Color.Gainsboro;
            toolStripDropDownButton2.BackColor = Color.Gainsboro;
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Red;
                toolStripButton5.BackColor = Color.Brown;
                toolStripButton7.BackColor = Color.Orange;
                toolStripButton8.BackColor = Color.Yellow;
                toolStripButton9.BackColor = Color.Lime;
                toolStripButton10.BackColor = Color.Aqua;
                toolStripButton11.BackColor = Color.Blue;
                toolStripButton12.BackColor = Color.Fuchsia;


            }
            catch { }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Orange;
                toolStripButton5.BackColor = Color.Red;
                toolStripButton7.BackColor = Color.Brown;
                toolStripButton8.BackColor = Color.Yellow;
                toolStripButton9.BackColor = Color.Lime;
                toolStripButton10.BackColor = Color.Aqua;
                toolStripButton11.BackColor = Color.Blue;
                toolStripButton12.BackColor = Color.Fuchsia;
            }
            catch { }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Yellow;
                toolStripButton5.BackColor = Color.Red;
                toolStripButton7.BackColor = Color.Orange;
                toolStripButton8.BackColor = Color.Brown;
                toolStripButton9.BackColor = Color.Lime;
                toolStripButton10.BackColor = Color.Aqua;
                toolStripButton11.BackColor = Color.Blue;
                toolStripButton12.BackColor = Color.Fuchsia;
            }
            catch { }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Lime;
                toolStripButton5.BackColor = Color.Red;
                toolStripButton7.BackColor = Color.Orange;
                toolStripButton8.BackColor = Color.Yellow;
                toolStripButton9.BackColor = Color.Brown;
                toolStripButton10.BackColor = Color.Aqua;
                toolStripButton11.BackColor = Color.Blue;
                toolStripButton12.BackColor = Color.Fuchsia;
            }
            catch { }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Aqua;
                toolStripButton5.BackColor = Color.Red;
                toolStripButton7.BackColor = Color.Orange;
                toolStripButton8.BackColor = Color.Yellow;
                toolStripButton9.BackColor = Color.Lime;
                toolStripButton10.BackColor = Color.Brown;
                toolStripButton11.BackColor = Color.Blue;
                toolStripButton12.BackColor = Color.Fuchsia;
            }
            catch { }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Blue;
                toolStripButton5.BackColor = Color.Red;
                toolStripButton7.BackColor = Color.Orange;
                toolStripButton8.BackColor = Color.Yellow;
                toolStripButton9.BackColor = Color.Lime;
                toolStripButton10.BackColor = Color.Aqua;
                toolStripButton11.BackColor = Color.Brown;
                toolStripButton12.BackColor = Color.Fuchsia;
            }
            catch { }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            frmChild child = this.ActiveMdiChild as frmChild;
            try
            {
                p.Color = Color.Fuchsia;
                toolStripButton5.BackColor = Color.Red;
                toolStripButton7.BackColor = Color.Orange;
                toolStripButton8.BackColor = Color.Yellow;
                toolStripButton9.BackColor = Color.Lime;
                toolStripButton10.BackColor = Color.Aqua;
                toolStripButton11.BackColor = Color.Blue;
                toolStripButton12.BackColor = Color.Brown;
            }
            catch { }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                File.Delete(Filename);
                Filename = null;
            }
            catch { }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(Filename);
                Filename = null;
            }
            catch { }
        }
    }
}
