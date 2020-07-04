using Codout.Framework.NH;
using DDD.Core.Domain;
using DDD.Core.Repository;
using NHibernate;

namespace DDD.Data.Repository
{
    public class RepositoryGame : NHRepository<Game>, IGameRepository
    {
        public RepositoryGame(ISession Session) : base(Session)
        {

        }
    }
}
