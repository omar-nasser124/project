using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 // خليناه نفس اسم المشروع عشان يتحل الخطأ
{
    public class Histogram
    {
        public static int indexOf(int hang, int cot, int stride)
        {
            return hang * stride + cot * 3;
        }

        unsafe public static Bitmap CreateHistogram(Bitmap source, bool isGray)
        {
            if (source.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Bitmap histogramBmp = new Bitmap(256, 256, PixelFormat.Format24bppRgb);
                BitmapData data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                    ImageLockMode.ReadWrite, source.PixelFormat);

                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - source.Width * 3;

                if (isGray == false)
                {
                    for (int hang = 0; hang < source.Height; hang++)
                    {
                        for (int cot = 0; cot < source.Width; cot++)
                        {
                            byte t = (byte)(0.07f * p[0] + 0.72f * p[1] + 0.21 * p[2]);
                            p[0] = p[1] = p[2] = t;
                            p += 3;
                        }
                        p += offset;
                    }
                    p = (byte*)data.Scan0;
                }

                int[] count = new int[256];
                int max = 0;
                for (int hang = 0; hang < source.Height; hang++)
                {
                    for (int cot = 0; cot < source.Width; cot++)
                    {
                        count[p[0]]++;
                        if (count[p[0]] > max) max = count[p[0]];
                        p += 3;
                    }
                    p += offset;
                }
                source.UnlockBits(data);

                for (int i = 0; i < 256; i++)
                    count[i] = (int)(count[i] * 255f / max);

                BitmapData dataHist = histogramBmp.LockBits(new Rectangle(0, 0, 256, 256),
                    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                p = (byte*)dataHist.Scan0;

                for (int cot = 0; cot < 256; cot++)
                {
                    for (int hang = 0; hang < 256; hang++)
                    {
                        byte value = (hang <= (255 - count[cot])) ? (byte)255 : (byte)0;
                        int idx = indexOf(hang, cot, dataHist.Stride);
                        p[idx] = p[idx + 1] = p[idx + 2] = value;
                    }
                }
                histogramBmp.UnlockBits(dataHist);
                return histogramBmp;
            }
            return source;
        }
    }
}