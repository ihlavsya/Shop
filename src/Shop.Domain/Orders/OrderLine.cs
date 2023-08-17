using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Shop.Orders
{
    public class OrderLine : Entity
    {
        public virtual Guid OrderId { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual short Count { get; protected set; } = 0;

        protected OrderLine()
        {

        }

        internal OrderLine(Guid orderId, Guid productId, short count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

        internal void ChangeCount(short newCount)
        {
            Count = newCount;
        }

        public override object[] GetKeys()
        {
            return new Object[] { OrderId, ProductId };
        }
    }
}
