using Dominio.Interfaces;
using Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoMensagem : IServicoMensagem
    {
        private readonly IMensagem _IMensagem;

        public ServicoMensagem(IMensagem IMensagem)
        {
            this._IMensagem = IMensagem;
        }
        
    }
}
