using Common.Lib.Core.Context.Interfaces;
using Project.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Lib.Context.Interfaces
{
    public interface ISubjectsRepository : IRepository<Subject>
    {
        Subject FindByName(string name);
    }
}
