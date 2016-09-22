using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.Models;

namespace Ellipsis.Models
{
    public class VideoConvertTaskModel : DataModel
    {
        public string Title { get; set; }
        public string Size { get; set; }
        public string Duration { get; set; }
    }
}
