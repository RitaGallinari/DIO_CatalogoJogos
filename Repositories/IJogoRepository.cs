using CatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoJogos.Repositories
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogos>> Obter(int pagina, int quantidade);
        Task<Jogos> Obter(Guid id);
        Task<List<Jogos>> Obter(string nome, string produtora);
        Task Inserir(Jogos Jogo);
        Task Atualizar(Jogos Jogo);
        Task Remover(Guid id);
    }
}
