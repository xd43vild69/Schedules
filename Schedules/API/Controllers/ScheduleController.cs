using BAL;
using DTO;
using Newtonsoft.Json;
using System;
using System.Web.Http;

namespace API.Controllers
{
    public class ScheduleController : ApiController
    {
        private ScheduleBAL ScheduleBAL { get; set; }
       
        private Schedule Schedule { get; set; }

        public ScheduleController()
        {
            Schedule = new Schedule();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Schedule.Id = id;
                ScheduleBAL = ConfigIOC.GetInstance<ScheduleBAL>(Schedule);
                return Ok(ScheduleBAL.Get());
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IHttpActionResult Post([FromBody] object postParameters)
        {
            try
            {
                Schedule = JsonConvert.DeserializeObject<Schedule>(postParameters.ToString());
                ScheduleBAL = ConfigIOC.GetInstance<ScheduleBAL>(Schedule);
                ScheduleBAL.Insert();
                return Ok("Ok. Post!");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Schedule.Id = id;
                ScheduleBAL = ConfigIOC.GetInstance<ScheduleBAL>(Schedule);
                ScheduleBAL.Delete();
                return Ok("Ok. Delete!");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}