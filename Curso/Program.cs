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

            InserirDados();
        }
        private static void InserirDados()
        {
            var produto = new Produto {
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
