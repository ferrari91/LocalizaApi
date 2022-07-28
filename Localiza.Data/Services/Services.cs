using Localiza.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Data.Services
{
    public class ServiceCliente
    {
        public RepositoryCliente _Repository { get; set; }

        public ServiceCliente()
        {
            _Repository = new RepositoryCliente();
        }
    }

    public class ServiceVeiculo
    {
        public RepositoryVeiculo _Repository { get; set; }

        public ServiceVeiculo()
        {
            _Repository = new RepositoryVeiculo();
        }
    }

    public class ServiceVeiculoModelo
    {
        public RepositoryVeiculoModelo _Repository { get; set; }

        public ServiceVeiculoModelo()
        {
            _Repository = new RepositoryVeiculoModelo();
        }
    }
}
