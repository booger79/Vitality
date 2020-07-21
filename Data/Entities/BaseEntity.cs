using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    public class BaseEntity:IBaseEntity
    {
       public Guid Id { get; set; }
       public DateTime CreatedTime { get; set; }

    }
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedTime { get; set; }
        
    }
}
