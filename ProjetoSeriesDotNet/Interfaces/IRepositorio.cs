using System.Collections.Generic;

namespace ProjetoSeriesDotNet.Interfaces
{
    public interface IRepositorio<T>//Tipo genérico
    {
         List<T> Lista();
         T RetornaPorId(int Id);

         void Insere(T entidade);

         void Exclui(int id);

         void Atualiza(int id, T entidade);

         int ProximoId();
    }
}