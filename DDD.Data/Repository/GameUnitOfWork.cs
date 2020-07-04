using Codout.Framework.DAL;
using Codout.Framework.NH;
using DDD.Core.Interface;
using DDD.Core.Repository;

namespace DDD.Data.Repository
{
    public class GameUnitOfWork : NHUnitOfWork, IGameUnitOfWork
    {
        public GameUnitOfWork(ITenant tenant) : base(tenant)
        {

        }

        private readonly IGameRepository _gameRepository;

        private readonly IGenderRepository _genderRepository;

        public IGameRepository Game => _gameRepository ?? new RepositoryGame(Session);

        public IGenderRepository Gender => _genderRepository ?? new RepositoryGender(Session);
    }
}
