using System;
using TMBrowser.UserControls;

namespace TMBrowser.ModelViews
{
    public class MVWebView : MVBase
    {
        public bool CanForward { get; set; }
        public bool CanBackward { get; set; }
        public string HomeUrl { get; set; }
        public string CurrentUrl { get; set; }
    }
}
