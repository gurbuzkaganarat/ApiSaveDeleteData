using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForm.Entity
{
    public class RootTeam
    {
      
        public List<Team> data { get; set; }

        public Meta meta { get; set; }
    }
}
