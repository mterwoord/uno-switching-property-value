using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TestUnoApp
{
    public class TestControl: ContentControl
    {
        private static int ControlCount = 0;

        private int _controlIndex;

        public TestControl()
        {
            _controlIndex = ++ControlCount;
        }

        public static readonly DependencyProperty DataItemProperty = DependencyProperty.Register(nameof(DataItem), typeof(object), typeof(TestControl), new PropertyMetadata(null, DataItemChanged));

        public object DataItem
        {
            get => (object)GetValue(DataItemProperty);
            set => SetValue(DataItemProperty, value);
        }

        private static void DataItemChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
        {
            ((TestControl)dependencyobject).DataItemChanged(args.OldValue, args.NewValue);
        }

        private void DataItemChanged(object oldValue, object newValue)
        {
            var type     = (newValue?.GetType()?.FullName) ?? "NULL";
            var dataItem = newValue as MyDataItem;

            var extraString = "";
            if (dataItem != null)
            {
                extraString = $", Message = '{dataItem.Message}'";
            }

            Console.WriteLine(@"{0} In DataItemChanged. newValue.Type = {1}" + extraString, _controlIndex, type);

            if (dataItem == null)
            {
                Content = new TextBlock
                          {
                              Text = "Unknown!"
                          };
            }
            else
            {
                Content = new TextBlock
                          {
                              Text = dataItem.Message
                          };
            }
        }
    }
}