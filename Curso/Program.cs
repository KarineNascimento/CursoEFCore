using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using System;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //using var db = new Data.ApplicationContext();
            //db.Database.Migrations();

            //InserirDados();
            //InserirDadosEmMassa();
        }
        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "123456789123",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var lstClientes = new[]
            {
               new Cliente
               {
               Nome = "Karine Iasmim",
                CEP = "99999999",
                Cidade = "GRU",
                Estado = "SP",
                Telefone = "11999999999"
               },
               new Cliente
               {
               Nome = "Cliente Teste",
                CEP = "0000000000",
                Cidade = "GRU",
                Estado = "SP",
                Telefone = "1190000001"
               }
            };

            using var db = new Data.ApplicationContext();
            //db.AddRange(produto, cliente);
            db.Produtos.Add(produto);
            db.Clientes.AddRange(lstClientes);
            var registros = db.SaveChanges();

            Console.WriteLine($"Total de Registros(s): {registros}");
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "123456789123",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            db.Produtos.Add(produto);
            var registros = db.SaveChanges();

            Console.WriteLine($"Total de Registros(s): {registros}");
        }
    }
}
