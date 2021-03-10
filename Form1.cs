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



// exception occurs when space clicked is in the outer most col/row <-- to fix
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
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10}};
        GImageArray gameBoard;
        string player1;
        string player2;  
        int isPlaying = 0;
        int player0Score;
        int player1Score;
       
       





        public Form1()
        {
            InitializeComponent();
        }


        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (player1TextBox.Text == "" || player2TextBox.Text == "")
            {
                MessageBox.Show("Please set the player names");
            }

            else
            {
                gameBoard = new GImageArray(this, gameSpace, 50, 50, 50, 50, 0, imageDirectory);
                gameBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                player1Score = 2;
                player0Score = 2;
                player0ScoreLabel.Text = player0Score.ToString();
                player1ScoreLabel.Text = player1Score.ToString();

            }

        }


        public void Which_Element_Clicked(object sender, EventArgs e)
        {

            int r = gameBoard.Get_Row(sender);
            int c = gameBoard.Get_Col(sender);

            bool validPosition = IsValidPosition(r, c);

            if (validPosition == true)
            {
                {
                    FlipNorth(r, c);
                    FlipSouth(r, c);
                    FlipEast(r, c);
                    FlipWest(r, c);
                    FlipSouthEast(r, c);
                    FlipNorthEast(r, c);
                    FlipNorthWest(r, c);
                    FlipNorthEast(r, c);
                }




            }






            // put the values for their true or false into a local list then run the ones which are in the list? 



            else
            {
                MessageBox.Show("Invalid placement - place in an empty space next to an opposing token");
            }
        }
       /* public void startNewGame_Click(object sender, EventArgs e)
        {

            if (player1TextBox.Text == "" || player2TextBox.Text == "")
            {
                MessageBox.Show("Please set the player names");
            }

            else
            {
                gameBoard = new GImageArray(this, gameSpace, 50, 50, 50, 50, 0, imageDirectory);        
                gameBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                player1Score = 2;
                player0Score = 2;
                player0ScoreLabel.Text = player0Score.ToString();
                player1ScoreLabel.Text = player1Score.ToString();
               
            }

        }


        public void Which_Element_Clicked(object sender, EventArgs e)
        {

            int r = gameBoard.Get_Row(sender);
            int c = gameBoard.Get_Col(sender);

            bool validPosition = IsValidPosition(r, c);

            if (validPosition == true)
            {
                {
                    FlipNorth(r, c);
                    FlipSouth(r, c);
                    FlipEast(r, c);
                    FlipWest(r, c);
                    FlipSouthEast(r, c);
                    FlipNorthEast(r, c);
                    FlipNorthWest(r, c);
                    FlipNorthEast(r, c);
                }

               

                
            }




           

            // put the values for their true or false into a local list then run the ones which are in the list? 



            else
            {
                MessageBox.Show("Invalid placement - place in an empty space next to an opposing token");
            }






        }*/







        public bool CheckNorth(int r, int c)
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
                return true;

            }

            else
            {
                return false;
            }

        }


        public bool CheckSouth(int r, int c)
        {
            bool invalidMove = false;
            int newRow = r + 1;
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
                return true;
            }

            else
            {
                return false;
            }

        
           

        }



        public bool CheckEast(int r, int c)
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

                return true;
            }
            else
            {
                return false;
            }

        }


        public bool CheckWest(int r, int c)
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

            if (locationC.Count > 0 && invalidMove != true)
            {

                return true;
            }
            else
            {
                return false;
            }


        }


        public bool CheckNorthWest(int r, int c)
        {
            int newRow = r - 1;
            int newCol = c - 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10 && IsValidPosition(r, c) != false) 
                {
                    locationR.Add(newRow);
                    locationC.Add(newCol);
                    newRow--;
                    newCol--;

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
                return true;
            }


            else
            {
                return false;
            }

        }


        public bool CheckNorthEast(int r, int c) // +1 to col -1 to row
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

                    if (newRow < 0 && newCol < 0)
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
                return true;
            }


            else
            {
                return false;
            }

        }


        public bool CheckSouthWest(int r, int c)
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

                return true;


            }

            else
            {
                return true;
            }
        }

        public bool CheckSouthEast(int r, int c)
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
                return true;

            }
            else
            {
                return false;
            }


        }

        public void FlipNorth(int r, int c)
        {
            bool invalidMove = false;
            int newRow = r - 1;

            bool validMove = CheckNorth(r, c);

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

            if (locationR.Count > 0 && invalidMove != true && validMove != false)
            {

                for (int token = 0; token < locationR.Count; token++)
                {
                    gameSpace[locationR[token], c] = isPlaying;
                    UpdateGameSpace(r, c);
                    if (isPlaying == 0)
                    {
                        
                        int tokensFlipped = locationR.Count;
                        player0Score = player0Score + tokensFlipped + 1;
                        Player1Score = player1Score - tokensFlipped;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                      
                    }
                    else
                    {
                       
                        int tokensFlipped = locationR.Count;
                        player0Score = player0Score - tokensFlipped;
                        Player1Score = player1Score + tokensFlipped + 1;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                        
                    }

                    UpdateGUI(r, c);

                }
            }

            


        }

        public void FlipSouth (int r, int c)
        {
            int newRow = r + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };



            bool validMove = CheckSouth(r, c);


            if (validMove == true)
            {
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

                if (locationR.Count > 0 && invalidMove != true && validMove != false)
                {


                    for (int token = 0; token < locationR.Count; token++)
                    {
                        gameSpace[locationR[token], c] = isPlaying;
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            Player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            Player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }


                        UpdateGUI(r, c);

                    }
                }
            }

            else
            {

            }

            

            

          

        }

        public void FlipWest (int r, int c)
        {
            int newCol = c - 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            bool validMove = CheckWest(r, c);

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

            while (gameSpace[r, newCol] != isPlaying && invalidMove != true && validMove != false);

            if (locationC.Count > 0 && invalidMove != true )
            {
              

                for (int token = 0; token < locationC.Count; token++)
                {
                    gameSpace[r, locationC[token]] = isPlaying;
                    UpdateGameSpace(r, c);
                    if (isPlaying == 0)
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score + tokensFlipped + 1;
                        Player1Score = player1Score - tokensFlipped;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                    }
                    else
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score - tokensFlipped;
                        Player1Score = player1Score + tokensFlipped + 1;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                    }

                    UpdateGUI(r, c);
                }
            }

            else
            {
             
            }
       

        }



        public void FlipEast(int r, int c)
        {
            int newCol = c + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            bool validMove = CheckEast(r, c);

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

            if (locationC.Count > 0 && invalidMove != true && validMove != false)
            {
           

                for (int token = 0; token < locationC.Count; token++)
                {
                    gameSpace[r, locationC[token]] = isPlaying;
                    UpdateGameSpace(r, c);
                    if (isPlaying == 0)
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score + tokensFlipped + 1;
                        Player1Score = player1Score - tokensFlipped;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                    }
                    else
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score - tokensFlipped;
                        Player1Score = player1Score + tokensFlipped + 1;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                    }

                    UpdateGUI(r, c);
                }
            }

            else
            {
               
            }
         

        }

        public void FlipNorthWest(int r, int c)
        {
            int newRow = r - 1;
            int newCol = c - 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            bool validMove = CheckNorthWest(r, c);

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

            if (locationR.Count > 0 && invalidMove != true && validMove != false) 
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for(int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            Player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            Player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }

                        UpdateGUI(r, c);
                    }       
                   
                }
            }

            else
            {
                
            }



        }

        public void FlipNorthEast(int r, int c)
        {
            int newRow = r - 1;
            int newCol = c + 1;
            bool invalidMove = false;
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };


            bool validMove = CheckNorthEast(r, c);

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

            if (locationR.Count > 0 && invalidMove != true && validMove != false)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for (int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            Player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            Player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }

                        UpdateGUI(r, c);
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

            bool validMove = CheckSouthEast(r, c);

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

            if (locationR.Count > 0 && invalidMove != true && validMove != false)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for (int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            Player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            Player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }

                        UpdateGUI(r, c);
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
            bool validMove = CheckSouthEast(r, c);
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

            if (locationR.Count > 0 && invalidMove != true && validMove != false)
            {

                for (int tokenRow = 0; tokenRow < locationR.Count; tokenRow++)
                {
                    for (int tokenCol = 0; tokenCol < locationC.Count; tokenCol++)
                    {
                        gameSpace[locationR[tokenRow], locationC[tokenCol]] = isPlaying;
                        UpdateGameSpace(r, c);
                        if(isPlaying == 0)
                    {
                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            Player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                    else
                        {
                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            Player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        UpdateGUI(r, c);
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
            int rowNeg = r - 1;
            int rowPos = r + 1;
            int colNeg = c - 1;
            int colPos = c + 1;

            if (gameSpace[r, c] == 10 && r >= 0 || r <= 7 && c >=  0 || c <= 7)
            {


                if (c == 7 && r == 7)
                {
                    if (gameSpace[rowNeg, c] != isPlaying && gameSpace[rowNeg, c] != 10)
                    {
                        return true;
                    }
                    if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }
                    if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                else if (c == 7 && r == 0)
                {
                    if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }
                    if (gameSpace[rowPos, c] != isPlaying && gameSpace[rowPos, c] != 10)
                    {
                        return true;
                    }
                    if (gameSpace[rowPos, colNeg] != isPlaying && gameSpace[rowPos, colNeg] != 10)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }

                else if (c == 0 && r == 0)
                {
                    if (gameSpace[rowPos, c] != isPlaying && gameSpace[rowPos, c] != 10)
                    {
                        return true;
                    }
                    if (gameSpace[r, colPos] != isPlaying && gameSpace[r, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, colPos] != isPlaying && gameSpace[rowPos, colPos] != 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (c == 0 && r == 7)
                {
                    if (gameSpace[r, colPos] != isPlaying && gameSpace[r, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, c] != isPlaying && gameSpace[rowNeg, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, colPos] != isPlaying && gameSpace[rowNeg, colPos] != 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                else if (r == 7)
                {
                    if (gameSpace[rowNeg, c] != isPlaying && gameSpace[rowNeg, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colPos] != isPlaying && gameSpace[r, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }
                    if (gameSpace[rowNeg, colNeg] != isPlaying && gameSpace[rowNeg, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, colPos] != isPlaying && gameSpace[rowNeg, colPos] != 10)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else if (r == 0)
                {
                    if (gameSpace[rowPos, colPos] != isPlaying && gameSpace[rowPos, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, colNeg] != isPlaying && gameSpace[rowPos, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, c] != isPlaying && gameSpace[rowPos, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colPos] != isPlaying && gameSpace[r, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }


                else if (c == 0)
                {
                    if (gameSpace[rowPos, c] != isPlaying && gameSpace[rowPos, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, c] != isPlaying && gameSpace[rowNeg, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colPos] != isPlaying && gameSpace[r, colPos] != 10)
                    {
                        return true;
                    }

                     if (gameSpace[rowNeg, colPos] != isPlaying && gameSpace[rowNeg, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, colPos] != isPlaying && gameSpace[rowPos, colPos] != 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                else if (c == 7)
                {
                    if (gameSpace[rowPos, colNeg] != isPlaying && gameSpace[rowPos, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, colNeg] != isPlaying && gameSpace[rowNeg, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, c] != isPlaying && gameSpace[rowNeg, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, c] != isPlaying && gameSpace[rowPos, c] != 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

               

                else
                {
                    if (gameSpace[rowNeg, colNeg] != isPlaying && gameSpace[rowNeg, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowNeg, colPos] != isPlaying && gameSpace[rowNeg, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, colPos] != isPlaying && gameSpace[rowPos, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, colNeg] != isPlaying && gameSpace[rowPos, colNeg] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[rowPos, c] != isPlaying && gameSpace[rowPos, c] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colPos] != isPlaying && gameSpace[r, colPos] != 10)
                    {
                        return true;
                    }
                     if (gameSpace[r, colNeg] != isPlaying && gameSpace[r, colNeg] != 10)
                    {
                        return true;
                    }

                     if (gameSpace[rowNeg, c] != isPlaying && gameSpace[rowNeg, c] != 10)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }

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


        private int Player1Score 
        {
            get { return player1Score; }
            set { 
                if (player1Score > value) 
                {
                    isPlaying = 1; 
                }
                else if (player1Score < value) 
                {
                    isPlaying = 0;
                }
                else
                {
                    MessageBox.Show("Invaild Move");
                }

                player1Score = value;
            } 
        }

       
    }


}






