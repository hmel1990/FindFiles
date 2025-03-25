using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace FindFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxPath.TextChanged += TextBoxPathChanged; // Подписываемся на событие изменения текста
            textBoxFile.TextChanged += TextBoxFileChanged;
        }

        private void Form1_Load(object sender, EventArgs e) {}
        private void TextBoxPathChanged (object sender, EventArgs e)
        {
            Thread tPath = new Thread(FindDirectory);
            tPath.IsBackground = false;
            tPath.Start();

            Thread fPathf = new Thread(FindFile);
            fPathf.IsBackground = false;
            fPathf.Start();
        }
        private void FindDirectory()
        {
            string path = textBoxPath.Text.Trim();
            listBoxResultsDirectories.Items.Clear(); // Очищаем список перед новым поиском
            if (Directory.Exists(path))
            {
                try
                {
                    var directories = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
                    // Добавляем в список
                    listBoxResultsDirectories.Items.AddRange(directories.ToArray());
                    if (directories.Length < 1)
                        listBoxResultsDirectories.Items.Add("Папка не содержит другие папки");
                }
                catch (Exception ex)
                {
                    listBoxResultsDirectories.Items.Add("Ошибка: " + ex.Message);
                }
            }
            else
            {
                listBoxResultsDirectories.Items.Add("Путь не найден");
            }

        }
        private void TextBoxFileChanged (object sender, EventArgs e)
        {
            Thread fPath = new Thread(FindFileWithParams);
            fPath.IsBackground = false;
            fPath.Start();


        }
        private void FindFileWithParams ()
        {
            string path = textBoxPath.Text.Trim();
            string fileName = textBoxFile.Text.Trim();
            listBoxResultsFiles.Items.Clear(); // Очищаем список перед новым поиском
            if (Directory.Exists(path))
            {               
                try
                {
                    
                    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(f=> Path.GetFileName(f).Contains(fileName)).ToArray();
                    // Добавляем в список
                    if(fileName.Length>0)
                    listBoxResultsFiles.Items.AddRange(files);
                    if (files.Length < 1)
                    listBoxResultsFiles.Items.Add("Файл не найден");


                }
                catch (Exception ex)
                {
                    listBoxResultsFiles.Items.Add("Ошибка: " + ex.Message);
                }
            }
            else
            {
                listBoxResultsFiles.Items.Add("Путь к файлу не найден");
            }

        }
        //++++++++++++++++++++++++++++++++++++++++++++++
        private void FindFile ()
        {
            string path = textBoxPath.Text.Trim();
            listBoxResultsFilesInDirectory.Items.Clear(); // Очищаем список перед новым поиском
            if (Directory.Exists(path))
            {
                try
                {
                    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                    // Добавляем в список
                    listBoxResultsFilesInDirectory.Items.AddRange(files.ToArray());
                    if (files.Length < 1)
                        listBoxResultsFiles.Items.Add("В папке нет файлов");


                }
                catch (Exception ex)
                {
                    listBoxResultsFilesInDirectory.Items.Add("Ошибка: " + ex.Message);
                }
            }
            else
            {
                listBoxResultsFilesInDirectory.Items.Add("Путь к файлу не найден");
            }
        }


    }
}

