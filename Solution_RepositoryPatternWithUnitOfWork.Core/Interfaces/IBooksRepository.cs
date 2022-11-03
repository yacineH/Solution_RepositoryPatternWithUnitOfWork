﻿using Solution_RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_RepositoryPatternWithUnitOfWork.Core.Interfaces
{
    public interface IBooksRepository :IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
