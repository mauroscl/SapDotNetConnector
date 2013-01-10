using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace SapService
{
    public class SapConnector
    {
        public readonly RfcDestination RfcDestination;

        public SapConnector(RfcConfigParameters configParameters)
        {
            //<add NAME="NCO_TESTS" USER="MY_USER" PASSWD="MY_PASSWORD" CLIENT="100" LANG="EN" ASHOST="MY_ASHOST" SYSNR="MY_SYSNR" POOL_SIZE="5" MAX_POOL_SIZE="10"/>

            RfcDestination = RfcDestinationManager.GetDestination(configParameters);

        }


    }
}
