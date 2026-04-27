using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using openCV;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        IplImage image1;
        IplImage img;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Images|*.jpg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = cvlib.CvLoadImage(openFileDialog1.FileName, cvlib.CV_LOAD_IMAGE_COLOR);
                DisplayOnPictureBox1(image1);
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;
                for (int i = 0; i < image1.widthStep * image1.height; i += 3)
                {
                    dst[i] = 0;         // Blue = 0
                    dst[i + 1] = 0;     // Green = 0
                    dst[i + 2] = src[i + 2]; // Red = الأصلي
                }
            }
            DisplayResult(img);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            // حجز مساحة للصورة الناتجة
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            unsafe
            {
                byte* src = (byte*)image1.imageData; // مؤشر للصورة الأصلية
                byte* dst = (byte*)img.imageData;    // مؤشر للصورة الجديدة

                // بنلف على كل البكسلات (بنمشي 3 خطوات كل مرة)
                for (int i = 0; i < image1.widthStep * image1.height; i += 3)
                {
                    dst[i] = 0;             // Blue = 0
                    dst[i + 1] = src[i + 1]; // Green = القيمة الأصلية
                    dst[i + 2] = 0;         // Red = 0
                }
            }
            DisplayResult(img); // عرض النتيجة في المربع التاني
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;

                for (int i = 0; i < image1.widthStep * image1.height; i += 3)
                {
                    dst[i] = src[i];     // Blue = القيمة الأصلية
                    dst[i + 1] = 0;     // Green = 0
                    dst[i + 2] = 0;     // Red = 0
                }
            }
            DisplayResult(img);
        }

        private void darkenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;
                for (int i = 0; i < image1.widthStep * image1.height; i++)
                {
                    dst[i] = (byte)Math.Max(0, src[i] - 50);
                }
            }
            DisplayResult(img);
        }

        private void brightenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;
                for (int i = 0; i < image1.widthStep * image1.height; i++)
                {
                    dst[i] = (byte)Math.Min(255, src[i] + 50);
                }
            }
            DisplayResult(img);
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;
                for (int i = 0; i < image1.widthStep * image1.height; i += 3)
                {
                    byte gray = (byte)(0.114 * src[i] + 0.587 * src[i + 1] + 0.299 * src[i + 2]);
                    dst[i] = dst[i + 1] = dst[i + 2] = gray;
                }
            }
            DisplayResult(img);
        }

        private void histToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackgroundImage == null) return;
            Bitmap source = new Bitmap(pictureBox2.BackgroundImage);
            Bitmap histogramBmp = new Bitmap(256, 256, PixelFormat.Format24bppRgb);
            BitmapData data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int[] count = new int[256];
                int max = 0;
                for (int i = 0; i < source.Height * source.Width; i++)
                {
                    count[p[1]]++; // بنحسب للأخضر زي صورة الكلية
                    if (count[p[1]] > max) max = count[p[1]];
                    p += 3;
                }
                source.UnlockBits(data);
                for (int i = 0; i < 256; i++) count[i] = (int)(count[i] * 255f / max);
                BitmapData dataH = histogramBmp.LockBits(new Rectangle(0, 0, 256, 256), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                byte* ph = (byte*)dataH.Scan0;
                for (int x = 0; x < 256; x++)
                {
                    for (int y = 0; y < 256; y++)
                    {
                        byte color = (y <= (255 - count[x])) ? (byte)255 : (byte)0;
                        int idx = y * dataH.Stride + x * 3;
                        ph[idx] = ph[idx + 1] = ph[idx + 2] = color;
                    }
                }
                histogramBmp.UnlockBits(dataH);
            }
            pictureBox3.Image = histogramBmp;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // 1. زرار الـ Equalized Image (لتحسين إضاءة الصورة)
        private void equalizedImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;

            // دالة المعالجة السريعة (بدون مكتبات خارجية)
            int[] hist = new int[256];
            int totalPixels = image1.width * image1.height;

            unsafe
            {
                byte* data = (byte*)image1.imageData;
                // حساب التكرارات (Histogram)
                for (int i = 0; i < image1.widthStep * image1.height; i += image1.nChannels)
                {
                    hist[data[i + 1]]++; // بنشتغل على القناة الخضراء للسرعة
                }

                // حساب الـ Cumulative Distribution Function (CDF)
                int[] cdf = new int[256];
                cdf[0] = hist[0];
                for (int i = 1; i < 256; i++) cdf[i] = cdf[i - 1] + hist[i];

                // تطبيق التعديل على صورة جديدة
                img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
                byte* d = (byte*)img.imageData;
                float minCdf = 0;
                for (int i = 0; i < 256; i++) if (cdf[i] > 0) { minCdf = cdf[i]; break; }

                for (int i = 0; i < image1.widthStep * image1.height; i += image1.nChannels)
                {
                    float val = (cdf[data[i + 1]] - minCdf) / (totalPixels - minCdf) * 255;
                    byte newVal = (byte)Math.Min(255, Math.Max(0, val));
                    d[i] = d[i + 1] = d[i + 2] = newVal; // تحسين التباين وعرضها كرمادي
                }
            }
            DisplayResult(img); // عرضها في PictureBox2
        }

        // 2. زرار الـ Equalized Histogram (رسم الهيستوجرام للصورة المعالجة)
        private void equalizedHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackgroundImage == null) return;

            // بنستخدم نفس كود الهيستوجرام اللي عملناه بس بياخد من PictureBox2
            Bitmap source = new Bitmap(pictureBox2.BackgroundImage);
            Bitmap histBmp = DrawHistogram(source); // دالة الرسم

            pictureBox4.Image = histBmp; // عرض الهيستوجرام الجديد في المربع الرابع
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // دالة مساعدة لرسم الهيستوجرام (نفس فكرة كود الدكتور)
        private Bitmap DrawHistogram(Bitmap source)
        {
            Bitmap res = new Bitmap(256, 256);
            int[] count = new int[256];
            int max = 0;

            BitmapData data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                for (int i = 0; i < source.Height * source.Width; i++)
                {
                    count[p[0]]++;
                    if (count[p[0]] > max) max = count[p[0]];
                    p += 3;
                }
            }
            source.UnlockBits(data);

            using (Graphics g = Graphics.FromImage(res))
            {
                g.Clear(Color.White);
                for (int i = 0; i < 256; i++)
                {
                    int height = (int)((float)count[i] / max * 256);
                    g.DrawLine(Pens.Black, i, 256, i, 256 - height);
                }
            }
            return res;
        }
        //----------------------------------------------------------------------------
        // دالة الـ Motion Blur اللي طلبتها
        private void motionBlurItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);

            int width = image1.width;
            int height = image1.height;
            int stride = image1.widthStep;
            int blurSize = 50;

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int avgB = 0, avgG = 0, avgR = 0, count = 0;
                        for (int i = 0; i < blurSize && (x + i) < width; i++)
                        {
                            int index = y * stride + (x + i) * 3;
                            avgB += src[index];
                            avgG += src[index + 1];
                            avgR += src[index + 2];
                            count++;
                        }
                        int currentIdx = y * stride + x * 3;
                        dst[currentIdx] = (byte)(avgB / count);
                        dst[currentIdx + 1] = (byte)(avgG / count);
                        dst[currentIdx + 2] = (byte)(avgR / count);
                    }
                }
            }
            DisplayResult(img);
        }
        //-----------------------------------------------------------------------------
        private void negativeFilterItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;

            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int width = image1.width;
            int height = image1.height;
            int stride = image1.widthStep;

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;

                // بنلف على كل البكسلات ونعكس قيمتها
                for (int i = 0; i < stride * height; i++)
                {
                    dst[i] = (byte)(255 - src[i]);
                }
            }
            DisplayResult(img);
        }
        //---------------------------------------------------------------
        private void embossFilterItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;

            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int width = image1.width;
            int height = image1.height;
            int stride = image1.widthStep;

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;

                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            // تطبيق مصفوفة النحت (Emboss Kernel)
                            int res = (src[(y - 1) * stride + (x - 1) * 3 + c] * -1) +
                                      (src[y * stride + x * 3 + c] * 1) +
                                      128; // إضافة 128 للوصول للون الرمادي المحفور

                            dst[y * stride + x * 3 + c] = (byte)Math.Max(0, Math.Min(255, res));
                        }
                    }
                }
            }
            DisplayResult(img);
        }
        //---------------------------------------------------------
        private void laplacianFilterItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int width = image1.width;
            int height = image1.height;
            int stride = image1.widthStep;

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;

                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            // مصفوفة Laplacian: [0, 1, 0], [1, -4, 1], [0, 1, 0]
                            int res = (src[(y - 1) * stride + x * 3 + c] +
                                       src[(y + 1) * stride + x * 3 + c] +
                                       src[y * stride + (x - 1) * 3 + c] +
                                       src[y * stride + (x + 1) * 3 + c]) -
                                       (4 * src[y * stride + x * 3 + c]);

                            dst[y * stride + x * 3 + c] = (byte)Math.Max(0, Math.Min(255, Math.Abs(res)));
                        }
                    }
                }
            }
            DisplayResult(img);
        }
        //----------------------------------------------------------------------------------
        private void contrastAdjustmentItem_Click(object sender, EventArgs e)
        {
            if (image1.ptr == IntPtr.Zero) return;

            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int width = image1.width;
            int height = image1.height;
            int stride = image1.widthStep;

            // معامل التباين: 1.2 يعني زيادة 20%
            // ممكن تخليها 1.5 لزيادة أقوى
            double contrast = 1.5;

            unsafe
            {
                byte* src = (byte*)image1.imageData;
                byte* dst = (byte*)img.imageData;

                for (int i = 0; i < stride * height; i++)
                {
                    // المعادلة: Contrast * (Pixel - 128) + 128
                    // الـ 128 هي نقطة المنتصف عشان نفتح الفاتح ونغمق الغامق
                    int pixelValue = (int)(contrast * (src[i] - 128) + 128);

                    // التأكد إن القيمة لا تتخطى الحدود (0-255)
                    dst[i] = (byte)Math.Max(0, Math.Min(255, pixelValue));
                }
            }
            DisplayResult(img);
        }

        private void DisplayOnPictureBox1(IplImage src)
        {
            pictureBox1.BackgroundImage = new Bitmap(src.width, src.height, src.widthStep, PixelFormat.Format24bppRgb, src.imageData);
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void DisplayResult(IplImage res)
        {
            pictureBox2.BackgroundImage = new Bitmap(res.width, res.height, res.widthStep, PixelFormat.Format24bppRgb, res.imageData);
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}