// Brad Wells
// 11/3/18 (11/9/18)
// CIS129.7785
// This program creates a one player battle ship game where the user will 
// fire at ships that are randomly placed on a board***(RESUBMIT)
//****************************************************************************************

using System;
using static System.Console;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//create grid
//populate grid
//loop start
//ask for(x,y)
//fire at(x,y)
//display grid for player() with hits or misses but not all ships


//continue until all sunk

class Program
{
    static void Main(string[] args)
    {
        // these will act as counters for hits against each ship
        int aircraftCtr = 5;
        int battleshipCtr = 4;
        int destroyerCtr = 3;
        int ptBoatCtr = 2;
        int submarineCtr = 3;

        // number of total ships
        int totalShipctr = 5;


        // list of ships to display to user
        List<String> ships = new List<String>();
        ships.Add("Aircraft Carrier");
        ships.Add("Battleship");
        ships.Add("Destroyer");
        ships.Add("PT Boat");
        ships.Add("Submarine");


        // player grid
        String[,] grid = new String[10, 10];

        // cells required for ships
        int[] SHIP_SIZES = { 5, 4, 3, 2, 3 };


        Populate(grid);
        // SetGridAircraft(grid, 0, 2);
        // SetGridBattleship(grid, 5, 7);

        //*******************************************************************************

        // enter loop for game play. when all ships are sunk gameOver will = true
        bool gameOver = false;
        while (gameOver == false)
        {
            //validation for player response
            String rowResponse;
            bool rowValid = false;

            String colResponse;
            bool colValid = false;

            int row;
            int col;

            String play;

            //give player the ship count and list of ships
            WriteLine("Total ship count: {0}", totalShipctr);
            WriteLine("\nShips that need blasted:");
            foreach (String ship in ships)
            {
                WriteLine(ship);
            }

            // allow player to exit game any time
            Write("\nEnter S to shoot Q to exit C to cheat: ");
            play = ReadLine().ToLower();

            if (play.Equals("q"))
            {
                break;  //quit the loop/game
            }
            else if(play.Equals("c"))
            {
                Cheat(grid);
            }



            else if (play.Equals("s"))
            {
                do
                {
                    //validate that response is on board and an int
                    Write("What row would you like to shoot?");
                    //row = Convert.ToInt32(ReadLine());
                    rowResponse = ReadLine();
                    rowValid = Int32.TryParse(rowResponse, out row);
                    if (rowValid == false)
                    {
                        WriteLine("You must enter a number");

                    }
                    if (row < 0 || row > 9)
                    {
                        WriteLine("You must enter a number between 0 and 9");
                    }
                } while ((rowValid == false) || row > 9 || row < 0);

                do
                {
                    //validate that response is on board and an int
                    Write("What col would you like to shoot?");
                    //int col = Convert.ToInt32(ReadLine());
                    colResponse = ReadLine();
                    colValid = Int32.TryParse(colResponse, out col);
                    if (colValid == false)
                    {
                        WriteLine("You must enter a number");
                    }
                    if (col < 0 || col > 9)
                    {
                        WriteLine("You must enter a number between 0 and 9");
                    }
                } while ((colValid == false) || col > 9 || col < 0);

                //after validation, if input equals empty sea, place an M on the board
                if (grid[row, col].Equals("~"))
                {
                    
                    grid[row, col] = "M";

                    //print board uncomment to see during gameplay
                    WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        Write((i).ToString() + " ");
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j] == "X" || grid[i, j] == "M")
                            {
                                Write(grid[i, j] + "  ");
                            }
                            else
                            {
                                Write("~  ");
                            }
                        }
                        WriteLine();
                    }
                    WriteLine("You missed!");
                }
                else if (grid[row,col].Equals("X") || grid[row,col].Equals("M"))
                {
                    WriteLine("\nThat position has already been fired at!\n");
                }
                else if (grid[row, col].Equals("A"))  // hit Aircraft Carrier
                {
                    
                    //subtract life point from aircraft counter
                    aircraftCtr--;

                    grid[row, col] = "X";            //mark an x for each hit

                   // print board uncomment to see during gameplay
                    WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        Write((i).ToString() + " ");
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j] == "X" || grid[i, j] == "M")
                            {
                                Write(grid[i, j] + "  ");
                            }
                            else
                            {
                                Write("~  ");
                            }

                        }
                        WriteLine();
                    }
                    WriteLine("You hit the Aircraft carrier");
                    if (aircraftCtr == 0)          //if no lifes are left
                    {
                        WriteLine("You sunk the Aircraft carrier!\n");
                        // subtract from total ship count
                        totalShipctr--;
                        //remove it from list of ships
                        ships.Remove("Aircraft Carrier");

                    }
                }
                else if (grid[row, col].Equals("B"))   //hit Battleship
                {
                    

                    battleshipCtr--;

                    grid[row, col] = "X";
                    //print board uncomment to see during gameplay
                    WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        Write((i).ToString() + " ");
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j] == "X" || grid[i, j] == "M")
                            {
                                Write(grid[i, j] + "  ");
                            }
                            else
                            {
                                Write("~  ");
                            }

                        }
                        WriteLine();
                    }
                    WriteLine("You hit the Battleship");
                    if (battleshipCtr == 0)
                    {
                        WriteLine("You sunk the Battleship!");
                        totalShipctr--;
                        ships.Remove("Battleship");

                    }
                }
                else if (grid[row, col].Equals("D"))       //hit Destroyer
                {
                   

                    destroyerCtr--;

                    grid[row, col] = "X";
                    // print board uncomment to see during gameplay
                    WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        Write((i).ToString() + " ");
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j] == "X" || grid[i, j] == "M")
                            {
                                Write(grid[i, j] + "  ");
                            }
                            else
                            {
                                Write("~  ");
                            }

                        }
                        WriteLine();
                    }
                    WriteLine("You hit the Destroyer");
                    if (destroyerCtr == 0)
                    {
                        WriteLine("You sunk the Destroyer!");
                        totalShipctr--;
                        ships.Remove("Destroyer");

                    }
                }
                else if (grid[row, col].Equals("P"))      // hit PT Boat
                {
                    

                    ptBoatCtr--;

                    grid[row, col] = "X";
                    //print board uncomment to see during gameplay
                    WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        Write((i).ToString() + " ");
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j] == "X" || grid[i, j] == "M")
                            {
                                Write(grid[i, j] + "  ");
                            }
                            else
                            {
                                Write("~  ");
                            }

                        }
                        WriteLine();
                    }
                    WriteLine("You hit the PT Boat");
                    if (ptBoatCtr == 0)
                    {
                        WriteLine("You sunk the PT Boat!");
                        totalShipctr--;
                        ships.Remove("PT Boat");

                    }
                }
                else if (grid[row, col].Equals("S"))         //hit submarine
                {
                    

                    submarineCtr--;

                    grid[row, col] = "X";
                    //print board uncomment to see during gameplay
                    WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        Write((i).ToString() + " ");
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j] == "X" || grid[i, j] == "M")
                            {
                                Write(grid[i, j] + "  ");
                            }
                            else
                            {
                                Write("~  ");
                            }

                        }
                        WriteLine();
                    }
                    WriteLine("You hit the Submarine");
                    if (submarineCtr == 0)
                    {
                        WriteLine("You sunk the Submarine!");
                        totalShipctr--;
                        ships.Remove("Submarine");

                    }
                }
                //when no ships are left, exit loop
                if (totalShipctr == 0)                      
                {
                    gameOver = true;
                }
            }
            else                  //if input is invalid 
            {
                //print board uncomment to see during gameplay
                WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    Write((i).ToString() + " ");
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (grid[i, j] == "X" || grid[i, j] == "M")
                        {
                            Write(grid[i, j] + "  ");
                        }
                        else
                        {
                            Write("~  ");
                        }

                    }
                    WriteLine();
                }
                WriteLine("\aYou did not follow directions!\n");
            }
        } // end while game over loop

        WriteLine("Game over");
        ReadKey();
    } // end main

    //// player ships
    //enum ShipType
    //{
    //    Carrier,
    //    Battleship,
    //    Destroyer,
    //    Boat,
    //    Submarine
    //};

    //enum StrikeResult
    //{
    //    Sink,
    //    Hit,
    //    Miss
    //};

    //**********************************************************************************

    // this is a method to set the Aircraft Carrier
    public static void SetGridAircraft(String[,] grid)
    {
        // random numbers for starting position on grid
        Random random = new Random();
        int setRow = random.Next(9);
        int setCol = random.Next(9);
        int q = setRow;
        int w = setCol;

        //for direction
        Random direction = new Random();
        int shipDirection = direction.Next(2);

        bool aircraftSet = false;
        switch (shipDirection)
        {
            //direction vertical
            case 0:
                {
                    while (aircraftSet == false)
                    {

 //use to display actual coordinates                       WriteLine("aircraft: q" + q + "w" + w);
                        if (q > grid.Length)
                        {
                            WriteLine("cant place ship off board");
                            return;
                        }

                        

                        // if every cell in total lengh of ship placed vertical is emmpty
                        if (((q + 4) <= 9) && grid[q, w].Equals("~") && grid[(q + 4), w].Equals("~") && grid[(q+3),w].Equals("~") && grid[(q+2),w].Equals("~") && grid[(q+1),w].Equals("~"))  //this means it has enough room for 5 spaces on board
                        {
                           

                            int ctr = 0;
                            while (ctr < 5)
                            {
                             
                                grid[q, w] = "A";            //mark with an A
                                ctr++;
                                q++;

                            }

                            aircraftSet = true;

                        }
                        else  // start again with new numbers 
                        {
                            q = random.Next(9);
                            w = random.Next(9);
                        }

                    }// end while bool
                } // end case 0
                break;

            // horizontal
            case 1:
                {
                   // WriteLine(shipDirection);
                   // WriteLine("In horizontal aircraft mode");
                    while (aircraftSet == false)
                    {

//use to display actual coordinates                        WriteLine("aircraft: q" + q + "w" + w);
                      
                        //if every cell in length of ship horizontal is empty
                        if (((w+4) <= 9) && grid[q, w].Equals("~") && grid[q, (w+4)].Equals("~") && grid[q,(w+3)].Equals("~") && grid[q,(w+2)].Equals("~") && grid[q,(w+1)].Equals("~") )  //this means it has enough room for 5 spaces on board
                        {
                            int ctr = 0;
                            while (ctr < 5)
                            {
                                grid[q, w] = "A";         //mark with an A
                                ctr++;
                                w++;

                            }
                            aircraftSet = true;

                        }
                        else  //start again with new numbers
                        {

                            q = random.Next(9);
                            w = random.Next(9);
                        }


                    } // end while bool
                } // end case 1
                break;

            } //end switch

    } // end set aircraft


    //************************************************************************************

    // this method sets the Destroyer, same as Aircraft
    public static void SetGridDestroyer(String[,] grid)
    {
        // random starting position
        Random randomD = new Random();
        int setRowD = randomD.Next(9);
        int setColD = randomD.Next(9);
        int q = setRowD;
        int w = setColD;

        //for direction
        Random direction = new Random();
        int shipDirection = direction.Next(2);

        bool destroyerSet = false;

        switch (shipDirection)
        {
            case 0: //vertical 
                {


                    while (destroyerSet == false)
                    {
 // use to display coordinates                       WriteLine("destroyer: q{0} w{1}", q, w);
                        if ((q + 3 <= 9) && grid[q, w].Equals("~") && grid[(q + 3), w].Equals("~") && grid[(q+2),w].Equals("~") && grid[(q+1),w].Equals("~") )
                        {

                            int ctr = 0;
                            while (ctr < 3)
                            {
                                grid[q, w] = "D";
                                ctr++;
                                q++;
                            }
                            destroyerSet = true;
                        }
                        else
                        {
                            q = randomD.Next(9);
                            w = randomD.Next(9);
                        }
                    } // end while 
                } // end case 0
                break;
            case 1:  // horizontal
                {
                    while (destroyerSet == false)
                    {
 // use to display coordinates                       WriteLine("destroyer: q{0} w{1}", q, w);
                        if ((w + 3 <= 9) && grid[q, w].Equals("~") && grid[q, (w+3)].Equals("~") && grid[q,(w+2)].Equals("~") && grid[q,(w+1)].Equals("~"))
                        {

                            int ctr = 0;
                            while (ctr < 3)
                            {
                                grid[q, w] = "D";
                                ctr++;
                                w++;
                            }
                            destroyerSet = true;

                        }
                        else
                        {
                            q = randomD.Next(9);
                            w = randomD.Next(9);
                        }
                    } // end while 
                    break;
                } // end case 1
        } // end switch
        
    } // end setDestroyer

    //************************************************************************************

    // this method sets the PT Boat, same as Aircraft
    public static void SetGridPTBoat(String[,] grid)
    {
        // random starting position
        Random randomP = new Random();
        int setRowP = randomP.Next(9);
        int setColP = randomP.Next(9);

        // for ship direction
        Random direction = new Random();
        int shipDirection = direction.Next(2);

        int q = setRowP;
        int w = setColP;

        bool PTBoatSet = false;

        switch (shipDirection)
        {
            case 0: //vertical
                {
                    while (PTBoatSet == false)
                    {
 // use to display coordinates                       WriteLine("PT Boat: q{0} w{1}", q, w);
                        if (q + 2 <= 9 && grid[q, w].Equals("~") && grid[(q + 2), w].Equals("~") && grid[(q+1),w].Equals("~") )
                        {

                            int ctr = 0;
                            while (ctr < 2)
                            {
                                grid[q, w] = "P";
                                ctr++;
                                q++;
                            }
                            PTBoatSet = true;
                            
                        }
                        else
                        {
                          
                            q = randomP.Next(9);
                            w = randomP.Next(9);
                        }
                    } // end while
                } // end case 0;
                break;
            case 1: // horizontal
                {
                    while (PTBoatSet == false)
                    {
 // use to display coordinates                       WriteLine("PT Boat: q{0} w{1}", q, w);
                        if (w + 2 <= 9 && grid[q, w].Equals("~") && grid[q , (w+2)].Equals("~") && grid[q,(w+1)].Equals("~") )
                        {

                            int ctr = 0;
                            while (ctr < 2)
                            {
                                grid[q, w] = "P";
                                ctr++;
                                w++;
                            }
                            PTBoatSet = true;
                            
                        }
                        else
                        {

                            q = randomP.Next(9);
                            w = randomP.Next(9);
                        }
                    } // end while
                } // end case 1
                break;
        } // end switch
    } // end SetPTBoat

    //***********************************************************************************

    // this method sets the Submarine, same as Aircraft
    public static void SetGridSub(String[,] grid)
    {
        // random starting position
        Random randomS = new Random();
        int setRowS = randomS.Next(9);
        int setColS = randomS.Next(9);

        // for direction
        Random direction = new Random();
        int shipDirection = direction.Next(2);


        int q = setRowS;
        int w = setColS;

        bool subSet = false;

        switch (shipDirection)
        {
            case 0: // vertical
                {
                    while (subSet == false)
                    {
 //                       WriteLine("Sub: q{0} w{1}", q, w);

                        if ((q + 3 <= 9) && grid[q, w].Equals("~") && grid[(q + 3), w].Equals("~") && grid[(q+2),w].Equals("~") && grid[(q+1),w].Equals("~") )
                        {

                            int ctr = 0;
                            while (ctr < 3)
                            {
                                grid[q, w] = "S";
                                ctr++;
                                q++;
                            }
                            subSet = true;
                            
                        }
                        else
                        {
                           
                            q = randomS.Next(9);
                            w = randomS.Next(9);
                        }
                    } // end while
                } // end case 0
                break;
            case 1: // horizontal
                {
                    while (subSet == false)
                    {
 //                       WriteLine("Sub: q{0} w{1}", q, w);

                        if ((w + 3 <= 9) && grid[q, w].Equals("~") && grid[(q), (w+3)].Equals("~") && grid[q,(w+2)].Equals("~") && grid[q,(w+1)].Equals("~") )
                        {


                            int ctr = 0;
                            while (ctr < 3)
                            {
                                grid[q, w] = "S";
                                ctr++;
                                w++;
                            }
                            subSet = true;

                        }
                        else
                        {
                         
                            q = randomS.Next(9);
                            w = randomS.Next(9);
                        }
                    } // end while
                } // end case 1
                break;
        } // end switch
    } // end setGridSub

    //************************************************************************************

    //this method sets the Battleship, same as Aircraft
    public static void SetGridBattleship(String[,] grid)//, int q, int w)
    {
        // random starting position
        Random randomB = new Random();
        int setRowB = randomB.Next(9);
        int setColB = randomB.Next(9);

        //for ship direction
        Random direction = new Random();
        int shipDirection = direction.Next(2);

        int q = setRowB;
        int w = setColB;

        bool battleShipSet = false;

        switch(shipDirection)
        {
            case 0:
                {
                    while(battleShipSet == false)
                    {
 //                       WriteLine("Battleship: q{0} w{1}", q, w);

                        if(q + 3 <=9 && grid[q,w].Equals("~") && grid[(q+3),w].Equals("~") && grid[(q+2),w].Equals("~") && grid[(q+1),w].Equals("~") )
                        {
                            int ctr = 0;
                            while (ctr<4)
                            {
                                grid[q, w] = "B";
                                ctr++;
                                q++;
                            }
                            battleShipSet = true;
                        }
                        else
                        {
                            q = randomB.Next(9);
                            w = randomB.Next(9);
                        }
                    } // end while
                } // end case
                break;

            case 1:
                {
                    while(battleShipSet == false)
                    {
 //                       WriteLine("Battleship: q{0} w{1}", q, w);

                        if (w + 3 <= 9 && grid[q, w].Equals("~") && grid[q, (w + 3)].Equals("~") && grid[q, (w + 2)].Equals("~") && grid[q, (w + 1)].Equals("~"))
                        {
                            int ctr = 0;
                            while (ctr < 4)
                            {
                                grid[q, w] = "B";
                                ctr++;
                                w++;
                            }
                            battleShipSet = true;
                        }
                        else
                        {
                            q = randomB.Next(9);
                            w = randomB.Next(9);
                        }
                    } // end while
                } // end case 1
                break;
        } // end switch

    } // end setBattleship

    //***********************************************************************************


    // populating the grid
    public static void Populate(String[,] grid)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = "~";
            }
            // WriteLine();
        }

        //WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
        //for (int row = 0; row < grid.GetLength(0); row++)
        //{
        //    Write((row).ToString() + " ");
        //    for (int col = 0; col < grid.GetLength(1); col++)
        //    {
        //        Write(grid[row, col] + "  ");
        //    }
        //    WriteLine();
        //}

        // set ships
        SetGridBattleship(grid);
        SetGridAircraft(grid);
        SetGridDestroyer(grid);
        SetGridPTBoat(grid);
        SetGridSub(grid);

        //print grid
        //uncomment to see grid       
        WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            Write((row).ToString() + " ");
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[row, col] == "X" || grid[row, col] == "M")
                {
                    Write(grid[row, col] + "  ");
                }
                else
                {
                    Write("~  ");
                }

            }
            WriteLine();
        }
    } // end populate

   public static void Cheat(String [,] grid)
    {
        WriteLine("  0  1  2  3  4  5  6  7  8  9 ");
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            Write((row).ToString() + " ");
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Write(grid[row, col] + "  ");
            }
            WriteLine();
        }
    }

} // end class Program