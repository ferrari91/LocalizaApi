using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localiza.Data.Interfaces;
using Localiza.Data.Models;
using Localiza.Data.Services;

namespace Localiza.Data.Repositories
{
    public class RepositoryVeiculo : RepositoryBase<TabVeiculo>, IRepositoryVeiculo
    {
        public RepositoryVeiculo(bool saves = true) : base(saves)
        {

        }

        public override List<TabVeiculo> SelecionarTodos()
        {
            ServiceVeiculoModelo service = new ServiceVeiculoModelo();

            var Listagem = base.SelecionarTodos();

            foreach (var item in Listagem)
            {
                var marca = service._Repository.SelecionarPrimaryKey(item.CodigoMarca);
                if (marca != null)
                    item.CodigoMarcaNavigation = marca;
            }

            return base.SelecionarTodos();
        }

        public override TabVeiculo SelecionarPrimaryKey(params object[] value)
        {
            var veiculo = base.SelecionarPrimaryKey(value);

            if (veiculo != null)
            {
                ServiceVeiculoModelo service = new ServiceVeiculoModelo();

                var marca = service._Repository.SelecionarPrimaryKey(veiculo.CodigoMarca);
                if (marca != null)
                    veiculo.CodigoMarcaNavigation = marca;
            }

            return veiculo;
        }

        public List<TbVeiculoModelo> ModelosMarcas()
        {
            RepositoryVeiculoModelo modelo = new RepositoryVeiculoModelo();
            return modelo.SelecionarTodos();
        }
    }

}
