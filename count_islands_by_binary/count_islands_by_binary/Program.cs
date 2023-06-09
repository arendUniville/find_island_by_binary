using count_island_by_binary.Entity;
using System;
using System.Drawing;


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


        int[,] matrixInt =
        {
            {0, 1, 2, 3, 4},
            {5, 6, 7, 8, 9},
            {10, 11, 12, 13, 14},
            {15, 16, 17, 18, 19}
        };



        ShowMatrixInt(matrixInt);


        int totalIslands = CountIslandsInt(matrixInt);


        Console.WriteLine($"Total islands: {totalIslands}");


    }


    public static int CountIslandsInt(int[,] matrix)
    {

        int iLine = matrix.GetLength(0) - 1;
        int iCol = matrix.GetLength(1) - 1;


        List<SpotInt> spots = new List<SpotInt>();
        List<SpotInt> islands = new List<SpotInt>();



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


                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Actual value: [{value}] / index: [{index[0]},{index[1]}]");


                //Verificando se é o primeiro valor da matriz
                if (a == 0 && b == 0)
                {
                    SpotInt spot = new SpotInt(index, value, null, null, null, null);
                    spots.Add(spot);

                    Console.WriteLine($"Left(val: null) | index([null, null])");


                }
                //Verificando se é a primeira linha, após a primeira coluna e antes da última
                else if (a == 0 && b != 0)
                {

                    SpotInt westValue = spots.Where(s => s.Index[0] == a && s.Index[1] == (b - 1)).First();
                    SpotInt spot = new SpotInt(index, value, null, null, null, westValue);
                    spots.Add(spot);

                    Console.WriteLine($"Left(val {westValue.Value}) | index([{westValue.Index[0]}, {westValue.Index[1]}])");


                }
                else if (a != 0 && b == 0)
                {

                    SpotInt northValue = spots.Where(s => s.Index[0] == (a - 1) && s.Index[1] == b).First();
                    SpotInt spot = new SpotInt(index, value, northValue, null, null, null);
                    spots.Add(spot);

                    Console.WriteLine($"North(val: {northValue.Value}) | index([{northValue.Index[0]}, {northValue.Index[1]}])");
                    Console.WriteLine($"West(val: null | index(null, null])");


                }
                else if (a != 0 && b != 0)
                {

                    SpotInt westValue = spots.Where(s => s.Index[0] == a && s.Index[1] == (b - 1)).First();
                    SpotInt northValue = spots.Where(s => s.Index[0] == (a - 1) && s.Index[1] == b).First();
                    SpotInt spot = new SpotInt(index, value, northValue, null, null, westValue);
                    spots.Add(spot);


                    Console.WriteLine($"North(val: {northValue.Value}) | index([{northValue.Index[0]}, {northValue.Index[1]}])");
                    Console.WriteLine($"West(val: {westValue.Value}) | index([{westValue.Index[0]}, {westValue.Index[1]}])");


                }


                Console.WriteLine();

                Console.Read();

            }


        }



        return 0;

    }

    public static int CountIslandsBool(bool[,] matrix)
    {

        int iLine = matrix.GetLength(0) - 1;
        int iCol = matrix.GetLength(1) - 1;


        List<SpotBool> islands = new List<SpotBool>();



        for (int a = 0; a <= iLine; a++)
        {

            for (int b = 0; b <= iCol; b++)
            {


                long iNorth;
                long iSouth;
                long iLest;
                long iWest;


                long[] index = { a, b };

                bool value = matrix[index[0], index[1]];

                Console.WriteLine($"Actual index: [{index[0]},{index[1]}]");
                Console.WriteLine($"Value: [{value}]");


                //Verificando se é o primeiro valor da matriz
                if (a == 0 && b == 0)
                {

                    Console.WriteLine("Primeiro valor\n");

                }
                //Verificando se é a última linha da matriz
                else if (a == iLine && b == 0)
                {
                    Console.WriteLine("Ultima linha\n");
                }
                //Verificando se é a primeira linha, após a primeira coluna e antes da última
                else if (a == 0 && b != 0)
                {


                    bool leftValue = matrix[a, (b - 1)];

                    SpotBool leftSpot = new SpotBool(index, leftValue);


                    SpotBool spot = new SpotBool(index, value, null, null, null, leftSpot);


                    Console.WriteLine($"Left: val {leftSpot.Value} | index [{leftSpot.Index[0]}, {leftSpot.Index[1]}]");
                    Console.WriteLine($"Spot: val {spot.Value} | index [{spot.Index[0]}, {spot.Index[1]}]");
                    Console.WriteLine();

                    Console.Read();

                }

                Console.WriteLine($"B: {b}\n\n----------\n");

            }

            Console.WriteLine($"A: {a}\n\n--------\n");

        }



        return 0;

    }




    public static void ShowMatrixInt(int[,] matrix)
    {

        int lines = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int lne = matrix.GetLength(0) - 1;
        int col = matrix.GetLength(1) - 1;


        int a = 0;
        int b = 0;


        Console.WriteLine("--------------------");
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

        Console.WriteLine("--------------------");


    }

    public static void ShowMatrixBool(bool[,] matrix)
    {

        int lines = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int lne = matrix.GetLength(0) - 1;
        int col = matrix.GetLength(1) - 1;


        int a = 0;
        int b = 0;


        Console.WriteLine("--------------------");
        Console.WriteLine($"Lines: {lines}");
        Console.WriteLine($"columns: {columns}\n");


        for (a = 0; a <= lne; a++)
        {
            b = 0;
            //Console.WriteLine($"A: {a}");
            Console.Write($"[{matrix[a, b]}, ");

            for (; b <= col; b++)
            {

                //Console.WriteLine($"B: {b} | col: {col}");

                if (b == col)
                {
                    //Console.WriteLine($"B1: {b} | Col: {col}");
                    Console.Write($"{matrix[a, b]}]");
                }
                else
                {

                    //Console.WriteLine($"B2: {b}");
                    Console.Write($"{matrix[a, b]}, ");


                }
            }

            Console.WriteLine("");

        }

        Console.WriteLine("--------------------");


    }



}