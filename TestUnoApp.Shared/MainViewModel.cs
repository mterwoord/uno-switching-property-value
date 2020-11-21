using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TestUnoApp
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private IList<MyDataItem> _items;

        public IList<MyDataItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var items = new List<MyDataItem>();

            items.Add(new MyDataItem("One"));
            items.Add(new MyDataItem("Two"));
            items.Add(new MyDataItem("Three"));
            items.Add(new MyDataItem("Four"));
            items.Add(new MyDataItem("Five"));

            Items = items;
        }
    }
}