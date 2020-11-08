using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CMInterface
{
    [ServiceContract]
    public interface ICMService
    {
        [OperationContract]
        string cmRequest();

    }
}
