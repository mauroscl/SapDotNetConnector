using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;
using SapService;

namespace TestSapConnector
{
    internal static class TestSapConnectorUtils
    {
        public static RfcConfigParameters GetDefaultConfigParameters(string configurationName)
        {
            return new RfcConfigParameters
                {
                    {RfcConfigParameters.Name, configurationName},
                    {RfcConfigParameters.User, "fusion_wylly"},
                    {RfcConfigParameters.Client, "100"},
                    {RfcConfigParameters.Language, "EN"},
                    {RfcConfigParameters.AppServerHost, "10.1.3.24"},
                    {RfcConfigParameters.SystemNumber, "0"},
                    {RfcConfigParameters.SystemID, "ECD"}
                };
        }

        public static SapConnector GetDefaultSapConnection()
        {
            RfcConfigParameters parameters = GetDefaultConfigParameters("FusionBsBiosDefault");
            parameters.Add(RfcConfigParameters.Password, "xxxx"); //colocar a senha
            return new SapConnector(parameters);
        }
    }
}
