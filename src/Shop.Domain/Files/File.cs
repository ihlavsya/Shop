using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Shop.Files
{
    public class File : Entity<Guid>
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
    }
}
