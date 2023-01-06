using Dominio.Interfaces;
using Entidades.Modelos;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Repositorios
{
    public class RepositorioMensagem : RepositorioGenerico<Mensagem>, IMensagem
    {
        private readonly DbContextOptions<ContextoBase> _OptionsBuilder;

        public RepositorioMensagem()
        {
            _OptionsBuilder = new DbContextOptions<ContextoBase>();
        }
    }
}
