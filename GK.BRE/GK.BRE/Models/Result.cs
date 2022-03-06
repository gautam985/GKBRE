using GK.BRE.Models.Enums;
using System.Collections.Generic;

namespace GK.BRE.Models
{
    public class Result
    {
        public ResultCode ResultCode { get; set; }
        public List<string> Errors { get; set; }
        public string Comments { get; set; }
    }
}
