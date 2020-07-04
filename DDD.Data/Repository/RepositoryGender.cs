using Codout.Framework.NH;
using DDD.Core.Domain;
using DDD.Core.Repository;
using NHibernate;

namespace DDD.Data.Repository
{
    public class RepositoryGender : NHRepository<Gender>, IGenderRepository
    {
        public RepositoryGender(ISession Session) : base(Session)
        {

        }
    }
}
