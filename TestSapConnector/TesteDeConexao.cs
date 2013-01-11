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
            //Obtém os parâmetros de conexão
            RfcConfigParameters configParameters = TestSapConnectorUtils.GetDefaultConfigParameters("FusionBsBiosInvalida");
            //Seta uma senha inválida para a conexão.
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
