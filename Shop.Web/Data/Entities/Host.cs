
namespace Shop.Web.Data.Entities
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Host:IEntity
    {
         public Host()
        {
            //this.Jornadas = new HashSet<Jornada>();
        }

        public int Id { get; set; }
        public string HostName { get; set; }
        public string Address { get; set; }
        //public  DbGeography PosicionGps { get; set; }
        public string Phone { get; set; }

        //public virtual ICollection<Jornada> Jornadas { get; set; }
    }
}
