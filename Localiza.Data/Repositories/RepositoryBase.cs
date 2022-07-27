using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localiza.Data.Interfaces;

namespace Localiza.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Editar(T obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(params object[] value)
        {
            throw new NotImplementedException();
        }

        public T Incluir(T obj)
        {
            throw new NotImplementedException();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }

        public T SelecionarPrimaryKey(params object[] value)
        {
            throw new NotImplementedException();
        }

        public List<T> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
