using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textBot_v0._002
{
    public partial class Form1 : Form
    {
        Color backForm; // Цвет фона формы
        Color backText; // Цвет фона текста
        Color backButton; // Цвет фона кнопки
        Color fore; // Цвет шрифта
        public Form1()
        {
            // Подгружаем из файла тему оформления и в зависимости от неё выбираем цвета
            using (System.IO.StreamReader sr = new System.IO.StreamReader("data\\theme.txt"))
            {
                var s = sr.ReadLine().Split(':');
                if (s[1] == "black") // Тёмная тема
                {
                    backForm = Color.FromArgb(21, 30, 39);
                    backText = Color.FromArgb(34, 46, 58);
                    backButton = Color.FromArgb(62, 97, 137);
                    fore = Color.FromName("white");
                }
                else if (s[1]== "white") // Светлая
                {
                    backForm = Color.FromArgb(208, 217, 224);
                    backText = Color.FromName("white");
                    backButton = Color.FromArgb(239, 254, 221);
                    fore = Color.FromName("black");
                }
            }
            string password; // Создаём переменную пароль
            using (System.IO.StreamReader sr = new System.IO.StreamReader("data\\settings.txt"))
            {
                var s = sr.ReadLine().Split(':');
                password = s[1]; // Считываем пароль из файла настроек
            }
            // Если установлен пароль
            if (password != "off")
            {
                FormPassword passwordF = new FormPassword(password, backForm, backText, backButton, fore); // Создаём объект новой формы (передаём пароль)
                passwordF.ShowDialog(); // Вызываем форму в модальном режиме (основная программа ждёт закрытия)
                // Если правильный пароль не получен
                if (passwordF.truePassword == false)
                {
                    Environment.Exit(0); // То выходим из программы
                }
            }
            InitializeComponent();
            ThisFormTheme(); // Вызываем метод настройки темы оформления
            // Далее в зависимости от выбранной темы включаем нужный радиобаттон
            if (fore==Color.FromName("white"))
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            DateTime date = DateTime.Now; // Получаем реальное время и дату (с пк)
            richTextBox1.Text += TextBot.FirstPhrase(); // Вводные фразы, а также подгрузка всех фраз из файлов
            richTextBox1.AppendText(TextBot.PhraseForSpecialDay(date)+"\n"); // Выводим поздравления, если это особенный день
            richTextBox2.Focus(); // Устанавливаем фокус на поле ввода текста
        }

        // Нажатие на клавишу отправить
        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage(); // Вызываем метод отправки сообщения
        }

        /// <summary>
        /// Метод отправки сообщения
        /// </summary>
        private void SendMessage()
        {
            richTextBox1.AppendText("Вы: " + richTextBox2.Text + "\n\n"); // Выводим наше сообщение в чат
            richTextBox1.AppendText(TextBot.PhraseAnalysis(richTextBox2.Text)+"\n"); // Выводим в чат ответ от бота
            richTextBox2.Clear(); // Очищаем поле ввода
            richTextBox2.Focus(); // Устанавливаем на него фокус
        }

        // Метод, вызывающийся при изменении текста
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret(); // Реализация автопрокрутки
        }

        // Изменить пароль 
        private void button2_Click(object sender, EventArgs e)
        {
            FormCreatePass f = new FormCreatePass(backForm,backText,backButton,fore); // Создаём форму
            f.Show(); // Открываем её в немодальном режиме
        }

        // Нажатие на клваишу в поле ввода (для отправки сообщений нажатием на Enter)
        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage(); // Отправляем сообщение
                e.Handled = true; // После вывода текста запрещаем использование Enter
            }
        }

        // Нажатие на кнопку открыть архив
        private void button3_Click(object sender, EventArgs e)
        {
            FormArchive f = new FormArchive(backForm, backText, backButton, fore); 
            f.Show(); // Открываем в немодальном режиме окно архива
        }

        // Помощь (подсказка) в главной форме
        private void button4_Click(object sender, EventArgs e)
        {
            FormHelp f = new FormHelp(1, backForm, backText, backButton, fore);
            f.Show(); // Открываем в немодальном режиме окно помощи
        }

        // Выбор тёмной темы
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            backForm = Color.FromArgb(21, 30, 39); // Устанавливаем необходимые цвета
            backText = Color.FromArgb(34, 46, 58);
            backButton = Color.FromArgb(62, 97, 137);
            fore = Color.FromName("white");

            ThisFormTheme(); // Применяем эти цвета к оформлению этого окна

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("data\\theme.txt"))
            {
                sw.WriteLine("theme:black"); // Сохраняем значение темы
            }
        }

        // Выбор светлой темы
        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            backForm = Color.FromArgb(208, 217, 224); // Всё аналогично ситуации выше
            backText = Color.FromName("white");
            backButton = Color.FromArgb(239, 254, 221);
            fore = Color.FromName("black");

            ThisFormTheme();

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("data\\theme.txt"))
            {
                sw.WriteLine("theme:white"); // Сохраняем значение темы
            }
        }

        /// <summary>
        /// Метод настройки темы оформления данного окна
        /// </summary>
        private void ThisFormTheme()
        {
            this.BackColor = backForm; // Настриваем фон формы
            richTextBox1.BackColor = richTextBox2.BackColor = backText; // Фон текста
            button1.BackColor = button2.BackColor = button3.BackColor = button4.BackColor = backButton; // Фон кнопок
            this.ForeColor = richTextBox1.ForeColor = richTextBox2.ForeColor = button1.ForeColor = button2.ForeColor =
                button3.ForeColor = button4.ForeColor = groupBox1.ForeColor = fore; // Цвет текста
        }
    }
}
