using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Threading;
using System.Globalization;
using MediaInfoLib;
using System.Web;

//wax.opx.pl
//h: Gg123456

//db----
//user(& baza): 1057611_KqZ
//pas: f8VNdd8B2nLpUT
//host: userdb1



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Wax TG = new Wax();

        List<Bitmap> PostersHTML = new List<Bitmap>();
        List<Bitmap> PostersHosting = new List<Bitmap>();
        List<string> url = new List<string>();
        public Form1()
        {
            InitializeComponent();
           
            TG.setting[0] = " ";
            TG.setting[1] = " ";
            TG.setting[2] = " ";
            TG.setting[3] = " ";
            TG.setting[4] = " ";
            TG.setting[5] = " ";
            TG.setting[6] = " ";
            TG.documents = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //WebClient c = new WebClient();
            //Stream o = c.OpenRead("http://pawno.pl/uploads/profile/photo-9878.png?_r=1350896326");

            //TG.PosterHTML[0] = new Bitmap("okladki//logo.png");
            TG.PosterHTML[0] = new Bitmap(12, 12);
            TG.PosterHTML[0] = new Bitmap(TG.PosterHTML[0], new Size(140, 200));
            pictureBox1.Image = TG.PosterHTML[0];
            TG.PosterHosting[0] = TG.PosterHTML[0];
            TG.PosterHosting[0] = new Bitmap(TG.PosterHosting[0], new Size(232, 327));

            if (Directory.Exists(TG.documents + "//BTG Generator_by Wax"))
            {
                if (System.IO.File.Exists(TG.documents + "//BTG Generator_by Wax//settings.wax"))
                {
                    TG.documents = TG.documents + "//BTG Generator_by Wax//settings.wax";
                    //System.IO.FileStream settingFile = new System.IO.FileStream(p, FileMode.Open, FileAccess.ReadWrite);
                    TG.settings = System.IO.File.ReadAllText(TG.documents);

                    #region <video>
                    StreamSettings(0, "<video>", "</video>", 7);
                    AddToComboBox(0, comboBox_Video);
                    #endregion

                    #region <audio>
                    StreamSettings(1, "<audio>", "</audio>", 7);
                    AddToComboBox(1, comboBox_Audio);
                    #endregion

                    #region <language>
                    StreamSettings(2, "<language>", "</language>", 10);
                    AddToComboBox(2, comboBox_Language);
                    #endregion

                    #region <language2>
                    StreamSettings(3, "<language2>", "</language2>", 11);
                    AddToComboBox(3, comboBox_Language2);
                    #endregion

                    #region <subtitle>
                    StreamSettings(4, "<subtitle>", "</subtitle>", 10);
                    AddToComboBox(4, comboBox_Subtitle);
                    #endregion

                    #region <nick>
                    StreamSettings(5, "<nick>", "</nick>", 6);
                    AddToComboBox(5, comboBox_nickauthor);
                    #endregion

                    #region <language3>
                    StreamSettings(6, "<language3>", "</language3>", 11);
                    AddToComboBox(6, comboBox_Language3);
                    #endregion
                }
                else
                {
                    TG.save = String.Format("<video>\r\n");
                    TG.save += String.Format("</video>\r\n");
                    TG.save += String.Format("<audio>\r\n");
                    TG.save += String.Format("</audio>\r\n");
                    TG.save += String.Format("<language>\r\n");
                    TG.save += String.Format("</language>\r\n");
                    TG.save += String.Format("<language2>\r\n");
                    TG.save += String.Format("</language2>\r\n");
                    TG.save += String.Format("<subtitle>\r\n");
                    TG.save += String.Format("</subtitle>\r\n");
                    TG.save += String.Format("<nick>\r\n");
                    TG.save += String.Format("</nick>\r\n");
                    TG.save += String.Format("<language3>\r\n");
                    TG.save += String.Format("</language3>");
                    //System.IO.File.WriteAllText(TG.documents, TG.save);

                    FileStream sv = new FileStream(TG.documents + "settings,wax", FileMode.Create);
                    StreamWriter file_ = new StreamWriter(sv);
                    file_.Write(TG.save);
                    file_.Close();
                    sv.Close();
                }
            }
            else
            {
                Directory.CreateDirectory(TG.documents +  "//BTG Generator_by Wax");
                TG.documents = TG.documents + "//BTG Generator_by Wax//settings.wax";

                //System.IO.FileStream fs = System.IO.File.Create(TG.documents);
                //fs.Close();
                TG.save = String.Format("<video>\r\n");
                TG.save += String.Format("</video>\r\n");
                TG.save += String.Format("<audio>\r\n");
                TG.save += String.Format("</audio>\r\n");
                TG.save += String.Format("<language>\r\n");
                TG.save += String.Format("</language>\r\n");
                TG.save += String.Format("<language2>\r\n");
                TG.save += String.Format("</language2>\r\n");
                TG.save += String.Format("<subtitle>\r\n");
                TG.save += String.Format("</subtitle>\r\n");
                TG.save += String.Format("<nick>\r\n");
                TG.save += String.Format("</nick>\r\n");
                TG.save += String.Format("<language3>\r\n");
                TG.save += String.Format("</language3>");
                //System.IO.File.WriteAllText(TG.documents, TG.save);

                FileStream sv = new FileStream(TG.documents, FileMode.Create);
                StreamWriter file_ = new StreamWriter(sv);
                file_.Write(TG.save);
                file_.Close();
                sv.Close();
                
            }

            HideUpdateForm();
            //CheckUpdate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }



        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //TG.documents += "//BTG Generator_by Wax//settings.wax";

            TG.save = String.Format("<video>\r\n{0}", TG.setting[0]);
            TG.save += String.Format("\r\n</video>");
            TG.save += String.Format("\r\n<audio>\r\n{0}", TG.setting[1]);
            TG.save += String.Format("\r\n</audio>");
            TG.save += String.Format("\r\n<language>\r\n{0}", TG.setting[2]);
            TG.save += String.Format("\r\n</language>");
            TG.save += String.Format("\r\n<language2>\r\n{0}", TG.setting[3]);
            TG.save += String.Format("\r\n</language2>");
            TG.save += String.Format("\r\n<subtitle>\r\n{0}", TG.setting[4]);
            TG.save += String.Format("\r\n</subtitle>");
            TG.save += String.Format("\r\n<nick>\r\n{0}", TG.setting[5]);
            TG.save += String.Format("\r\n</nick>");
            TG.save += String.Format("\r\n<language3>\r\n{0}", TG.setting[6]);
            TG.save += String.Format("\r\n</language3>");

            FileStream sv = new FileStream(TG.documents, FileMode.Create);
            StreamWriter file_ = new StreamWriter(sv);
            file_.Write(TG.save);
            file_.Close();
            sv.Close();

            //System.IO.Path.GetDirectoryName(Application.ExecutablePath); "//BTG Generator_by Wax//s.wax"
        }

        private void AddToComboBox(int id, ComboBox wax)
        {
            string[] split = TG.setting[id].Split(new Char[] { '\n' });

            foreach (string s in split)
            {
                if (s.Trim() != "") wax.Items.Add(s);
            }
        }

        private void StreamSettings(int id, string f, string l, int num)
        {
            TG.first = TG.settings.IndexOf(f);
            TG.last = TG.settings.IndexOf(l, TG.first);
            TG.setting[id] = TG.settings.Substring(TG.first + num, TG.last - TG.first - num - 2);
        }

        static long LinesCount4(string s)
        {
            long count = 0;
            int position = -1;
            while ((position = s.IndexOf('\n', position + 1)) != -1) count++;
            return count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog okienko = new OpenFileDialog();
            okienko.Filter = "Pliki Video |*.avi|Pliki MKV |*.mkv";

            TG.PosterHTML[0] = new Bitmap("okladki//logo.png");
            if (okienko.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("Wybrano plik: " + okienko.FileName);
                TG.file_path = okienko.FileName;
                TG.file_name = okienko.FileName.Substring(okienko.FileName.LastIndexOf('\\') + 1);
                TG.file_name = TG.file_name.Substring(0, TG.file_name.Length - 4);
                progressBar_One.Value = 100; 
                LoadInfoMovie();
                //progressBar_One.Value = 100; 
            }
        }

        void newTheard(Label tb, string msg)
        {
            tb.BeginInvoke(
                    new Action(() =>
                    {
                        tb.Text = msg;
                    }
                           ));
        }
        void newTheard(TextBox tb, string msg)
        {
            tb.BeginInvoke(
                    new Action(() =>
                    {
                        tb.Text = msg;
                    }
                           ));
        }
        void newTheard(RichTextBox tb, string msg)
        {
            tb.BeginInvoke(
                    new Action(() =>
                    {
                        tb.Text = msg;
                    }
                           ));
        }
        void newTheard(ProgressBar pb, int value)
        {
            pb.BeginInvoke(
               new Action(() =>
               {
                   pb.Increment(value);
               }
                ));
        }


        void threadDownload()
        {
            WebClient client = new WebClient();
            newTheard(progressBar_Two, 1);

            #region Film Info #1
            Byte[] pageData = client.DownloadData(textBox_FilmWeb.Text);
            string pageHtml = Encoding.UTF8.GetString(pageData);
            newTheard(progressBar_Two, 1);
            #region Genres
            newTheard(label33, "Downloading genres...");
            if (textBox_FilmWeb.Text.Contains("serial"))
            {
                TG.first = pageHtml.IndexOf("gatunek:</th><td><a href=\"/search/serial?genreIds=") + 52;
                TG.last = pageHtml.IndexOf("</td></tr></table></div>", TG.first);
                
            }
            else
            {
               //<a href="/films/search?genres=">  || <a href=\"/search/film?genreIds=   
                TG.first = pageHtml.IndexOf("gatunek:</th><td><ul class=\"inline sep-comma genresList\"><li><a href=\"/films/search?genres=") + 94;
               // TG.last = pageHtml.IndexOf("</a>", TG.first);
                TG.last = pageHtml.IndexOf("</ul>", TG.first);
            }
            //TG.first = pageHtml.IndexOf("gatunek:</th><td><ul class=\"inline sep-comma genresList\"><li><a href=\"/search/film?genreIds=") + 95;
            //TG.last = pageHtml.IndexOf("</a></li></ul></td></tr><tr><th>produkcja:");
            //TG.last = pageHtml.IndexOf("</a>", TG.first);
            if (TG.last - TG.first > 0)
            {
                TG.FilmInfo[0] = pageHtml.Substring(TG.first, TG.last - TG.first);
                TG.FilmInfo[0] = TG.FilmInfo[0].Replace(">", "").Replace("</a", "");
                
                while (TG.FilmInfo[0].Contains("<a href="))
                {
                    TG.first = TG.FilmInfo[0].IndexOf("<a href=\"/films/search?genres=");
                    if (TG.first < 0) TG.first = TG.FilmInfo[0].IndexOf("<a href=\"/search/serial?genreIds=");
                    TG.last = TG.FilmInfo[0].IndexOf("\"", TG.first + 9);
                    if (TG.first >= 0) TG.FilmInfo[0] = TG.FilmInfo[0].Remove(TG.first, TG.last - TG.first + 1);
                    else break;
                    TG.FilmInfo[0] = TG.FilmInfo[0].Replace("</li<li", ", ").Replace(">", "").Replace("</li", "");
                }
            }
            TG.FilmInfo[0] = TG.FilmInfo[0].Replace("</li", "");
            #endregion
            //TG.FilmInfo[0] = "Gatunek............: " + TG.FilmInfo[0];
            newTheard(textBox_Genres, TG.FilmInfo[0].Replace(">", ""));
            newTheard(progressBar_Two, 5);
            #region Country
            newTheard(label33, "Checking production..."); 
            pageHtml = Encoding.UTF8.GetString(pageData);
                                                                 //href=\"/search/film?countryIds || href="/films/search?countries="
            TG.first = pageHtml.IndexOf("produkcja:</th><td><ul class=\"inline sep-comma\"><li><a href=\"/films/search?countries=") + 88;
            TG.last = pageHtml.IndexOf("</a></li></ul></td></tr><tr><th>premiera:");

            if (TG.last < 0) TG.last = pageHtml.IndexOf("</a></li></ul></td></tr></table></div><script type=\"text/javascript\">var");

            if (TG.last - TG.first > 0)
            {
                TG.FilmInfo[1] = pageHtml.Substring(TG.first, TG.last - TG.first);

                while (TG.FilmInfo[1].Contains("<a href="))
                {
                    TG.first = TG.FilmInfo[1].IndexOf("<a href=");
                    TG.last = TG.FilmInfo[1].IndexOf("\">", TG.first);
                    TG.FilmInfo[1] = TG.FilmInfo[1].Remove(TG.first, TG.last - TG.first + 2);
                    TG.FilmInfo[1] = TG.FilmInfo[1].Replace("</a></li><li>", ", ");
                }
            }
            #endregion
            //TG.FilmInfo[1] = "Premiera...........: " + TG.FilmInfo[1];
            if (TG.FilmInfo[1] != null) newTheard(textBox_Country, TG.FilmInfo[1].Replace(">", ""));
            newTheard(progressBar_Two, 5);
            #region Premiere
            newTheard(label33, "Download release date...");
            pageHtml = Encoding.UTF8.GetString(pageData);

            TG.first = pageHtml.IndexOf("<tr><th>premiera:</th><td>") + 26;
            TG.last = pageHtml.IndexOf("</a></td></tr><tr><th>boxoffice:");
            
            if (TG.last < 0) TG.last = pageHtml.IndexOf("</a></td></tr></table></div><script type=\"text/javascript\">var");
            if (TG.last < 0) TG.last = pageHtml.IndexOf("</a></td>", TG.first + 1);
            //newTheard(richTextBox6, TG.last.ToString() + " i " + TG.first.ToString());
            if (TG.last - TG.first > 0 && !textBox_FilmWeb.Text.Contains("serial"))
            {
                TG.FilmInfo[2] = pageHtml.Substring(TG.first, TG.last - TG.first);

                TG.first = TG.FilmInfo[2].IndexOf("<a href");
                TG.last = TG.FilmInfo[2].IndexOf("\">");
                TG.FilmInfo[2] = TG.FilmInfo[2].Remove(TG.first, TG.last - TG.first + 2);

                while (TG.FilmInfo[2].Contains("<span "))
                {
                    TG.first = TG.FilmInfo[2].IndexOf("<span id=");
                    TG.last = TG.FilmInfo[2].IndexOf("</span>", TG.first);
                    TG.FilmInfo[2] = TG.FilmInfo[2].Remove(TG.first, TG.last - TG.first + 7);
                }
                TG.FilmInfo[2] = TG.FilmInfo[2].Replace("<span> ", "").Replace("</span> ", "").Replace("ka)", "ka),");
            }
            #endregion
            //TG.FilmInfo[2] = "Produkcja..........: " + TG.FilmInfo[2];
            newTheard(textBox_Premiere, TG.FilmInfo[2]);

            newTheard(progressBar_Two, 5);
            #region Director
            //pageHtml = Encoding.UTF8.GetString(pageData);
            newTheard(label33, "Downloading directors...");
            TG.first = pageHtml.IndexOf("reżyseria:</th><td><ul class=\"inline sep-comma\">") + 49;
            TG.last = pageHtml.IndexOf("</td></tr><tr><th>scenariusz:");
            /*
            if (TG.last - TG.first > 0)
            {
                TG.FilmInfo[3] = pageHtml.Substring(TG.first, TG.last - TG.first);
                
                TG.first = TG.FilmInfo[3].LastIndexOf("name\">") + 6;
                TG.last = TG.FilmInfo[3].LastIndexOf("</a>");
                //TG.first = TG.FilmInfo[3].IndexOf("\">") + 2;
                //TG.last = TG.FilmInfo[3].IndexOf("</a>");
                TG.FilmInfo[3] = TG.FilmInfo[3].Substring(TG.first, TG.last - TG.first).Replace("&aacute;", "á").Replace("&eacute;", "é");
               
            }*/




            if (TG.last - TG.first > 0) TG.FilmInfo[3] = pageHtml.Substring(TG.first, TG.last - TG.first);
            else TG.FilmInfo[3] = " ";

       
            string str = "";
            int wax_j = 0;
            while (TG.FilmInfo[3].Contains("name\">"))
            {
                TG.first = TG.FilmInfo[3].IndexOf("name\">") + 6;
                TG.last = TG.FilmInfo[3].IndexOf("</a>", TG.first);
                if (wax_j == 1) str += ", ";
                str += TG.FilmInfo[3].Substring(TG.first, TG.last - TG.first);
                TG.FilmInfo[3] = TG.FilmInfo[3].Remove(0, TG.last);
                wax_j++;

            }
            TG.FilmInfo[3] = str;




           // TG.FilmInfo[3] = test;


            #endregion
            //TG.FilmInfo[3] = "Reżyseria..........: " + TG.FilmInfo[3];
            newTheard(textBox_Director, TG.FilmInfo[3]);

            newTheard(progressBar_Two, 5);
            #region Writers
            newTheard(label33, "Downloading writers...");
            pageHtml = Encoding.UTF8.GetString(pageData);

            TG.first = pageHtml.IndexOf("scenariusz:</th><td><ul class=\"inline sep-comma\">") + 49;
            TG.last = pageHtml.IndexOf("<a class=\"space-left", TG.first);//  </a></li></ul></td></tr>

            if (TG.last - TG.first > 0) TG.FilmInfo[4] = pageHtml.Substring(TG.first, TG.last - TG.first);
            else
            {
                TG.last = pageHtml.IndexOf("</a></li></ul></td></tr>", TG.first);
                if (TG.last - TG.first > 0) TG.FilmInfo[4] = pageHtml.Substring(TG.first, TG.last - TG.first);
            }

            if (TG.FilmInfo[4].Contains("<li><a href=\"/person"))
            {
                while (TG.FilmInfo[4].Contains("<li><a href=\"/person"))
                {
                    TG.first = TG.FilmInfo[4].IndexOf("<li><a href=\"/person");
                    TG.last = TG.FilmInfo[4].IndexOf("\">");
                    if (TG.last - TG.first > 0)
                    {
                        TG.FilmInfo[4] = TG.FilmInfo[4].Remove(TG.first, TG.last - TG.first + 2);
                        TG.FilmInfo[4] = TG.FilmInfo[4].Replace("</a>", ", ").Replace("</li>", "").Replace("&egrave;", "é").Replace("&eacute;", "é").Replace(", </ul>", "");
                    }
                    else
                    {
                        TG.FilmInfo[4] = "";
                        break;
                    }
                }
            }
            else TG.FilmInfo[4] = "";
            #endregion
            //TG.FilmInfo[4] = "Scenariusz.........: " + TG.FilmInfo[4];
            newTheard(richTextBox1, TG.FilmInfo[4]);

            newTheard(progressBar_Two, 5);
            #region Stars
            newTheard(label33, "Downloading cast...");
            pageHtml = Encoding.UTF8.GetString(pageData);

            TG.first = pageHtml.IndexOf("<table class=\"filmCast filmCastCast\"><thead><tr><") + 49;
            //TG.first = pageHtml.IndexOf("<li id=\"filmMenu-filmFullCast") + 29;


            TG.last = pageHtml.IndexOf("class=\"sbtn seeAll seeAllCast\">zobacz pełną obsadę</a><script type=\"text/javascript\">(function(){var a=\"picture\",b=Sizzle(\".filmCastBox .rolePhoto a[data-photo]\"),c=[\"gallery\",", TG.first);
            //</span><script type="text/javascript">(function(a){if(isBeforePremiere()){return false}
            TG.last = pageHtml.LastIndexOf("</span><script type=\"text/javascript\">(function(a){if(isBeforePremiere()){return false}");
            //if(TG.last < 0) TG.last = pageHtml.LastIndexOf("</span></td><td class=roleVote><script type=\"text/javascript\">(function(a");
            //richTextBox6.Text = pageHtml.Substring(TG.first, TG.last - TG.first);

            if (TG.last - TG.first > 0) pageHtml = pageHtml.Substring(TG.first, TG.last - TG.first);
           
            if (TG.last < 0) TG.last = pageHtml.LastIndexOf("<script type=\"text/javascript\">(function(){var a=\"picture\",b=Sizzle(\".filmCastBox");

            /* int l = pageHtml.IndexOf(">obsada</a></h2><span class=\"vertical-align space-left\">(") + 57;//
             int le = pageHtml.IndexOf(")", l);
             string nu = pageHtml.Substring(l, le - l);

             if (pageHtml.IndexOf("<p class=text>Wiesz, kto tworzył ten film? Podziel się swoją wiedzą z innymi! ") < 0)
             {
                 pageHtml = pageHtml.Substring(TG.first, TG.last - TG.first);
                 int ilosc = Convert.ToInt16(nu);

                 if (ilosc > 8) ilosc = 8;
                 else ilosc = 0;

                 TG.FilmInfo[5] = String.Empty;
                 for (int i = 0; i < ilosc; i++)
                 {
                     TG.first = pageHtml.IndexOf("class=pImg49 rel=\"nofollow v:starring\" title=\"") + 46;
                     TG.last = pageHtml.IndexOf("\">", TG.first);

                     if (TG.last > 0)
                     {
                         TG.FilmInfo[5] += pageHtml.Substring(TG.first, TG.last - TG.first).Replace("&eacute;", "é");
                         TG.FilmInfo[5] += ", ";
                         pageHtml = pageHtml.Remove(1, TG.last + 2);
                     }
                 }
                 if (TG.FilmInfo[5] != String.Empty) TG.FilmInfo[5] = TG.FilmInfo[5].Replace("&egrave;", "é") + "!";

                 TG.first = TG.FilmInfo[5].IndexOf("/td>");
                 TG.last = TG.FilmInfo[5].IndexOf("!");
                 if (TG.first > 0) TG.FilmInfo[5] = TG.FilmInfo[5].Remove(TG.first, TG.FilmInfo[5].Length - TG.first);

                 TG.first = TG.FilmInfo[5].IndexOf("pl");
                 if (TG.first > 0) TG.FilmInfo[5] = TG.FilmInfo[5].Remove(TG.first, TG.FilmInfo[5].Length - TG.first);
            
             }
             else TG.FilmInfo[5] = "";
            

             int wowek = Convert.ToInt16(pageHtml.Contains("rel=\"v:starring\">").ToString());
             for (int i = 0; i < wowek - 1; i++)
             {
                 TG.first = pageHtml.IndexOf("rel=\"v:starring\">") + 17;
                 TG.last = pageHtml.IndexOf("</a>", TG.first);
                 TG.FilmInfo[5] += pageHtml.Substring(TG.first, TG.last - TG.first);
             }*/
            int wax_i = 0;
            while (pageHtml.Contains("rel=\"v:starring\">") && wax_i <=3)
            {
                TG.first = pageHtml.IndexOf("rel=\"v:starring\">") + 17;
                TG.last = pageHtml.IndexOf("</a>", TG.first);
                TG.FilmInfo[5] += pageHtml.Substring(TG.first, TG.last - TG.first);
                if (wax_i <= 2) TG.FilmInfo[5] += ", ";
                pageHtml = pageHtml.Remove(0, TG.last + 3);
                wax_i++;
            }



            #endregion
            //TG.FilmInfo[5] = "Obsada.............: " + TG.FilmInfo[5] + "i inni...";
            #endregion
            TG.FilmInfo[5] = WebUtility.HtmlDecode(TG.FilmInfo[5]);
            if (TG.FilmInfo[5] == "") newTheard(richTextBox3, TG.FilmInfo[5] + "Brak obsady");
            //else newTheard(richTextBox3, TG.FilmInfo[5] + "i inni...");
            else newTheard(richTextBox3, TG.FilmInfo[5]);
            newTheard(progressBar_Two, 10);

            #region Creators(serials)
            newTheard(label33, "Downloading creators...");
            pageHtml = Encoding.UTF8.GetString(pageData);

            TG.first = pageHtml.IndexOf("twórc") + 16;
            //if (TG.first < 0) TG.first = pageHtml.IndexOf("twórca:</th><td>") + 16;
            TG.last = pageHtml.IndexOf("</td></tr>", TG.first);

            if (TG.last - TG.first > 0)
            {
                pageHtml = pageHtml.Substring(TG.first, TG.last - TG.first);

                while (pageHtml.Contains("<a h"))
                {
                    TG.first = pageHtml.IndexOf("<a h");
                    TG.last = pageHtml.IndexOf("\">", TG.first);
                    pageHtml = pageHtml.Remove(TG.first, TG.last - TG.first + 2);

                }

                newTheard(textBox_Authors, pageHtml.Replace("</a>", ""));
            }

            #endregion

            #region Film Info #2
            newTheard(label33, "Downloading storyline...");
            pageData = client.DownloadData(textBox_FilmWeb.Text.Replace("#", "") + TG.LinkDescs);
            pageHtml = Encoding.UTF8.GetString(pageData);

            TG.first = pageHtml.IndexOf("<p class=\"text\">") + 16;
            // TG.first = pageHtml.IndexOf("</a></h3><div class=\"s-13\"><span>autor:</span> <a href=\"") + 56;
            TG.last = pageHtml.IndexOf("</p><div class=\"top-10\">", TG.first);
            //TG.last = pageHtml.IndexOf("%</div></div></div> <div class=\"centeredContainer cl\">", TG.first);

            //richTextBox6.Text = pageHtml.Substring(TG.first, TG.last - TG.first);

            if (TG.last - TG.first > 0) TG.FilmDescs = pageHtml.Substring(TG.first, TG.last - TG.first);
            else// TG.FilmDescs = "Brak opisu";
            {
                pageData = client.DownloadData(textBox_FilmWeb.Text.Replace("#", ""));
                pageHtml = Encoding.UTF8.GetString(pageData);
                TG.first = pageHtml.IndexOf("<div class=\"filmPlot bottom-15\"><p class=\"text\">") + 48;
                TG.last = pageHtml.IndexOf("<br/></p>", TG.first);

                if (TG.last - TG.first > 0) TG.FilmDescs = pageHtml.Substring(TG.first, TG.last - TG.first);
                else TG.FilmDescs = "Brak opisu";

            }

            while (TG.FilmDescs.Contains("<a class='internal' href="))
            {
                TG.first = TG.FilmDescs.IndexOf("<a class='internal' href=");
                TG.last = TG.FilmDescs.IndexOf("'>");
                if (TG.last - TG.first > 0) TG.FilmDescs = TG.FilmDescs.Remove(TG.first, TG.last - TG.first + 2).Replace("</a>", "");
                else
                {
                    TG.first = TG.FilmDescs.IndexOf("<a class='internal' href=");
                    TG.last = TG.FilmDescs.IndexOf(">");
                    TG.FilmDescs = TG.FilmDescs.Remove(TG.first, TG.last - TG.first + 1).Replace("</a>", "");
                }
            }








            newTheard(label33, "Replacing characters...");
            TG.FilmDescs = TG.FilmDescs.Replace("&oacute;", "ó").Replace("&nbsp;", "").Replace("&rsquo;", "'").Replace("&ndash;", "-").Replace("&quot;", "\"").Replace("<br/>", "\n").Replace("<b>", "").Replace("</b>", "").Replace("&eacute;", "é").Replace("&egrave;", "è");// &eacute;
            #endregion
            TG.FilmDescs = WebUtility.HtmlDecode(TG.FilmDescs);
            newTheard(richTextBox2, TG.FilmDescs);
            newTheard(progressBar_Two, 10);

            #region Poster download
            newTheard(label33, "Downloading the poster...");
            pageData = client.DownloadData(textBox_FilmWeb.Text);
            pageHtml = Encoding.UTF8.GetString(pageData);

            TG.first = pageHtml.IndexOf("<div id=filmPosterLink class=hide>") + 34;
            TG.last = pageHtml.IndexOf("</div><div class=posterLightbox>");
            if (TG.last - TG.first > 0)
            {
                pageHtml = pageHtml.Substring(TG.first, TG.last - TG.first);

                Stream odczytWykresu = client.OpenRead(pageHtml);
                TG.PosterHTML[0] = new Bitmap(odczytWykresu);
                TG.PosterHosting[0] = TG.PosterHTML[0];
            }
            newTheard(label33, "Editing Covers...");
            #endregion
            TG.PosterHTML[0] = new Bitmap(TG.PosterHTML[0], new Size(140, 200));
            TG.PosterHosting[0] = new Bitmap(TG.PosterHosting[0], new Size(232, 327));
            pictureBox1.Image = TG.PosterHTML[0];

            pictureBox1.BeginInvoke(
                    new Action(() =>
                    {
                        pictureBox1.Image = TG.PosterHTML[0];
                    }
                              ));
            newTheard(progressBar_Two, 10);

            #region Poster2
            newTheard(label33, "Searching for more posters...");
            pageData = client.DownloadData(textBox_FilmWeb.Text.Replace("#", "") + "/posters");
            pageHtml = Encoding.UTF8.GetString(pageData);
            

            // TG.first = pageHtml.IndexOf("<h2 class=inline>plakaty</h2>(") + 30;
            TG.first = pageHtml.IndexOf("plakaty<span> (") + 15;
            TG.last = pageHtml.IndexOf(")", TG.first);
            // TG.last = pageHtml.IndexOf(")", TG.first);
            string text = pageHtml.Substring(TG.first, TG.last - TG.first);
            Console.WriteLine(text);
            
            int.TryParse(text, out int number);

            newTheard(progressBar_Two, 1);
            if (number >= 1)
            {
                newTheard(label33, "Downloading more the posters...");
                //TG.first = pageHtml.IndexOf("</script><script type=\"text/javascript\">fw.loadOnClick(Sizzle") + 61;
                TG.first = pageHtml.IndexOf("<h2 class=\"inline\">plakaty</h2>") + 31;
                //TG.last = pageHtml.IndexOf("var a=\"poster\",d=Sizzle");
                TG.last = pageHtml.IndexOf("</div></div></li></ul><script type=\"text/javascript\"");

                pageHtml = pageHtml.Substring(TG.first, TG.last - TG.first);
                int lastFirst = 0, lastLast = 0;
                #region posters find & download
                int h = 0;
                while (pageHtml.IndexOf("http://1.fwcdn.pl/po") > -1)
                {
                    newTheard(label33, "editing poster #" + h.ToString() + " ...");
                    TG.first = pageHtml.IndexOf("http://1.fwcdn.pl/po", lastFirst);
                    TG.last = pageHtml.IndexOf(".jpg\"", lastLast);
                    string g = pageHtml.Substring(TG.first, TG.last - TG.first + 4);
                    pageHtml = pageHtml.Remove(TG.first, TG.last - TG.first + 5);

                    if (g[g.Length - 5] == '3') url.Add(g);

                    lastFirst = TG.first;
                    lastLast = TG.last;
                    h++;
                }

              
                

                #endregion
                newTheard(progressBar_Two, 20);

                for (int i = 0; i < url.Count; i++)
                {
                    newTheard(label33, "Cutting poster #" + i.ToString() + " ...");

                    Stream read = client.OpenRead(url[i]);
                    PostersHTML.Add(new Bitmap(read));
                    PostersHosting.Add(PostersHTML[i]);
                    PostersHTML[i] = new Bitmap(PostersHTML[i], new Size(140, 200));
                    PostersHosting[i] = new Bitmap(PostersHosting[i], new Size(232, 327));

                    comboBox2.Items.Add(String.Format("Poster {0}", i));
                }
            }
            #endregion
            newTheard(progressBar_Two, 15);
            newTheard(textBox2, TG.file_name + ".nfo");

            progressBar_Two.BeginInvoke(new Action(() => progressBar_Two.Value = 100));
            newTheard(label33, "All data downloaded...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_FilmWeb.Text != "")//WEJSCIE: http://www.filmweb.pl/film/Pompeje-2014-643796
            {
                //button2.Enabled = false;
                if (textBox_FilmWeb.Text.Contains("serial"))
                {
                    label_Authors.Visible = true;
                    textBox_Authors.Visible = true;
                    TG.Authors = 1;
                }
                Thread thr = new Thread(threadDownload);
                thr.Start();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar_Three.Value += 35;
            if (TG.IsC[0] == 1 && checkBox1.Enabled == true)
            {
                PosterUpload(TG.PosterHosting2[0], 0);
            }
            if(TG.IsC[1] == 1) PosterUpload(TG.PosterHosting2[1], 1);
            if (TG.IsC[0] == 0 && TG.IsC[1] == 0) PosterUpload(TG.PosterHosting[2], 0);
            if (TG.IsC[0] == 1 && checkBox1.Enabled == false) PosterUpload(TG.PosterHosting[2], 0);

            progressBar_Three.Value += 5;

            if(TG.FilmInfo[5] != String.Empty) EditStars();
            progressBar_Three.Value += 10;
            TG.Code = String.Format("[IMG]{0}[/IMG]", TG.PosterLink);
            if (TG.IsC[1] == 1) TG.Code += String.Format(" [IMG]{0}[/IMG]", TG.PosterLink2);
            if (TG.Authors == 1)
            {
                if(textBox_Authors.Text.Contains(",")) TG.Code += String.Format("\n[pre]\nGatunek............: {0}\nTwórcy.............: {1}\nObsada.............: {2}\n[/pre]\n\n", TG.FilmInfo[0].Replace("</li", ""), textBox_Authors.Text, TG.FilmInfo[5]);
                else TG.Code += String.Format("\n[pre]\nGatunek............: {0}\nTwórca.............: {1}\nObsada.............: {2}\n[/pre]\n\n", TG.FilmInfo[0], textBox_Authors.Text, TG.FilmInfo[5]);
            }
            else TG.Code += String.Format("\n[pre]\nGatunek............: {0}\nPremiera...........:{1}\nProdukcja..........: {2}\nReżyseria..........: {3}\nScenariusz.........: {4}\nObsada.............: {5}\n[/pre]\n\n", TG.FilmInfo[0], TG.FilmInfo[2], TG.FilmInfo[1].Replace(">", ""), TG.FilmInfo[3], TG.FilmInfo[4], richTextBox3.Text/*TG.FilmInfo[5]*/);
            TG.Code += String.Format("[b]OPIS:[/b]\n\n{0}\n\n[b]RELEASE iNF0RMATI0N:[/b][pre]\n\n", TG.FilmDescs);
            progressBar_Three.Value += 20;
            InfoNFO();
            if (textBox1.Text != String.Empty) TG.Code += String.Format("\r\n[b]SAMPLE:[/b]\r\n{0}\r\n\r\n", textBox1.Text);
            progressBar_Three.Value += 10;
            TG.Code = TG.Code.Replace("\r", "");
            TG.Code += String.Format("\n[b]UPLOADER's NOTe:[/b]\n{0}\n[url=http://btgigs.info/browse.php?search=inTGrity][b]Więcej filmów od inTGrity Klik [/b][/url]\n\n[center][url=http://btgigs.info/forums.php?action=viewtopic&topicid=5724][img=http://btgigs.info/rotator/shell_rotator.php][/url] [/center]", richTextBox5.Text);
            richTextBox4.Text = TG.Code;
            button4.Enabled = true;
            progressBar_Three.Value = 100;
        }

        private void EditStars()
        {
            int wax = 0;
            for (int i = 0; i < TG.FilmInfo[5].Length; i++)
            {
                if (TG.FilmInfo[5][i] == ',')
                {
                    wax++;
                    if (wax == 4)
                    {
                        wax = i;
                        break;
                    } 
                }  
            }

            char[] charsToTrim = {',', ' ' };
            string text = TG.FilmInfo[5].Substring(0, wax-1);
            text += "\n                     " + TG.FilmInfo[5].Substring(wax + 1);
            TG.FilmInfo[5] = text.Trim(charsToTrim);
            //TG.FilmInfo[5] += String.Format(" [url={0}/cast/actors][b]i inni...[/b][/url]", textBox_FilmWeb.Text);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox4.Text);
            button4.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPoster(comboBox1.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexSelected(comboBox2.SelectedIndex);
        }

        private void IndexSelected(int y)
        {
            if (PostersHTML.Count > 0)
            {
                TG.IndexP = y;
                TG.PosterHTML[0] = PostersHTML[TG.IndexP];
                TG.PosterHosting[0] = PostersHosting[TG.IndexP];
                pictureBox1.Image = TG.PosterHTML[0];
                AddPoster(TG.IndexPoster);
            }
        }

        private void AddPoster(int index)
        {
            TG.IndexPoster = index;
            string link = "okladki//" + TG.PosterIndex(TG.IndexPoster) + ".png";
            string log = "okladki//logo.png";

            ((Control)tabPage1).Enabled = true;
            ((Control)tabPage2).Enabled = true;
            ((Control)tabPage3).Enabled = true;
            ((Control)tabPage4).Enabled = true;
            TG.PosterIs = 1;

            TG.PosterHTML[1] = new Bitmap(link);
            TG.PosterHTML[1] = new Bitmap(TG.PosterHTML[1], new Size(171, 216));
            TG.PosterHTML[2] = new Bitmap(171, 216);

            Graphics g = Graphics.FromImage(TG.PosterHTML[2]);
            g.DrawImageUnscaled(TG.PosterHTML[0], 21, 8);
            g.DrawImageUnscaled(TG.PosterHTML[1], 0, 0);
            pictureBox1.Image = TG.PosterHTML[2];

            TG.PosterHosting[1] = new Bitmap(link);
            TG.PosterHosting[1] = new Bitmap(TG.PosterHosting[1], new Size(276, 350));
            TG.PosterHosting[2] = new Bitmap(276, 350);
            TG.PosterHosting[3] = new Bitmap(log);
            TG.PosterHosting[3] = new Bitmap(TG.PosterHosting[3], new Size(72, 43));
            Graphics gg = Graphics.FromImage(TG.PosterHosting[2]);
            gg.DrawImageUnscaled(TG.PosterHosting[0], 35, 10);
            gg.DrawImageUnscaled(TG.PosterHosting[1], 0, 0);
            gg.DrawImageUnscaled(TG.PosterHosting[3], 175, 275);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "NFO file|*.nfo";
            save.InitialDirectory = TG.file_path;
            save.FileName = TG.file_name;

            if (save.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = save.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InfoNFO();
            
            NFO_top();
            NFO_bottom();

            FileStream save = new FileStream(textBox2.Text, FileMode.Create);
            Encoding enc = Encoding.GetEncoding(437);

            
            StreamWriter save2 = new StreamWriter(save, enc);
            save2.Write(TG.NFO[0] + TG.Code.Replace("[/pre]", "").Replace("[b]", "").Replace("[/b]", "") + TG.NFO[1]);
            save2.Close();
            save.Close();
        }

        private void InfoNFO()
        {
            TG.Code += String.Format("{0}\r\n\nRel Date ....................: {1}\r\n\r\nSource (Thank You!):\r\n\r\nVideo........................: {2}\r\nAudio........................: {3}\r\n\r\nRELEASE SPECIFICATION\r\n", TG.file_name, dateTimePicker1.Value.ToString("dd/MM/yyyy")/*Tutaj usuwam godzine*/, comboBox_Video.Text, comboBox_Audio.Text/*textBox_Video.Text, textBox_Audio.Text*/);
            TG.Code += String.Format("\nVideo codec .................: {0}\r\nBitrate .....................: {1}\nResolution ..................: {2}\r\nFrame rate ..................: {3}", textBox_VideoCodec.Text, textBox_BitrateVideo.Text, textBox_Resolution.Text, textBox_FPS.Text);

            if (textBox_Audio2.Text == "") TG.Code += String.Format("\r\nAudio .......................: {0}\r\n", textBox_Audio1.Text);
            else TG.Code += String.Format("\r\nAudio .......................: {0}\r\nAudio2 ......................: {1}\r\n", textBox_Audio1.Text, textBox_Audio2.Text);

            TG.Code += String.Format("Language ....................: {0}\r\n", comboBox_Language.Text.TrimStart());
            if (comboBox_Language2.Text != "") TG.Code += String.Format("Language2 ...................: {0}\r\n", comboBox_Language2.Text.TrimStart());
            if (comboBox_Language3.Text != "") TG.Code += String.Format("Language3 ...................: {0}\r\n", comboBox_Language3.Text.TrimStart());

            TG.Code += String.Format("Subtitle ....................: {0}\r\n", comboBox_Subtitle.Text.TrimStart());
            TG.Code += String.Format("Time ........................: {0}\nSize ........................:{1}\n", textBox_Time.Text, TG.Size);

            if (radioButton_Custom.Checked == true) TG.Code += String.Format("Customed by .................: {0}\r\n", comboBox_nickauthor.Text);
            else if (radioButton_Encoded.Checked == true) TG.Code += String.Format("Encoded by ..................: {0}\r\n", comboBox_nickauthor.Text);

            TG.first = textBox_FilmWeb.Text.LastIndexOf('-');
            if(TG.first > -1) TG.Code += String.Format("\nIMDb ........................: {0}\r\nFilmweb .....................: http://filmweb.pl/Film?id={1} [/pre]\r\n", textBox_IMDb.Text, textBox_FilmWeb.Text.Substring(TG.first+1));
            else TG.Code += String.Format("\nIMDb ........................: {0}\r\nFilmweb .....................: {1} [/pre]\r\n", textBox_IMDb.Text, textBox_FilmWeb.Text);

        }

        private void NFO_top()
        {
            TG.NFO[0] = String.Format("\r\n__               __________   _________               __ __                        \r\n");
            TG.NFO[0] += String.Format("██              ▄███████████ ■█████████▄              ██ ██                        \r\n");
            TG.NFO[0] += String.Format("__ _____        █▀   ██   ██ ██        █ ___________  __ ██____       __         __\r\n");
            TG.NFO[0] += String.Format("██ █████▄_      █    ██   ██ ██__      █ ████████████ ██ ██████       ██         ██\r\n");
            TG.NFO[0] += String.Format("██ ██  ▀██▄_         ██      █████▄_     ██         █ ██ ██           ██         ██\r\n");
            TG.NFO[0] += String.Format("██ ██    ▀██▄_       ██      ██  ▀██▄_   ██         █ ██ ██           ██        _██\r\n");
            TG.NFO[0] += String.Format("██ ██      ▀██▄      ██      ██    ▀██▄_ ██           ██ ██           ██      _▄███\r\n");
            TG.NFO[0] += String.Format("██ ██        ██      ██      ██      ▀██ ██           ██ ██         _ ██    _▄██▀██\r\n");
            TG.NFO[0] += String.Format("██ ██        ██      ██      ██________█ ██           ██ ██_________█ ██___▄██▀  ██\r\n");
            TG.NFO[0] += String.Format("██ ██        ██      ██      ███████████ ██           ██ ■███████████ ██████▀    ██\r\n");
            TG.NFO[0] += String.Format("_________________________________________________________________________________██\r\n");
            TG.NFO[0] += String.Format("███████████████████████████████████████████████████████████████████████████████████\r\n\r\n\r\n");
        }

        private void NFO_bottom()
        {
            TG.NFO[1] += String.Format("\r\n");
            TG.NFO[1] += String.Format("                               There Can Be Only One                               \r\n\n");
            TG.NFO[1] += String.Format("                                   .:inTGrity:.                                  \r\n\n");
            TG.NFO[1] += String.Format("                                 INTERNAL GROUP OF                                 \r\n\n");
            TG.NFO[1] += String.Format("                                http://btgigs.info                                 \r\n");
        }

        private void LoadInfoMovie()
        {
            label19.Text = TG.file_name;
            textBox_Name.Text = TG.file_name;
            MediaInfo n = new MediaInfo();
            n.Open(@TG.file_path);


            TG.VideoCodec = n.Get(StreamKind.Video, 0, "Format");
            if (TG.VideoCodec == "MPEG-4 Visual") TG.VideoCodec = "MPEG-4";
            else TG.VideoCodec = "x264";
            textBox_VideoCodec.Text = TG.VideoCodec;

            TG.Bitrate = n.Get(StreamKind.Video, 0, "BitRate/String");
            textBox_BitrateVideo.Text = TG.Bitrate;

            TG.Resolution_Width = n.Get(StreamKind.Video, 0, "Width");
            TG.Resolution_Height = n.Get(StreamKind.Video, 0, "Height");
            TG.Resolution_Display = n.Get(StreamKind.Video, 0, "DisplayAspectRatio/String");
            textBox_Resolution.Text = TG.Resolution_Width;
            textBox_Resolution.Text += " x " + TG.Resolution_Height;
            textBox_Resolution.Text += " (" + TG.Resolution_Display + ")";


            TG.FPS = n.Get(StreamKind.Video, 0, "FrameRate/String");
            TG.first = TG.FPS.IndexOf(" ");
            TG.FPS = TG.FPS.Substring(0, TG.first + 1);
            textBox_FPS.Text = TG.FPS + "fps";

            TG.AudioChannels = Channels(n.Get(StreamKind.Audio, 0, "Channel(s)"));

            textBox_Audio1.Text = n.Get(StreamKind.Audio, 0, "Format") + " | ";
            textBox_Audio1.Text += n.Get(StreamKind.Audio, 0, "BitRate/String") + " | ";
            textBox_Audio1.Text += TG.AudioChannels;

            if (n.Get(StreamKind.Audio, 1, "Format").Length > 0)
            {
                textBox_Audio2.Text = n.Get(StreamKind.Audio, 1, "Format") + " | ";
                textBox_Audio2.Text += n.Get(StreamKind.Audio, 1, "BitRate/String") + " | ";
                textBox_Audio2.Text += TG.AudioChannels;
            }

            string y = n.Get(StreamKind.Video, 0, "Duration/String4");
            TG.Time = y.Substring(0, 2).Replace("0", "") + "h ";
            if (y.Substring(3, 2)[0] == '0') TG.Time += y.Substring(4, 1) + "min ";//+ "min " + y.Substring(6, 2) + "sec";
            else TG.Time += y.Substring(3, 2) + "min ";

            if (y.Substring(6, 2)[0] == '0') TG.Time += y.Substring(7, 1) + "sec";
            else TG.Time += y.Substring(6, 2) + "sec";


            if (TG.Time[0] == 'h') TG.Time = TG.Time.Replace("h ", "");

            textBox_Time.Text = TG.Time;
            TG.Size = " " + n.Get(StreamKind.General, 0, "FileSize/String").Replace("MiB", "MB").Replace("GiB", "GB");

            button4.Enabled = true;
            textBox2.Text = TG.file_path;
            n.Close();
            /*MediaFile aviFile = new MediaFile(@TG.file_path);
            aviFile.MediaInfo_Available = true;

           label37.Text =  aviFile.Audio.Count.ToString();

            #region Video Codec
            TG.VideoCodec = aviFile.Video[0].Format;
            if (TG.VideoCodec.Length > 7)
            {
                TG.VideoCodec = TG.VideoCodec.Remove(TG.VideoCodec.Length - 7, 7);//MPEG-4
                TG.VideoCodec = aviFile.Video[0].CodecID + " " + TG.VideoCodec;
            }
            if (aviFile.Video[0].Format == "AVC") TG.VideoCodec = "x264";
            #endregion
            textBox_VideoCodec.Text = TG.VideoCodec;

            #region Bit rate
            TG.first = aviFile.Info_Text.IndexOf("Bit rate :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.Bitrate = aviFile.Info_Text.Substring(TG.first + 11, TG.last - TG.first - 11);
            #endregion
            textBox_BitrateVideo.Text = TG.Bitrate;

            #region Resolution
            TG.first = aviFile.Info_Text.IndexOf("Width :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.Resolution_Width = aviFile.Info_Text.Substring(TG.first + 8, TG.last - TG.first - 15);
            TG.Resolution_Width = TG.Resolution_Width.Replace(" ", "");

            TG.first = aviFile.Info_Text.IndexOf("Height :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.Resolution_Height = aviFile.Info_Text.Substring(TG.first + 8, TG.last - TG.first - 15);

            TG.first = aviFile.Info_Text.IndexOf("Display aspect ratio :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.Resolution_Display = aviFile.Info_Text.Substring(TG.first + 23, TG.last - TG.first - 24);
            #endregion
            textBox_Resolution.Text = TG.Resolution_Width;
            textBox_Resolution.Text += " x" + TG.Resolution_Height;
            textBox_Resolution.Text += "(" + TG.Resolution_Display + ")";

            #region FPS
            TG.first = aviFile.Info_Text.IndexOf("Frame rate :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.FPS = aviFile.Info_Text.Substring(TG.first + 13, TG.last - TG.first - 12);
            #endregion
            textBox_FPS.Text = TG.FPS;

            #region Audio Channels

            TG.AudioChannels = TG.Audio(aviFile.Audio[0].Channels);

            TG.first = aviFile.Info_Text.IndexOf("Audio #1");
            if (TG.first > 0)
            {
                textBox_Audio2.Text = aviFile.Audio[1].Format + " | ";
                textBox_Audio2.Text += aviFile.Audio[1].Bitrate.ToString() + " Kbps | ";
                textBox_Audio2.Text += TG.AudioChannels2 = TG.Audio(aviFile.Audio[1].Channels);
            }
            #endregion
            textBox_Audio1.Text = aviFile.Audio[0].Format + " | ";
            textBox_Audio1.Text += aviFile.Audio[0].Bitrate.ToString() + " Kbps | ";
            textBox_Audio1.Text += TG.AudioChannels;


            #region Time
            TG.first = aviFile.Info_Text.IndexOf("Duration :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.Time = aviFile.Info_Text.Substring(TG.first + 11, TG.last - TG.first - 11);
            label38.Text = dd;
            #endregion
            textBox_Time.Text = TG.Time;

            #region Size
            TG.first = aviFile.Info_Text.IndexOf("File size :");
            TG.last = aviFile.Info_Text.IndexOf("\n", TG.first);
            TG.Size = aviFile.Info_Text.Substring(TG.first + 11, TG.last - TG.first - 11);
            #endregion
            TG.Size = TG.Size.Replace("MiB", "MB").Replace("GiB", "GB");*/

            button2.Enabled = true;
        }

        private string Channels(string ch)
        {
            if (ch == "8") return "7.1";
            else if (ch == "6") return "5.1";
            else if (ch == "3") return "2.1";
            else if (ch == "2") return "2.0";
            return String.Empty;
        }

        private void PosterUpload(Bitmap bitmap, int wax)
        {
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            
            byte[] bitmapBytes = memoryStream.GetBuffer();
            string bitmapString = Convert.ToBase64String(bitmapBytes, Base64FormattingOptions.InsertLineBreaks);

            using (var w = new WebClient())
            {
                /*var values = new NameValueCollection
                {
                    { "key", "433a1bf4743dd8d7845629b95b5ca1b4" },
                    //{ "image", Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:/dupa.png")) }
                    { "image", bitmapString }
                };

                byte[] response = w.UploadValues("http://imgur.com/api/upload.xml", values);*/

                string clientID = "c7aae31bbc3db20";
                w.Headers.Add("Authorization", "Client-ID " + clientID);

                var values = new NameValueCollection
                {
                    { "image", bitmapString }
                };

                byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);

                if (wax == 0)
                {
                    TG.PosterLink = XDocument.Load(new MemoryStream(response)).ToString();

                   //TG.first = TG.PosterLink.IndexOf("<original_image>");
                    TG.first = TG.PosterLink.IndexOf("<link>");
                    TG.PosterLink = TG.PosterLink.Remove(0, TG.first + 6);
                    //TG.first = TG.PosterLink.IndexOf("</original_image>");
                    TG.first = TG.PosterLink.IndexOf("</link>");
                    TG.PosterLink = TG.PosterLink.Remove(TG.first, TG.PosterLink.Length - TG.first);//.Replace("<original_image>", "");
                }
                else if(wax == 1)
                {
                    TG.PosterLink2 = XDocument.Load(new MemoryStream(response)).ToString();

                    //TG.first = TG.PosterLink2.IndexOf("<original_image>");
                    TG.first = TG.PosterLink2.IndexOf("<link>");
                    TG.PosterLink2 = TG.PosterLink2.Remove(0, TG.first + 6);
                    //TG.first = TG.PosterLink2.IndexOf("</original_image>");
                    TG.first = TG.PosterLink2.IndexOf("</link>");
                    TG.PosterLink2 = TG.PosterLink2.Remove(TG.first, TG.PosterLink2.Length - TG.first);//.Replace("<original_image>", "");
                }
            }
        }

        private void Main_Enter(object sender, EventArgs e)
        {
            //((Control)tabPage5).
        }

        private void Main_Selected(object sender, System.Windows.Forms.TabControlEventArgs e)
        {
            if((e.TabPage.Text == "Other") && TG.PosterIs == 0)
            {
                ((Control)tabPage1).Enabled = false;
                ((Control)tabPage2).Enabled = false;
                ((Control)tabPage3).Enabled = false;
                ((Control)tabPage4).Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    TG.file_path = fileLoc;
                    TG.file_name = fileLoc.Substring(fileLoc.LastIndexOf('\\') + 1);
                    TG.file_name = TG.file_name.Substring(0, TG.file_name.Length - 4);
                    LoadInfoMovie();
                }
            }
        }

        private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveOrDelete(0, comboBox_Video);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SaveOrDelete(1, comboBox_Audio);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SaveOrDelete(2, comboBox_Language);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SaveOrDelete(3, comboBox_Language2);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SaveOrDelete(4, comboBox_Subtitle);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SaveOrDelete(5, comboBox_nickauthor);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SaveOrDelete(6, comboBox_Language3);
        }

        private void SaveOrDelete(int id, ComboBox wax)
        {
            if (wax.Text != String.Empty)
            {
                if (TG.setting[id].IndexOf(wax.Text) >= 0)
                {
                    TG.setting[id] = TG.setting[id].Replace(wax.Text, "");
                    wax.Items.Remove(wax.Text);
                    wax.Text = String.Empty;
                }
                else
                {
                    TG.setting[id] += wax.Text + "\r\n";
                    wax.Items.Add(wax.Text);
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (TG.IndexP > 0)
            {
                TG.IndexP -= 1;
                IndexSelected(TG.IndexP);
                comboBox2.SelectedIndex = comboBox2.FindStringExact(String.Format("Poster {0}", TG.IndexP));
            }
            else
            {
                /*TG.IndexP = 0;
                IndexSelected(TG.IndexP);
                comboBox2.SelectedIndex = comboBox2.FindStringExact("Poster 0");*/
                TG.IndexP = PostersHTML.Count - 1;
                IndexSelected(TG.IndexP);
                comboBox2.SelectedIndex = comboBox2.FindStringExact(String.Format("Poster {0}", TG.IndexP));
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (TG.IndexP < PostersHTML.Count -1)
            {
                TG.IndexP += 1;
                IndexSelected(TG.IndexP);

                comboBox2.SelectedIndex = comboBox2.FindStringExact(String.Format("Poster {0}", TG.IndexP));
            }
            else
            {
                TG.IndexP = 0;
                IndexSelected(TG.IndexP);
                comboBox2.SelectedIndex = comboBox2.FindStringExact(String.Format("Poster {0}", TG.IndexP));
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                TG.PosterHosting2[0] = TG.PosterHosting[2];
                TG.IsC[0] = 1;
            }
            else TG.IsC[0] = 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                TG.PosterHosting2[1] = TG.PosterHosting[2];
                TG.IsC[1] = 1;
            }
            else TG.IsC[1] = 0;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpenFileDialog okienkoo = new OpenFileDialog();
            okienkoo.Filter = "Pliki JPG |*.jpg|Pliki PNG |*.png";

            if (okienkoo.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(okienkoo.FileName);
                TG.PosterHTML[0] = new Bitmap(bit, new Size(140, 200));
                TG.PosterHosting[0] = new Bitmap(bit, new Size(232, 327));
                pictureBox1.Image = TG.PosterHTML[0];
                AddPoster(TG.IndexPoster);


                pictureBox10.Visible = false;
                pictureBox11.Visible = false;

                checkBox1.Checked = true;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox2.Visible = false;
                comboBox2.Enabled = false;
            }
        }

        /*private void pictureBox12_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            Byte[] up = client.DownloadData("http://wax.opx.pl");
            string p = Encoding.UTF8.GetString(up);

            TG.first = p.IndexOf("<div v = ") + 10;
            TG.last = p.IndexOf("\">", TG.first);
            string ver = p.Substring(TG.first, TG.last - TG.first);

            TG.first = p.IndexOf("<div url = ") + 12;
            TG.last = p.IndexOf("\">", TG.first);
            string link = p.Substring(TG.first, TG.last - TG.first);



            //richTextBox6.Text = "JP" + "wersja " + ver + "link " + link;

            WebClient webClient = new WebClient();

            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

            try
            {
                webClient.DownloadFileAsync(new Uri("http://wax.opx.pl/inTGrity%20Generator.rar"), @"C:\Users\damia_000\Desktop\waxxxxxxxx.rar");
            }
            catch (WebException )
            {
                //stało się coś bardzo niedobrego ;)
            }

            /*using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(new Uri("http://wax.opx.pl/inTGrity%20Generator.rar"), @"D:\JPpppp.rar");
                                         
            }*/

           /*

            
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //zobaczmy ile procent pobrano: 

            //label34.Text = e.ProgressPercentage.ToString();
        }

        void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //zakończono pobieranie pliku
        }*/

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            HideUpdateForm();
            
        }

        private void HideUpdateForm()
        {
            button7.Location = new Point(500, 500);
            label34.Location = new Point(500, 500);
            progressBar1.Location = new Point(500, 500);
            pictureBox14.Location = new Point(500, 500);
            pictureBox13.Location = new Point(500, 500);
            label38.Text = "";
        }
        private void ShowUpdateForm()
        {
            button7.Location = new Point(41, 103);
            label34.Location = new Point(38, 70);
            progressBar1.Location = new Point(41, 132);
            pictureBox13.Location = new Point(11, 35);
            pictureBox14.Location = new Point(586, 54);      
        }

        private void CheckUpdate()
        {
            WebClient client = new WebClient();

            Byte[] up = client.DownloadData("http://wax.opx.pl");
            string p = Encoding.UTF8.GetString(up);

            TG.first = p.IndexOf("<div v = ") + 10;
            TG.last = p.IndexOf("\">", TG.first);
            string ver = p.Substring(TG.first, TG.last - TG.first);

            TG.first = p.IndexOf("<div url = ") + 12;
            TG.last = p.IndexOf("\">", TG.first);
           TG.updateLink = p.Substring(TG.first, TG.last - TG.first);

            float nVersion = float.Parse(ver.Substring(0, 3), CultureInfo.InvariantCulture);
            float cVersion = float.Parse(TG.version.Substring(0, 3), CultureInfo.InvariantCulture);
            char nS = ver[3];
            char cS = TG.version[3];
            button7.Enabled = false;

            if ((cVersion > nVersion) || (cVersion == nVersion && nS > cS))
            {
                button7.Enabled = true;
                label35.Text = "The update is available(to version: " + nVersion + nS + ")";
            }
            else label35.Text = "This program is current.";
            label34.Text = label35.Text;
           
        }

        private void DownloadUpdate()
        {
            WebClient webClient = new WebClient();

            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

            string path_ = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//BTG Generator_by Wax";

            try
            {
                //webClient.DownloadFileAsync(new Uri(TG.updateLink), @"C:\Users\damia_000\Desktop\x99997x.rar");
                webClient.DownloadFileAsync(new Uri(TG.updateLink), path_ + "//TemporaryFile.zip");

            }
            catch (WebException)
            {
                //LIPA
            }
            //tu utworze plik i zamkne program otwierajac konsole
            
            if (Directory.Exists(path_))
            {
                string s = path_ + "//s.wax";
                FileStream sv = new FileStream(s, FileMode.Create);
                StreamWriter file_ = new StreamWriter(sv);
                file_.Write(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
                file_.Close();
                sv.Close();
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > TG.updateValue)
            {
                //Console.Clear();
                //Console.WriteLine(e.ProgressPercentage.ToString() + "%");
                progressBar1.Increment(e.ProgressPercentage);
            }
            TG.updateValue = e.ProgressPercentage;
        }

        private void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
           // Console.Clear();
            //Console.WriteLine("Download complete.\n\n");
           // Console.WriteLine("Please press enter!");
           
            //label36.Text = "koniec";
            label38.Text = "Aktualizacja pobrana, lecz nie może zostać zainstalowana!";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //DownloadUpdate();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            ShowUpdateForm();    
        }
        private void tttt()
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
           // ShowUpdateForm();
            tttt();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            label36.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);//Application.StartupPath

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//BTG Generator_by Wax"))
            {
                string s = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//BTG Generator_by Wax//s.wax";
                FileStream sv = new FileStream(s, FileMode.Create);
                StreamWriter file_ = new StreamWriter(sv);
                file_.Write(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
                file_.Close();
                sv.Close();
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Genres_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
