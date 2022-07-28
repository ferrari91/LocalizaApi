using Localiza.Data.Interfaces;
using Localiza.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Data.Repositories
{
    public class RepositoryLocação : RepositoryBase<TabLocacao>, IRepositoryLocação
    {
        public RepositoryLocação(bool saves = true) : base(saves)
        {

        }
    }
}
