using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TripAdvisor.Controllers
{
    public class ImageDownloader
    {
        public bool IsSizeOfImageAcceptable(String p_strUrl)
        {
            var bytes = getImageFromUrl(p_strUrl);

            bool isSuccess = false;

            using (Stream memStream = new MemoryStream(bytes))
            {
                Image tempImg = new Bitmap(0,0);
                using (Image img = tempImg.FromStream(memStream))
                {                    
                    int width = img.Width;
                    int height = img.Height;

                    if(width == 900 && height == 400)                    
                        isSuccess = true;                    
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// Downloading an Image to local machine
        /// </summary>
        /// <param name="p_strUrl">The url of the image</param>
        /// <returns>The url its been saved.</returns>
        public string DownloadImage(String p_strUrl)
        {
            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(p_strUrl);


            using (WebResponse imageResponse = imageRequest.GetResponseAsync().Result)
            {
                using (Stream responseStream = imageResponse.GetResponseStream())
                {
                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        imageBytes = br.ReadBytes(500000);
                    }
                } 
            }

            string fileLocation = "";

            using (FileStream fs = new FileStream(fileLocation, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(imageBytes);
                }
            }

            return fileLocation;                       
        }

        public byte[] getImageFromUrl(string url)
        {                     
            byte[] b = null;

            var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            var response = request.GetResponseAsync().Result;                        
            if (request.HaveResponse)
            {
                using (Stream receiveStream = response.GetResponseStream())
                {                    
                    using (BinaryReader br = new BinaryReader(receiveStream))
                    {
                        b = br.ReadBytes(500000);
                    }
                }
            }

            return b;
        }

    }
}
