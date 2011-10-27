using System;
using System.Windows;
using System.Windows.Controls;

namespace Front
{
    public partial class MainPage : UserControl
    {
        private readonly FooService _fooService = new FooService();

        public MainPage()
        {
            InitializeComponent();
        }

        private void GetOneButton_Click(object sender, RoutedEventArgs e)
        {
            var requestedId = Convert.ToInt32(IdToRequest.Text);

            // this is how we consume the service
            _fooService.GetOne(requestedId)
                .WhenReady(foo => OnePanel.DataContext = foo);
        }
    }
}
