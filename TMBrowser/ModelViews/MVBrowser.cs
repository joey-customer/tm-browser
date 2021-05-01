using System;
using System.Collections.ObjectModel;
using EO.WebBrowser;

namespace TMBrowser.ModelViews
{
    public class MVBrowser : MVBase
    {
        private double height;

        private readonly string homeUrl = "https://tm-frontend-test-6y377xz4cq-as.a.run.app/"; //"https://cld-center.rta.mi.th/login";
        private readonly ObservableCollection<MVTabItem> tabItems = new ObservableCollection<MVTabItem>();

        public ObservableCollection<MVTabItem> TabItems
        {
            get { return tabItems; }
        }

        public void InitStartTab(double areaHeight)
        {
            var item = new MVTabItem("Google", homeUrl, areaHeight, homeUrl);
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
