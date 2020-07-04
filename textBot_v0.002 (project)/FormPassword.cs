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
    public partial class FormPassword : Form
    {
        int countTry = 0; // Количество попыток ввода
        public bool truePassword = false; // Статус правильного пароля
        string password; // Переменная пароль
        // Конструктор получает пароль
        public FormPassword(string pass, Color backForm, Color backText, Color backButton, Color fore)
        {
            InitializeComponent();
            this.BackColor = backForm; // Получаем цвет из главной формы
            textBox1.BackColor = backText;
            button1.BackColor = backButton;
            this.ForeColor = textBox1.ForeColor = button1.ForeColor = fore;
            password = pass; // Получаем пароль
            label1.Text = String.Format("Осталось попыток ввода пароля: {0}", (3 - countTry)); // Выводим количество попыток
        }
        // Нажатие на клавишу ввести пароль
        private void button1_Click(object sender, EventArgs e)
        {
            // Если введённый пароль совпадаёт с правильным
            if (textBox1.Text == password)
            {
                truePassword = true; // ТО устанавливаем флаг правильного пароля
                this.Close(); // Закрываем форму
            }
            // Иначе
            else
            {
                textBox1.Text = ""; // Очищаем поле ввода
                countTry++; // + кол-во попыток
            }
            label1.Text = String.Format("Осталось попыток ввода пароля: {0}", (3 - countTry)); // Выводим кол-во попыток
            if (countTry == 3) // Если 3 попытки было
                this.Close(); // Закрываем форму
        }
    }
}
