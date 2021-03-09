using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIImageArray;

namespace Othello_Game_Assignment
{
    public partial class Form1 : Form
    {
        string imageDirectory = Directory.GetCurrentDirectory() + "\\images\\";
        int[,] gameSpace = new int[8, 8]
            {{10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,0,1,10,10,10 },
            { 10,10,10,1,0,10,10,10 },
            { 10,10,10,1,10,10,10,10 },
            { 10,10,10,1,10,10,10,10 },
            { 10,10,10,10,10,10,10,10}};
        GImageArray gameBoard;
        string player1;
        string player2;
        int isPlaying = 0;
       
       



        public Form1()
        {
            InitializeComponent();
        }

        public void startNewGame_Click(object sender, EventArgs e)
        {


            if (player1TextBox.Text == "" || player2TextBox.Text == "")
            {
                MessageBox.Show("Please set the player names");
            }

            else
            {
                gameBoard = new GImageArray(this, gameSpace, 50, 50, 50, 50, 0, imageDirectory);

                gameBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);

            }




        }


        public void Which_Element_Clicked(object sender, EventArgs e)
        {


            int r = gameBoard.Get_Row(sender);
            int c = gameBoard.Get_Col(sender);


           if(IsValidPosition(r,c) == true)
            {

                FlipNorth(r, c);
                if(CheckSouth(r,c) == true)
                {
                    FlipSouth(r, c);
                }
                
                if(CheckEast(r,c) == true)
                {
                    FlipEast(r, c);
                }
               
                if (CheckWest(r,c) == true)
                {
                    FlipWest(r, c);
                }
                
                if(CheckNorthEast(r,c) == true)
                {
                    FlipNorthEast(r, c);
                }
                
                if(CheckNorthWest(r,c) == true)
                {
                    FlipNorthWest(r, c);
                }
                
                if(CheckSouthEast(r,c) == true)
                {
                    FlipSouthEast(r, c);
                }
                
                if(CheckSouthWest(r,c) == true)
                {
                    FlipSouthWest(r, c);
                }
                

            
              
            }

            UpdateGameSpace(r, c);
            UpdateGUI(r, c);
            PlayerTurn();

        }




        public bool CheckNorth(int r, int c)
        {
            if (r == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public bool CheckSouth (int r, int c)
        {

            if(r == 7)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        public bool CheckEast(int r, int c)
        {

            if (c == 7)
            {
                return false;
            }
            else
            {
                return true;
            }



        }


        public bool CheckWest(int r, int c)
        {
            if (c == 0)
            {
                return false;
            }
            else
            {
                return true;
            }



        }


        public bool CheckNorthWest(int r, int c)
        {
            if (r == 0 || c == 0)
            {
                return false;
            }
            else
            {
                return true;
            }


        }


        public bool CheckNorthEast(int r, int c)
        {
            if (r == 0 || c == 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool CheckSouthWest(int r, int c)
        {
            if (r == 7 || c == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public bool CheckSouthEast(int r, int c)
        {

            if(r == 7 || c == 7)
            {
                return false;
            }
            else
            {
                return true;
            }
           


            
        }

        public void FlipNorth(int r, int c)
        {
            bool invalidMove = false;
            int newRow = r - 1;

            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, c] != isPlaying && gameSpace[newRow, c] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(c);
                    newRow--;

                    if (newRow <= 0)
                    {
                        invalidMove = true;
                        newRow = 0;
                    }

                    
                }
                else
                {
                    invalidMove = true;
                }

            while (gameSpace[newRow, c] != isPlaying && invalidMove != true);

            if (locationR.Count > 0 && invalidMove != true)
            {
               
                for (int token = 0; token < locationR.Count; token++)
                {
                    gameSpace[locationR[token], c] = isPlaying;

                }
            }

        }

        public void FlipSouth (int r, int c)
        {
            int newRow = r + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, c] != isPlaying && gameSpace[newRow, c] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(c);
                    newRow++;

                    if (newRow > 7)
                    {
                        invalidMove = true;
                        newRow = 7;
                    }

                }

                else
                {
                    invalidMove = true;
                }


            while (gameSpace[newRow, c] != isPlaying && invalidMove != true);

            if (locationR.Count > 0 && invalidMove != true)
            {
            

                for (int token = 0; token < locationR.Count; token++)
                {
                    gameSpace[locationR[token], c] = isPlaying;

                }
            }
        

        }

        public void FlipWest (int r, int c)
        {
            int newCol = c - 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[r, newCol] != isPlaying && gameSpace[r, newCol] != 10)
                {
                    locationC.Add(newCol);
                    locationR.Add(r);
                    newCol--;

                    if (newCol < 0)
                    {
                        invalidMove = true;
                        newCol = 0;
                    }

                    
                }

                else
                {
                    invalidMove = true;
                }

            while (gameSpace[r, newCol] != isPlaying && invalidMove != true);

            if (locationC.Count > 0 && invalidMove == true)
            {
              

                for (int token = 0; token < locationC.Count; token++)
                {
                    gameSpace[r, locationC[token]] = isPlaying;

                }
            }
       

        }



        public void FlipEast(int r, int c)
        {
            int newCol = c + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[r, newCol] != isPlaying && gameSpace[r, newCol] != 10)
                {
                    locationC.Add(newCol);
                    locationR.Add(r);
                    newCol++;

                    if (newCol > 7)
                    {
                        invalidMove = true;
                        newCol = 7;
                    }

                 
                }

                else
                {
                    invalidMove = true;
                }

            while (gameSpace[r, newCol] != isPlaying && invalidMove != true);

            if (locationC.Count > 0 && invalidMove != true)
            {
           

                for (int token = 0; token < locationC.Count; token++)
                {
                    gameSpace[r, locationC[token]] = isPlaying;

                }
            }
         

        }

        public void FlipNorthWest(int r, int c)
        {
            int newRow = r - 1;
            int newCol = c - 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(newCol);
                    newRow--;
                    newCol--;

                    if (newRow < 0 && newCol < 0)
                    {
                        invalidMove = true;
                        newRow = 0;
                        newCol = 0;
                    }

                    
                }

                else
                {
                    invalidMove = true;
                }

            while (gameSpace[newRow, newCol] != isPlaying && invalidMove != true);

            if (locationR.Count > 0 && invalidMove != true)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for(int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                    }       
                   
                }
            }



        }

        public void FlipNorthEast(int r, int c)
        {
            int newRow = r - 1;
            int newCol = c + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(newCol);
                    newRow--;
                    newCol++;

                    if (newRow < 0 && newCol > 7)
                    {
                        invalidMove = true;
                        newRow = 0;
                        newCol = 7;
                    }

                 
                }


                else
                {
                    invalidMove = true;
                } 
            while (gameSpace[newRow, newCol] != isPlaying && invalidMove != true);

            if (locationR.Count > 0 && invalidMove != true)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for (int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                    }

                }
            }



        }

        public void FlipSouthEast(int r, int c)
        {
            int newRow = r + 1;
            int newCol = c + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(newCol);
                    newRow++;
                    newCol++;

                    if (newRow > 7 && newCol > 7)
                    {
                        invalidMove = true;
                        newRow = 7;
                        newCol = 7;
                    }

                   
                }


                else
                {
                    invalidMove = true;
                }

            while (gameSpace[newRow, newCol] != isPlaying && invalidMove != true);

            if (locationR.Count > 0 && invalidMove != true)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for (int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                    }

                }
            }



        }

        public void FlipSouthWest(int r, int c)
        {
            int newRow = r + 1;
            int newCol = c - 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(newCol);
                    newRow++;
                    newCol--;

                    if (newRow > 7 && newCol < 0)
                    {
                        invalidMove = true;
                        newRow = 7;
                        newCol = 0;
                    }

                    
                }

                else
                {
                    invalidMove = true;
                }

            while (gameSpace[newRow, newCol] != isPlaying && invalidMove != true);

            if (locationR.Count > 0 && invalidMove != true)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for (int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                    }

                }
            }



        }









        public void player1TextBox_TextChanged(object sender, EventArgs e)
        {

            TextBox player1TextBox = (TextBox)sender;
            Convert.ToString(player1TextBox.Text);
            player1 = player1TextBox.Text;

        }


        public void player2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox player2TextBox = (TextBox)sender;
            Convert.ToString(player2TextBox.Text);
            player2 = player2TextBox.Text;

        }


        public void PlayerTurn()
        {
            if (isPlaying == 0)
            {
                isPlaying = 1;
            }

            else if (isPlaying == 1)
            {
                isPlaying = 0;
            }

        }


        public bool IsValidPosition(int r, int c)
        {

            PictureBox elementClicked = gameBoard.Get_Element(r, c);


            if (elementClicked.ImageLocation == imageDirectory + "10" + ".PNG")
            {
                return true;
            }

            else
            {
                return false;
            }


        }

        public void UpdateGUI(int r, int c)
        {
            gameBoard.UpDateImages(gameSpace);
        }


        public void UpdateGameSpace(int r, int c)
        {
            gameSpace[r, c] = isPlaying;
        }




        // error with checking what needs to turn - if one statement is true 

        //row - gameSpace[row] = the amount of rows left to check in the array










    }


}






