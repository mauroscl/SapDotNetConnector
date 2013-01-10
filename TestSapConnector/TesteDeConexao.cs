using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAP.Middleware.Connector;
using SapService;

namespace TestSapConnector
{
    [TestClass]
    public class TesteDeConexao
    {
        [TestMethod]
        [ExpectedException(typeof (RfcLogonException))]
        public void NaoConsigoConectarNoSapComCredenciaisInvalidas()
        {
            RfcConfigParameters configParameters = TestSapConnectorUtils.GetDefaultConfigParameters("FusionBsBiosInvalida");
            configParameters.Add(RfcConfigParameters.Password, "inicial1");

            var sapConnector = new SapConnector(configParameters);
            sapConnector.RfcDestination.Ping();
        }

        [TestMethod]
        public void ConsigoConectarNoSapComCredenciaisValidas()
        {
            var configParameters = TestSapConnectorUtils.GetDefaultConfigParameters("FusionBsBiosValida");
            configParameters.Add(RfcConfigParameters.Password, "inicial");

            var sapConnector = new SapConnector(configParameters);

            sapConnector.RfcDestination.Ping();
        }

    }
}
