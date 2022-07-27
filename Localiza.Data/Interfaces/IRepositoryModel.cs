using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Data.Interfaces
{
    public interface IRepositoryModel<T> where T : class
    {
        List<T> SelecionarTodos();

        T SelecionarPrimaryKey(params object[] value);

        T Incluir(T obj);

        T Editar(T obj);

        void Excluir(T obj);

        void Excluir(params object[] value);

        void Salvar();
    }
}
