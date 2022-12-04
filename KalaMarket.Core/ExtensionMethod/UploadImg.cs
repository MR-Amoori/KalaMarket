using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KalaMarket.Core.ExtensionMethod
{
  public  static class UploadImg
    {
        public static string CreateImage(IFormFile file)
        {
            try
            {
                string imgName = GenerateCode.GuidCode() + Path.GetExtension(file.FileName);
                string pathImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/main/assets/images/slider-main",imgName);
                using (var  stream = new  FileStream(pathImg,FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return imgName;
            }
            catch
            {
                return "false";
            }
        }

        public static bool DeleteImg(string path, string imgName)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/main/assets/images/" + path + "/" + imgName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
