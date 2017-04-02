using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.NotificationHubs;
using connectivesportService.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Microsoft.Azure.Mobile.Server;
using System.Net;
using System.Data.SqlClient;

namespace connectivesportService.Controllers
{
    [MobileAppController]
    public class NotificationController : ApiController
    {

        connectivesportContext _context = new connectivesportContext();
        NotificationHubClient _hub = NotificationHubClient.CreateClientFromConnectionString(Constants.HubConnectionString, Constants.HubName);
        // GET api/Notification
        public string Get()
        {
            return "Hello from custom controller!";
        }
        

        //GET api/Test
        [HttpGet]
        [Route("api/Notification/Test")]
        public string Test()
        {
            return "This is a test";
        }

        //GET api/Come
        [HttpGet]
        [Route("api/Notification/Come")]
        public string Come(string usd)
        {
            return "This is a test" + usd;
        }

        //GET api/HubRegistration
        [HttpGet]
        [Route("api/Notification/HubRegistration")]
        public async Task<string> HubRegistration()
        {
            await NotifyByTag("This is message","all" );
            return "This is a HubRegistration";
        }


        //GET api/TestNotificationRegistration
        [HttpGet]
        [Route("api/Notification/TestNotificationRegistration")]
        public async Task<string> TestNotificationRegistration()
        {
            //await NotifyByTag("This is message", "all");
            HttpConfiguration config = this.Configuration;
            MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            string notificationHubName = settings.NotificationHubName;
            string notificationHubConnection = settings.Connections[MobileAppSettingsKeys.NotificationHubConnectionString].ConnectionString;

            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(notificationHubConnection, notificationHubName,true);


            //var x = await hub.GetAllRegistrationsAsync(10);

            
            Dictionary<string, string> templateParams = new Dictionary<string, string>();
            templateParams["messageParam"] =  "Notification OK.";

            string gcmpl = @"{""data"":{""message"":""Notification Hub test notification"", ""title"":""ConnectiveSport Notification""}}";

            var outcome  = await hub.SendGcmNativeNotificationAsync(gcmpl, new List<String> { "all" });
            //var outcome = await hub.SendTemplateNotificationAsync(templateParams, new List<String> { "falcons","all" });

            return "excuted";// 'outcome.State.ToString();
        }



        [HttpPut]
        [Route("api/Notification/registerWithHub")]
        public async Task<string> RegisterWithHub(DeviceRegistration deviceUpdate)
        {

            string newRegistrationId = null;
            try
            {
            //    // make sure there are no existing registrations for this push handle (used for iOS and Android)
            //    if (deviceUpdate.Handle != null)
            //    {
            //        //Azure likes to uppercase the iOS device handles for some reason - no worries tho, I only spent 2 hours tracking this down
            //        if (deviceUpdate.Platform == "iOS")
            //            deviceUpdate.Handle = deviceUpdate.Handle.ToUpper();

            //        var registrations = await _hub.GetRegistrationsByChannelAsync(deviceUpdate.Handle, 100);

            //        foreach (var reg in registrations)
            //        {
            //            if (newRegistrationId == null)
            //            {
            //                newRegistrationId = reg.RegistrationId;
            //            }
            //            else
            //            {
            //                await _hub.DeleteRegistrationAsync(reg);
            //            }
            //        }
            //    }

                if (newRegistrationId == null)
                    newRegistrationId = await _hub.CreateRegistrationIdAsync();

                GcmRegistrationDescription registration =  new GcmRegistrationDescription(deviceUpdate.Handle,deviceUpdate.Tags);
                registration.RegistrationId = newRegistrationId;
                await _hub.CreateOrUpdateRegistrationAsync(registration);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newRegistrationId;
        }

        [HttpGet]
        [Route("api/data/getNearbyUser")]
        public string GetNearbyUser(double lat, double lon)
        {
            connectivesportContext _context = new connectivesportContext();
            string querry = "select * from users where abs(users.lastlocationX - @lat) < 0.005 and abs(users.lastlocationY - @lon) < 0.005";
            var querryresult = _context.Users.SqlQuery(querry, new SqlParameter("@lat",lat), new SqlParameter("@lon", lon)).ToListAsync();
            
            string result = "";
            result = JsonConvert.SerializeObject(querryresult);
            return result;
        }


        #region Notification
        public async Task NotifyByTags(string message, List<string> tags, NotificationPayload payload = null, int? badgeCount = null)
        {
            var notification = new Dictionary<string, string> { { "message", message } };

            if (payload != null)
            {
                var json = JsonConvert.SerializeObject(payload);
                notification.Add("payload", json);
            }
            else
            {
                notification.Add("payload", "");
            }

            if (badgeCount == null)
                badgeCount = 0;

            notification.Add("badge", badgeCount.Value.ToString());

            try
            {
                await _hub.SendTemplateNotificationAsync(notification, tags);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task NotifyByTag(string message, string tag, NotificationPayload payload = null, int? badgeCount = null)
        {
            await NotifyByTags(message, new List<string> { tag }, payload, badgeCount);
        }

        #endregion

        [HttpGet]
        [Route("api/Notification/sendTestPushNotification")]
        public string SendTestPushNotification(string athleteId)
        {
            //if (athleteId != null)
            //{
            //    var message = "Push notifications are working for you - excellent!";
            //    await NotifyByTag(message, athleteId);
            //}
            return "Test sent";
        }
    }
}
