using Academico.Models;

namespace Academico.Repositorio
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private readonly AcademicoContext _context;
        public DepartamentoRepositorio(AcademicoContext academicoContext)
        {
            this._context = academicoContext;
        }

        public TbDepartamento Adicionar(TbDepartamento departamento)
        {
            _context.TbDepartamentos.Add(departamento);
            _context.SaveChanges();
            return departamento;
        }

        public List<TbDepartamento> BuscarTodos()
        {
            return _context.TbDepartamentos.ToList();
        }

        public int ObterUltimoID()
        {
            return _context.TbDepartamentos.Max(d => d.IdDepartamento);
        }

        public TbDepartamento BuscarId(int id)
        {
            return _context.TbDepartamentos.First(d => d.IdDepartamento == id);
        }
        public TbDepartamento Alterar(TbDepartamento departamento)
        {
            TbDepartamento departamentoDB = BuscarId(departamento.IdDepartamento);

            if (departamentoDB == null)
            {
                throw new Exception("Departamento não encontrado.");
            }

            departamentoDB.IdDepartamento = departamento.IdDepartamento;
            departamentoDB.NmDepartamento = departamento.NmDepartamento;
            departamentoDB.Localizacao = departamento.Localizacao;
            departamentoDB.IdGerente = departamento.IdGerente;
            departamentoDB.FgAtivo = departamento.FgAtivo;

            _context.SaveChanges();

            return departamentoDB;
        }

        public bool Apagar(int id)
        {
            TbDepartamento departamentoDB = BuscarId(id);

            if (departamentoDB == null) throw new Exception("Houve um erro");
            _context.TbDepartamentos.Remove(departamentoDB);
            _context.SaveChanges();

            return true;
        }

    }
}
