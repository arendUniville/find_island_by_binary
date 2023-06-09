using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_island_by_binary.Entity;

class SpotBool
{

    public long[] Index { get; set; }//Onde o spot está localizado na matriz
    public bool Value { get; set; } // Valor do spot na matriz
    
    public long[]? North { get; set; } //Índice do elemento acima dele. North = Posição[x,y - 1]
    public long[]? South { get; set; } //Índice do elemento abaixo dele. South = Posição[x,y + 1]
    public long[]? Lest { get; set; } //Índicedo elemento ao lado esquerdo dele. Lest = Posição[x + 1,y]
    public SpotBool? West { get; set; } //Índicedo elemento ao lado direito dele. West = Posição[x - 1,y]

    public SpotBool(long[] index, bool value)
    {
        Index = index ?? throw new ArgumentNullException(nameof(index));
        Value = value;
    }

    public SpotBool(long[] index, bool value, long[] n, long[] s, long[] l, SpotBool w)
    {
        Index = index ?? throw new ArgumentNullException(nameof(index),"Valor do index do spot está incorreto.");
        Value = value;
        North = n ?? null;
        South = s ?? null;
        Lest = l ?? null;
        West = w ?? null;
    }
}
