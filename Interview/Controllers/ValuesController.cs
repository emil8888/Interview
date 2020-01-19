using Interview.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Interview.Controllers
{
    public class ValuesController : ApiController
    {
        // normally we should add authorize and add token 
        //  now data are not protected 


        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
       
            List<MainApp> mainApps = Tools.GetMainAppClass();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, mainApps);
            return response;
           
        }

        [HttpGet]
        public HttpResponseMessage Get(string ID)
        {
            HttpResponseMessage response;
            if (ID == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest , "Provide Application ID");
                return response;
            }

            List<MainApp> mainApps = Tools.GetMainAppClass();
            
            var oneApp = mainApps.Where(item => item.Id == ID).Select(item => item);
             response = Request.CreateResponse(HttpStatusCode.OK, oneApp);
            return response;


        }



            // POST api/values
        public HttpResponseMessage Post([FromBody] MainApp value)
        {
            HttpResponseMessage response;

            if (!ModelState.IsValid)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Not Valid Model");


            List<MainApp> mainApps = Tools.GetMainAppClass();
            try
            {
                mainApps.Add(value);
                Tools.UpdateFile(mainApps);
                response = Request.CreateResponse(HttpStatusCode.Created, "Data with  id= " + value.Id + " was created");
            }
            catch (Exception ex)
            {
                 response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;


        }

        // PUT api/values/
        public HttpResponseMessage Put([FromBody]MainApp value)
        {
            HttpResponseMessage response;
            if (!ModelState.IsValid)
              response = Request.CreateResponse(HttpStatusCode.BadRequest, "Not Valid Model");


            List<MainApp> mainApps = Tools.GetMainAppClass();
            try
            {
                var oneApp = mainApps.FirstOrDefault(item => item.Id == value.Id);

                //for example only 2 fields
                oneApp.Amount = value.Amount;
                oneApp.Summary = value.Summary;

               
                Tools.UpdateFile(mainApps);
                response = Request.CreateResponse(HttpStatusCode.OK, "Data with id= " + value.Id + " was updated");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return response;
            }
        

            

        }

    

        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {

            HttpResponseMessage response;
            if (id == null)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Provide ID");


            List<MainApp> mainApps = Tools.GetMainAppClass();
            try
            {
                var oneApp = mainApps.FirstOrDefault(item => item.Id == id);
                mainApps.Remove(oneApp);
                Tools.UpdateFile(mainApps);
                response = Request.CreateResponse(HttpStatusCode.OK, "Data with id= " + id + " was deleted");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return response;
            }



        }



    }
}
