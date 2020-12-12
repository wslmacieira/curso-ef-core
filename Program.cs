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
            InserirDadosEmMassa();
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
