using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : Irepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();

        public void Atualizacao(int id, Serie entidade)
        {   
            //Recebe o objeto(série) e adiciona na lista vetor
            listaSerie[id] = entidade;
            //throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
             listaSerie.Add(entidade);
            
        }

        public List<Serie> Lista()
        {
           return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int Id)
        {
            return listaSerie[Id];
        }
    }
}