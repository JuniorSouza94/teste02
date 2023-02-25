using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste02.Domain.Repositories
{
    public interface IChamadoRepository
    {
        // Adiciona um novo chamado ao repositório
        void AdicionarChamado(Chamado chamado);

        // Retorna todos os chamados do repositório
        List<Chamado> ObterTodosChamados();

        // Remove um chamado do repositório com base no seu Id
        void RemoverChamado(Chamado chamadoDeletado);
    }
}
