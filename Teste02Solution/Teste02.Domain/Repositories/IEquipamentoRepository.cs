using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste02.Domain.Repositories
{
    public interface IEquipamentoRepository
    {
        // Adiciona um novo equipamento ao repositório
        void AdicionarEquipamento(Equipamento equipamento);

        // Atualiza um equipamento existente no repositório
        void AtualizarEquipamento(Equipamento equipamento);

        // Retorna todos os equipamentos do repositório
        List<Equipamento> ObterTodosEquipamentos();

        // Remove um equipamento do repositório com base no seu número de série
        void RemoverEquipamento(Equipamento equipamento);
    }
}
