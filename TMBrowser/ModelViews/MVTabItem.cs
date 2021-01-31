using System;
using System.Windows;
using System.Windows.Controls;
using TMBrowser.UserControls;

namespace TMBrowser.ModelViews
{
    public class MVTabItem : MVBase
    {
        public string Header { get; set; }
        public UWebView ContentControl { get; set; }
        public Visibility SpinningIconVisibility { get; set; }
        public Visibility FavIconVisibility { get; set; }
        public Image FavIconImage { get; set; }

        public MVTabItem(String header, String url, double areaHeight, String homeUrl)
        {
            SpinningIconVisibility = Visibility.Visible;
            FavIconVisibility = Visibility.Hidden;
            FavIconImage = new Image();

            Header = header;

            //Each tab item has it own web view user control
            UWebView wv = new UWebView()
            {
                Url = url,
                Height = areaHeight,
                HomeUrl = homeUrl,
                TabItem = this
            };

            ContentControl = wv;
        }

        public MVTabItem Self 
        { 
            get { return this; }
        }

        public void NotifyHeightChanged(double height)
        {
            ContentControl.AreaHeight = height;
        }
    }
}
