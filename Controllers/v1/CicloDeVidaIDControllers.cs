using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoJogos.Controllers.v1
{
    [Route("api/v1/controller]")]
    [ApiController]
    public class CicloDeVidaIDControllers : ControllerBase
    {
        // gera instancia e fica ate sair do projeto

        public readonly IExemploSingleton _exemploSingleton1;
        public readonly IExemploSingleton _exemploSingleton2;

        //Instanci que perdura durante toda requisição 
        public readonly IExemploScoped _exemploScoped1;
        public readonly IExemploScoped _exemploScoped2;

        // cada vez que injeta, tem uma nova instancia 
        public readonly IExemploTransient _exemploTransient1;
        public readonly IExemploTransient _exemploTransient2;

        public CicloDeVidaIDControllers(IExemploSingleton exemplSingleton1,
                                        IExemploSingleton exemplSingleton2,
                                        IExemploScoped exemploScoped1,
                                        IExemploScoped exemploScoped2,
                                        IExemploTransient exemploTransient1,
                                        IExemploTransient exemploTransient2)
        {
            _exemploSingleton1 = exemplSingleton1;
            _exemploSingleton2 = exemplSingleton2;
            _exemploScoped1 = exemploScoped1;
            _exemploScoped2 = exemploScoped2;
            _exemploTransient1 = exemploTransient1;
            _exemploTransient2 = exemploTransient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1 : {_exemploSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2 : {_exemploSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1 : {_exemploScoped1}");
            stringBuilder.AppendLine($"Scoped 2 : {_exemploScoped2}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"TRansient 1 : {_exemploTransient1}");
            stringBuilder.AppendLine($"TRansient 2 : {_exemploTransient2}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IExemploGeral
    {
        public Guid Id { get; }
    }

    public interface IExemploSingleton : IExemploGeral
    { }

    public interface IExemploScoped : IExemploGeral
    { }

    public interface IExemploTransient : IExemploGeral
    { }

    public class ExemploCicloDeVida : IExemploSingleton, IExemploScoped, IExemploTransient
    {
        private readonly Guid _guid;

        public ExemploCicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }
}
