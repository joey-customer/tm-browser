using System.Collections.ObjectModel;

namespace TMBrowser.ModelViews
{
    public class MVBrowser : MVBase
    {
        private readonly string homeUrl = "https://rta.mi.th/";
        private readonly ObservableCollection<MVTabItem> tabItems = new ObservableCollection<MVTabItem>();

        public ObservableCollection<MVTabItem> TabItems
        {
            get { return tabItems; }
        }

        public void InitStartTab(double areaHeight)
        {
            var item = new MVTabItem("Royal Thai Army", "https://rta.mi.th/", areaHeight, homeUrl);
            tabItems.Add(item);

            item = new MVTabItem("Google", "www.google.com", areaHeight, homeUrl);
            tabItems.Add(item);
        }

        public void NotifyHeightChanged(double areaHeight)
        {
            foreach (MVTabItem item in tabItems)
            {
                item.NotifyHeightChanged(areaHeight);
            }
        }
    }
}
