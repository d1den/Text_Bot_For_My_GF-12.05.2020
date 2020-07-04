using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace textBot_v0._002
{
    public partial class FormArchive : Form
    {
        Color backForm; // Цвета формы
        Color backText;
        Color backButton;
        Color fore;
        public FormArchive(Color colorForm, Color colorText, Color colorButton, Color colorFore)
        {
            InitializeComponent();
            backForm = colorForm; // Получаем цвета из главной формы
            backText = colorText;
            backButton = colorButton;
            fore = colorFore;
            this.BackColor = backForm;
            richTextBox1.BackColor = backText;
            button1.BackColor = button2.BackColor = button3.BackColor = button4.BackColor =
                button5.BackColor = button6.BackColor = button7.BackColor = button8.BackColor = button9.BackColor = backButton;
            this.ForeColor = richTextBox1.ForeColor = groupBox1.ForeColor = groupBox2.ForeColor = richTextBox1.ForeColor=
                button1.ForeColor = button2.ForeColor = button3.ForeColor = button4.ForeColor =
                button5.ForeColor = button6.ForeColor = button7.ForeColor = button8.ForeColor = button9.ForeColor = fore;
        }

        // Открыть видео
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("data\\archive\\video"); // Запускаем процесс открытия папки видео
        }

        // Добавить видео
        private async void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Видео(*.MP4;*.AVI;*.MOV)|*.MP4;*.AVI;*.MOV|Все файлы(*.*)|*.*"; // Фильтр на популярные форматы
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите видео, которое хотите добавить в архив";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            string newFileName = "data\\archive\\video\\" + Path.GetFileName(fileName); // Получаем нвое имя файла
            await Task.Run(()=>File.Copy(fileName, newFileName, true)); // Асинхронно копируем файл
        }

        // Открыть фото
        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("data\\archive\\photo");
        }
        // Добавить фото
        private async void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Фото(*.JPEG;*.PNG;*.JPG;*.GIF)|*.JPEG;*.PNG;*.JPG;*.GIF|Все файлы(*.*)|*.*"; // Фильтр на популярные форматы
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите фото, которое хотите добавить в архив";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            string newFileName = "data\\archive\\photo\\" + Path.GetFileName(fileName); // Получаем нвое имя файла
            await Task.Run(() => File.Copy(fileName, newFileName, true)); // Асинхронно копируем файл
        }

        // Добавить музыку
        private async void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Музыка(*.MP3;*.WAV;*.AIFF)|*.MP3;*.WAV;*.AIFF|Все файлы(*.*)|*.*"; // Фильтр на популярные форматы
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите музыку, которую хотите добавить в архив";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            string newFileName = "data\\archive\\music\\" + Path.GetFileName(fileName); // Получаем нвое имя файла
            await Task.Run(() => File.Copy(fileName, newFileName, true)); // Асинхронно копируем файл
        }
        // Открыть музыку
        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("data\\archive\\music");
        }

        // Открыть заметку
        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = Path.Combine(Application.StartupPath, "data\\archive\\notes");
            openFileDialog2.Filter = "Текстовый файл(*txt)|*.txt|Все файлы(*.*)|*.*"; // Фильтр на популярные форматы
            openFileDialog2.FileName = "";
            openFileDialog2.Title = "Выберите заметку, которую хотите открыть";
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog2.FileName;
            using (StreamReader sr = new StreamReader(fileName))
            {
                richTextBox1.Text = sr.ReadToEnd();
            }
        }

        // Сохранить заметку
        private void button8_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, "data\\archive\\notes");
            saveFileDialog1.Filter = "Текстовый файл(*txt)|*.txt|Все файлы(*.*)|*.*"; // Фильтр на популярные форматы
            saveFileDialog1.FileName = "";
            saveFileDialog1.Title = "Сохраните заметку";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = saveFileDialog1.FileName;
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(richTextBox1.Text);
            }
        }

        // Помощь в архиве
        private void button9_Click(object sender, EventArgs e)
        {
            FormHelp f = new FormHelp(2, backForm, backText, backButton, fore);
            f.Show();
        }
    }
}
