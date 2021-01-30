using System.Windows;
using System.Collections.ObjectModel;

using TMBrowser.ModelViews;

namespace TMBrowser
{
    public partial class MainWindow : Window
    {
        private MVBrowser browser = new MVBrowser();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = browser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
