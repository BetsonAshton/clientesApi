using ClientesApi.Domain.Entities;
using ClientesApi.Domain.Interfaces.Repositories;
using ClientesApi.InfraStructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.InfraStructure.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        public void Create(Cliente entity)
        {
            using (var dataContext = new DataContext())
            {
                try
                {
                    dataContext.Clientes.Add(entity);
                    dataContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Acesso à exceção interna para obter mais detalhes
                    var innerException = ex.InnerException;
                    
                }
            }
        }

        public void Update(Cliente entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Clientes.Attach(entity);
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Cliente entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Clientes.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Cliente GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Clientes.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
