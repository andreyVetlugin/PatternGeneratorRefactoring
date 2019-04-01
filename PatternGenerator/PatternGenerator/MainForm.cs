using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PatternGenerator
{
    public static class PageGenerator
    {
        private static string materialsPath = "../../Materials/";
        enum PlaceType { description, link, image, header };

        public static void CreatePage(int pagePaternIndex, string pathToPage = "index.html")
        {
            CreateFileForPage(pagePaternIndex, pathToPage);
            CopyDesignFiles(pagePaternIndex);
            FillPageFile(pathToPage);
        }

        private static void CopyDesignFiles(int pagePatternIndex, string pathToPage = "main.css")
        {
            pagePatternIndex++;
            string path = materialsPath + "main" + pagePatternIndex + ".css";
            CopyFile(path, pathToPage);
            string background = "bg.gif";
            CopyFile(materialsPath + background, background);
        }

        private static void CreateFileForPage(int pagePatternIndex, string pathToPage)
        {
            pagePatternIndex++;
            string path = materialsPath + "index_pattern" + pagePatternIndex + ".html";
            CopyFile(path, pathToPage);
        }

        private static void CopyFile(string pathFrom, string pathTo)
        {
            FileInfo file_pattern = new FileInfo(pathFrom);
            if (File.Exists(pathTo))
                File.Delete(pathTo);
            file_pattern.CopyTo(pathTo);
        }

        private static void PutTextToPage(string pathToPage)
        {
            var pageText = File.ReadAllText(pathToPage);
            foreach (var textType in new PlaceType[] { PlaceType.description, PlaceType.link, PlaceType.header })
                pageText = pageText.Replace(textType.ToString() + "_variable", GetTextForPage(textType));
            File.WriteAllText(pathToPage, pageText);
        }

        private static void PutImageToPage(string pathToPage)
        {
            var pageText = File.ReadAllText(pathToPage);
            pageText = pageText.Replace("image_variable", GetPathToImageForPage());
            File.WriteAllText(pathToPage, pageText);
        }

        private static void FillPageFile(string pathToPage = "index.html")
        {
            PutTextToPage(pathToPage);
            PutImageToPage(pathToPage);
        }

        private static string GetTextForPage(PlaceType placeType)
        {
            string path = materialsPath + placeType.ToString() + ".txt";
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader reader = new StreamReader(file, enc);
            string data = reader.ReadToEnd();
            string[] dataArray;
            dataArray = data.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            reader.Close();
            file.Close();
            Random random = new Random();
            return dataArray[random.Next(0, dataArray.Length)];
        }

        private static string GetPathToImageForPage()
        {
            string path = materialsPath + "Photos/";
            Random random = new Random();
            string[] photos = Directory.GetFiles(path);
            return photos[random.Next(0, photos.Length)];
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