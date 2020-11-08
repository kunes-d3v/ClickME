using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CMInterface;

namespace CMServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // create http url (base addr)
            Uri baseAddr = new Uri("http://127.0.0.1:9999/CMServer/CMService");

            // create service host
            ServiceHost cmHost = new ServiceHost(typeof(CMService), baseAddr);

            // add service endpoint
            cmHost.AddServiceEndpoint(typeof(CMInterface.ICMService), new WSHttpBinding(), "srv");

            // enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            cmHost.Description.Behaviors.Add(smb);

            // add mex EP
            cmHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            cmHost.Open();
            Console.WriteLine("CM Service is up \n press any key to exit!");
            Console.ReadLine();
        }
    }
}
