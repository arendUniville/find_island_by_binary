namespace count_island_by_binary.Entity;


class SpotInt
{

    public long[] Index { get; set; }//Onde o spot está localizado na matriz
    public int Value { get; set; } // Valor do spot na matriz
    
    public SpotInt? North { get; set; } //Índice do elemento acima dele. North = Posição[x,y - 1]
    public SpotInt? South { get; set; } //Índice do elemento abaixo dele. South = Posição[x,y + 1]
    public SpotInt? Lest { get; set; } //Índicedo elemento ao lado esquerdo dele. Lest = Posição[x + 1,y]
    public SpotInt? West { get; set; } //Índicedo elemento ao lado direito dele. West = Posição[x - 1,y]

    public SpotInt(long[] index, int value)
    {
        Index = index ?? throw new ArgumentNullException(nameof(index));
        Value = value;
    }

    public SpotInt(long[] index, int value, SpotInt n, SpotInt s, SpotInt l, SpotInt w)
    {
        Index = index ?? throw new ArgumentNullException(nameof(index),"Valor do index do spot está incorreto.");
        Value = value;
        North = n ?? null;
        South = s ?? null;
        Lest = l ?? null;
        West = w ?? null;
    }
}
