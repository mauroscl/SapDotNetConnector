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
                    /*{RfcConfigParameters.Password, "inicial"},*/
                    {RfcConfigParameters.Client, "100"},
                    {RfcConfigParameters.Language, "EN"},
                    {RfcConfigParameters.AppServerHost, "10.1.3.24"},
                    {RfcConfigParameters.SystemNumber, "0"},
                    {RfcConfigParameters.SystemID, "ECD"}/*,
                    {RfcConfigParameters.SAPRouter, "/H/200.102.153.17/W/123456/H/"}*/
                };
        }

        public static SapConnector GetDefaultSapConnection()
        {
            RfcConfigParameters parameters = GetDefaultConfigParameters("FusionBsBiosDefault");
            parameters.Add(RfcConfigParameters.Password, "inicial");
            return new SapConnector(parameters);
        }
    }
}
