using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MoblieUpload
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fileData = context.Request.Form["formFile"];//Base64编码过的图片数据信息，对字节数组字符串进行Base64解码

            string aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);
            string dirPath = context.Server.MapPath(aspxUrl+"/upload");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string imgPath = uploadFile(fileData, dirPath);
        }

        public string uploadFile(string fileData, string dirPath)
        {
            //拼接文件名称，不存在就创建
            string imgPath = dirPath + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

            var btyeData = Convert.FromBase64String(fileData);

            File.WriteAllBytes(imgPath, btyeData);
            //if (!f.exists())
            //{
            //    f.mkdir();
            //}
            ////使用BASE64对图片文件数据进行解码操作
            //BASE64Decoder decoder = new BASE64Decoder();
            //try
            //{
            //    //通过Base64解密，将图片数据解密成字节数组
            //    byte[] bytes = decoder.decodeBuffer(fileData);
            //    //构造字节数组输入流
            //    ByteArrayInputStream bais = new ByteArrayInputStream(bytes);
            //    //读取输入流的数据
            //    BufferedImage bi = ImageIO.read(bais);
            //    //将数据信息写进图片文件中
            //    ImageIO.write(bi, "jpg", f);// 不管输出什么格式图片，此处不需改动
            //    bais.close();
            //}
            //catch (IOException e)
            //{
            //    log.error("e:{}", e);
            //}
            return "";
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}