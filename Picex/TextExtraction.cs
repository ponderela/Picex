using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;
using System.IO;
namespace Picex
{
    class TextExtraction
    {
        public TextExtraction(string Origin, string Dest , string URL)
        {
            if(true)
            {
                Get_Picture(Dest, URL);
            }
            else
            {
                Get_Cover(Origin, Dest, URL);
            }
        }

        public void Get_Cover(string Origin, string Dest, string URL)
        {
            //Read HTML file (utf8)
            //string test = "http://www.finejewelthai.com/pic/ไพลิน-พลอยแท้-พลอยราศี-พลอยไพลิน-พลอยประจำเดือนเกิดกันยายน-Blue-Sapphire-Diamond-Silver-finejewelthai.com-R1274bl-1.jpg";
            /*string url = "http://www.finejewelthai.com/Thailand-Best%E2%80%93Silver-Ring-%E0%B9%81%E0%B8%AB%E0%B8%A7%E0%B8%99%E0%B9%80%E0%B8%87%E0%B8%B4%E0%B8%99.php?product=1&type=1&memid=";
            string HTML = GetHTML(url);*/

            IO write = new IO();
            var HTML = File.ReadAllText(Origin, Encoding.UTF8);

            HtmlNodeCollection col = GetElement(HTML, "//div[@class='pDetailList_img']//img");
            foreach (var node in col)
            {
                string initial = @"http://www.finejewelthai.com/";
                string productFileName = URLExtract_loadlink(node.OuterHtml, "pic");
                byte[] content = write.readByteFromURL(initial + productFileName);
                write.writeByte(content, Dest + "\\" + productFileName.Replace("pic/", ""));
            }
        }

        public void Get_Picture(string Dest, string URL)
        {
            string test = "http://www.finejewelthai.com/Thailand-Best%E2%80%93Silver-Ring-%E0%B9%81%E0%B8%AB%E0%B8%A7%E0%B8%99%E0%B9%80%E0%B8%87%E0%B8%B4%E0%B8%99.php?product=1&type=1&memid=";
            IO read = new IO();
            var HTML = read.readTextFromURL(test);
            //string result = System.Text.Encoding.UTF8.GetString(HTML);
        }

        public HtmlNodeCollection GetElement(string html,string node)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument.DocumentNode.SelectNodes(node);
        }

        public string URLExtract_loadlink(string text,string pinIndex)
        {
            String result = null;
            var splitArray = text.Split('"');        
            foreach(var value in splitArray)
            {
                var find = value.IndexOf(pinIndex);
                if(find == 0)
                {
                    result = value;
                    break;
                }
            }

            return result;
        }

        public string URLExtract_ItemID(string text)
        {
            return null;
        }
    }
}
