using System.Windows;
using System.Windows.Controls;
using TMBrowser.ModelViews;

namespace TMBrowser
{
    public partial class MainWindow : Window
    {
        private readonly MVBrowser browser = new MVBrowser();

        public MVBrowser Browser { get; set; }

        public MainWindow()
        {
            Browser = browser;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //40 - height of nagivate buttons and text box
            browser.InitStartTab(tabMain.ActualHeight - 40);
            tabMain.SelectedIndex = 0;
        }

        private void TabMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            browser.NotifyHeightChanged(e.NewSize.Height);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tabMain.Items.Count <= 1)
            {
                //Must have at least 1 tab item.
                return;
            }

            Button btn = (Button) sender;
            var obj = (MVTabItem) btn.Tag;

            browser.RemoveTabItem(obj);
        }
    }
}
