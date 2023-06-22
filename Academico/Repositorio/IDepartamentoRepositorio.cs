using Academico.Models;

namespace Academico.Repositorio
{
    public interface IDepartamentoRepositorio
    { 
        
        TbDepartamento Adicionar(TbDepartamento departamento);
        List<TbDepartamento> BuscarTodos();
        int ObterUltimoID();
        TbDepartamento BuscarId(int id);
        TbDepartamento Alterar(TbDepartamento departamento);

        bool Apagar(int  id);



    }
}

