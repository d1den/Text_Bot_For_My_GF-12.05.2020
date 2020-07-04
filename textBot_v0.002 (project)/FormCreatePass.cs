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
    public partial class FormCreatePass : Form
    {
        public FormCreatePass(Color backForm, Color backText, Color backButton, Color fore)
        {
            InitializeComponent();
            this.BackColor = backForm; // Получаем цвет из главной формы
            textBox1.BackColor = backText;
            button1.BackColor = backButton;
            this.ForeColor = textBox1.ForeColor = button1.ForeColor = button2.ForeColor = fore;
        }

        // Установить пароль
        private void button1_Click(object sender, EventArgs e)
        {
            using(System.IO.StreamWriter sw= new System.IO.StreamWriter("data\\settings.txt"))
            {
                sw.WriteLine("password:" + textBox1.Text); // Перезаписываем файл настроек, сохраняя введённое значение
            }
            this.Close(); // Закрываем форму
        }

        // Удалить пароль
        private void button2_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("data\\settings.txt"))
            {
                sw.WriteLine("password:off"); // Записываем, что пароль выключен
            }
            this.Close(); // Закрываем форму
        }
    }
}
