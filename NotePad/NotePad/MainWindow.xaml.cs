using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuHelpInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            info.ShowDialog();
        }

        private void menuFileExit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath)) 
            {
                menuFileSave_Click(sender, e);
                this.Close();
            }
            else
            {
                menuFileSaveAs_Click(sender, e);
            }
        }

        private void menuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "текстовые файлы (*.txt*)|*.txt|Все файлы (*.*)|*.*)";
            if(saveFileDialog.ShowDialog() == true)
            {
                currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(currentFilePath, txtEditor.Text);
                this.Title = $"Мой блокнот - {Path.GetFileName(currentFilePath)}";
            }
        }

        private void menuFileSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath)) 
            {
                File.WriteAllText(currentFilePath, txtEditor.Text);
            }
            else
            {
                menuFileSaveAs_Click(sender, e);
            }
        }

        private void menuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                currentFilePath = openFileDialog.FileName;
                txtEditor.Text = File.ReadAllText(currentFilePath);
                this.Title = $"Мой Блокнот - {Path.GetFileName(currentFilePath)}";
            }
        }

        private void menuFileNew_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.Text) && !string.IsNullOrEmpty(currentFilePath) && File.ReadAllText(currentFilePath) != txtEditor.Text)
            {
                MessageBoxResult result = MessageBox.Show("Сохранить изменения перед созданием нового файла?", "Предупреждение", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    menuFileSave_Click(sender, e); 
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(txtEditor.Text) && string.IsNullOrEmpty(currentFilePath))
            {
                MessageBoxResult result = MessageBox.Show("Сохранить изменения перед созданием нового файла?", "Предупреждение", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    menuFileSaveAs_Click(sender, e);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            txtEditor.Clear();

            currentFilePath = null;

            this.Title = "Мой Блокнот";
        }

        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Control_Size_Text_Click(object sender, RoutedEventArgs e)
        {
            Control_Size_Font fontSizeWindow = new Control_Size_Font(this); // Передаем ссылку на текущее окно MainWindow
            fontSizeWindow.ShowDialog(); // Или fontSizeWindow.Show(); если не хочешь модальное окно
        }
    }
}