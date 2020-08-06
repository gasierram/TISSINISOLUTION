using System;
using System.Collections.Generic;
using System.Text;

namespace TissiniModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber{ get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
