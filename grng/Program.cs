
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public static class MainProgram
{

    const int width = 100;
    const int height = 25;

    static readonly List<int[]> Directions2D = new List<int[]>()
    {
        new int[2] {
            0,1 //up
        },
        new int[2] {
            1,0 //right
        },
        new int[2] {
            0,-1 //left
        },
        new int[2] {
            -1,0//down
        },
        new int[2] {
            1,1 //up right
        },
        new int[2] {
            -1,-1//down,left
        },
        new int[2] {
            1,-1//up left
        },
        
        new int[2] {
            -1,1//down right
        },
    };

    const string activeString = "\u2588";
    const string mountainString = "\u2589";
    const string inactiveString = "\u2591";

    const string mapSideLeftString = "\u2551 ";
    const string mapSideRightString = " \u2551\n";

    const string mapSideTopLeft = "\u2554";
    const string mapSideTopRight = "\u2557\n";
    const string mapSideBottomLeft = "\u255A";
    const string mapSideBottomRight = "\u255D\n";
    const string mapSideTopMiddle = "\u2550";
    const string mapSideBottomMiddle = "\u2550";

    const byte TopLeftCode = 255;
    const byte TopRightCode = 254;
    const byte MiddleCode = 253;
    const byte BottomLeftCode = 252;
    const byte BottomRightCode = 251;
    const byte EdgeLeftCode = 250;
    const byte EdgeRightCode = 249;
    static int neighborsToBeActive = 3;
    static float valueForActive = 0.0f;

    private static List<int[]> AllActivePositions;
    static void CheckNeighbors()
    {
        
    }

    static void PrintVoronoiTest()
    {
         VoronoiNoise vN = new VoronoiNoise();
        int displacement = 10;
        var algo = (GRNG.AlgorithmChoices.AdaptedLehmer32);
        vN.displacement = displacement;

        for(var i = 0; i <= (int)GRNG.AlgorithmChoices.Reverse23; i++)
        {
            algo = (GRNG.AlgorithmChoices)i;

            vN = new VoronoiNoise(algo);
            

            Console.WriteLine("\n");
            Console.WriteLine(algo);
            Console.WriteLine("Diplacement of: " + displacement);

            vN.displacement = displacement;

            Console.WriteLine("Voronoi 1D No Distance: " + vN.Sample1D(1));
            Console.WriteLine("Voronoi 2D No Distance: " + vN.Sample2D(1,1));
            Console.WriteLine("Voronoi 3D No Distance: " + vN.Sample3D(1,1,1));
            Console.WriteLine("");
            Console.WriteLine("Voronoi 1D With Distance: " + vN.Sample1D(1,true));
            Console.WriteLine("Voronoi 2D With Distance: " + vN.Sample2D(1,1,true));
            Console.WriteLine("Voronoi 3D With Distance: " + vN.Sample3D(1,1,1,true));
        }

        
        Console.WriteLine("\n");
    }



    static void CreateStringMap(out string[,] stringMap, ref VoronoiNoise vN)
    {
        stringMap = new string[height,width+2];
        AllActivePositions = new List<int[]>();
        var nm = vN.SampleNoiseMap(width,height,2);

        for(var y = 0; y < height; y++)
        {
            stringMap[y,0] = mapSideLeftString;

            for(var x = 1; x < width; x++)
            {
                var currentRand = nm[x-1,y];//(vN.Sample2D(x,y,true));
                
                if(currentRand >= valueForActive && y > 0 && x > 1 && x < width-1 && y < height - 1)
                {
                    stringMap[y,x]=activeString;
                }
                else
                {
                    stringMap[y,x] = inactiveString;
                }
            }

            stringMap[y,width] = mapSideRightString;
            
        }


        for(var y = 1; y < height-1; y++)
        {
            for(var x = 1; x < width-2; x++)
            {
                if(stringMap[y,x] == activeString)
                {
                    var activeNeighborsCount = 0;

                    foreach(var dir in Directions2D)
                    {
                        if(stringMap[y+dir[0],x+dir[1]] == activeString)
                        {
                            activeNeighborsCount++;
                        }
                    }

                    if(activeNeighborsCount < neighborsToBeActive)
                    {
                        stringMap[y,x]=inactiveString;

                        foreach(var dir in Directions2D)
                        {
                            stringMap[y+dir[0],x+dir[1]] = inactiveString;
                        }
                    }
                
                }


                
                

            }
        }


        for(var y = 1; y < height-1; y++)
        {
            for(var x = 1; x < width-2; x++)
            {
                if(stringMap[y,x] == activeString)
                {
                    AllActivePositions.Add(new int[]{y,x});
                }
            }
        }
    }


    static void PrintMap(GRNG.AlgorithmChoices algo, int displacement, ref VoronoiNoise vN)
    {
        string[,] noiseMap = new string[height,width+2];
        byte[,] valueMap = new byte[height,width+2];

        ConsoleColor[,] colorMap = new ConsoleColor[height,width+2];
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        CreateStringMap(out noiseMap, ref vN);

        var savedColor = Console.ForegroundColor;

        Console.Write("\u2554");
        for(var x = 1; x < width+2; x++)
        {
            Console.Write("\u2550");
        }
        Console.Write("\u2557\n");

        foreach(var pos in noiseMap)
        {
            if(pos == inactiveString)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else if(pos == mountainString)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if(pos == activeString)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write(pos);
            Console.ForegroundColor = savedColor;
        }


        


        Console.Write("\u255A");
        for(var x = 1; x < width+2; x++)
        {
            Console.Write("\u2550");
        }
        Console.Write("\u255D\n");

    }

    static void EnterSettings(ref VoronoiNoise vN, ref GRNG.AlgorithmChoices algo, ref int displacement)
    {
        string consoleInput="";
        
        while(true)
        {
            Console.WriteLine("\nSelected Algorithm: " + algo);
            Console.WriteLine("Diplacement of: " + displacement);
            Console.WriteLine("Seed of: " + vN.seed);
            Console.WriteLine("Neighbors to be active: " + neighborsToBeActive);
            Console.WriteLine("Minimum value to be active: " + valueForActive);
            Console.WriteLine("\n");
            Console.WriteLine("Enter input(exit or x for exit, 1 for displacement, 2 for algorithm, 3 for seed, 4 for neighborsToBeActive, 5 for valueForActive):");
            
            consoleInput = Console.ReadLine().ToLower();



            if(consoleInput == "exit" || consoleInput == "x")
                {
                    break;
                }
                else if(consoleInput == "1")
                {
                    Console.WriteLine("Enter Displacement Integer:");

                    var displacementString = Console.ReadLine();

                    if(displacementString != null)
                    {
                        if(!int.TryParse(displacementString, out displacement))
                        {
                            Console.WriteLine("Bad Input");
                            displacement = 100;
                        }
                        
                    }

                    
                }
                else if(consoleInput == "2")
                {
                    Console.WriteLine("Enter Algorithm Integer\n0=AdaptedLehmer32,\n1=Lehmer64,\n2=Xorshift32,\n3=Xorshift64,\n4=Xorshift128,\n5=Wyhash,\n6=Reverse17,\n7=Reverse23,:");

                    string algoString = Console.ReadLine();

                    if(int.TryParse(algoString, out var algoOut))
                    {
                        if(algoOut > 7)
                        {
                            Console.WriteLine("Bad Input");
                            algo=GRNG.AlgorithmChoices.AdaptedLehmer32;
                        }
                        else
                        {
                            algo = (GRNG.AlgorithmChoices)algoOut;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad Input");
                        algo=GRNG.AlgorithmChoices.AdaptedLehmer32;
                    }

                    
                }
                else if(consoleInput == "3")
                {
                    Console.WriteLine("Enter Seed Integer:");

                    var seedString = Console.ReadLine();
                    int newSeed = 0;
                    if(seedString != null)
                    {
                        if(!int.TryParse(seedString, out newSeed))
                        {
                            Console.WriteLine("Bad Input");
                        }
                        else
                        {
                            vN.SetSeed(newSeed);
                        }
                        
                    }
                }
                else if(consoleInput == "4")
                {
                    Console.WriteLine("Enter Integer for the amount of neighbors for position to stay active:");

                    var inputString = Console.ReadLine();
                    int newVal = 0;
                    if(inputString != null)
                    {
                        if(!int.TryParse(inputString, out newVal))
                        {
                            Console.WriteLine("Bad Input");
                        }
                        else
                        {
                            neighborsToBeActive = newVal;
                        }
                        
                    }
                }
                else if(consoleInput == "5")
                {
                    Console.WriteLine("Enter float for the minimum amount for a position to count as active:");

                    var inputString = Console.ReadLine();
                    float newVal = 0;
                    if(inputString != null)
                    {
                        if(!float.TryParse(inputString, out newVal))
                        {
                            Console.WriteLine("Bad Input");
                        }
                        else
                        {
                            valueForActive = newVal;
                        }
                        
                    }
                }
        }
    }

    static void MapProgram()
    {
        VoronoiNoise vN = new VoronoiNoise();
        var algo = (GRNG.AlgorithmChoices.AdaptedLehmer32);
        int displacement = 100;
        

        
        string consoleInput = "";
        while(true)
        {
            Console.WriteLine("\nSelected Algorithm: " + algo);
            Console.WriteLine("Diplacement of: " + displacement);
            Console.WriteLine("Seed of: " + vN.seed);
            Console.WriteLine("Neighbors to be active: " + neighborsToBeActive);
            Console.WriteLine("Minimum value to be active: " + valueForActive);
            Console.WriteLine("\n");
            

            Console.WriteLine("Enter input(exit or x for exit, s for settings, p for print):");

            consoleInput = Console.ReadLine().ToLower();


            if(consoleInput != null)
            {
                if(consoleInput == "exit" || consoleInput == "x")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if(consoleInput == "p")
                {
                    PrintMap(algo,displacement, ref vN);
                }
                else if(consoleInput == "s")
                {
                    EnterSettings(ref vN, ref algo, ref displacement);
                    vN.SetAlgorithm(algo);
                    vN.displacement = displacement;
                }
                
            }

        }

        
        
    }


    public static void Main(string[] args)
    {
        MapProgram();
        
    }


}