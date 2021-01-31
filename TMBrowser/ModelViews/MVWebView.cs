using System;
using System.Windows;

namespace TMBrowser.ModelViews
{
    public class MVWebView : MVBase
    {
        public bool CanForward { get; set; }
        public bool CanBackward { get; set; }
        public string HomeUrl { get; set; }
        public string CurrentUrl { get; set; }
        public Visibility CertificateOKVisibility { set; get; }
        public Visibility CertificateErrorVisibility { set; get; }
    }
}
