using System.Collections.Generic;

namespace SVAuto.EF.Model
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
