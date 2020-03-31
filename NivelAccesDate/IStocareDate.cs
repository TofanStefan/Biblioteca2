using System;
using System.Collections.Generic;
using EvidentaBiblioteca;

namespace NivelAccesDate
{
    public interface IStocareDate
    {
        void AdaugaCarte(Carte book);
       Carte[] GetCarti(out int nrCarti);


    }
}
