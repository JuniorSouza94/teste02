using System;
using System.Collections.Generic;
using Teste02.Domain;
using Teste02.Domain.Repositories;
using Teste02.Infra.Data.DAO;

namespace Teste02.Infra.Data
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly ChamadoDao _chamadoDao;
        public ChamadoRepository()
        {
            _chamadoDao = new ChamadoDao();
        }
        public void AdicionarChamado(Chamado novoChamado)
        {
            _chamadoDao.AdicionarChamado(novoChamado);
        }

        public List<Chamado> ObterTodosChamados()
        {
            return _chamadoDao.BuscarTodos();
        }

        public void RemoverChamado(Chamado chamadoDeletado)
        {
            _chamadoDao.DeletarChamado(chamadoDeletado);
        }
    }
}
