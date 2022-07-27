using Localiza.Data.Interfaces;
using Localiza.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<TabCliente>, IRepositoryCliente
    {
        public RepositoryCliente(bool saves = true) : base(saves)
        {

        }

        public override TabCliente SelecionarPrimaryKey(params object[] value)
        {
            var cliente = base.SelecionarPrimaryKey(value);
            cliente.Senha = Functions.Criptografia.Descriptografar(cliente.Senha);
            return cliente;
        }

        public override TabCliente Incluir(TabCliente obj)
        {
            obj.Senha = Functions.Criptografia.Criptografar(obj.Senha);
            return base.Incluir(obj);
        }

        public override TabCliente Editar(TabCliente obj)
        {
            obj.Senha = Functions.Criptografia.Criptografar(obj.Senha);
            return base.Editar(obj);
        }

        public bool Acesso(string Login, string Senha)
        {
            var usuario = _context.TabCliente.Where(c => c.Documento == Login).Where(c => c.Senha == Functions.Criptografia.Criptografar(Senha)).First();

            if (usuario == null || usuario.NivelAcesso <= 0)
                return false;

            return true;
        }


    }
}
