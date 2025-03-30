using System.Windows;

namespace NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        }

        private void menuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuFileSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuFileOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuFileNew_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtEditor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}