using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

//Створити консольний додаток. 
//Програма задає питання щодо розмірів, кольору форми, розмірів  кнопки і зображує відповідну форму з кнопкою на формі.

namespace My_Classwork_WindowsForm_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowForm();
        }

        private static void ShowForm()
        {
            var form = new Form(); // створюємо форму

            form.BackColor = System.Drawing.Color.LightBlue; // колір фону

            Console.WriteLine("Enter color text form (red, white, black, green, yellow): ");
            string color_text_forma = Console.ReadLine(); //вибір кольору тексту
            form.ForeColor = Color.FromName(color_text_forma); // колір тексту на фоні

            Console.WriteLine("Enter width form: ");
            int width = int.Parse(Console.ReadLine());
            form.Width = width; // ширина вікна

            Console.WriteLine("Enter height form: ");
            int height = int.Parse(Console.ReadLine());
            form.Height = height; // довжина вікна

            form.Font = new Font("Impact", 16); // Шифр та шрифт тексту на фоні
            form.Text = "My first form"; // назва заголовку

            var label = new Label(); // створюємо лейбу (текст на фоні)
            label.Text = "Sunday, 20 June"; // текст лейби
            label.AutoSize = true; // автоматичне розширення тексту лейби
            label.Location = new Point(form.ClientSize.Width / 2 - label.Width / 2, form.ClientSize.Height / 2 - label.Height / 2); // розміщення лейби на фоні (тут буде по середині)

            var button = new Button(); // створюємо кнопку
            button.Text = "Press me"; // назва на кнопці
            button.Font = new Font(form.Font.FontFamily, 12, FontStyle.Italic); // шифр та шрифт надпису на кнопці
            button.ForeColor = Color.FromArgb(100, 34, 200);  // колір тексту, Color.FromArgb - метод, дозволяє змішати колір по числових значеннях, від 0..255
            button.BackColor = Color.FromName("Orange"); // колір фону

            Console.WriteLine("Enter width button: ");
            int width_button = int.Parse(Console.ReadLine());
            button.Width = width_button; // ширина кнопки (100)

            Console.WriteLine("Enter height button: ");
            int height_button = int.Parse(Console.ReadLine());
            button.Height = height_button; // довжина кнопки (40)

            button.Click += Button_Click; // підписка на подію Click по кнопці

            form.Controls.Add(label);  // додаю текст на фоні в колекцію контролів на формі
            form.Controls.Add(button); // додаю кнопку в колекцію контролів на формі

            form.ShowDialog(); // показати форму
        }

        static bool isClicked = false;
        static int num = 0;

        // При натисненні кнопки - змінюємо фон кнопки
        private static void Button_Click(object sender, EventArgs e)
        {
            isClicked = !isClicked; // ?
            var obj = (sender as Button);
            num++; // рахує кількість натискань
            // достуавємось до батьківського класу форми
            (obj.Parent as Form).Text = ($"Кількість натискань кнопки мишки = {num}"); // записує кількість натискань кнопки мишки в заголовок форми
            // Parent - властивість елемента, що містить "батьківський" елемент
            // наступний рядок змінить фон форми
            //obj.Parent.BackColor = isClicked ? Color.Red : Color.Orange; // зміна кольору фону при натискані на кнопку
            obj.BackColor = isClicked ? Color.Red : Color.Orange; // зміна кольору кнопки при натискані
            var rand = new Random();
            //Color c = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //рандомно змінює колір кнопки
            obj.BackColor = isClicked ? Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)) : Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
}
