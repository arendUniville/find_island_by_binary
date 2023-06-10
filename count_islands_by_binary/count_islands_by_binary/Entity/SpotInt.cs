using System.Data;

namespace count_island_by_binary.Entity;


class SpotInt
{

    public long[] Index { get; set; }//Onde o spot está localizado na matriz
    public int Value { get; set; } // Valor do spot na matriz

    public SpotInt? North { get; set; } //Índice do elemento acima dele. North = Posição[x,y - 1]
    public SpotInt? South { get; set; } //Índice do elemento abaixo dele. South = Posição[x,y + 1]
    public SpotInt? East { get; set; } //Índicedo elemento ao lado esquerdo dele. Lest = Posição[x + 1,y]
    public SpotInt? West { get; set; } //Índicedo elemento ao lado direito dele. West = Posição[x - 1,y]





    public SpotInt() { }

    public SpotInt(long[] index, int value)
    {
        Index = index ?? throw new ArgumentNullException(nameof(index));
        Value = value;
    }

    public SpotInt(long[] index, int value, SpotInt n, SpotInt s, SpotInt e, SpotInt w)
    {
        Index = index ?? throw new ArgumentNullException(nameof(index), "Valor do index do spot está incorreto.");
        Value = value;
        North = n ?? null;
        South = s ?? null;
        East = e ?? null;
        West = w ?? null;
    }





    public void ShowSpotsDeatils(List<SpotInt> spots)
    {

        List<SpotInt> s = spots;

        object north = null;
        object south = null;
        object east = null;
        object west = null;

        for (int a = 0; a < s.Count; a++)
        {

            north = null;
            south = null;
            east = null;
            west = null;


            Console.WriteLine($"========[{s[a].Index[0]}, {s[a].Index[0]}]========");
            Console.WriteLine($"Value: {s[a].Value}");
            Console.WriteLine($"------------");


            if (s[a].North != null)
            {
                north = s[a].North.Value;
                Console.WriteLine($"North: {north}");
            }
            else
            {
                Console.WriteLine($"North: null");
            }


            if (s[a].South != null)
            {
                north = s[a].South.Value;
                Console.WriteLine($"South: {south}");
            }
            else
            {
                Console.WriteLine($"South: null");
            }


            if (s[a].East != null)
            {
                east = s[a].East.Value;
                Console.WriteLine($"East: {east}");
            }
            else
            {
                Console.WriteLine($"East: null");
            }


            if (s[a].West != null)
            {
                west = s[a].West.Value;
                Console.WriteLine($"West: {west}");
            }
            else
            {
                Console.WriteLine($"West: null");
            }


            Console.WriteLine($"------------\n");

        }


    }


    public void ShowSpotRound(List<SpotInt> spots, int[,] matrix)
    {


        int lines = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        SpotInt north = null;
        SpotInt south = null;
        SpotInt east = null;
        SpotInt west = null;


        foreach (SpotInt s in spots)
        {

            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"Spot: {s.Index[0]}, {s.Index[1]} | Value: {s.Value}");
            Console.WriteLine("--------------------------------");


            for (int a = 0; a < lines; a++)
            {

                north = s.North;
                south = s.South;
                east = s.East;
                west = s.West;


                Console.Write("[");


                for (int b = 0; b < columns; b++)
                {

                    //SpotInt actualSpot = spots.Where(s => s.Index[0] == a && s.Index[1] == b).FirstOrDefault();

                    if (s.Index[0] == a && s.Index[1] == b)
                    {
                        if (s.Value < 10)
                            Console.Write($"0{s.Value}");
                        else
                            Console.Write($"{s.Value}");


                        if (b == (columns - 1))
                            Console.Write($"]\n");
                        else
                            Console.Write($", ");
                    }

                    else if (north != null && north.Index[0] == a && north.Index[1] == b)
                    {
                        if (north.Value < 10)
                            Console.Write($"0{north.Value}");
                        else
                            Console.Write($"{north.Value}");


                        if (b == (columns - 1))
                            Console.Write($"]\n");
                        else
                            Console.Write($", ");

                    }

                    else if (south != null && south.Index[0] == a && south.Index[1] == b)
                    {
                        if (south.Value < 10)
                            Console.Write($"0{south.Value}");
                        else
                            Console.Write($"{south.Value}");


                        if (b == (columns - 1))
                            Console.Write($"]\n");
                        else
                            Console.Write($", ");

                    }

                    else if (east != null && east.Index[0] == a && east.Index[1] == b)
                    {
                        if (east.Value < 10)
                            Console.Write($"0{east.Value}");
                        else
                            Console.Write($"{east.Value}");


                        if (b == (columns - 1))
                            Console.Write($"]\n");
                        else
                            Console.Write($", ");

                    }


                    else if (west != null && west.Index[0] == a && west.Index[1] == b)
                    {
                        if (west.Value < 10)
                            Console.Write($"0{west.Value}");
                        else
                            Console.Write($"{west.Value}");



                        if (b == (columns - 1))
                            Console.Write($"]\n");
                        else
                            Console.Write($", ");

                    }

                    else if(b == (columns - 1))
                    {
                        Console.Write("  ]\n");
                    }
                    else
                    {
                        Console.Write("  , ");
                    }


                }


            }

            Console.WriteLine();

        }



    }
    
    public void ShowSpotRoundClear(List<SpotInt> spots, int[,] matrix, int timeExecution)
    {


        int lines = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        SpotInt north = null;
        SpotInt south = null;
        SpotInt east = null;
        SpotInt west = null;


        foreach (SpotInt s in spots)
        {

            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"Spot: {s.Index[0]}, {s.Index[1]} | Value: {s.Value}");
            Console.WriteLine("--------------------------------");


            for (int a = 0; a < lines; a++)
            {

                north = s.North;
                south = s.South;
                east = s.East;
                west = s.West;


                Console.Write("[");

                if (a == s.Index[0])
                {

                    for (int b = 0; b < columns; b++)
                    {

                        //SpotInt actualSpot = spots.Where(s => s.Index[0] == a && s.Index[1] == b).FirstOrDefault();

                        if (s.Index[0] == a && s.Index[1] == b)
                        {
                            if (s.Value < 10)
                                Console.Write($"0{s.Value}");
                            else
                                Console.Write($"{s.Value}");


                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");
                        }

                        else if (north != null && north.Index[0] == a && north.Index[1] == b)
                        {
                            if (north.Value < 10)
                                Console.Write($"0{north.Value}");
                            else
                                Console.Write($"{north.Value}");


                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");

                        }

                        else if (south != null && south.Index[0] == a && south.Index[1] == b)
                        {
                            if (south.Value < 10)
                                Console.Write($"0{south.Value}");
                            else
                                Console.Write($"{south.Value}");


                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");

                        }

                        else if (east != null && east.Index[0] == a && east.Index[1] == b)
                        {
                            if (east.Value < 10)
                                Console.Write($"0{east.Value}");
                            else
                                Console.Write($"{east.Value}");


                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");

                        }


                        else if (west != null && west.Index[0] == a && west.Index[1] == b)
                        {
                            if (west.Value < 10)
                                Console.Write($"0{west.Value}");
                            else
                                Console.Write($"{west.Value}");



                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");

                        }

                        else if (b == (columns - 1))
                        {
                            Console.Write("  ]\n");
                        }
                        
                        else
                        {
                            Console.Write("  , ");
                        }

                    }

                }

                else
                {

                    for (int b = 0; b < columns; b++)
                    {

                        if (north != null && north.Index[0] == a && north.Index[1] == b)
                        {

                            if (north.Value < 10)
                                Console.Write($"0{north.Value}");
                            else
                                Console.Write($"{north.Value}");


                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");

                        }

                        else if (south != null && south.Index[0] == a && south.Index[1] == b)
                        {

                            if (south.Value < 10)
                                Console.Write($"0{south.Value}");
                            else
                                Console.Write($"{south.Value}");


                            if (b == (columns - 1))
                                Console.Write($"]\n");
                            else
                                Console.Write($", ");

                        }

                        else if (b == (columns - 1))
                        {
                            Console.Write("  ]\n");
                        }

                        else
                        {
                            Console.Write("  , ");
                        }

                    }

                }
            }

            Console.Write("\nPress 'enter' to skip. ");
            Console.ReadLine();

            Thread.Sleep(timeExecution);
            Console.Clear();


        }



    }

}
