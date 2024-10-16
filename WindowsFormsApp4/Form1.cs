using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private Image originalImage; // Переменная для хранения оригинального изображения
        private float zoomFactor = 1.0f; // Коэффициент масштабирования

        public Form1()
        {
            InitializeComponent();
        }

        // Метод для выбора изображения
        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Загружаем изображение
                    originalImage = Image.FromFile(openFileDialog.FileName);
                    pictureBox.Image = originalImage;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Устанавливаем режим отображения изображения
                    zoomFactor = 1.0f; // Сбрасываем коэффициент масштабирования
                    pictureBox.Refresh();
                }
            }
        }

        // Метод для масштабирования изображения
        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                // Получаем значение масштаба с ползунка TrackBar (значение от 1 до 200%)
                zoomFactor = zoomTrackBar.Value / 10.0f;

                // Обновляем размеры PictureBox относительно коэффициента масштабирования
                pictureBox.Width = (int)(originalImage.Width * zoomFactor);
                pictureBox.Height = (int)(originalImage.Height * zoomFactor);

                // Центрируем PictureBox
                pictureBox.Left = (this.ClientSize.Width - pictureBox.Width) / 2;
                pictureBox.Top = (this.ClientSize.Height - pictureBox.Height - 60) / 2; // -60 для учета кнопок
            }
        }
    }
}
