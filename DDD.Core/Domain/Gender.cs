using Codout.Framework.Domain.DAL;
using System;

namespace DDD.Core.Domain
{
    public class Gender : EntityWithTypedId<Guid?>
    {
        public virtual string Name { get; set; }
    }
}
