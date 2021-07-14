using CatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogos> jogos = new Dictionary<Guid, Jogos>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Jogos{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Nome01", Produtora = "Produtora 01", Preco = 10 } },
        };


        public Task<List<Jogos>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogos> Obter(Guid id)
        {
            if (!jogos.ContainsKey (id))
                return Task.FromResult<Jogos>(null);

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogos>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());

        }
        public Task<List<Jogos>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogos>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogos jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogos jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }
        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}