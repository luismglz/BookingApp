using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookingApp.Services
{
    public class ImageService
    {


        //Converts an image in base64 format to image in binary format to be able to be visualized
        public ImageSource ConvertImageFromBase64ToImageSource(string imageBase64) {
            if (!string.IsNullOrEmpty(imageBase64))
            {
                try
                {
                    return ImageSource.FromStream(() =>
                new MemoryStream(System.Convert.FromBase64String(imageBase64)));
                }
                catch
                {

                    return null;
                }




            }
            else
            {
                return null; //TODO: Send NotFound Image
            }
        }

        public async Task<string> ConvertImageFilePathToBase64(string filePath) {

            //Converts an image from file path to text in base 64 format
            if (!string.IsNullOrEmpty(filePath))
            {
                FileStream stream = File.Open(filePath, FileMode.Open);
                byte[] bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                return System.Convert.ToBase64String(bytes);
            }
            else
            {
                return string.Empty;
            }
        }

        public string SaveImageFromBase64(string imageBase64, int id) {

            if (!string.IsNullOrEmpty(imageBase64))
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), id + ".tmp");
                byte[] data = Convert.FromBase64String(imageBase64);
                System.IO.File.WriteAllBytes(filePath, data);
                return filePath;
            }

            return string.Empty;

        }
    }
}
