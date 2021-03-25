
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CG_lab3
{
    public enum Rgb
    {
        R,
        G,
        B
    }
    public partial class Form1 : Form
    {
        string fileName = "";
        bool loaded = false;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            label_kernel_size.Text = trackBar1.Value.ToString();
            label_kernel_size_2.Text = trackBar2.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                pictureBox1.Image = Image.FromFile(fileName);
                loaded = true;
            }

            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                Mat src = new Mat(fileName);
                Mat dst = new Mat();
                int size = trackBar1.Value;
               // Cv2.Blur(src, dst, new OpenCvSharp.Size(size, size));
                Cv2.BoxFilter(src, dst, -1, new OpenCvSharp.Size(size, size), null, true);
               
                showFilter(dst, "blur");
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_kernel_size.Text = trackBar1.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                Mat src = new Mat(fileName);
                Mat dst = new Mat();
                int size = trackBar2.Value;
                Cv2.GaussianBlur(src, dst, new OpenCvSharp.Size(size, size), Double.Parse(textBox1.Text));
                showFilter(dst, "blur");

            }
        }

        private void showFilter(Mat dst, string title)
        {
            Window w = new Window(title);
            Cv2.Resize(dst, dst, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Width * pictureBox1.Image.Height / (pictureBox1.Image.Width)));
            Cv2.ImShow(title, dst);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if(trackBar2.Value % 2 == 0)
            {
                trackBar2.Value += 1;
            }
            label_kernel_size_2.Text = trackBar2.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mat src = new Mat(fileName);
            Mat dst = new Mat();

            // Histogram view
            const int Width = 260, Height = 200;
            Mat render = new Mat(new OpenCvSharp.Size(Width, Height), MatType.CV_8UC3, Scalar.All(255));

            // Calculate histogram
            Mat hist = new Mat();
            int[] hdims = { 256 }; // Histogram size for each dimension
            Rangef[] ranges = { new Rangef(0, 256), }; // min/max 
            Cv2.CalcHist(
                new Mat[] { src },
                new int[] { 0 },
                null,
                hist,
                1,
                hdims,
                ranges);

            // Get the max value of histogram
            double minVal, maxVal;
            Cv2.MinMaxLoc(hist, out minVal, out maxVal);

            Scalar color = Scalar.All(2);
            // Scales and draws histogram
            hist = hist * (maxVal != 0 ? Height / maxVal : 0.0);
            for (int j = 0; j < hdims[0]; ++j)
            {
                int binW = (int)((double)Width / hdims[0]);
                render.Rectangle(
                    new OpenCvSharp.Point(j * binW, render.Rows - (int)(hist.Get<float>(j))),
                    new OpenCvSharp.Point((j + 1) * binW, render.Rows),
                    color,
                    -1);
            }

            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(render);
            pictureBox5.Image = bp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mat src = new Mat(fileName);
            Mat dst = new Mat();

            src = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            Cv2.EqualizeHist(src, src);

            // Histogram view
            const int Width = 260, Height = 200;
            Mat render = new Mat(new OpenCvSharp.Size(Width, Height), MatType.CV_8UC3, Scalar.All(255));

            // Calculate histogram
            Mat hist = new Mat();
            Mat hist2 = new Mat();
            int[] hdims = { 256 }; // Histogram size for each dimension
            Rangef[] ranges = { new Rangef(0, 256), }; // min/max 
           
            Cv2.CalcHist(
                new Mat[] { src },
                new int[] { 0 },
                null,
                hist,
                1,
                hdims,
                ranges);

            

            // Get the max value of histogram
            double minVal, maxVal;
            Cv2.MinMaxLoc(hist, out minVal, out maxVal);

            Scalar color = Scalar.All(2);
            // Scales and draws histogram
            hist = hist * (maxVal != 0 ? Height / maxVal : 0.0);
            for (int j = 0; j < hdims[0]; ++j)
            {
                int binW = (int)((double)Width / hdims[0]);
                render.Rectangle(
                    new OpenCvSharp.Point(j * binW, render.Rows - (int)(hist.Get<float>(j))),
                    new OpenCvSharp.Point((j + 1) * binW, render.Rows),
                    color,
                    -1);
            }

            src = src.CvtColor(ColorConversionCodes.GRAY2BGR);

            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(render);
            pictureBox5.Image = bp;

            showFilter(src, "gray equalize");
        }

        public unsafe int[] GetHistogram(Rgb component)
        {
            var histogram = new int[256];

            
                Bitmap OriginalImage = (Bitmap)Image.FromFile(fileName);

                var data = OriginalImage.LockBits(new Rectangle(0, 0, OriginalImage.Width, OriginalImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                var offset = data.Stride - OriginalImage.Width * 3;

                var p = (byte*)data.Scan0.ToPointer();

                for (var i = 0; i < OriginalImage.Height; i++)
                {
                    for (var j = 0; j < OriginalImage.Width; j++, p += 3)
                    {
                        switch (component)
                        {
                            case Rgb.R:
                                histogram[p[2]]++;
                                break;
                            case Rgb.G:
                                histogram[p[1]]++;
                                break;
                            default:
                                histogram[p[0]]++;
                                break;
                        }
                    }
                    p += offset;
                }

                OriginalImage.UnlockBits(data);

            
            return histogram;
        }

        public unsafe Bitmap EqualizeHistogram()
        {
            var finalImg = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

            var rHistogram = GetHistogram(Rgb.R);
            var gHistogram = GetHistogram(Rgb.G);
            var bHistogram = GetHistogram(Rgb.B);

            Bitmap OriginalImage = (Bitmap)Image.FromFile(fileName);

            var data = OriginalImage.LockBits(new Rectangle(0, 0, OriginalImage.Width, OriginalImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var finalData = finalImg.LockBits(new Rectangle(0, 0, finalImg.Width, finalImg.Height),
                 ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            var histR = new float[256];
            var histG = new float[256];
            var histB = new float[256];

            histR[0] = (rHistogram[0] * rHistogram.Length) / (finalData.Width * finalData.Height);
            histG[0] = (gHistogram[0] * gHistogram.Length) / (finalData.Width * finalData.Height);
            histB[0] = (bHistogram[0] * bHistogram.Length) / (finalData.Width * finalData.Height);

            long cumulativeR = rHistogram[0];
            long cumulativeG = gHistogram[0];
            long cumulativeB = bHistogram[0];

            for (var i = 1; i < histR.Length; i++)
            {
                cumulativeR += rHistogram[i];
                histR[i] = (cumulativeR * rHistogram.Length) / (finalData.Width * finalData.Height);

                cumulativeG += gHistogram[i];
                histG[i] = (cumulativeG * gHistogram.Length) / (finalData.Width * finalData.Height);

                cumulativeB += bHistogram[i];
                histB[i] = (cumulativeB * bHistogram.Length) / (finalData.Width * finalData.Height);
            }

            var ptr = (byte*)data.Scan0;
            var ptrFinal = (byte*)finalData.Scan0;

            var remain = data.Stride - data.Width * 3;

            for (var i = 0; i < data.Height; i++, ptr += remain, ptrFinal += remain)
            {
                for (var j = 0; j < data.Width; j++, ptrFinal += 3, ptr += 3)
                {
                    var intensityR = ptr[2];
                    var intensityG = ptr[1];
                    var intensityB = ptr[0];

                    var nValueR = (byte)histR[intensityR];
                    var nValueG = (byte)histG[intensityG];
                    var nValueB = (byte)histB[intensityB];

                    if (histR[intensityR] < 255)
                        nValueR = 255;
                    if (histG[intensityG] < 255)
                        nValueG = 255;
                    if (histB[intensityB] < 255)
                        nValueB = 255;

                    ptrFinal[2] = nValueR;
                    ptrFinal[1] = nValueG;
                    ptrFinal[0] = nValueB;
                }
            }

            OriginalImage.UnlockBits(data);
            finalImg.UnlockBits(finalData);

            return finalImg;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tt((Bitmap)pictureBox1.Image);

        }

        public void Tt(Bitmap bmp)
        {

            createHist(bmp);
          
        }

        private void createHistR(Bitmap bmp)
        {
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];
                }
            }

            int histHeight = pictureBox2.Height;
            Bitmap img_r = new Bitmap(histogram_r.Length, histHeight);

            using (Graphics g = Graphics.FromImage(img_r))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Red,
                        new System.Drawing.Point(i, img_r.Height),
                        new System.Drawing.Point(i, img_r.Height - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }

            pictureBox2.Image = img_r;
        }

        private void createHistG(Bitmap bmp)
        {
            int[] histogram_g = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).G;

                    histogram_g[redValue]++;
                    if (max < histogram_g[redValue])
                        max = histogram_g[redValue];
                }
            }

            int histHeight = pictureBox3.Height;
            Bitmap img_g = new Bitmap(histogram_g.Length, histHeight);

            using (Graphics g = Graphics.FromImage(img_g))
            {
                for (int i = 0; i < histogram_g.Length; i++)
                {
                    float pct = histogram_g[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Green,
                        new System.Drawing.Point(i, img_g.Height),
                        new System.Drawing.Point(i, img_g.Height - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }

            pictureBox3.Image = img_g;
        }

        private void createHistB(Bitmap bmp)
        {
            int[] histogram_b = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).B;

                    histogram_b[redValue]++;
                    if (max < histogram_b[redValue])
                        max = histogram_b[redValue];
                }
            }

            int histHeight = pictureBox4.Height;
            Bitmap img_b = new Bitmap(histogram_b.Length, histHeight);

            using (Graphics g = Graphics.FromImage(img_b))
            {
                for (int i = 0; i < histogram_b.Length; i++)
                {
                    float pct = histogram_b[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Blue,
                        new System.Drawing.Point(i, img_b.Height),
                        new System.Drawing.Point(i, img_b.Height - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }

            pictureBox4.Image = img_b;
        }

        private void createHistV(Bitmap bmp)
        {
            int[] histogram_v = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = (int)Math.Floor(255 * bmp.GetPixel(i, j).GetBrightness());

                    histogram_v[redValue]++;
                    if (max < histogram_v[redValue])
                        max = histogram_v[redValue];
                }
            }

            int histHeight = pictureBox6.Height;
            Bitmap img_v = new Bitmap(histogram_v.Length, histHeight);

            using (Graphics g = Graphics.FromImage(img_v))
            {
                for (int i = 0; i < histogram_v.Length; i++)
                {
                    float pct = histogram_v[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.DimGray,
                        new System.Drawing.Point(i, img_v.Height),
                        new System.Drawing.Point(i, img_v.Height - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }

            pictureBox6.Image = img_v;
        }

        private void createHist(Bitmap bmp)
        {
            createHistR(bmp);
            createHistG(bmp);
            createHistB(bmp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mat OriginalImage = new Mat(fileName, ImreadModes.Color);
            Mat FillMatrix = Mat.Zeros(OriginalImage.Size(), MatType.CV_8UC1);

            Mat[] rgb;

            Cv2.Split(OriginalImage, out rgb);

            Mat[] rr = { FillMatrix, FillMatrix, rgb[2] };
            Mat[] gg = { FillMatrix, rgb[1], FillMatrix };
            Mat[] bb = { rgb[0], FillMatrix, FillMatrix };

            Mat merge = new Mat();


            if(rbr.Checked) Cv2.EqualizeHist(rr[2], rr[2]);
            Cv2.Merge(rr, merge);

            if (rbg.Checked)  Cv2.EqualizeHist(gg[1], gg[1]);
            Cv2.Merge(gg, merge);

            if (rbb.Checked)  Cv2.EqualizeHist(bb[0], bb[0]);
            Cv2.Merge(bb, merge);
           
            Cv2.Merge(rgb, merge);
            
            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(merge);
            createHist(bp);

            showFilter(merge, "rgb equalize");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Mat OriginalImage = new Mat(fileName, ImreadModes.Color);
            Mat hsvIm = new Mat();

            Cv2.CvtColor(OriginalImage, hsvIm, ColorConversionCodes.BGR2HSV);

            Mat[] hsv;
            hsv = Cv2.Split(hsvIm);
         
            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(hsv[2]);
            createHistV(bp);            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mat OriginalImage = new Mat(fileName, ImreadModes.Color);
            Mat hsvIm = new Mat();

            Cv2.CvtColor(OriginalImage, hsvIm, ColorConversionCodes.BGR2HSV);

            Mat[] hsv;
            hsv = Cv2.Split(hsvIm);
            Cv2.EqualizeHist(hsv[2], hsv[2]);
            Mat res = new Mat();
            Cv2.Merge(hsv, res);
           

            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(hsv[2]);
            createHistV(bp);

            Cv2.CvtColor(res, res, ColorConversionCodes.HSV2BGR);
            showFilter(res, "brightness equalize");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Mat src = new Mat(fileName, ImreadModes.Color);
            Mat channel = src.ExtractChannel(0);
            byte[] arr = channel.ToBytes();
            byte[] arr2 = src.ExtractChannel(1).ToBytes();
            byte[] arr3 = src.ExtractChannel(2).ToBytes();

            Mat mat = Cv2.ImDecode(arr, ImreadModes.Color);

            Mat FillMatrix = Mat.Zeros(src.Size(), MatType.CV_8UC1);
            Mat[] bb = { mat.ExtractChannel(0), FillMatrix, FillMatrix };

            Mat merge = new Mat();
            Cv2.Merge(bb, merge);
            Cv2.ImShow("w1", merge);

            arr = LinearСontrast(arr);

            mat = Cv2.ImDecode(arr, ImreadModes.Color);
            Cv2.ImShow("w1", mat);


            Mat FillMatrix2 = Mat.Zeros(src.Size(), MatType.CV_8UC1);
            Mat[] bb2 = { mat.ExtractChannel(0), FillMatrix2, FillMatrix2 };

            Mat merge2 = new Mat();
            Cv2.Merge(bb2, merge2);
            Cv2.ImShow("w2", merge2);

        }

        private byte[] LinearСontrast(byte[] img)
        {
            
            byte BrightnessMin = img.Min();
            byte BrightnessMax = img.Max();

            for (int i = 0; i < img.Length; i++)
            {

               // MessageBox.Show(img[i].ToString());
                    img[i] = (byte)(((double)img[i] - BrightnessMin) / (BrightnessMax - BrightnessMin) * 255.0);
               // MessageBox.Show(img[i].ToString());
            }
            return img;
        }


    }

   
}
 


