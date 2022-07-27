using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localiza.Data.Interfaces;
using Localiza.Data.Models;

namespace Localiza.Data.Repositories
{
    internal class RepositoryVeiculo : RepositoryBase<TabVeiculo>, IRepositoryVeiculo
    {
        public RepositoryVeiculo(bool saves = true) : base(saves)
        {

        }
    }
    
}
