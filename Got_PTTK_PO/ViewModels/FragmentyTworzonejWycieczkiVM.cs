using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Got_PTTK_PO.Models;

namespace Got_PTTK_PO.Views
{
    public class FragmentyTworzonejWycieczkiVM
    {
        public List<FragmentWycieczki> Fragmenty { get; set; }

        public FragmentyTworzonejWycieczkiVM()
        {
            Fragmenty = new List<FragmentWycieczki>();
        }
        virtual public void RemoveLastFragment()
        {
            Fragmenty.RemoveAt(Fragmenty.Count-1);
        }
    }
}
