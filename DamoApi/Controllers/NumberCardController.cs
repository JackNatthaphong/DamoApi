using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DamoApi.Controllers
{
    [Route("api/[controller]")]
    public class NumberCardController : Controller
    {
        [HttpGet("{citizen_id}")]
        public ActionResult Get(string citizen_id)
        {
            if (citizen_id == null || citizen_id.Length < 13 || citizen_id.Length > 13)
            {
                return BadRequest(new { success = false, error_code = "001", error_msg = "citizen_id require" });
            }
            char[] lists = citizen_id.ToCharArray();
            int total = 0;
            for (int i = 0; i < 12; i++)
            {
                if (Int32.TryParse(lists[i].ToString(), out int result))
                {
                    total += result * (13 - i);
                }
                else
                {
                    return BadRequest(new { success = false, error_code = "001", error_msg = "citizen_id invalid" });
                }
            }
            int modValue = total % 11;
            int state5 = 11 - modValue;
            char[] liststate = state5.ToString().ToCharArray();
            int checkDigit = Int32.Parse(liststate[liststate.Length - 1].ToString());
            if (checkDigit.ToString() != lists[12].ToString()) {
                return BadRequest(new { success = false, error_code = "001", error_msg = "citizen_id invalid" });
            }
            return Ok(new {success = true,error_code = "200",error_msg=""});
        }

        [HttpPost]
        public ActionResult Post(string citizen_id)
        {
            return Get(citizen_id);
        }
    }
}

