﻿using System;
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
            var httpAddr = new Uri("http://127.0.0.1:9999/CMServer/CMService/srv");
            var channel = new ChannelFactory<ICMService>(new WSHttpBinding());
            var ep = new EndpointAddress(httpAddr);
            var proxy = channel.CreateChannel(ep);
            var resp = proxy.cmRequest();
            MessageBox.Show(resp);
            /*MessageBox.Show("You'v just clicked me.");
            CMServer.CMServiceClient cmsc = new CMServiceClient();
            cmsc.Open();
            string req = cmsc.cmRequest();
            MessageBox.Show(req);
            cmsc.Close();*/
        }
    }
}
