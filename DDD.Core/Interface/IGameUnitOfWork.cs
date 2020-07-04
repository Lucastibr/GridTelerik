using Codout.Framework.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using DDD.Core.Repository;

namespace DDD.Core.Interface
{
    public interface IGameUnitOfWork : IUnitOfWork
    {
        IGameRepository Game { get; }

        IGenderRepository Gender { get; }
    }
}
