using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Exceptions
{
    public class jogoJaCadastradoException : Exception
    {
        public jogoJaCadastradoException()

        : base("Este jogo já está cadastrado")
        { }
    }
}
