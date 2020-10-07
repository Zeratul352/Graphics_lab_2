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
    public partial class Form1 : Form
    {
        public static Bitmap FilterMap;//to save filter image
        public static Bitmap SourceMap;//to save source image
        public static List<int> mask;
        private static int[,] Filtermask;
        private static List<Tuple<int, int>> maskpoints;
        private static string filter;
        public Form1()
        {
            InitializeComponent();
            mask = new List<int>();
            mask.Add(1);
            mask.Add(1);
            mask.Add(1);
        }
        private static Tuple<double, double, double>[,] RGBtoLAB(Bitmap sourse)//dry math in converting RGB to LAB 
        {
            Tuple<double, double, double>[,] LAB = new Tuple<double, double, double>[sourse.Width, sourse.Height];
            for(int i = 0; i < sourse.Width; i++)
            {
                for(int j = 0; j < sourse.Height; j++)
                {
                    var bit = sourse.GetPixel(i, j);
                    int R = Math.Max(Convert.ToInt32(bit.R), 3);
                    int G = Math.Max(Convert.ToInt32(bit.G), 3);
                    int B = Math.Max(Convert.ToInt32(bit.B), 3);
                    var L = (0.3811 * R + 0.5783 * G + 0.0402 * B)/255 * 0.92157;//scaling can help to avoid some unwanted values
                    var M = (0.1962 * R + 0.7244 * G + 0.0782 * B)/255 * 0.92157;
                    var S = (0.0241 * R + 0.1288 * G + 0.8444 * B)/255 * 0.92157;
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

        private static Tuple<double, double, double>[,] RGBtoHSV(Bitmap sourse)
        {
            Tuple<double, double, double>[,] HSV = new Tuple<double, double, double>[sourse.Width, sourse.Height];
            for (int i = 0; i < sourse.Width; i++)
            {
                for (int j = 0; j < sourse.Height; j++)
                {
                    var bit = sourse.GetPixel(i, j);
                    double R = Math.Max(Convert.ToInt32(bit.R), 3)/255;
                    double G = Math.Max(Convert.ToInt32(bit.G), 3)/255;
                    double B = Math.Max(Convert.ToInt32(bit.B), 3)/255;
                    double max = Math.Max(R, Math.Max(G, B));
                    double min = Math.Min(R, Math.Min(G, B));
                    double h, s, v;
                    if(max == R && G >= B)
                    {
                        h = 60 * (G - B) / (max - min) + 0;
                    }else if(max == R && G < B)
                    {
                        h = 60 * (G - B) / (max - min) + 360;
                    }else if(max == G)
                    {
                        h = 60 * (B - R) / (max - min) + 120;
                    }
                    else
                    {
                        h = 60 * (R - G) / (max - min) + 240;
                    }
                    if(max != 0)
                    {
                        s = 1 - min / max;
                    }
                    else
                    {
                        s = 0;
                    }
                    v = max;
                    HSV[i, j] = new Tuple<double, double, double>(h, s, v);
                }
            }

            return HSV;
        }
        private static Bitmap HSVtoRGB(Tuple<double, double, double>[,] HSV, Bitmap sourse)//just converts LAB to RGB
        {
            Bitmap RGB = new Bitmap(sourse);
            for (int i = 0; i < sourse.Width; i++)
            {
                for (int j = 0; j < sourse.Height; j++)
                {
                    int Hi = Convert.ToInt32(Math.Truncate(HSV[i, j].Item1 / 60)) / 6;
                    int Vmin = Convert.ToInt32((100 - HSV[i, j].Item2) * HSV[i, j].Item3 / 100);
                    int a = Convert.ToInt32((HSV[i, j].Item3 - Vmin) * Math.IEEERemainder(HSV[i, j].Item1, 60) / 60);
                    int Vinc = Vmin + a;
                    int Vdec = Convert.ToInt32(HSV[i, j].Item3 - a);
                    int R, G, B;
                    if(Hi == 0)
                    {
                        R = Convert.ToInt32(HSV[i,j].Item3);
                        G = Vinc;
                        B = Vmin;

                    }else if(Hi == 1)
                    {
                        R = Vdec;
                        G = Convert.ToInt32(HSV[i, j].Item3);
                        B = Vmin;
                    }else if(Hi == 2)
                    {
                        R = Vmin;
                        G = Convert.ToInt32(HSV[i, j].Item3);
                        B = Vinc;
                    }else if(Hi == 3)
                    {
                        R = Vmin;
                        G = Vdec;
                        B = Convert.ToInt32(HSV[i, j].Item3);
                    }else if(Hi == 4)
                    {
                        R = Vinc;
                        G = Vmin;
                        B = Convert.ToInt32(HSV[i, j].Item3);
                    }
                    else
                    {
                        R = Convert.ToInt32(HSV[i, j].Item3);
                        G = Vmin;
                        B = Vdec;
                    }
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
        private static Bitmap LABtoRGB(Tuple<double, double, double>[,] LAB, Bitmap sourse)//just converts LAB to RGB
        {
            Bitmap RGB = new Bitmap(sourse);
            for(int i = 0; i < sourse.Width; i++)
            {
                for(int j = 0; j < sourse.Height; j++)
                {
                    var L = Math.Pow(10, (0.5774 * LAB[i, j].Item1 + 0.4082 * LAB[i, j].Item2 + 0.7071 * LAB[i, j].Item3)/0.92157);// / 0.92157;
                    var M = Math.Pow(10, (0.5774 * LAB[i, j].Item1 + 0.4082 * LAB[i, j].Item2 - 0.7071 * LAB[i, j].Item3) / 0.92157);// / 0.92157;
                    var S = Math.Pow(10, (0.5774 * LAB[i, j].Item1 - 2 * 0.4082 * LAB[i, j].Item2) / 0.92157);// / 0.92157;
                    
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
        private void UseFilter()
        {
            try
            {
                var FilterLab = RGBtoLAB(FilterMap);
                var SourceLab = RGBtoLAB(SourceMap);
                //var FilterLab = RGBtoHSV(FilterMap);
                //var SourceLab = RGBtoHSV(SourceMap);
                int filtercount = FilterMap.Width * FilterMap.Height;
                int sourcecount = SourceMap.Width * SourceMap.Height;

                double FEL, FEA, FEB, FDL, FDA, FDB, SEL, SEA, SEB, SDL, SDA, SDB;//FIlter E L, Filter E A, etc.
                FEL = 0;
                FEA = 0;
                FEB = 0;
                FDL = 0;
                FDA = 0;
                FDB = 0;
                for (int i = 0; i < FilterMap.Width; i++)
                {
                    for (int j = 0; j < FilterMap.Height; j++)
                    {
                        FEL += FilterLab[i, j].Item1 / filtercount;
                        FEA += FilterLab[i, j].Item2 / filtercount;
                        FEB += FilterLab[i, j].Item3 / filtercount;
                    }
                }
                for (int i = 0; i < FilterMap.Width; i++)
                {
                    for (int j = 0; j < FilterMap.Height; j++)
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
                for (int i = 0; i < SourceMap.Width; i++)
                {
                    for (int j = 0; j < SourceMap.Height; j++)
                    {
                        SEL += SourceLab[i, j].Item1 / sourcecount;
                        SEA += SourceLab[i, j].Item2 / sourcecount;
                        SEB += SourceLab[i, j].Item3 / sourcecount;
                    }
                }
                for (int i = 0; i < SourceMap.Width; i++)
                {
                    for (int j = 0; j < SourceMap.Height; j++)
                    {
                        SDL += Math.Pow(SourceLab[i, j].Item1 - SEL, 2) / sourcecount;
                        SDA += Math.Pow(SourceLab[i, j].Item2 - SEA, 2) / sourcecount;
                        SDB += Math.Pow(SourceLab[i, j].Item3 - SEB, 2) / sourcecount;
                    }
                }
                SDL = Math.Pow(SDL, 0.5);
                SDA = Math.Pow(SDA, 0.5);
                SDB = Math.Pow(SDB, 0.5);
                Tuple<double, double, double>[,] LAB = new Tuple<double, double, double>[SourceMap.Width, SourceMap.Height];
                if(Filtermask == null)
                {
                    for (int i = 0; i < SourceMap.Width; i++)
                    {
                        for (int j = 0; j < SourceMap.Height; j++)
                        {
                            double L, A, B;
                            if (mask[0] == 1)
                            {
                                L = FEL + (SourceLab[i, j].Item1 - SEL) * FDL / SDL;
                            }
                            else
                            {
                                L = SourceLab[i, j].Item1;
                            }
                            if (mask[1] == 1)
                            {
                                A = FEA + (SourceLab[i, j].Item2 - SEA) * FDA / SDA;
                            }
                            else
                            {
                                A = SourceLab[i, j].Item2;
                            }
                            if (mask[2] == 1)
                            {
                                B = FEB + (SourceLab[i, j].Item3 - SEB) * FDB / SDB;
                            }
                            else
                            {
                                B = SourceLab[i, j].Item3;
                            }
                            /*var L = FEL + (SourceLab[i, j].Item1 - SEL) * FDL / SDL * mask[0];
                            var A = FEA + (SourceLab[i, j].Item2 - SEA) * FDA / SDA * mask[1];
                            var B = FEB + (SourceLab[i, j].Item3 - SEB) * FDB / SDB * mask[2];*/
                            LAB[i, j] = new Tuple<double, double, double>(L, A, B);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < SourceMap.Width; i++)
                    {
                        for (int j = 0; j < SourceMap.Height; j++)
                        {
                            double L, A, B;
                            if(Filtermask[i,j] == 1)
                            {
                                if(mask[0] == 1)
                                {
                                    L = FEL + (SourceLab[i, j].Item1 - SEL) * FDL / SDL;
                                }
                                else
                                {
                                    L = SourceLab[i, j].Item1;
                                }
                                if (mask[1] == 1)
                                {
                                    A = FEA + (SourceLab[i, j].Item2 - SEA) * FDA / SDA;
                                }
                                else
                                {
                                    A = SourceLab[i, j].Item2;
                                }
                                if (mask[2] == 1)
                                {
                                    B = FEB + (SourceLab[i, j].Item3 - SEB) * FDB / SDB;
                                }
                                else
                                {
                                    B = SourceLab[i, j].Item3;
                                }
                                 
                                
                                

                            }
                            else
                            {
                                L = SourceLab[i, j].Item1;
                                A = SourceLab[i, j].Item2;
                                B = SourceLab[i, j].Item3;

                            }
                            LAB[i, j] = new Tuple<double, double, double>(L, A, B);
                        }
                    }
                }
                
                var result = LABtoRGB(LAB, SourceMap);
                Result.Image = result;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Not enough data to start converting process\nPlease fill both picture boxes", "Error", MessageBoxButtons.OK);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {


                if (OpenPicture.ShowDialog() == DialogResult.OK)
                {
                    Filter.Image = Image.FromFile(OpenPicture.FileName);
                    FilterMap = new Bitmap(Filter.Image);
                    label1.Visible = false;

                }
            }
            catch
            {
                MessageBox.Show("Can't open this file as an image\nPlease, try another file", "Error", MessageBoxButtons.OK);
            }
        }

        private void Source_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenPicture.ShowDialog() == DialogResult.OK)
                {
                    Source.Image = Image.FromFile(OpenPicture.FileName);
                    SourceMap = new Bitmap(Source.Image);
                    label2.Visible= false;
                }
            }
            catch
            {
                MessageBox.Show("Can't open this file as an image\nPlease, try another file", "Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UseFilter();
            SourceGist_Click(sender, e);
            ResultGist_Click(sender, e);
            FilterGist_Click(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Result.Image.Save(saveFileDialog1.FileName);
                //map.Save(saveFileDialog1.FileName);
            }
        }

        private void FilterGist_Click(object sender, EventArgs e)
        {
            Bitmap source = new Bitmap(Filter.Image);
            List<int> red = new List<int>();
            List<int> green = new List<int>();
            List<int> blue = new List<int>();
            for(int i =0; i < 256; i++)
            {
                red.Add(0);
                green.Add(0);
                blue.Add(0);
            }
            for(int  i = 0; i < source.Width; i++)
            {
                for(int j = 0; j < source.Height; j++)
                {
                    red[source.GetPixel(i, j).R]++;
                    green[source.GetPixel(i, j).G]++;
                    blue[source.GetPixel(i, j).B]++;
                }
            }
            int redscalar = red.Max() / 200 + 1;
            int greenscalar = green.Max() / 200 + 1;
            int bluescalar = blue.Max() / 200 + 1;
            Bitmap FilterGistMap = new Bitmap(FilterGist.Width, FilterGist.Height);
            if (FilterGistRed.Checked)
            {
                using (Graphics g = Graphics.FromImage(FilterGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Red), i, FilterGist.Height, i, FilterGist.Height - red[i] / redscalar);
                       
                    }
                }
            }
            if (FilterGistGreen.Checked)
            {
                using (Graphics g = Graphics.FromImage(FilterGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Green), i, FilterGist.Height, i, FilterGist.Height - green[i] / greenscalar);
                    }
                }

            }
            if (FilterGistBlue.Checked)
            {
                using (Graphics g = Graphics.FromImage(FilterGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                       g.DrawLine(new Pen(Brushes.Blue), i, FilterGist.Height, i, FilterGist.Height - blue[i] / bluescalar);
                    }
                }
            }
            
            FilterGist.Image = FilterGistMap;
        }

        private void FilterGistGreen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SourceGist_Click(object sender, EventArgs e)
        {
            Bitmap source = new Bitmap(Source.Image);
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
            Bitmap SourceGistMap = new Bitmap(SourceGist.Width, SourceGist.Height);
            if (SourceGistRed.Checked)
            {
                using (Graphics g = Graphics.FromImage(SourceGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Red), i, SourceGist.Height, i, SourceGist.Height - red[i] / redscalar);

                    }
                }
            }
            if (SourceGistGreen.Checked)
            {
                using (Graphics g = Graphics.FromImage(SourceGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Green), i, SourceGist.Height, i, SourceGist.Height - green[i] / greenscalar);
                    }
                }

            }
            if (SourceGistBlue.Checked)
            {
                using (Graphics g = Graphics.FromImage(SourceGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Blue), i, SourceGist.Height, i, SourceGist.Height - blue[i] / bluescalar);
                    }
                }
            }

            SourceGist.Image = SourceGistMap;
        }

        private void ResultGist_Click(object sender, EventArgs e)
        {
            Bitmap source = new Bitmap(Result.Image);
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
            Bitmap ResultGistMap = new Bitmap(ResultGist.Width, ResultGist.Height);
            if (ResultGistRed.Checked)
            {
                using (Graphics g = Graphics.FromImage(ResultGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Red), i, ResultGist.Height, i, ResultGist.Height - red[i] / redscalar);

                    }
                }
            }
            if (ResultGistGreen.Checked)
            {
                using (Graphics g = Graphics.FromImage(ResultGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Green), i, ResultGist.Height, i, ResultGist.Height - green[i] / greenscalar);
                    }
                }

            }
            if (ResultGistBlue.Checked)
            {
                using (Graphics g = Graphics.FromImage(ResultGistMap))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Blue), i, ResultGist.Height, i, ResultGist.Height - blue[i] / bluescalar);
                    }
                }
            }

            ResultGist.Image = ResultGistMap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(mask[0] == 0)
            {
                mask[0] = 1;
                button3.Text = "IgnoreLCorrection";
            }
            else
            {
                mask[0] = 0;
                button3.Text = "AddL";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(mask[1] == 0)
            {
                mask[1] = 1;
                button5.Text = "IgnoreACorrection";
            }
            else
            {
                mask[1] = 0;
                button5.Text = "AddA";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(mask[2] == 0)
            {
                mask[2] = 1;
                button4.Text = "IgnoreBCorrection";
            }
            else
            {
                mask[2] = 0;
                button4.Text = "AddB";
            }
        }

        private void SquareFulter_Click(object sender, EventArgs e)
        {
            Filtermask = new int[SourceMap.Width, SourceMap.Height];
            maskpoints = new List<Tuple<int, int>>();
            filter = "SQUARE";
            for(int i = 0; i < SourceMap.Width; i++)
            {
                for(int j = 0; j < SourceMap.Height; j++)
                {
                    Filtermask[i, j] = 0;
                }
            }
        }

        private void Source_MouseClick(object sender, MouseEventArgs e)
        {
            if(Filtermask == null)
            {
                Source_Click(sender, e);
                return;
            }
            if(maskpoints.Count == 0)
            {
                maskpoints.Add(new Tuple<int, int>(e.X, e.Y));
                return;
            }
            if(filter == "SQUARE")
            {
                int x1 = e.X;
                int y1 = e.Y;
                int x0 = maskpoints[0].Item1;
                int y0 = maskpoints[0].Item2;
                maskpoints.Clear();
                if (x0 < x1 && y0 < y1)
                {
                    maskpoints.Add(new Tuple<int, int>(x0, y0));
                    maskpoints.Add(new Tuple<int, int>(x1, y1));
                }
                else if (x0 < x1 && y0 > y1)
                {
                    maskpoints.Add(new Tuple<int, int>(x0, y1));
                    maskpoints.Add(new Tuple<int, int>(x1, y0));
               }else if(x0 > x1 && y0 < y1)
                {
                    maskpoints.Add(new Tuple<int, int>(x1, y0));
                    maskpoints.Add(new Tuple<int, int>(x0, y1));
                }
                else
                {
                    maskpoints.Add(new Tuple<int, int>(x1, y1));
                    maskpoints.Add(new Tuple<int, int>(x0, y0));
                }
                for(int i = maskpoints[0].Item1; i < maskpoints[1].Item1; i++)
                {
                    for(int j = maskpoints[0].Item2; j < maskpoints[1].Item2; j++)
                    {
                        Filtermask[i, j] = 1;
                    }
                }
                
            }else if(filter == "CIRCLE")
            {
                int x1 = e.X;
                int y1 = e.Y;
                int R = Convert.ToInt32(Math.Round(Math.Sqrt(Math.Pow(x1 - maskpoints[0].Item1, 2) + Math.Pow(y1 - maskpoints[0].Item2, 2))));
                int x = maskpoints[0].Item1;
                int y = maskpoints[0].Item2;
                for(int i = 0; i < SourceMap.Width; i++)
                {
                    for(int j = 0; j < SourceMap.Height; j++)
                    {
                        int r = Convert.ToInt32(Math.Round(Math.Sqrt(Math.Pow(i - x, 2) + Math.Pow(j - y, 2))));
                        if(r < R)
                        {
                            Filtermask[i, j] = 1;
                        }
                    }
                }
                
            }
            button1_Click(sender, e);
            /*Filtermask = new int[SourceMap.Width, SourceMap.Height];
            maskpoints = new List<Tuple<int, int>>();
            
            for (int i = 0; i < SourceMap.Width; i++)
            {
                for (int j = 0; j < SourceMap.Height; j++)
                {
                    Filtermask[i, j] = 0;
                }
            }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Filtermask = new int[SourceMap.Width, SourceMap.Height];
            maskpoints = new List<Tuple<int, int>>();
            filter = "CIRCLE";
            for (int i = 0; i < SourceMap.Width; i++)
            {
                for (int j = 0; j < SourceMap.Height; j++)
                {
                    Filtermask[i, j] = 0;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Filtermask = new int[SourceMap.Width, SourceMap.Height];
            for (int i = 0; i < SourceMap.Width; i++)
            {
                for (int j = 0; j < SourceMap.Height; j++)
                {
                    Filtermask[i, j] = 0;
                }
            }
            button1_Click(sender, e);
            Filtermask = null;
            maskpoints = null;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
