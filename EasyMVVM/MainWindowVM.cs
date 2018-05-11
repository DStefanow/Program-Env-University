using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> _BackingProperty;

        public MainWindowVM()
        {
            Model model = new Model();
            BoundProperty = model.GetData();
        }

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set {
                _BackingProperty = value;
                PropChanged("Bound Property");
            }
        }

        public void PropChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
