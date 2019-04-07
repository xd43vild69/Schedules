using BAL;
using DTO;
using Newtonsoft.Json;
using System;
using System.Web.Http;

namespace API.Controllers
{
    public class TypeScheduleController : ApiController
    {
        private TypeScheduleBAL TypeSchedule { get; set; }

        public IHttpActionResult Get()
        {
            try
            {
                TypeSchedule = new TypeScheduleBAL();
                return Ok(TypeSchedule.GetLists());
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