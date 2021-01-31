using System.ComponentModel;

namespace TMBrowser.ModelViews
{
    public class MVBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged implementation

        public void NotifyPropertyChange(string propertyName)
        {
            Notify(propertyName);
        }
    }
}
