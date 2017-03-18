using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace connectivesportService
{
    internal class Constants
    {
        internal static readonly string HubConnectionString = "Endpoint=sb://connectivesportservice.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=VmfLZgCsPdGQ29Y3sLWsorh5ArCfvIHwylvTr0OlTsI=";
        internal static readonly string HubName = "ConnectiveSportNotificationHub";
    }
}