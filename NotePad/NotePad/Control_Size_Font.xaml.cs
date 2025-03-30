// В Control_Size_Font.xaml.cs
using System.Windows;

namespace NotePad
{
    /// <summary>
    /// Логика взаимодействия для Control_Size_Font.xaml
    /// </summary>
    public partial class Control_Size_Font : Window
    {
        private MainWindow _mainWindow;

        public Control_Size_Font(MainWindow mainWindow) 
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void CLick_FontSize_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtSize.Text, out double fontSize)) 
            {
                _mainWindow.txtEditor.FontSize = fontSize;
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для размера шрифта.", "Ошибка");
            }
        }

    }
}