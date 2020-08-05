using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EnableX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EnableX.Controllers
{
    /// <summary>
    /// The main EnableX api controller class
    /// Contains methods for api endpoints
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EnablexController : ControllerBase
    {
        private readonly ILogger<EnablexController> _logger;
        private EnablexConfig enablexConfig;

        public EnablexController(ILogger<EnablexController> logger, EnablexConfig iConfig)
        {
            _logger = logger;
            enablexConfig = iConfig;
        }

        /// <summary>
        /// Method to get info about EnableX room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Result of the room</returns>
        [HttpGet("/api/get-room")]
        public async Task<string> GetRoom(string roomId)
        {
            // build auth token for using EnableX video API
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{enablexConfig.APP_ID}:{enablexConfig.APP_KEY}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // EnableX get room details api - /api/rooms/{roomId}
            string apiEndpoint = $"{enablexConfig.API_URL}rooms/{roomId}";

            var result = await client.GetAsync(apiEndpoint);
            return await result.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Method to create EnableX room
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/create-room")]
        public async Task<string> CreateRoom()
        {
            #region
            // Build JSON Raw Body Payload for creating EnableX room
            RoomBodySip roomBodySip = new RoomBodySip();
            roomBodySip.enabled = false;

            RoomBodySettings roomBodySettings = new RoomBodySettings();
            roomBodySettings.description = "";
            roomBodySettings.quality = "SD";
            roomBodySettings.mode = "group";
            roomBodySettings.participants = "1";
            roomBodySettings.duration = "30";
            roomBodySettings.scheduled = false;
            roomBodySettings.auto_recording = false;
            roomBodySettings.active_talker = true;
            roomBodySettings.wait_moderator = false;
            roomBodySettings.adhoc = true;

            var rand = new Random();
            int randNum = rand.Next();

            RoomBody roomBody = new RoomBody();
            roomBody.name = $"Sample Room {randNum}";
            roomBody.owner_ref = $"{randNum}";
            roomBody.settings = roomBodySettings;
            roomBody.sip = roomBodySip;
            #endregion

            // build auth token for using EnableX video API
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{enablexConfig.APP_ID}:{enablexConfig.APP_KEY}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            
            // EnableX create room api - /api/rooms/
            string apiEndpoint = $"{enablexConfig.API_URL}rooms/";

            var json = JsonConvert.SerializeObject(roomBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiEndpoint, data);

            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Method to create EnableX token
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/create-token")]
        public async Task<string> CreateToken()
        {
            string requestJSON = await new StreamReader(Request.Body).ReadToEndAsync();
            if (!String.IsNullOrEmpty(requestJSON)) {
                CreateTokenBody createTokenBody = JsonConvert.DeserializeObject<CreateTokenBody>(requestJSON);

                // build auth token for using EnableX video API
                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{enablexConfig.APP_ID}:{enablexConfig.APP_KEY}"));

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

                // EnableX create token api - /api/rooms/{roomId}/tokens
                string apiEndpoint = $"{enablexConfig.API_URL}rooms/{createTokenBody.roomId}/tokens";

                var data = new StringContent(requestJSON, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiEndpoint, data);

                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "";
            }
        }
    }
}
