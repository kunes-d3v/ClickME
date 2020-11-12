using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using CMInterface;

namespace CMClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // create base address
            var httpAddr = new Uri("http://127.0.0.1:9999/CMServer/CMService/srv");

            // create a new channel
            var channel = new ChannelFactory<ICMService>(new WSHttpBinding());

            // create the EP
            var ep = new EndpointAddress(httpAddr);

            // assign the EP to the channel
            var proxy = channel.CreateChannel(ep);

            // use the channel
            var resp = proxy.cmRequest();

            MessageBox.Show(resp);
        }
    }
}
