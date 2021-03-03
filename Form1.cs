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
                    UpdateGUI(r, c);
                    CheckLeft(r, c);
                    
                }

                else 
                {
                    UpdateGUI(r, c);
                    CheckLeft(r, c);
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




        public void CheckLeft(int r, int c)
        {

            // maybe look to use a foreach loop - i.e. for each counter which != isPlaying which has a column number greater than a counter which is the same as isPlaying gets changed to the is playing value 
            // we need to find everything in this row until we reach the edge

            // foreach value in a row, check its value vs value of element clicked.
            //if it != the same, check the element left of this.
            // it it's value is 10 - break and do no thing
            // if it's value is the same as isPlaying, change it's value to the same as isPlaying
            //update GUI
            //else if its value is != the as isPlaying repeat the loop
            c = c--; // currently trying to check where has been clicked which is outside of the array boundaries in this while loop as it is a 10


            do
            {
         
                gameSpace[r, c] = isPlaying;    
                gameBoard.UpDateImages(gameSpace);
                c--;
                
            }
            while (gameSpace[r, c] != isPlaying && c <= 0 && gameSpace[r, c] != 10 || gameSpace[r, c] != isPlaying);
     



            /*else
            {
                gameSpace[r, col] = isPlaying;
                gameBoard.UpDateImages(gameSpace);
            }*/

            

       



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


