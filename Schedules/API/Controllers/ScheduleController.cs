using BAL;
using DTO;
using Newtonsoft.Json;
using System;
using System.Web.Http;

namespace API.Controllers
{
    public class ScheduleController : ApiController
    {
        private ScheduleBAL scheduleBAL { get; set; }

        public IHttpActionResult Get(int id)
        {
            try
            {
                scheduleBAL = new ScheduleBAL();
                return Ok(scheduleBAL.GetByIdPatient(id));

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
        public IHttpActionResult Post([FromBody] object postParameters)
        {
            try
            {
                Schedule schedule = Newtonsoft.Json.JsonConvert.DeserializeObject<Schedule>(postParameters.ToString());
                scheduleBAL = new ScheduleBAL();
                scheduleBAL.Insert(schedule);
                return Ok("Ok. Post!");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Message));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                scheduleBAL = new ScheduleBAL();
                scheduleBAL.Delete(id);
                return Ok("Ok. Delete!");
            }
            catch (ApplicationException ex)
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