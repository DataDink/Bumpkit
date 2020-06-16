using BumpKit;
using System;
using System.Drawing;
using System.IO;

namespace Demonstrations
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Demonstrations());


            using (FileStream fs = new FileStream(@"E:\123.gif", FileMode.OpenOrCreate))
            {
                GifEncoder gifEncoder = new GifEncoder(fs);

                foreach (string item in Directory.EnumerateFiles(@"E:\Pictures"))
                {
                    try
                    {
                        Image img = Image.FromFile(item);
                        gifEncoder.AddFrame(Image.FromFile(item));
                    }
                    catch
                    {

                    }

                }
            }


        }
    }
}
