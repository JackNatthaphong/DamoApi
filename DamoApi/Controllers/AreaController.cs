using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DamoApi.Controllers
{
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(double _base, double height)
        {
            if (_base == 0 || height == 0)
            {
                return BadRequest();
            }
            double areaValue = 0.5 * (_base * height);
            return Ok($"\"area\": {areaValue}");
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post([FromQuery] double _base, double height)
        {
            return Get(_base, height);
        }

        [HttpPut("{_base:double}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(double _base, double height)
        {
            return Get(_base, height);
        }

        [HttpDelete("{_base:double}/{height:double}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(double _base, double height)
        {
            return Get(_base, height);
        }
    }
}

