using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste02.Domain;
using Teste02.Domain.Repositories;
using Teste02.Infra.Data.DAO;

namespace Teste02.Infra.Data
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly EquipamentoDao _equipamentoDao;
        public EquipamentoRepository()
        {
            _equipamentoDao = new EquipamentoDao();
        }
        public void AdicionarEquipamento(Equipamento equipamento)
        {
            _equipamentoDao.AdicionarEquipamento(equipamento);
        }

        public void AtualizarEquipamento(Equipamento equipamento)
        {
            _equipamentoDao.AtualizarEquipamento(equipamento);
        }

        public List<Equipamento> ObterTodosEquipamentos()
        {
            return _equipamentoDao.BuscarTodos();
        }

        public void RemoverEquipamento(Equipamento equipamento)
        {
            _equipamentoDao.DeletarEquipamento(equipamento);
        }
    }
}
