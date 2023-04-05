using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DamoApi.Controllers
{
    [Route("api/[controller]")]
    public class starController : Controller
    {
        [HttpGet("{amount:int}")]
        public string Get(int amount)
        {
            StringBuilder star = new StringBuilder();
            for (int line = 1; line <= amount; line++)
            {
                if (line == 1)
                {
                    star.AppendLine($"{line,20}{line}");
                }
                else
                {
                    int count = (line - 1) * 2;
                    string L = line + "" + new String('*', count / 2);
                    string R = new String('*', count / 2) + "" + line;
                    star.AppendLine($"{L,20}{R}");
                }
            }
            for (int line = amount-1; line >= 1; line--)
            {
                if (line == 1)
                {
                    star.AppendLine($"{line,20}{line}");
                }
                else
                {
                    int count = (line - 1) * 2;
                    string L = line + "" + new String('*', count / 2);
                    string R = new String('*', count / 2) + "" + line;
                    star.AppendLine($"{L,20}{R}");
                }
            }
            return star.ToString();
        }
    }
}

