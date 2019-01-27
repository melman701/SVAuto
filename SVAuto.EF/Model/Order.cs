using System;

namespace SVAuto.EF.Model
{
    public class Order : BaseEntity
    {
        public string Client { get; set; }
        public string Phone { get; set; }
        public string Car { get; set; }
        public string Part { get; set; }
        public DateTimeOffset CreationDateTime { get; set; }
        public DateTimeOffset ModificationDateTime { get; set; }

        public int StatusId { get; set; }
        public virtual OrderStatus Status { get; set; }
    }
}
