using Solution_RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_RepositoryPatternWithUnitOfWork.Core.Interfaces
{
    //rassemble tous les repositories
    public interface IUnitOfWork :IDisposable
    {
        IBaseRepository<Author> Authors { get; }

        IBooksRepository Books { get; }

        int Complete();
    }
}
