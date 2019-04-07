using BAL;
using Newtonsoft.Json;
using System;
using System.Web.Http;

namespace API.Controllers
{
    public class PatientController : ApiController
    {
        private PatientBAL patientBAL { get; set; }
        public IHttpActionResult Get()
        {
            try
            {
                patientBAL = new PatientBAL();
                return Ok(patientBAL.GetLists());
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Message));
            }

        }
    }
}