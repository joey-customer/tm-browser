using System;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;

using TMBrowser.ModelViews;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using EO.WebBrowser;

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

        public MVTabItem TabItem { set; get; }

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

        private void updateLoading()
        {
            TabItem.SpinningIconVisibility = Visibility.Visible;
            TabItem.FavIconVisibility = Visibility.Hidden;
            TabItem.Header = "กำลังโหลดข้อมูล...";

            TabItem.NotifyPropertyChange("FavIconVisibility");
            TabItem.NotifyPropertyChange("SpinningIconVisibility");
            TabItem.NotifyPropertyChange("Header");
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            webview.Url = mwv.HomeUrl;
            updateLoading();
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

        private void Webview_ScriptCallDone(object sender, EO.WebBrowser.ScriptCallDoneEventArgs e)
        {
        }

        private void Webview_BeforeSendHeaders(object sender, EO.WebBrowser.RequestEventArgs e)
        {
        }

        private void Webview_LoadFailed(object sender, EO.WebBrowser.LoadFailedEventArgs e)
        {
        }

        private void Webview_BeforeNavigate(object sender, EO.WebBrowser.BeforeNavigateEventArgs e)
        {
            if (e.NavigationType == NavigationType.Other)
            {
                return;
            }

            updateLoading();
        }

        private void Webview_LoadCompleted(object sender, EO.WebBrowser.LoadCompletedEventArgs e)
        {
            TabItem.SpinningIconVisibility = Visibility.Hidden;
            TabItem.FavIconVisibility = Visibility.Visible;
            TabItem.Header = webview.Title;

            TabItem.NotifyPropertyChange("FavIconVisibility");
            TabItem.NotifyPropertyChange("SpinningIconVisibility");
            TabItem.NotifyPropertyChange("Header");
        }

        private void Webview_FaviconChanged(object sender, EventArgs e)
        {
            TabItem.FavIconImage.Source = GetImageSource(webview.Favicon);
            TabItem.NotifyPropertyChange("FavIconImage");
        }

        private BitmapImage GetImageSource(System.Drawing.Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Bmp);
                stream.Position = 0;

                var bmpImgage = new BitmapImage();
                bmpImgage.BeginInit();
                bmpImgage.CacheOption = BitmapCacheOption.OnLoad;
                bmpImgage.StreamSource = stream;
                bmpImgage.EndInit();

                return bmpImgage;
            }
        }
    }
}
