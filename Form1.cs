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
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10}};
        GImageArray gameBoard;
        string player1;
        string player2;
        int isPlaying = 0;
        bool validMove;









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


            if (IsValidPosition(r,c) == true)
            {
                
                LookNorth(r, c);
                UpdateGameSpace(r, c);
                UpdateGUI(r, c);

            }
            
                //firstly check if this is a legal move e.g. is there a black square in the 8 surrounding squares of this element. therefore psuedocode: is elementClicked next to a picturebox with the value of 0? If yes then change element if no then don't.

                



           
        /*        if (IsValidPosition(r, c) == true)
            {
                if (isPlaying == 0)
                {

                    if (CheckLeft(r, c) == true)
                    {
                        FlipLeft(r, c);
                        UpdateGUI(r, c);
                    }
                    else if (CheckLeft(r,c) == false)
                    {
                        if(CheckRight(r,c) == true)
                        {
                            FlipRight(r, c);
                            UpdateGUI(r, c);
                        }
                        else if(CheckRight(r,c) == false)
                        {
                            if(CheckUp(r, c) == true)
                            {
                                FlipUp(r, c);
                                UpdateGUI(r, c);
                            }
                            else if(CheckUp(r,c) == false)
                            {
                                if(CheckDown(r,c) == true)
                                {
                                    FlipDown(r, c);
                                    UpdateGUI(r, c);
                                }
                                else
                                {
                                    

                                }
                            }
                        }
                    }
                    




                }

                else
                {

                    if (CheckLeft(r, c) == true)
                    {
                        FlipLeft(r, c);
                        UpdateGUI(r, c);
                    }
                    else if (CheckLeft(r, c) == false)
                    {
                        if (CheckRight(r, c) == true)
                        {
                            FlipRight(r, c);
                            UpdateGUI(r, c);
                        }
                        else if (CheckRight(r, c) == false)
                        {
                            if (CheckUp(r, c) == true)
                            {
                                FlipUp(r, c);
                                UpdateGUI(r, c);
                            }
                            else if (CheckUp(r, c) == false)
                            {
                                if (CheckDown(r, c) == true)
                                {
                                    FlipDown(r, c);
                                    UpdateGUI(r, c);
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Move");

                                }
                            }
                        }
                    }

                    

                }

                PlayerTurn();
            }

                else
            {
                MessageBox.Show("Invalid placement of counter");
            }*/


                





            






        }


      




        public void LookNorth(int r, int c)
        {
            int newRow = r-1;
            
            List<int> locationR = new List<int> { };
            List<int> locationC = new List<int> { };


            do
                if (gameSpace[newRow, c] != isPlaying && gameSpace[newRow, c] != 10)
                {
                    locationR.Add(newRow);
                    locationC.Add(c);
                    newRow--;

                    if (newRow < 0)
                    {
                        validMove = false;
                        newRow = 0;
                    }

                    else
                    {
                        validMove = true;
                    }
                }

            while (gameSpace[newRow, c] != isPlaying && validMove == true);


            if (locationR.Count>0 && validMove == true)
            {
                for(int token =0; token <locationR.Count; token++)
                {
                    gameSpace[locationR[token], locationC[token]] = isPlaying;
                    
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

        public bool CheckLeft(int r, int c)
        {
            if (c == 0 || gameSpace[r, c - 1] == 10 || gameSpace[r, c - 1] == isPlaying) //add validation here to check all spaces left e.g. if there is a counter of the opposing colour then green then false
            {
                return false;
            }

            else return true;



        }

        public void FlipLeft(int r, int c)
        {
            c = c--;
            do
            {

                gameSpace[r, c] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
                c--;

            }
            while (gameSpace[r, c] != isPlaying && c > 0 && gameSpace[r, c] != 10 || gameSpace[r, c] != isPlaying); // if there is a green on the otherside of all counters of opposing colour this should be an invalid move. 
        }



        public bool CheckRight(int r, int c)
        {
            if (c == 7 || gameSpace[r, c + 1] == 10 || gameSpace[r, c + 1] == isPlaying)
            {
                return false;
            }


            else return true;



        }


        public void FlipRight(int r, int c)
        {

            c = c++;
            do
            {

                gameSpace[r, c] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
                c++;

            }
            while (gameSpace[r, c] != isPlaying && c <= 7 && gameSpace[r, c] != 10 || gameSpace[r, c] != isPlaying);

        }



        public bool CheckUp(int r, int c)
        {
            if (r == 0 || gameSpace[r - 1, c] == 10 || gameSpace[r - 1, c] == isPlaying)
            {
                return false;
            }


            else return true;



        }







        public void FlipUp(int r, int c)
        {

            r = r--;
            do
            {

                gameSpace[r, c] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
                r--;

            }
            while (gameSpace[r, c] != isPlaying && r >= 0 && gameSpace[r, c] != 10 || gameSpace[r, c] != isPlaying);

        }



        public bool CheckDown(int r, int c)
        {
            if (r == 7 || gameSpace[r + 1, c] == 10 || gameSpace[r + 1, c] == isPlaying)
            {
                return false;
            }


            else return true;



        }

        public void FlipDown(int r, int c)
        {



            r = r++;
            do
            {

                gameSpace[r, c] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
                r++;

            }
            while (gameSpace[r, c] != isPlaying && r <= 7 && gameSpace[r, c] != 10 || gameSpace[r, c] != isPlaying);



        }









    }


}






