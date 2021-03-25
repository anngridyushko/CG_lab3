
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    public partial class lab3 : Form
    {
        string fileName = "";
        bool loaded = false;

        public lab3()
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
            int Width = 260, Height = pictureBox5.Height;
            double minVal, maxVal;
            Mat hist = new Mat();
            int[] hdims = { 256 };
            Rangef[] ranges = { new Rangef(0, 256), };

            Mat render = new Mat(new OpenCvSharp.Size(Width, Height), MatType.CV_8UC3, Scalar.All(255));
            Cv2.CalcHist( new Mat[] { src }, new int[] { 0 }, null, hist, 1, hdims, ranges);
            Scalar color = Scalar.All(2);
            Cv2.MinMaxLoc(hist, out minVal, out maxVal);
            
            hist = hist * (maxVal != 0 ? Height / maxVal : 0.0);
            for (int j = 0; j < hdims[0]; j++)
            {
                render.Rectangle(
                    new OpenCvSharp.Point(j * (int)((double)Width / hdims[0]), render.Rows - (int)(hist.Get<float>(j))),
                    new OpenCvSharp.Point((j + 1) * (int)((double)Width / hdims[0]), render.Rows),
                    color,
                    -1);
            }

            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(render);
            pictureBox5.Image = bp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mat src = new Mat(fileName);
            int Width = 260, Height = pictureBox5.Height;
            double minVal, maxVal;
            Mat hist = new Mat();
            int[] hdims = { 256 };
            Rangef[] ranges = { new Rangef(0, 256), };

            src = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Cv2.EqualizeHist(src, src);    
            Mat render = new Mat(new OpenCvSharp.Size(Width, Height), MatType.CV_8UC3, Scalar.All(255));
            Cv2.CalcHist(new Mat[] { src }, new int[] { 0 }, null, hist, 1, hdims, ranges);
            Scalar color = Scalar.All(2);

            Cv2.MinMaxLoc(hist, out minVal, out maxVal);
         
            hist = hist * (maxVal != 0 ? Height / maxVal : 0.0);
            for (int j = 0; j < hdims[0]; ++j)
            {
               
                render.Rectangle(
                    new OpenCvSharp.Point(j * (int)((double)Width / hdims[0]), render.Rows - (int)(hist.Get<float>(j))),
                    new OpenCvSharp.Point((j + 1) * (int)((double)Width / hdims[0]), render.Rows),
                    color,
                    -1);
            }

            src = src.CvtColor(ColorConversionCodes.GRAY2BGR);
            Bitmap bp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(render);
            pictureBox5.Image = bp;
            showFilter(src, "gray equalize");
        }

        public unsafe int[] GetHistogram(Rgb rgb)
        {
            var hist = new int[256];
            Bitmap src = (Bitmap)Image.FromFile(fileName);
            var data = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            var offset = data.Stride - src.Width * 3;
            var po = (byte*)data.Scan0.ToPointer();

            for (var i = 0; i < src.Height; i++) {
                for (var j = 0; j < src.Width; j++, po += 3) {
                    switch (rgb) {
                        case Rgb.R:
                            hist[po[2]]++;
                            break;
                        case Rgb.G:
                            hist[po[1]]++;
                            break;
                        default:
                            hist[po[0]]++;
                                break;
                        }
                    }
                    po += offset;
                }

            src.UnlockBits(data);
            return hist;
        }

        private float calc_hist(long hist, int len, int width, int height)
        {
            return (hist *len) / (width * height);
        }

        public unsafe Bitmap EqualizeHistogram()
        {
            var dst = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

            int[] r_hist = GetHistogram(Rgb.R), g_hist = GetHistogram(Rgb.G), b_hist = GetHistogram(Rgb.B);
            float[] histR = new float[256], histG = new float[256], histB = new float[256];

            Bitmap src = (Bitmap)Image.FromFile(fileName);
            BitmapData data = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData final = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height),
                 ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            histR[0] = calc_hist(r_hist[0], r_hist.Length, final.Width, final.Height);
            histG[0] = calc_hist(g_hist[0], g_hist.Length, final.Width, final.Height);
            histB[0] = calc_hist(b_hist[0], b_hist.Length, final.Width, final.Height);

            long cumulativeR = r_hist[0];
            long cumulativeG = g_hist[0];
            long cumulativeB = b_hist[0];

            for (var i = 1; i < histR.Length; ++i)
            {
                cumulativeR += r_hist[i];
                histR[i] = calc_hist(cumulativeR, r_hist.Length, final.Width, final.Height);

                cumulativeG += g_hist[i];
                histG[i] = calc_hist(cumulativeG, g_hist.Length, final.Width, final.Height);

                cumulativeB += b_hist[i];
                histB[i] = calc_hist(cumulativeB, b_hist.Length, final.Width, final.Height);
            }

            var ptr = (byte*)data.Scan0;
            var ptr_fin = (byte*)final.Scan0;

            var remain = data.Stride - data.Width * 3;

            for (var i = 0; i < data.Height; ++i, ptr += remain, ptr_fin += remain)
            {
                for (var j = 0; j < data.Width; j++, ptr_fin += 3, ptr += 3)
                {
                    byte intensityR = ptr[2], nValueR = (byte)histR[intensityR];
                    byte intensityG = ptr[1], nValueG = (byte)histG[intensityG];
                    byte intensityB = ptr[0], nValueB = (byte)histB[intensityB];

                    if (histR[intensityR] < 255) nValueR = 255;
                    if (histG[intensityG] < 255) nValueG = 255;
                    if (histB[intensityB] < 255) nValueB = 255;

                    ptr_fin[0] = nValueB;
                    ptr_fin[1] = nValueG;
                    ptr_fin[2] = nValueR;
                  
                }
            }

            src.UnlockBits(data);
            dst.UnlockBits(final);

            return dst;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tt((Bitmap)pictureBox1.Image);

        }

        public void Tt(Bitmap bmp)
        {

            createHist(bmp);
          
        }

        private Bitmap get_rgb_hist(int[] histogram, int histHeight, float max, Pen color)
        {
            Bitmap img = new Bitmap(histogram.Length, histHeight);

            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram.Length; i++)
                {
                    float pct = histogram[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(color,
                        new System.Drawing.Point(i, img.Height),
                        new System.Drawing.Point(i, img.Height - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }

            return img;
        }

        private void createHistR(Bitmap bmp)
        {
            int[] histogram_r = new int[256];
            
            float max = 0;
            for (int i = 0; i < bmp.Width; ++i)
            {
                for (int j = 0; j < bmp.Height; ++j)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (histogram_r[redValue] > max) max = histogram_r[redValue];
                }
            }

            int histHeight = pictureBox2.Height;
            pictureBox2.Image = get_rgb_hist(histogram_r, histHeight, max, Pens.Red);
        }

        private void createHistG(Bitmap bmp)
        {
            int[] histogram_g = new int[256];
            float max = 0;
            for (int i = 0; i < bmp.Width; ++i)
            {
                for (int j = 0; j < bmp.Height; ++j)
                {
                    int greenValue = bmp.GetPixel(i, j).G;
                    histogram_g[greenValue]++;
                    if (histogram_g[greenValue] > max) max = histogram_g[greenValue];
                }
            }

            int histHeight = pictureBox2.Height;
            pictureBox3.Image = get_rgb_hist(histogram_g, histHeight, max, Pens.Green);
        }

        private void createHistB(Bitmap bmp)
        {
            int[] histogram_b = new int[256];
            float max = 0;
            for (int i = 0; i < bmp.Width; ++i)
            {
                for (int j = 0; j < bmp.Height; ++j)
                {
                    int blueValue = bmp.GetPixel(i, j).B;
                    histogram_b[blueValue]++;
                    if (histogram_b[blueValue] > max) max = histogram_b[blueValue];
                }
            }

            int histHeight = pictureBox2.Height;
            pictureBox4.Image = get_rgb_hist(histogram_b, histHeight, max, Pens.Blue);
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
            
            pictureBox6.Image = get_rgb_hist(histogram_v, histHeight, max, Pens.Gray);
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
           

            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
           
            byte[] array = new byte[] { };
            //Cv2.ImEncode(".jpg", src, out array);
            array = ToByteArray(bmp, ImageFormat.Bmp);
            array = LinearСontrast(array);
            Mat mat = Cv2.ImDecode(array, ImreadModes.AnyColor);
            showFilter(mat, "linear");

        }

        private byte[] LinearСontrast(byte[] img)
        {
            int len = img.Length;
            int min = 255, max = 0;

            for(int i = 54; i< len; i++)
            {
                if( (i-1)% 4 == 0) continue;
                if (img[i] < min) min = img[i];
                if (img[i] > max) max = img[i];
            }
 
            for (int i = 54; i < img.Length; i++)
            {
                img[i] = (byte)(((double)img[i] - min) / (max - min) * 255.0);
               
            }

             return img;
        }

        private byte[] ToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }


    }

   
}
 


