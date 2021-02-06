using System;
using System.Collections.ObjectModel;
using EO.WebBrowser;

namespace TMBrowser.ModelViews
{
    public class MVBrowser : MVBase
    {
        private double height;

        private readonly string homeUrl = "https://rta.mi.th/";
        private readonly ObservableCollection<MVTabItem> tabItems = new ObservableCollection<MVTabItem>();

        public ObservableCollection<MVTabItem> TabItems
        {
            get { return tabItems; }
        }

        public void InitStartTab(double areaHeight)
        {
            //var item = new MVTabItem("Royal Thai Army", "https://rta.mi.th/", areaHeight, homeUrl);
            //tabItems.Add(item);

            var item = new MVTabItem("Google", "www.google.com", areaHeight, homeUrl);
            item.ContentControl.NeedNeeWindowEvent = Webview_NewWindow;

            tabItems.Add(item);            

            height = areaHeight;
        }

        public void NotifyHeightChanged(double areaHeight)
        {
            foreach (MVTabItem item in tabItems)
            {
                item.NotifyHeightChanged(areaHeight);
            }
        }

        public void RemoveTabItem(MVTabItem item)
        {
            tabItems.Remove(item);
        }

        private void Webview_NewWindow(object sender, NewWindowEventArgs e)
        {
            var item = new MVTabItem(e.TargetUrl.Substring(0, 10), e.TargetUrl, height, homeUrl);
            item.ContentControl.NeedNeeWindowEvent = Webview_NewWindow;

            tabItems.Add(item);
        }
    }
}
