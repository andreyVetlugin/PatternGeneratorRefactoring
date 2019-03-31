using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PatternGenerator
{
    static public class PageGenerator
    {
        private static string patternPath = "../../Materials/index_pattern";
        enum PlaceType { description, link, image, header };
        public static void CreatePage(int pagePaternIndex, string pathToPage = "index.html")
        {
            CreateFileForPage(pagePaternIndex, pathToPage);
            FillPageFile(pathToPage);
        }

        public static void CreateFileForPage(int pagePatternIndex, string pathToPage = "index.html")
        {
            pagePatternIndex++;
            string path = patternPath + pagePatternIndex + ".html";
            FileInfo file_pattern = new FileInfo(path);
            if (File.Exists(pathToPage))
                File.Delete(pathToPage);            
            file_pattern.CopyTo(pathToPage);
        }

        private static void PutTextToPage(string pathToPage)
        {
            var pageText = File.ReadAllText(pathToPage);
            foreach (var textType in new PlaceType[] { PlaceType.description, PlaceType.link, PlaceType.header })
            {
                pageText = pageText.Replace(textType.ToString() + "_variable", GetTextForPage(textType));                
                File.WriteAllText(pathToPage, pageText);
            }
        }

        private static void PutImageToPage(string pathToPage)
        {
            var pageText = File.ReadAllText(pathToPage);
            pageText = pageText.Replace("image_variable", GetPathToImageForPage());
            File.WriteAllText(pathToPage, pageText);
        }

        public static void FillPageFile(string pathToPage = "index.html")
        {
            PutTextToPage(pathToPage);
            PutImageToPage(pathToPage);
        }

        private static string GetTextForPage(PlaceType placeType)
        {
            string path = "../../Materials/" + placeType.ToString() + ".txt";
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader reader = new StreamReader(stream, enc);
            string data = reader.ReadToEnd();
            string[] dataArray;
            dataArray = data.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            reader.Close();
            Random random = new Random();           
            return dataArray[random.Next(0, dataArray.Length)];
        }

        private static string GetPathToImageForPage()
        {
            string path = "../../Materials/Photos/";
            Random random = new Random();
            return path + random.Next(0, Directory.GetFiles(path).Length) + ".png";
        }
    }
    public partial class MainForm : Form
    {
        static string filePath = "index.html";
        public MainForm()
        {
            InitializeComponent();
        }

        private void Generate_Page_Button_Click(object sender, EventArgs e)
        {
            PageGenerator.CreatePage(SetPattern.SelectedIndex, filePath);
            Process.Start(filePath);
        }
    }
}