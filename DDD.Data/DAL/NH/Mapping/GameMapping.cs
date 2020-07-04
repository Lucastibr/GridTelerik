using System;
using System.Collections.Generic;
using System.Text;
using DDD.Core.Domain;
using FluentNHibernate.Mapping;

namespace DDD.Data.DAL.NH.Mapping
{
    public class GameMapping : ClassMap<Game>
    {
        public GameMapping()
        {
            Table("TBGames");
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);

            References(x => x.Gender);
        }
    }
}
