using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //InserirDados();
            //InserirDadosEmMassa();
            //ConsultarDados();
            //CadastrarPedido();
            //ConsultarPedidoCarregamentoAdiantado();
            //AtualizarDados();
            //RemoverRegistro();
        }
        private static void RemoverRegistro()
        {
            using var db = new Data.ApplicationContext();
            var cliente = db.Clientes.Find(2);
            //db.Clientes.Remove(cliente);
            //db.Remove(cliente);
            db.Entry(cliente).State = EntityState.Deleted;
            db.SaveChanges();
        }
        private static void AtualizarDados()
        {
            using var db = new Data.ApplicationContext();
            var cliente = db.Clientes.Find(1);
            cliente.Nome = "Cliente Alterado Passo 1";

            // RASTREAMENTO DA ENTIDADE
            //db.Entry(cliente).State = EntityState.Modified;

            // UPDATE SOBRESCREVE O REGISTRO TODO, ATÉ OS CAMPOS QUE NÃO SOFREU ALTERAÇÃO
            //db.Clientes.Update(cliente);
            db.SaveChanges();
        }
        private static void ConsultarPedidoCarregamentoAdiantado()
        {
            using var db = new Data.ApplicationContext();
            var pedidos = db.Pedidos.Include(k => k.Itens).ThenInclude(k => k.Produto).ToList();

            Console.WriteLine(pedidos.Count);
        }
        private static void CadastrarPedido()
        {
            using var db = new Data.ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido Teste",
                Status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10,
                    }
                },
            };

            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }
        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            //var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultarPorMetodo = db.Clientes.OrderBy(k => k.Id > 0).Where(k => k.Id > 0).ToList();
            foreach (var cliente in consultarPorMetodo)
            {
                Console.WriteLine($"Consultando Clinete: {cliente.Id}");
                //db.Clientes.Find(cliente.Id);
                db.Clientes.FirstOrDefault(k => k.Id == cliente.Id);
            }
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
