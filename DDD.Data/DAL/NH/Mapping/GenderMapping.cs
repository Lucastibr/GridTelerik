using DDD.Core.Domain;
using FluentNHibernate.Mapping;

namespace DDD.Data.DAL.NH.Mapping
{
    public class GenderMapping : ClassMap<Gender>
    {
        public GenderMapping()
        {
            Table("TBGender");
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
        }
    }
}
