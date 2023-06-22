
using Academico.Models;

namespace Academico.Repositorio
{
    public interface IEmpregadoRepositorio
    {

        TbEmpregado Adicionar(TbEmpregado empregado);
        List<TbEmpregado> BuscarTodos();
        int ObterUltimoID();

        TbEmpregado BuscarId(int id);

        List<TbEmpregado>BuscarTodos(int id);
        List<TbEmpregado>ToList();

        TbEmpregado Alterar(TbEmpregado empregado);

        TbEmpregado listarid(int id);

    }
}