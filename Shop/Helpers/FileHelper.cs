using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    public class FileHelper
    {
        public static IHostingEnvironment env { get; set; }
        public static string Upload(IFormFile formfile,string folder="uploads")
        {
            try
            {
                var filename = Guid.NewGuid().ToString() + formfile.FileName;
                var folderPath = Path.Combine(env.WebRootPath, folder);
                var filePath = Path.Combine(folderPath, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formfile.CopyTo(stream);
                }

                return filename;
            }
            catch
            {
                return null;
            }
        }

        public static bool Delete(string filename,string  folder="uploads")
        {
            var folderPath = Path.Combine(env.WebRootPath, folder);
            var filepath = Path.Combine(folderPath, filename);
            if(File.Exists(filepath))
            {
                File.Delete(filepath);
                return true;
            }
            else
            {
               return false;
            }

        }
    }
}
