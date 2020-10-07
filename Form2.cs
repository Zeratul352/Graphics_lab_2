using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_lab_2
{
    public partial class Form2 : Form
    {
        private static Bitmap HelpMap;
        private static List<int> mask = new List<int>();
        public Form2()
        {
            InitializeComponent();
            mask.Add(1);
            mask.Add(1);
            mask.Add(1);
        }

        private static Tuple<double, double, double>[,] RGBtoLAB(Bitmap sourse)//dry math in converting RGB to LAB 
        {
            Tuple<double, double, double>[,] LAB = new Tuple<double, double, double>[sourse.Width, sourse.Height];
            for (int i = 0; i < sourse.Width; i++)
            {
                for (int j = 0; j < sourse.Height; j++)
                {
                    var bit = sourse.GetPixel(i, j);
                    int R = Math.Max(Convert.ToInt32(bit.R) , 3);
                    int G = Math.Max(Convert.ToInt32(bit.G) , 3);
                    int B = Math.Max(Convert.ToInt32(bit.B) , 3);
                    var L = (0.3811 * R + 0.5783 * G + 0.0402 * B) / 255 * 0.92157;//scaling can help to avoid some unwanted values
                    var M = (0.1962 * R + 0.7244 * G + 0.0782 * B) / 255 * 0.92157;
                    var S = (0.0241 * R + 0.1288 * G + 0.8444 * B) / 255 * 0.92157;
                    L = Math.Max(L, 0.01176);
                    M = Math.Max(M, 0.01176);//to avoid zero's
                    S = Math.Max(S, 0.01176);
                    var l = 0.5774 * (Math.Log10(L) + Math.Log10(M) + Math.Log10(S));
                    var a = 0.4082 * (Math.Log10(L) + Math.Log10(M) - 2 * Math.Log10(S));
                    var b = 0.7071 * (Math.Log10(L) - Math.Log10(M));
                    LAB[i, j] = new Tuple<double, double, double>(l, a, b);
                }
            }

            return LAB;
        }

        private static Bitmap LABtoRGB(Tuple<double, double, double>[,] LAB, Bitmap sourse)//just converts LAB to RGB
        {
            Bitmap RGB = new Bitmap(sourse);
            for (int i = 0; i < sourse.Width; i++)
            {
                for (int j = 0; j < sourse.Height; j++)
                {
                    var L = Math.Pow(10, (0.5774 * LAB[i, j].Item1 * mask[0] + 0.4082 * LAB[i, j].Item2 * mask[1] + 0.7071 * LAB[i, j].Item3 * mask[2]) / 0.92157);// / 0.92157;
                    var M = Math.Pow(10, (0.5774 * LAB[i, j].Item1 * mask[0] + 0.4082 * LAB[i, j].Item2 * mask[1] - 0.7071 * LAB[i, j].Item3 * mask[2]) / 0.92157) ;// / 0.92157;
                    var S = Math.Pow(10, (0.5774 * LAB[i, j].Item1 * mask[0] - 2 * 0.4082 * LAB[i, j].Item2 * mask[1]) / 0.92157);// / 0.92157;

                    var R = Convert.ToInt32(Math.Round((4.4679 * L - 3.5873 * M + 0.1193 * S) * 255));
                    var G = Convert.ToInt32(Math.Round((-1.2186 * L + 2.3809 * M - 0.1624 * S) * 255));
                    var B = Convert.ToInt32(Math.Round((0.0497 * L - 0.2439 * M + 1.2045 * S) * 255));
                    R = Math.Max(R, 0);//this block can suppress some mistakes
                    G = Math.Max(G, 0);
                    B = Math.Max(B, 0);
                    R = Math.Min(R, 255);
                    G = Math.Min(G, 255);
                    B = Math.Min(B, 255);

                    RGB.SetPixel(i, j, Color.FromArgb(255, R, G, B));
                }
            }
            return RGB;
        }
        private void UseMask()
        {
            var ExtraLab = RGBtoLAB(HelpMap);
            var Result = LABtoRGB(ExtraLab, HelpMap);
            HelpPicture.Image = Result;
            BuildGist();
        }

        private void BuildGist()
        {
            Bitmap source = new Bitmap(HelpPicture.Image);
            List<int> red = new List<int>();
            List<int> green = new List<int>();
            List<int> blue = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                red.Add(0);
                green.Add(0);
                blue.Add(0);
            }
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    red[source.GetPixel(i, j).R]++;
                    green[source.GetPixel(i, j).G]++;
                    blue[source.GetPixel(i, j).B]++;
                }
            }
            int redscalar = red.Max() / 200 + 1;
            int greenscalar = green.Max() / 200 + 1;
            int bluescalar = blue.Max() / 200 + 1;
            Bitmap SourceGistMap = new Bitmap(HelpGist.Width, HelpGist.Height);
            if (checkBox1.Checked)
            {
                using (Graphics g = Graphics.FromImage(SourceGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Red), i, HelpGist.Height, i, HelpGist.Height - red[i] / redscalar);
                       
                    }
                }
            }
            if (checkBox2.Checked)
            {
                using (Graphics g = Graphics.FromImage(SourceGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Green), i, HelpGist.Height, i, HelpGist.Height - green[i] / greenscalar);
                        
                    }
                }
            }
            if (checkBox3.Checked)
            {
                using (Graphics g = Graphics.FromImage(SourceGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                       g.DrawLine(new Pen(Brushes.Blue), i, HelpGist.Height, i, HelpGist.Height - blue[i] / bluescalar);

                    }
                }
            }
            
            

            HelpGist.Image = SourceGistMap;
        }
        private void UseFilter()
        {
            try
            {
                var FilterLab = RGBtoLAB(Form1.FilterMap);
                var SourceLab = RGBtoLAB(Form1.SourceMap);
                int filtercount = Form1.FilterMap.Width * Form1.FilterMap.Height;
                int sourcecount = Form1.SourceMap.Width * Form1.SourceMap.Height;

                double FEL, FEA, FEB, FDL, FDA, FDB, SEL, SEA, SEB, SDL, SDA, SDB;//FIlter E L, Filter E A, etc.
                FEL = 0;
                FEA = 0;
                FEB = 0;
                FDL = 0;
                FDA = 0;
                FDB = 0;
                for (int i = 0; i < Form1.FilterMap.Width; i++)
                {
                    for (int j = 0; j < Form1.FilterMap.Height; j++)
                    {
                        FEL += FilterLab[i, j].Item1 / filtercount;
                        FEA += FilterLab[i, j].Item2 / filtercount;
                        FEB += FilterLab[i, j].Item3 / filtercount;
                    }
                }
                for (int i = 0; i < Form1.FilterMap.Width; i++)
                {
                    for (int j = 0; j < Form1.FilterMap.Height; j++)
                    {
                        FDL += Math.Pow(FilterLab[i, j].Item1 - FEL, 2) / filtercount;
                        FDA += Math.Pow(FilterLab[i, j].Item2 - FEA, 2) / filtercount;
                        FDB += Math.Pow(FilterLab[i, j].Item3 - FEB, 2) / filtercount;
                    }
                }
                FDL = Math.Pow(FDL, 0.5);
                FDA = Math.Pow(FDA, 0.5);
                FDB = Math.Pow(FDB, 0.5);
                SEL = 0;
                SEA = 0;
                SEB = 0;
                SDL = 0;
                SDA = 0;
                SDB = 0;
                for (int i = 0; i < Form1.SourceMap.Width; i++)
                {
                    for (int j = 0; j < Form1.SourceMap.Height; j++)
                    {
                        SEL += SourceLab[i, j].Item1 / sourcecount;
                        SEA += SourceLab[i, j].Item2 / sourcecount;
                        SEB += SourceLab[i, j].Item3 / sourcecount;
                    }
                }
                for (int i = 0; i < Form1.SourceMap.Width; i++)
                {
                    for (int j = 0; j < Form1.SourceMap.Height; j++)
                    {
                        SDL += Math.Pow(SourceLab[i, j].Item1 - SEL, 2) / sourcecount;
                        SDA += Math.Pow(SourceLab[i, j].Item2 - SEA, 2) / sourcecount;
                        SDB += Math.Pow(SourceLab[i, j].Item3 - SEB, 2) / sourcecount;
                    }
                }
                SDL = Math.Pow(SDL, 0.5);
                SDA = Math.Pow(SDA, 0.5);
                SDB = Math.Pow(SDB, 0.5);
                Tuple<double, double, double>[,] LAB = new Tuple<double, double, double>[Form1.SourceMap.Width, Form1.SourceMap.Height];
                for (int i = 0; i < Form1.SourceMap.Width; i++)
                {
                    for (int j = 0; j < Form1.SourceMap.Height; j++)
                    {
                        var L = FEL + (SourceLab[i, j].Item1 - SEL) * FDL / SDL;
                        var A = FEA + (SourceLab[i, j].Item2 - SEA) * FDA / SDA;
                        var B = FEB + (SourceLab[i, j].Item3 - SEB) * FDB / SDB;
                        LAB[i, j] = new Tuple<double, double, double>(L, A, B);
                    }
                }
                var result = LABtoRGB(LAB, Form1.SourceMap);
                HelpPicture.Image = result;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Not enough data to start converting process\nPlease fill both picture boxes", "Error", MessageBoxButtons.OK);
            }
        }
        private void HelpPicture_Click(object sender, EventArgs e)
        {
            //UseFilter();
            try
            {
                //mask = new List<int>();
                
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    HelpPicture.Image = Image.FromFile(openFileDialog1.FileName);
                    HelpMap = new Bitmap(HelpPicture.Image);
                }
            }
            catch
            {
                MessageBox.Show("Can't open this file as an image\nPlease, try another file", "Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mask[0] = 1;
            UseMask();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mask[1] = 1;
            UseMask();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mask[2] = 1;
            UseMask();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mask[0] = 0;
            mask[1] = 0;
            mask[2] = 0;
            HelpPicture.Image = HelpMap;
        }

        private void L_CheckedChanged(object sender, EventArgs e)
        {
            if (L.Checked)
            {
                mask[0] = 1;
            }
            else
            {
                mask[0] = 0;
            }
            UseMask();
        }

        private void A_CheckedChanged(object sender, EventArgs e)
        {
            if (A.Checked)
            {
                mask[1] = 1;
            }
            else
            {
                mask[1] = 0;
            }
            UseMask();
        }

        private void B_CheckedChanged(object sender, EventArgs e)
        {
            if (B.Checked)
            {
                mask[2] = 1;
            }
            else
            {
                mask[2] = 0;
            }
            UseMask();
        }

        private void HelpGist_Click(object sender, EventArgs e)
        {
            BuildGist();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HelpPicture.Image.Save(saveFileDialog1.FileName);
                //map.Save(saveFileDialog1.FileName);
            }
        }
    }
}
