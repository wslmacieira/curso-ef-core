using System;
using System.Linq;
using Curso.Domain;
using Curso.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Curso
{
    class Program
    {
        static void Main(string[] args)
        {
            /* using var db = new Data.ApplicationContext();

             // db.Database.Migrate();
             var existe = db.Database.GetPendingMigrations().Any();
             if (existe)
             {
                 //
             }*/
            // InserirDados();
            // InserirDadosEmMassa();
            ConsultarDados();
        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            // var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.Clientes
                .Where(p => p.Id > 0)
                .OrderBy(p => p.Id)
                .ToList();
            foreach (var cliente in consultaPorMetodo)
            {
                Console.WriteLine($"Consultando Cliente: {cliente.Id}");
                // db.Clientes.Find(cliente.Id);
                db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
            }
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto teste",
                CodigoBarras = "123456789",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaVenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Wagner Santos Lima",
                CEP = "99999999",
                Cidade = "São Paulo",
                Estado = "SP",
                Telefone = "99002200331"
            };

            var listaClientes = new[]
            {
                new Cliente
            {
                Nome = "Wagner Santos Lima",
                CEP = "999999999",
                Cidade = "São Paulo",
                Estado = "SP",
                Telefone = "990022003311"
            },
                new Cliente
            {
                Nome = "Daniela Santos Lima",
                CEP = "999999999",
                Cidade = "São Paulo",
                Estado = "SP",
                Telefone = "990022003311"
            },
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(produto, cliente);
            // db.Set<Cliente>().AddRange(listaClientes);
            // db.Clientes.AddRange(listaClientes);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registro(s): {registros}");
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto teste",
                CodigoBarras = "123456789",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaVenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            // db.Produtos.Add(produto);
            // db.Set<Produto>().Add(produto);
            // db.Entry(produto).State = EntityState.Added;
            db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registro(s): {registros}");

        }
    }
}
