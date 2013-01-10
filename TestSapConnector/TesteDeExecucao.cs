using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAP.Middleware.Connector;
using SapService;

namespace TestSapConnector
{
    [TestClass]
    public class TesteDeExecucao
    {
        private readonly SapConnector _sapConnector;
        public TesteDeExecucao()
        {
            _sapConnector = TestSapConnectorUtils.GetDefaultSapConnection();
        }

        [TestMethod]
        public void ConsigoObterEstruturaDeUmaTabela()
        {
            RfcStructureMetadata rfcTableMetadata = _sapConnector.RfcDestination.Repository.GetStructureMetadata("EKKO");
            Assert.AreEqual("EKKO", rfcTableMetadata.Name);
            Assert.IsTrue(rfcTableMetadata.FieldCount > 0);
        }
        [TestMethod]
        public void ConsigoExecutarUmaFuncao()
        {
            try
            {
                IRfcFunction function = _sapConnector.RfcDestination.Repository.CreateFunction("ZNFIN_FS_MIMI_INBOUND");
                function.SetValue("IV_STRING","HELLO WORLD");
                function.Invoke(_sapConnector.RfcDestination);
                throw new Exception("Não gerou a excessão esperada ao invocar o RFC");
            }
            catch (RfcAbapException ex)
            {
                Assert.AreEqual("INVALID_XML",ex.Key);
            }
        }

        [TestMethod]
        public void TesteNFe()
        {
            StreamReader reader = File.OpenText("C:\\Users\\Francisco\\Documents\\Meus arquivos recebidos\\43121289432702000158550010000252811489153832-nfe.xml");
            string conteudo = reader.ReadToEnd();
            IRfcFunction function = _sapConnector.RfcDestination.Repository.CreateFunction("ZNFIN_FS_MIMI_INBOUND");
            function.SetValue("IV_STRING", conteudo );
            function.Invoke(_sapConnector.RfcDestination);

        }
    }
}
