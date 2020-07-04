using System;
using Codout.Framework.Domain.DAL;

namespace DDD.Core.Domain
{
    public class Game : EntityWithTypedId<Guid?>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal Price { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
