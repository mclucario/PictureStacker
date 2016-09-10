using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace PictureStackerConsole {

    class Program {

        static void Main(string[] args) {

            Bitmap finalImg;
            List<Image> imgs = new List<Image>();
            int pictureheight = 0;
            int picturewidth = 0;

            int offsetwidth = 0;
            int offsetheight = 0;

            string oName = "output.png";

            if (args.Count() < 2) {

                Console.WriteLine("McLucario's Picture Stacker" + Environment.NewLine 
                    + "Usage: stacker.exe <filepath1> <filepath2> ... outputname:output.png" 
                    + Environment.NewLine + "Need's to have at least 2 pictures.");
                Environment.Exit(1);

            } else {

                foreach (string lImg in args) {

                    if (lImg.StartsWith("outputname:")) {

                        oName = lImg.Split((char)32)[1];

                    } else {

                        try {

                            imgs.Add(Image.FromFile(lImg));

                        } catch (Exception ex) {

                            Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                            Environment.Exit(2);


                        }
                    }

                }

                foreach (Image sImg in imgs) {

                    pictureheight = pictureheight + sImg.Height;

                    if (picturewidth < sImg.Width) {

                        picturewidth = sImg.Width;

                    }

                }

                finalImg = new Bitmap(picturewidth, pictureheight);

                foreach (Bitmap sImg in imgs) {

                    for (int y = 0; y < sImg.Height; y++) {

                        for (int x = 0; x < sImg.Width; x++) {

                                finalImg.SetPixel(x, y + offsetheight, sImg.GetPixel(x, y));

                        }

                    }

                    offsetheight = offsetheight + sImg.Height;
                    offsetwidth = offsetwidth + sImg.Width;
                }

                finalImg.Save(oName);
                Console.WriteLine("Saved file as " + oName);


            }

        }
    }
}
