using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Wax
    {
        public string version = "0.3d";
        public string updateLink;
        public int updateValue = 0;

        public string file_path; // Ścieżka do pliku || Zakładka 1
        public string file_name; // Nazwa pliku      || Zakładka 2
        public string VideoCodec;
        public string Bitrate;
        public string Resolution_Width;
        public string Resolution_Height;
        public string Resolution_Display;
        public string FPS;
        public string AudioChannels = " ";
        public string Time;
        public string Size;
        public string LinkDescs = "/descs";
        public string LinkPoster = "/posters";
        public string FilmDescs;
        public string AudioChannels2;
        public string file_path_main;
        public string PosterLink;
        public string PosterLink2;
        public int IndexPoster;
        public int IndexP;

        public string[] FilmInfo = new string[6] { "", "", "", "", "", "" };


        public int first;
        public int last;

        public string Code;
        public string[] NFO = new string[2];

        public Bitmap[] PosterHTML = new Bitmap[4];
        public Bitmap[] PosterHosting = new Bitmap[4];

       

        public virtual string PosterIndex(int w)
        {
            switch (w)
            {
                case 0: return "bluray";
                    break;
                case 1: return "bluray3d";
                    break;
                case 2: return "dvd";
                    break;
                case 3: return "dvdhd";
                    break;
                case 4: return "hddvd";
                    break;
                case 5: return "hdtv";
                    break;
                case 6: return "webrip";
                    break;
                case 7: return "ultrahd";
                    break;
            }
            return "error";
        }

        public virtual string Audio(int channel)
        {
            switch (channel)
            {
                case 2: return "2.0";
                    break;
                case 3: return "2.1";
                    break;
                case 6: return "5.1";
                    break;
                case 8: return "7.1";
                    break;
            }
            return String.Empty;
        }

        public int PosterIs;

        public string settings;
        public string[] setting = new string[7];
     
        public string save;

        public string documents;

        public Bitmap[] PosterHTML2 = new Bitmap[2];
        public Bitmap[] PosterHosting2 = new Bitmap[2];
        public int[] IsC = new int[2];
        public int Authors = 0;
    }
}
