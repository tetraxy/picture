using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace picture
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.DefaultRequestHeaders.Add("X-Api-Key", "I8Y8O9NbvXQ4wqmsgrze7g==tJWrfgtuOLmJII5s");
            client.DefaultRequestHeaders.Add("Accept", "image/jpg");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string category = "nature"; // Вы можете позволить пользователю выбрать категорию
            string apiUrl = $"https://api.api-ninjas.com/v1/randomimage?category={category}";

            try
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        // Загружаем изображение в PictureBox
                        using (var image = Image.FromStream(stream))
                        {
                            pictureBox1.Image = new Bitmap(image);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp";
                    saveFileDialog.Title = "Сохранить изображение как";
                    saveFileDialog.FileName = "image"; // Имя файла по умолчанию

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Сохраняем изображение в выбранный путь
                            pictureBox1.Image.Save(saveFileDialog.FileName);
                            MessageBox.Show("Изображение успешно сохранено!", "Сообщение", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
            
