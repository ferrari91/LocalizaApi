using Localiza.Data.Interfaces;
using Localiza.Data.Models;
using Localiza.Data.Services;
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

        public override List<TabLocacao> SelecionarTodos()
        {
            ServiceVeiculo service = new ServiceVeiculo();

            var Listagem = base.SelecionarTodos();

            foreach (var item in Listagem)
            {
                var veiculo = service._Repository.SelecionarPrimaryKey(item.CodigoVeiculo);
                if (veiculo != null)
                    item.CodigoVeiculoNavigation = veiculo;
            }

            return base.SelecionarTodos();
        }

        public override TabLocacao SelecionarPrimaryKey(params object[] value)
        {
            var locação = base.SelecionarPrimaryKey(value);
            ServiceVeiculo service = new ServiceVeiculo();

            var veiculo = service._Repository.SelecionarPrimaryKey(locação.CodigoVeiculo);
            if (veiculo != null)
                locação.CodigoVeiculoNavigation = veiculo;

            return locação;
        }

        public override TabLocacao Editar(TabLocacao obj)
        {
            decimal horas = Convert.ToDecimal((obj.DataFinal - obj.DataInicial).Value.TotalHours);
            var totalLiquido = obj.CodigoVeiculoNavigation.Valor * horas;
            obj.Total = obj.CodigoVeiculoNavigation.Valor * horas;

            if (obj.CarroLimpo == false)
                obj.Total += (totalLiquido * 30) / 100;
            if (obj.TanqueCheio == false)
                obj.Total += (totalLiquido * 30) / 100;
            if (obj.Amassados == true)
                obj.Total += (totalLiquido * 30) / 100;
            if (obj.Arranhoes == true)
                obj.Total += (totalLiquido * 30) / 100;
          
            return base.Editar(obj);
        }
    }
}
