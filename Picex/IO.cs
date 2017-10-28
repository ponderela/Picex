using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Picex
{//Addtsetgit 
    class IO
    {
        private string path = null;
        public IO()
        {

        }
        public void writeByte(byte[] raw , String path)
        {
            try {
                using (FileStream fs = new FileStream(path, System.IO.FileMode.Create))
                {
                    fs.Write(raw, 0, raw.Length);
                    using (StreamWriter sr = new StreamWriter(fs, Encoding.UTF8))
                        sr.Write(Encoding.UTF8.GetString(raw));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] readByteFromURL(string URL)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    return client.DownloadData(URL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String readTextFromURL(string URL)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(URL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
