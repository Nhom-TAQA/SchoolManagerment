using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuanLyTruongHoc.User
{
    public static class ImageHandle
    {
        public static Image ByteToImage(byte[] arrImage)
        {
            if (arrImage == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(arrImage, 0, arrImage.Length);
            ms.Write(arrImage, 0, arrImage.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public static byte[] StringToByte(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] arrImage = new byte[fs.Length];
            fs.Read(arrImage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return arrImage;
        }
    }
}
