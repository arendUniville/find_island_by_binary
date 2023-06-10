using count_island_by_binary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_islands_by_binary.Entity;

class Island
{
    public int Id { get; set; }
    public SpotInt LandSpot { get; set; } //Pontos do mapa que juntos formam a ilha



    public Island(int id) 
    {
        Id = id;
    }

    public Island(int id, SpotInt landSpot)
    {
        Id = id;
        LandSpot = landSpot ?? null;
    }






}
