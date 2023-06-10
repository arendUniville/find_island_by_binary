using count_island_by_binary.Entity;
using count_islands_by_binary.Entity;
using System;
using System.Drawing;
using System.Dynamic;

class Progam
{

    public static void Main(String[] args)
    {

        bool[,] matrixBool =
        {
            {true, true, false, false, false},
            {true, true, false, false, false},
            {false, false, true, false, false},
            {false, false, false, true, true}
        };


        int[,] matrixInt0 =
        {
            {1, 1, 1, 0, 0},
            {1, 1, 0, 0, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 0, 1, 1}
        };


        Console.Write("Set total lines: ");
        int lines = int.Parse(Console.ReadLine());

        Console.Write("Set total columns: ");
        int columns = int.Parse(Console.ReadLine());


        Wait();



        int[,] matrixInt = new int[lines, columns];

        int counter = 1;

        for(int a = 0; a < lines; a++)
        {

            for(int b = 0; b < columns; b++)
            {
                matrixInt[a, b] = counter;

                counter++;
            }

        }


        ShowMatrixInt(matrixInt0);
        Console.Write("\nThis is your map, press enter to continue.");
        Console.Read();

        for (int a = 0; a < 3; a++)
        {

            Console.Clear();

            Console.Write($"Scanning map ({a + 1})");

            Thread.Sleep(1000);

        }

        Console.Clear();


        Console.WriteLine("Map has been scanned.");

        Thread.Sleep(1500);

        Console.Clear();

        Console.Write("Press enter to continue.");
        Console.Read();
        Console.Clear();
        Thread.Sleep(500);



        //int totalIslands = CountIslandsInt(matrixInt);
        List<SpotInt> spots = ScanMap(matrixInt0);


        Console.WriteLine("\nThe map has been divided by spots, \neach spot have a north, south, east and west poles that represents your neighborhood.");
        Console.Write("\n\nPress enter to continue.");
        Console.Read();
        Console.Clear();


        List<Island> islands = FindIslands(spots, matrixInt0);

        Console.WriteLine($"Total spots: {spots.Count}");
        Console.WriteLine($"Total islands: {islands.Count}");


        foreach(Island i in islands)
        {
            Console.WriteLine($"[{i.LandSpot.Index[0]}, {i.LandSpot.Index[1]}] | {i.LandSpot}");
        }

    }




    public static List<SpotInt> ScanMap(int[,] matrix)
    {

        int iLine = matrix.GetLength(0) - 1;
        int iCol = matrix.GetLength(1) - 1;


        List<SpotInt> spots = new List<SpotInt>();


        for (int a = 0; a <= iLine; a++)
        {

            for (int b = 0; b <= iCol; b++)
            {


                long iNorth;
                long iSouth;
                long iLest;
                long iWest;


                long[] index = { a, b };

                int value = matrix[index[0], index[1]];


                //Verificando se é o primeiro valor da matriz
                if (a == 0 && b == 0)
                {
                    SpotInt spot = new SpotInt(index, value, null, null, null, null);
                    spots.Add(spot);

                }
                //Verificando se é a primeira linha, após a primeira coluna e antes da última
                else if (a == 0 && b != 0)
                {
                        
                    //Get left value
                    SpotInt westValue = spots.Where(s => s.Index[0] == a && s.Index[1] == (b - 1)).First();

                    //Create actual spot
                    SpotInt spot = new SpotInt(index, value, null, null, null, westValue);

                    //Add actual spot in a spot list
                    spots.Add(spot);



                    //Inserting spot 'east' in previus value
                    westValue.East = spot;


                }
                else if (a != 0 && b == 0)
                {

                    //Get north value
                    SpotInt northValue = spots.Where(s => s.Index[0] == (a - 1) && s.Index[1] == b).First();

                    //Create actual spot
                    SpotInt spot = new SpotInt(index, value, northValue, null, null, null);
                    
                    //Add actual spot in a spot list
                    spots.Add(spot);


                    //Inserting spot 'south' in north value
                    northValue.South = spot;

                }
                else if (a != 0 && b != 0)
                {

                    //Get west value
                    SpotInt westValue = spots.Where(s => s.Index[0] == a && s.Index[1] == (b - 1)).First();

                    //Get north value
                    SpotInt northValue = spots.Where(s => s.Index[0] == (a - 1) && s.Index[1] == b).First();

                    //Create actual spot
                    SpotInt spot = new SpotInt(index, value, northValue, null, null, westValue);

                    //Add actual spot in a spot list
                    spots.Add(spot);


                    //Inserting spot 'south' in north value
                    northValue.South = spot;

                    //Inserting spot 'east' in previus value
                    westValue.East = spot;

                }

            }

        }

        SpotInt objSpot = new SpotInt();
        objSpot.ShowSpotRoundClear(spots, matrix, 100);


        return spots;

    }



    public static List<Island> FindIslands(List<SpotInt> spots, int[,] map)
    {

        List<Island> islands = new List<Island>();


        int countIsland = 1;

        bool isWhater = false;


        Island island = new Island(countIsland);


        foreach (SpotInt s in spots) 
        {

            int truePole = 0;

            //Se encontrou agua
            if (isWhater)
            {
                island = new Island(countIsland);
                isWhater = false;
            }
            else
            {
                countIsland--;
            }


            //Se não estiver nulo
            if (s.North != null)
            {
                if(s.North.Value == 1)
                {
                    //Se já não existir na lista
                    if (!islands.Any(x => x.LandSpot.Index == s.Index))
                    {
                        island.LandSpot = s;
                        islands.Add(island);
                        truePole++;
                    }
                }
            }

            if(s.South != null)
            {
                if (s.South.Value == 1)
                {
                    //Se já não existir na lista
                    if (!islands.Any(x => x.LandSpot.Index == s.Index))
                    {
                        island.LandSpot = s;
                        islands.Add(island);
                        truePole++;
                    }
                }
            }

            if(s.East != null)
            {
                if (s.East.Value == 1)
                {
                    //Se já não existir na lista
                    if (!islands.Any(x => x.LandSpot.Index == s.Index))
                    {
                        island.LandSpot = s;
                        islands.Add(island);
                        truePole++;
                    }
                }
            }

            if(s.West != null)
            {
                if (s.West.Value == 1)
                {
                    //Se já não existir na lista
                    if (!islands.Any(x => x.LandSpot.Index == s.Index))
                    {
                        island.LandSpot = s;
                        islands.Add(island);
                        truePole++;
                    }
                }
            }

            countIsland++;

        }

        return islands;

    }


    public static void ShowMatrixInt(int[,] matrix)
    {

        int lines = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int lne = matrix.GetLength(0) - 1;
        int col = matrix.GetLength(1) - 1;


        int a = 0;
        int b = 0;


        Console.WriteLine($"Lines: {lines}");
        Console.WriteLine($"columns: {columns}\n");


        for (a = 0; a <= lne; a++)
        {
            b = 0;
            //Console.WriteLine($"A: {a}");
            Console.Write($"[");

            for (; b <= col; b++)
            {

                //Console.WriteLine($"B: {b} | col: {col}");

                if (b == col)
                {
                    //Console.WriteLine($"B1: {b} | Col: {col}");
                    if (matrix[a, b] < 10)
                    {
                        Console.Write($"0{matrix[a, b]}]");
                    }
                    else
                    {
                        Console.Write($"{matrix[a, b]}]");
                    }
                }
                else
                {

                    //Console.WriteLine($"B2: {b}");
                    if (matrix[a, b] < 10)
                    {
                        Console.Write($"0{matrix[a, b]}, ");
                    }
                    else
                    {
                        Console.Write($"{matrix[a, b]}, ");
                    }


                }
            }

            Console.WriteLine("");

        }



    }


    public static void Wait()
    {
        Thread.Sleep(500);
        Console.Clear();
    }

}