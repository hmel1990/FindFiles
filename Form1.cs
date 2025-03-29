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
//using static System.Net.WebRequestMethods;

namespace FindFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxPath.TextChanged += TextBoxPathChanged; // Подписываемся на событие изменения текста
            textBoxFile.TextChanged += TextBoxFileChanged;
            //buttonSearch_Click += FindFileWithWord;
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
                    
                    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(f=>Path.GetFileName(f).Contains(fileName)).ToArray();
                    // Добавляем в список
                    if (fileName.Length > 0)
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


        //========================================================================================


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Thread tSearchText = new Thread(FindFileWithWord);
            tSearchText.IsBackground = false;
            tSearchText.Start();
        }
        private void SearchLinesInFile2(string file, string searchText) //  метод для себя, мне нужен поиск только по содержимому без подсчета количества слов, + тут задействуется меньше памяти
        {
            foreach (var line in File.ReadLines(file)) // Читаем файл построчно
            {
                if (line.Contains(searchText))
                {
                    listBoxResultsFiles.Items.Add(file);
                    break; // Достаточно одной строки, выходим из цикла
                }
            }
        }

        private void SearchLinesInFile (string file, string searchText)
        {
            try
            {
                string content = File.ReadAllText(file); // Читаем содержимое
                if (content.Contains(searchText)) 
                {
                    int count = new System.Text.RegularExpressions.Regex(searchText).Matches(content).Count;
                    listBoxResultsFiles.Items.Add(file+$"\tискомое слово встречается {count} раз");
                }
            }
            catch (Exception ex)
            {
                listBoxResultsFiles.Items.Add($"Ошибка при чтении {file}: {ex.Message}");
            }
        }
        private void FindFileWithWord()
        {
            string path = textBoxPath.Text.Trim();
            string searchText = textBoxWord.Text.Trim();

            listBoxResultsFiles.Items.Clear(); // Очищаем список перед новым поиском
             
            if (Directory.Exists(path))
            {
                try
                {
                    ThreadPool.SetMaxThreads(500, 500); 
                    ThreadPool.SetMinThreads(20, 20); 

                    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                    foreach (var file in files)
                    {

                        ThreadPool.QueueUserWorkItem(state => SearchLinesInFile(file, searchText));


                        //Thread tSearchLine = new Thread(() => SearchLinesInFile2(file, searchText)); //() => создаёт анонимную функцию без параметров, которая вызывает SearchLinesInFile(file, searchText)
                        //tSearchLine.IsBackground = false;
                        //tSearchLine.Start();
                    }

                }
                catch (Exception ex)
                {
                    listBoxResultsFiles.Items.Add("Ошибка: " + ex.Message);
                }
            }
            else
            {
                listBoxResultsFiles.Items.Add("Путь не найден");
            }

        }

    }
}

