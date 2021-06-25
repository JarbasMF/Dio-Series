using System.Collections.Generic;
namespace DIO.Series.Interfaces
{
    public interface Irepositorio<L>
    {
         List<L> Lista();
         L RetornaPorId(int Id);

         void Insere(L entidade);

         void Exclui(int id);

         void Atualizacao (int id, L entidade);

         int ProximoId();

    }
}