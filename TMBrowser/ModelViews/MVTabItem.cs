using System;
using TMBrowser.UserControls;

namespace TMBrowser.ModelViews
{
    public class MVTabItem : MVBase
    {
        public string Header { get; set; }
        public UWebView ContentControl { get; set; }

        public MVTabItem(String header, String url, double areaHeight, String homeUrl)
        {
            Header = header;

            //Each tab item has it own web view user control
            UWebView wv = new UWebView()
            {
                Url = url,
                Height = areaHeight,
                HomeUrl = homeUrl
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
