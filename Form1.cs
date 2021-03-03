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

                //firstly check if this is a legal move e.g. is there a black square in the 8 surrounding squares of this element. therefore psuedocode: is elementClicked next to a picturebox with the value of 0? If yes then change element if no then don't.

                IsValidPosition(r, c);

                if (IsValidPosition(r, c) == true)
            {
                if (isPlaying == 0)
                {

                    if (CheckLeft(r, c) == true)
                    {
                        FlipLeft(r, c);
                    }
                    if (CheckRight(r, c) == true)
                    {
                        FlipRight(r, c);
                    }
                    if (CheckUp(r, c) == true)
                    {
                        FlipUp(r, c);
                    }
                    if (CheckDown(r, c) == true)
                    {
                        FlipDown(r, c);
                    }



                    UpdateGUI(r, c);

                }

                else
                {

                    if (CheckLeft(r, c) == true)
                    {
                        FlipLeft(r, c);
                    }
                  if (CheckRight(r, c) == true)
                    {
                        FlipRight(r, c);
                    }
                    if (CheckUp(r, c) == true)
                    {
                        FlipUp(r, c);
                    }
                    if (CheckDown(r, c) == true)
                    {
                        FlipDown(r, c);
                    }


                    UpdateGUI(r, c);

                }

                PlayerTurn();
            }

                else
            {
                MessageBox.Show("Invalid placement of counter");
            }


                





            






        }


        /* public void SetArrayValue() //potentially use this to search in the array for other values to set elements next to the element which has been clicked according to game logic
         {  //currently function does not work - null object reference

             if (playerTurn == true)
             {
                 gameSpace[r, c] = 0;
             }

             else if (playerTurn == false)
             {
                 gameSpace[r, c] = 1;
             }

         }*/




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

            if (elementClicked.ImageLocation == imageDirectory + "10" + ".PNG") //add validation for if it is next an opposing colour
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
            if (isPlaying == 0)
            {       
                gameSpace[r, c] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
            }

            else if (isPlaying == 1)
            {
                gameSpace[r, c] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
            }
        }




        // error with checking what needs to turn - if one statement is true 



        public bool CheckLeft(int r, int c)
        {
            if (c == 0 || gameSpace[r, c - 1] == 10)
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
            while (gameSpace[r, c] != isPlaying && c >= 0 && gameSpace[r, c] != 10 || gameSpace[r, c] != isPlaying);
        }



        public bool CheckRight(int r, int c)
        {
            if (c == 7 || gameSpace[r, c + 1] == 10)
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
            if (r == 0 || gameSpace[r - 1, c] == 10)
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



        public bool CheckDown (int r, int c)
        {
            if (r == 7 || gameSpace[r + 1, c] == 10)
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
















        //need to validate if it is in a position to actually change an element rather than if it is next to one
        /*
         if (playerTurn == true)
         {
             PictureBox topLeft = gameBoard.Get_Element(r - 1, c - 1);
             PictureBox topCenter = gameBoard.Get_Element(r - 1, c);
             PictureBox topRight = gameBoard.Get_Element(r - 1, c + 1);
             PictureBox left = gameBoard.Get_Element(r, c - 1);
             PictureBox centre = gameBoard.Get_Element(r, c);
             PictureBox right = gameBoard.Get_Element(r, c + 1);
             PictureBox bottomLeft = gameBoard.Get_Element(r + 1, c - 1);
             PictureBox bottomCenter = gameBoard.Get_Element(r + 1, c);
             PictureBox bottomRight = gameBoard.Get_Element(r + 1, c + 1);


             //if the row or col is = 0 or 8 then do not run the commands related to that


             if (centre.ImageLocation != imageDirectory + "10" + ".PNG")
               {
                     MessageBox.Show("You cannot place a counter ontop of one which has already been placed");
                 }

             else if (topLeft.ImageLocation == imageDirectory + "1" + ".PNG")
             {

                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (topCenter.ImageLocation == imageDirectory + "1" + ".PNG")
                 {
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (topRight.ImageLocation == imageDirectory + "1" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (left.ImageLocation == imageDirectory + "1" + ".PNG"){
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (right.ImageLocation == imageDirectory + "1" + ".PNG"){
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (bottomLeft.ImageLocation == imageDirectory + "1" + ".PNG"){
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (bottomCenter.ImageLocation == imageDirectory + "1" + ".PNG"){
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }
             else if (bottomRight.ImageLocation == imageDirectory + "1" + ".PNG"){
                 gameBoard.Set_Element(r, c, "0");
                 PlayerTurn();
             }


             else
             {
                 MessageBox.Show("Invalid Placement of Black Counter, try again");
             }



             // error occurs here when selecting element in col 0 or col 7 because it attempts to check if there is something in the element to its left or right respectively (e.g. col -1 or col, 8) which do not exist
         }

        else if (playerTurn != true)
         {
             // need to set these dynamically so edge elements do not result in exception
             PictureBox topLeft = gameBoard.Get_Element(r - 1, c - 1);
             PictureBox topCenter = gameBoard.Get_Element(r - 1, c);
             PictureBox topRight = gameBoard.Get_Element(r - 1, c + 1);
             PictureBox left = gameBoard.Get_Element(r, c - 1);
             PictureBox centre = gameBoard.Get_Element(r, c);
             PictureBox right = gameBoard.Get_Element(r, c + 1);
             PictureBox bottomLeft = gameBoard.Get_Element(r + 1, c - 1);
             PictureBox bottomCenter = gameBoard.Get_Element(r + 1, c);
             PictureBox bottomRight = gameBoard.Get_Element(r + 1, c + 1);

             if (centre.ImageLocation != imageDirectory + "10" + ".PNG")
             {
                 MessageBox.Show("You cannot place a counter ontop of one which has already been placed");
             }

             else if (topLeft.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (topCenter.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (topRight.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (left.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (right.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (bottomLeft.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (bottomCenter.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }
             else if (bottomRight.ImageLocation == imageDirectory + "0" + ".PNG")
             {
                 gameBoard.Set_Element(r, c, "1");
                 PlayerTurn();
             }

             else
             {
                 MessageBox.Show("Invalid Placement of White Counter, try again");
             }





         }
     }*/



        /*public void IsOutFlankingLeft()
         {


             // have where the element is clicked as r and c
             //we then want to use these values to count up in a diagonal line and check the values of the images in this line 

            // take col given by Which_Element_Clicked then find first instance of same colour in that row. Count inbetween these two figures then change anything if it needs changing.

         }*/


















    }
}


