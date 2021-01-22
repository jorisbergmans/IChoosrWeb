using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IChoosrWebApp.Models;
using IChoosrWebApp.Models.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IChoosrWebApp.Controllers
{
    public class CameraController : Controller
    {
        private ILogger<CameraController> logger;
        private readonly CameraViewModel model;
        string baseUrl = "http://localhost:58302/api/";

        public CameraController(ILogger<CameraController> logger)
        {
            this.logger = logger;
            this.model = new CameraViewModel();
        }
        // GET: api/Camera
        [EnableCors]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<CameraModel> cameras = new List<CameraModel>();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(baseUrl + "Camera");

                    if (response.IsSuccessStatusCode)
                    {
                        var objResponse = await response.Content.ReadAsStringAsync();
                        cameras = JsonConvert.DeserializeObject<List<CameraModel>>(objResponse);
                    }

                    cameras = model.ConvertCameraNameToNumbers(cameras);

                    return View(cameras);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: api/Camera/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Camera
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Camera/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
