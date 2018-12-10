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
    public partial class frmChild : Form
    {
        public bool changed = false;
        public Bitmap ns;
        public Bitmap mp;
        int newX, newY;
        public static frmMain main;
        public frmChild()
        {
             main = this.MdiParent as frmMain;
            InitializeComponent();
        }

        int oldX, oldY;
        public Bitmap bmp;
        Graphics g;
        private void frmChild_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            frmMain main = this.MdiParent as frmMain;
            try
            {
                if (main.extra == "pen")
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        changed = true;
                        g = Graphics.FromImage(pictureBox1.Image);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                        g.DrawLine(main.p, oldX, oldY, e.X, e.Y);
                        oldX = e.X;
                        oldY = e.Y;
                        pictureBox1.Refresh();
                        ns = new Bitmap(pictureBox1.Image);
                    }
                }
                else if (main.extra == "eraser")
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        changed = true;
                        main.p.Color = pictureBox1.BackColor;
                        g = Graphics.FromImage(pictureBox1.Image);
                        g.DrawLine(main.p, oldX, oldY, e.X, e.Y);
                        oldX = e.X;
                        oldY = e.Y;
                        pictureBox1.Refresh();
                        main.p.Color = Color.Black;
                        ns = new Bitmap(pictureBox1.Image);
                    }
                }
                else if (main.extra == "star")
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        changed = true;
                        newX = e.X;
                        newY = e.Y;
                        pictureBox1.Refresh();
                        ns = new Bitmap(pictureBox1.Image);
                    }

                }
                else if (main.extra == "ellipse")
                {
                    if(e.Button == MouseButtons.Left)
                    {
                        changed = true;
                        newX = e.X - oldX;
                        newY = e.Y - oldY;
                        pictureBox1.Refresh();
                        ns = new Bitmap(pictureBox1.Image);
                    }
                }
                else if (main.extra == "line")
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        changed = true;
                        newX = e.X;
                        newY = e.Y;
                        pictureBox1.Refresh();
                        ns = new Bitmap(pictureBox1.Image);

                    }
                }
            }
            catch
            {

            }
        }
       
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                oldX = e.X;
                oldY = e.Y;
                //координаты
            }
        }
        private void frmChild_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            frmMain main = this.MdiParent as frmMain;
            if (main.extra == "line")
            {
                e.Graphics.DrawLine(main.p, oldX, oldY, newX, newY);
                e.Graphics.Save();
            }
            if (main.extra == "ellipse")
            {
                e.Graphics.DrawEllipse(main.p, oldX, oldY, newX, newY);
                e.Graphics.Save();
            }
            if (main.extra == "star")
            {
                PointF[] points = new PointF[11];
                double a = Math.PI / 10;
                double da = Math.PI / 5; 
                double r1 = Math.Abs(oldX - newX), r2 = Math.Abs(oldY - newY);
                if (r1 > r2)
                {
                    var tmp = r1;
                    r1 = r2;
                    r2 = tmp;
                }

                double l;
                for (int k = 0; k < 11; k++)
                {
                    l = k % 2 == 0 ? r1 : r2; 
                    points[k] = new PointF((float)(oldX + l * Math.Cos(a)), (float)(oldY + l * Math.Sin(a)));
                    a += da;
                }

                e.Graphics.DrawLines(main.p, points); 
                e.Graphics.Save();
            }
        }
        private void frmChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changed)
            {
                FrmClose();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            frmMain main = this.MdiParent as frmMain;
            if (main.extra == "line")
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.DrawLine(main.p, oldX, oldY, newX, newY);
                g.Save();
                pictureBox1.Refresh();
            }
            if (main.extra == "ellipse")
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.DrawEllipse(main.p, oldX, oldY, newX, newY);
                g.Save();
                pictureBox1.Refresh();
            }
            if (main.extra == "star")
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                PointF[] points = new PointF[11];
                double a = Math.PI / 10; 
                double da = Math.PI / 5; 
                double r1 = Math.Abs(oldX - newX), r2 = Math.Abs(oldY - newY);
                if (r1 > r2)
                {
                    var tmp = r1;
                    r1 = r2;
                    r2 = tmp;
                }

                double l;
                for (int k = 0; k < 11; k++)
                {
                    l = k % 2 == 0 ? r1 : r2;
                    points[k] = new PointF((float)(oldX + l * Math.Cos(a)), (float)(oldY + l * Math.Sin(a)));
                    a += da;
                }

                g.DrawLines(main.p, points); 
                g.Save();
                pictureBox1.Refresh();
            }
        }

        private void frmChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        public void FrmClose()
        {
            frmMain main = this.MdiParent as frmMain;
            Random rn = new Random();
            DialogResult tr = MessageBox.Show("Сохранить изображение перед закрытием?", this.Text, MessageBoxButtons.YesNo);
            if (tr == DialogResult.Yes)
            {
                if (main.Filename != null)
                {
                    main.todel = true;
                    Save(@"D:\\Pictures\\" + rn.Next(0, 100000) + ".BMP");
                }
                else // сохранение нового файла
                {
                    Save(@"D:\\Pictures\\" + rn.Next(0, 100000) + ".BMP");
                }
            }
            main.Filename = null;
        }
        public void Save(string path)
        {
            pictureBox1.Image.Save(path);
        }
        public void Save(string path,Bitmap bmp)
        {
            bmp.Save(path);
        }
    }
}
