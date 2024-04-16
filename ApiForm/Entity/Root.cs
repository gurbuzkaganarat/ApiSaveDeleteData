using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForm.Entity
{
    public class Root
    {
        public int RootId { get; set; }
        public List<Player> data { get; set; }

        
       
        public Meta meta { get; set; }
    }
}
