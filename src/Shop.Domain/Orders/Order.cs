using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Shop.Orders
{
    public class Order : AggregateRoot<Guid>
    {
        public virtual string ReferenceNo { get; protected set; }

        public virtual short TotalItemCount { get; protected set; } = 0;

        public virtual DateTime CreationTime { get; protected set; }

        public virtual List<OrderLine> OrderLines { get; protected set; }

        protected Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public Order(Guid id, string referenceNo)
        {
            Check.NotNull(referenceNo, nameof(referenceNo));

            Id = id;
            ReferenceNo = referenceNo;

            OrderLines = new List<OrderLine>();
        }

        public void AddProduct(Guid productId, short count)
        {
            if (count <= 0)
            {
                throw new ArgumentException(
                    "You can not add zero or negative count of products!",
                    nameof(count)
                );
            }

            var existingLine = OrderLines.FirstOrDefault(ol => ol.ProductId == productId);

            if (existingLine == null)
            {
                OrderLines.Add(new OrderLine(Id, productId, count));
            }
            else
            {
                existingLine.ChangeCount((short)(existingLine.Count + count));
            }

            TotalItemCount += count;
        }
    }

}

