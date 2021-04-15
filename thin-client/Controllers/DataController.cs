using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace thin_client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "red", "class","instead", "thisIsALongWordWithTheWordRedAtTheEndOfIt" ,"local", "bread", "anyone","stiff","combine","thus","citizen","rocket","someone","dream","process","human","completely","enjoy","nothing","shorter","did","baseball","joy","ordinary","business","student","pet","correctly","positive","tell","figure","new","bit","cool","girl","village","given","southern","decide","cause","fighting","thin","swung","public","nearby","percent","problem","expression","west","customs","cost","read","length","exchange","want","choice","map","draw","label","earth","successful","element","meat","bag","further","this","guard","deer","am","night","knew","likely","short","catch","compare","lot","wear","fish","loud","earlier","way","island","magic","strike","store","roll","hospital","per","needs","black","run","rubber","coffee","individual","article","willing","maybe","signal","press","help","few",
"region","vertical","fellow","design","instead","meet","hungry","hundred","underline","grandfather","queen","silence","kids","so","began","caught","pot","brave","me","mix","aloud","mark","fellow","quick","excitement","empty","how","station","ate","been","studied","nose","citizen","breath","trace","zoo","got","chief","do","mostly","ocean","he","exactly","review","it","naturally","handsome","other","floor","frame","toward","tried","team","stone","village","age","brick","deal","official","spend","government","porch","suddenly","chance","piece","nobody","consonant","collect","brick","pencil","ordinary","troops","massage","regular","some","control","powder","plus","attached","bow","writer","screen","mail","special","larger","pack","snow","bag","frighten","stepped","student","there","spell","boat","scientific","structure","everyone","position"
        };

        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ReturnObject Get()
        {
            return new ReturnObject(){
                Data = Summaries
            };
        }

        [HttpGet]
        [Route("should-be-red/{value}")]
        public bool ShouldBeRed(string value)
        {
            var charArray = value.ToCharArray();
            for (var i = 0; i < charArray.Length; i++) {
                if (charArray[i] == 'r'){
                    for (var j = i + 1 ; j < charArray.Length; j++){
                        if (charArray[j] == 'e') {
                            for (var k = j + 1; k < charArray.Length; k++) {
                                if (charArray[k] == 'd') {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public class ReturnObject {
            public string[] Data { get; set; }
        }
    }
}
