using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localiza.Data.Interfaces;
using Localiza.Data.Models;

namespace Localiza.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected localizaDBContext _context;
        public bool _Saves = true;

        public RepositoryBase(bool saves = true)
        {
            _Saves = saves;
            _context = new localizaDBContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T Editar(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            if (_Saves)
            {
                _context.SaveChanges();
            }

            return obj;
        }

        public void Excluir(T obj)
        {
           _context.Set<T>().Remove(obj);

            if (_Saves)
            {
                _context.SaveChanges();
            }
        }

        public void Excluir(params object[] value)
        {
            var obj = SelecionarPrimaryKey(value);
            Excluir(obj);
        }

        public T Incluir(T obj)
        {
            _context.Set<T>().Add(obj);

            if (_Saves)
            {
                _context.SaveChanges();
            }
            return obj;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public T SelecionarPrimaryKey(params object[] value)
        {
            return _context.Set<T>().Find(value);
        }

        public List<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList();
        }
    }
}
