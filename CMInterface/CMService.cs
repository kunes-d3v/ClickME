using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMInterface
{
    public class CMService : ICMService
    {
        public string cmRequest()
        {
            Console.WriteLine("Request recieved");
            return "Click Me response from service :)";
        }
    }
}
