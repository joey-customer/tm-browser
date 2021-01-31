using System;
using System.Windows;
using System.Windows.Controls;
using TMBrowser.ModelViews;

namespace TMBrowser.UserControls
{
    public partial class UWebView : UserControl
    {
        private readonly MVWebView mwv = new MVWebView();

        #region Url

        public String Url
        {
            get { return (String)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(UWebView),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnSelectedUrlChanged)));

        #endregion

        #region AreaHeight

        public double AreaHeight
        {
            get { return (double) GetValue(AreaHeightProperty); }
            set { SetValue(AreaHeightProperty, value); }
        }

        public static readonly DependencyProperty AreaHeightProperty =
            DependencyProperty.Register("AreaHeight", typeof(double), typeof(UWebView),
                new FrameworkPropertyMetadata(100.00, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnSelectedAreaHeightChanged)));

        #endregion

        private static void OnSelectedUrlChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UWebView control = sender as UWebView;
            control.webview.Url = (String) e.NewValue;
        }

        private static void OnSelectedAreaHeightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UWebView control = sender as UWebView;
            control.Height = (double) e.NewValue;
        }

        public UWebView()
        {
            mwv.CanBackward = false;
            mwv.CanForward = false;

            InitializeComponent();
        }

        public MVWebView WebviewContext
        {
            get 
            {
                return mwv;
            }

            set 
            { 
            }
        }

        public string HomeUrl
        {
            get
            {
                return mwv.HomeUrl;
            }

            set
            {
                mwv.HomeUrl = value;
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            webview.Url = mwv.HomeUrl;
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            webview.GoForward();
        }

        private void BtnBackward_Click(object sender, RoutedEventArgs e)
        {
            webview.GoBack();
        }

        private void Webview_CanGoBackChanged(object sender, EventArgs e)
        {
            mwv.CanBackward = webview.CanGoBack;
            mwv.NotifyPropertyChange("CanBackward");
        }

        private void Webview_CanGoForwardChanged(object sender, EventArgs e)
        {
            mwv.CanForward = webview.CanGoForward;
            mwv.NotifyPropertyChange("CanForward");
        }

        private void Webview_UrlChanged(object sender, EventArgs e)
        {
            mwv.CurrentUrl = webview.Url;
            mwv.NotifyPropertyChange("CurrentUrl");
        }
    }
}
