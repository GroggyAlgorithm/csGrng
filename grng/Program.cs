
using System;
using System.Collections;
using System.Collections.Generic;







public static class MainProgram
{

    const int width = 100;
    const int height = 25;

    const string activeString = "\u2588";
    const string inactiveString = "\u2591";


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


    public static void Main(string[] args)
    {

        VoronoiNoise vN;
        var algo = (GRNG.AlgorithmChoices.AdaptedLehmer32);
        int displacement;
        string[,] noiseMap = new string[height,width+2];

        string noiseMapString="";
        displacement = 100;
        vN = new VoronoiNoise(algo);

        Console.WriteLine("\nSelected Algorithm: ");
        Console.WriteLine(algo);
        Console.WriteLine("\nDiplacement of: " + displacement);

        vN.displacement = displacement;

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        noiseMapString+="\u2554";
        for(var x = 1; x < width+2; x++)
        {
            noiseMapString+="\u2550";
        }
        noiseMapString+="\u2557\n";

        for(var y = 0; y < height; y++)
        {
            noiseMap[y,0] = "\u2551 ";

            for(var x = 1; x < width; x++)
            {
                var currentRand = (vN.Sample2D(x,y,true));
                
                if(currentRand >= 0 && y > 0 && x > 1 && x < width-1 && y < height - 1)
                {
                    noiseMap[y,x]=activeString;
                }
                else
                {
                    noiseMap[y,x]=inactiveString;

                }
            }

            noiseMap[y,width]=" \u2551\n";
        }

        // var x = new int[1,1];
        var dirs = new List<int[]>()
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

        for(var y = 1; y < height-1; y++)
        {
            for(var x = 1; x < width-2; x++)
            {
                if(noiseMap[y,x]==activeString)
                {
                    var activeNeighborsCount = 0;

                    foreach(var dir in dirs)
                    {
                        if(noiseMap[y+dir[0],x+dir[1]] == activeString)
                        {
                            activeNeighborsCount++;
                        }
                    }

                    if(activeNeighborsCount < 3)
                    {
                        noiseMap[y,x]=inactiveString;

                        foreach(var dir in dirs)
                        {
                            noiseMap[y+dir[0],x+dir[1]] = inactiveString;
                            
                        }
                    }
                
                }


                
                

            }
        }

        foreach(var pos in noiseMap)
        {

            noiseMapString+=pos;
        }

        noiseMapString+="\u255A";
        for(var x = 1; x < width+2; x++)
        {
            noiseMapString+="\u2550";
            // noiseMapString+="-";
        }
        noiseMapString+="\u255D\n";

        Console.WriteLine(noiseMapString);
    }


}