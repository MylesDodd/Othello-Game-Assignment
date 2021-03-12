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
        bool gameInProgress;
       
       





        public Form1()
        {
            InitializeComponent();
        }


        public void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveGame();

        }


        public void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadGame();   
        }


        



        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (player1TextBox.Text == "" || player2TextBox.Text == "")
            {
                MessageBox.Show("Please set the player names");
            }

            

            else
            {
                gameInProgress = true;
                gameBoard = new GImageArray(this, gameSpace, 50, 50, 50, 50, 0, imageDirectory);
                gameBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                player1Score = 2;
                player0Score = 2;
                player0ScoreLabel.Text = player0Score.ToString();
                player1ScoreLabel.Text = player1Score.ToString();
                blackPlayingLabel.Visible = true;
                whitePlayingLabel.Visible = false;
                    

            }

        }


        public void Which_Element_Clicked(object sender, EventArgs e)
        {

            int r = gameBoard.Get_Row(sender);
            int c = gameBoard.Get_Col(sender);


            IsValidPosition(r, c);

    
          
        }
     




        public bool CheckNorth(int r, int c)
        {
            bool invalidMove = false;
            int newRow = r - 1;

            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };

            do
                if (gameSpace[newRow, c] != isPlaying && gameSpace[newRow, c] != 10 )
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

            while (gameSpace[newRow, c] != isPlaying && invalidMove != true );

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
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10) 
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
                if (gameSpace[newRow, newCol] != isPlaying && gameSpace[newRow, newCol] != 10 )
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

            while (gameSpace[newRow, newCol] != isPlaying && invalidMove != true );

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

            while (gameSpace[newRow, newCol] != isPlaying && invalidMove != true );

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
                    UpdateGameSpace(r, c);
                    if (isPlaying == 0)
                    {
                        
                        int tokensFlipped = locationR.Count;
                        player0Score = player0Score + tokensFlipped + 1;
                        player1Score = player1Score - tokensFlipped;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                      
                    }
                    else
                    {
                       
                        int tokensFlipped = locationR.Count;
                        player0Score = player0Score - tokensFlipped;
                        player1Score = player1Score + tokensFlipped + 1;
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

                if (locationR.Count > 0 && invalidMove != true )
                {


                    for (int token = 0; token < locationR.Count; token++)
                    {
                        gameSpace[locationR[token], c] = isPlaying;
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }


                        UpdateGUI(r, c);

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
                        player1Score = player1Score - tokensFlipped;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                    }
                    else
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score - tokensFlipped;
                        player1Score = player1Score + tokensFlipped + 1;
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
                    UpdateGameSpace(r, c);
                    if (isPlaying == 0)
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score + tokensFlipped + 1;
                        player1Score = player1Score - tokensFlipped;
                        player0ScoreLabel.Text = player0Score.ToString();
                        player1ScoreLabel.Text = player1Score.ToString();
                    }
                    else
                    {

                        int tokensFlipped = locationC.Count;
                        player0Score = player0Score - tokensFlipped;
                        player1Score = player1Score + tokensFlipped + 1;
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
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            player1Score = player1Score + tokensFlipped + 1;
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
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            player1Score = player1Score + tokensFlipped + 1;
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
                        UpdateGameSpace(r, c);
                        if (isPlaying == 0)
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        else
                        {

                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            player1Score = player1Score + tokensFlipped + 1;
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
                        UpdateGameSpace(r, c);
                        if(isPlaying == 0)
                    {
                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score + tokensFlipped + 1;
                            player1Score = player1Score - tokensFlipped;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                    else
                        {
                            int tokensFlipped = locationR.Count;
                            player0Score = player0Score - tokensFlipped;
                            player1Score = player1Score + tokensFlipped + 1;
                            player0ScoreLabel.Text = player0Score.ToString();
                            player1ScoreLabel.Text = player1Score.ToString();
                        }
                        UpdateGUI(r, c);
                    }
                }
            }
        }




        // remember to change the get set as this is changing the turn as soon as tokens have been changed 




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


        




        
       public void IsValidPosition(int r, int c)
        {
            

            if (gameSpace[r, c] == 10 && r >= 0 || r <= 7 && c >=  0 || c <= 7)
            {


                if (c == 7 && r == 7)
                {
                    if (CheckNorth(r,c) != false)
                    {
                        FlipNorth(r, c);
                       
                    }
                    if (CheckWest(r,c) != false)
                    {

                        FlipWest(r, c);
                    }
                    if (CheckNorthWest(r, c) != false)
                    {

                        FlipNorthWest(r, c);
                    }
                    else if(CheckNorth(r,c) == false && CheckWest(r,c) == false && CheckNorthWest(r,c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }
                }


                else if (c == 7 && r == 0)
                {
                    if ( CheckWest(r,c) != false)
                    {
                        FlipWest(r, c);
                    }
                    if ( CheckSouth(r,c) != false)
                    {
                        FlipSouth(r, c);
                    }
                    if ( CheckSouthWest(r, c) != false)
                    {
                        FlipSouthWest(r, c);
                    }

                    else if (CheckWest(r,c) == false && CheckSouth(r,c) == false && CheckSouthWest(r,c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }

                }

                else if (c == 0 && r == 0)
                {
                    if ( CheckSouth(r, c) != false)
                    {
                        FlipSouth(r, c);
                    }
                    if (CheckEast(r,c) != false) 
                    {
                        FlipEast(r, c);
                    }
                     if (CheckSouthEast(r,c) != false) 
                    {
                        FlipSouthEast(r, c);
                    }
                    else if (CheckSouth(r,c) == false && CheckEast(r,c) == false && CheckSouthEast(r,c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }
                }

                else if (c == 0 && r == 7)
                {
                    if ( CheckEast(r,c) != false)
                    {
                        FlipEast(r, c);
                    }
                     if (CheckNorth(r,c) != false)
                    {
                        FlipNorth(r, c);
                    }
                     if (CheckNorthEast(r,c) != false)
                    {
                        FlipNorthEast(r, c);
                    }
                    else if (CheckEast(r,c) == false && CheckNorth(r,c) == false && CheckNorthEast(r,c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }
                }


                else if (r == 7)
                {
                    if (CheckNorth(r,c) != false)
                    {
                        FlipNorth(r, c);
                    }
                     if ( CheckEast(r,c) != false)
                    {
                        FlipEast(r, c);
                    }
                     if (CheckWest(r,c) != false)
                    {
                        FlipWest(r, c);
                    }
                    if (CheckNorthWest(r,c) != false)
                    {
                        FlipNorthWest(r, c);
                    }
                     if (CheckNorthEast(r,c) != false)
                    {
                        FlipNorthEast(r, c);
                    }

                    else if (CheckNorth(r,c) == false && CheckEast(r,c) == false && CheckWest(r,c) == false && CheckNorthWest(r,c) == false && CheckNorthEast(r,c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }
                }

                else if (r == 0)
                {
                    if (CheckSouthEast(r, c) != false)
                    {
                        FlipSouthEast(r, c);
                    }
                     if (CheckSouthWest(r,c) != false)
                    {
                        FlipSouthWest(r, c);
                    }
                     if (CheckSouth(r,c) != false)
                    {
                        FlipSouth(r,c);
                    }
                     if (CheckEast(r,c) != false)
                    {
                        FlipEast(r, c);
                    }
                     if (CheckWest(r,c) != false)
                    {
                        FlipWest(r, c);
                    }
                    else if(CheckSouth(r, c) == false && CheckEast(r, c) == false && CheckWest(r, c) == false && CheckSouthWest(r, c) == false && CheckSouthEast(r, c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }

                }


                else if (c == 0)
                {
                    if ( CheckSouth(r,c) != false)
                    {
                        FlipSouth(r, c);
                    }
                     if (CheckNorth(r,c) != false)
                    {
                        FlipNorth(r, c);
                    }
                     if (CheckEast(r,c) != false)
                    {
                        FlipEast(r, c);
                    }

                     if (CheckNorthEast(r,c) != false)
                    {
                        FlipNorthEast(r, c);
                    }
                     if (CheckSouthEast(r,c) != false)
                    {
                        FlipSouthEast(r, c);
                    }
                    else if (CheckSouth(r, c) == false && CheckEast(r, c) == false && CheckNorth(r, c) == false && CheckNorthEast(r, c) == false && CheckSouthEast(r, c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }
                }


                else if (c == 7)
                {
                    if (CheckSouthWest(r,c) != false)
                    {
                        FlipSouthWest(r, c);
                    }
                     if ( CheckNorthWest(r,c) != false)
                    {
                        FlipNorthWest(r, c);
                    }
                     if (CheckWest(r,c) != false)
                    {
                        FlipWest(r, c);
                    }
                     if (CheckNorth(r,c) != false)
                    {
                        FlipNorth(r, c);
                    }
                     if ( CheckSouth(r,c) != false)
                    {
                        FlipSouth(r, c);
                    }
                    else if (CheckSouth(r, c) == false && CheckWest(r, c) == false && CheckNorth(r, c) == false && CheckNorthWest(r, c) == false && CheckSouthWest(r, c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }
                }

               

                else
                {
                    if (CheckNorthWest(r, c) != false)
                    {
                        FlipNorthWest(r, c);
                    }
                     if ( CheckNorthEast(r, c) != false)
                    {
                        FlipNorthEast(r, c);
                    }
                     if (CheckSouthEast(r, c) != false)
                    {
                        FlipSouthEast(r, c);
                    }
                     if (CheckSouthWest(r, c) != false)
                    {
                        FlipSouthWest(r, c);
                    }
                     if (CheckSouth(r,c) != false)
                    {
                        FlipSouth(r, c);
                    }
                     if ( CheckEast(r,c) != false)
                    {
                        FlipEast(r, c);
                    }
                     if (CheckWest(r,c) != false)
                    {
                        FlipWest(r, c);
                    }
                     if (CheckNorth(r,c) != false)
                    {
                        FlipNorth(r, c);
                    }

                    else if (CheckNorthWest(r, c) == false && CheckNorthEast(r, c) == false && CheckSouthEast(r, c) == false && CheckSouthWest(r, c) == false && CheckSouth(r, c) == false && CheckEast(r, c) == false && CheckWest(r, c) == false && CheckNorth(r, c) == false)
                    {
                        MessageBox.Show("Invalid move");
                    }

                }


                PlayerTurn();

            }
            else
            {
                MessageBox.Show("Invalid move");
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


      /*  private int Player1Score 
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
        } */


        public void WinnerOfGame()
        {

        }



        public void PlayerTurn()
        {
            if(isPlaying == 1)
            {
                isPlaying = 0;
                blackPlayingLabel.Visible = true;
                whitePlayingLabel.Visible = false;
            }
            else
            {
                isPlaying = 1;
                whitePlayingLabel.Visible = true;
                blackPlayingLabel.Visible = false;
            }
            
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(gameInProgress == true)
            {
              if( MessageBox.Show("Do you want to save your current game?", "Save Game?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveGame();
                }
                else
                {
                    MessageBox.Show("Your game will not be saved");

                }
            }
   
        }



        public void saveGame()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\";



            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save your game";

            saveFileDialog1.ShowDialog();

            if(saveFileDialog1.FileName != "")
            {
                

                var stringBuilder = new StringBuilder();

                foreach (var arrayElement in gameSpace)
                {

                    stringBuilder.Append(arrayElement + ",".ToString());
                }


                stringBuilder.Remove(stringBuilder.Length - 1, 1);

                File.WriteAllText(saveFileDialog1.FileName, stringBuilder.ToString());
            }



        






        }



        public void loadGame()
        {

            


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files(*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Load your game";


            openFileDialog.ShowDialog();


            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();

                StreamReader sr = new StreamReader(fileStream);

                string line = sr.ReadLine();

                List<List<int>> array = new List<List<int>> { };


                var split = line.Split(","); //returns array - returns a 64 element array with each digit (int) in the array

                for (int i = 0; i <= 7; i++) //looping over rows
                {
                    List<int> row = new List<int> { };


                    for (int j = 0; j <= 7; j++) //looping over columns
                    {
                        int index = i * 8 + j;
                        var elementString = split[index];
                        int element = Int32.Parse(elementString);
                        row.Add(element);
                    }

                    array.Add(row);
                }

                gameSpace = new int[8, 8]
                {{array[0][0],array[0][1],array[0][2],array[0][3],array[0][4],array[0][5],array[0][6],array[0][7] },
            { array[1][0],array[1][1],array[1][2],array[1][3],array[1][4],array[1][5],array[1][6],array[1][7] },
            { array[2][0],array[2][1],array[2][2],array[2][3],array[2][4],array[2][5],array[2][6],array[2][7] },
            { array[3][0],array[3][1],array[3][2],array[3][3],array[3][4],array[3][5],array[3][6],array[3][7] },
            { array[4][0],array[4][1],array[4][2],array[4][3],array[4][4],array[4][5],array[4][6],array[4][7] },
            { array[5][0],array[5][1],array[5][2],array[5][3],array[5][4],array[5][5],array[5][6],array[5][7] },
            { array[6][0],array[6][1],array[6][2],array[6][3],array[6][4],array[6][5],array[6][6],array[6][7] },
            { array[7][0],array[7][1],array[7][2],array[7][3],array[7][4],array[7][5],array[7][6],array[7][7] }};


                gameInProgress = true;
                gameBoard = new GImageArray(this, gameSpace, 50, 50, 50, 50, 0, imageDirectory);
                gameBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
            }
            

            

        }

       
    }
}









