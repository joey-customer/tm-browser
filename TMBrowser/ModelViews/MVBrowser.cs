using System.Collections.ObjectModel;

namespace TMBrowser.ModelViews
{
    public class MVBrowser : MVBase
    {
        private ObservableCollection<MVTabItem> tabItems = new ObservableCollection<MVTabItem>();

        public ObservableCollection<MVTabItem> TabItems
        {
            get { return tabItems; }
        }
    }
}
