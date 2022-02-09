using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Label[,] labelArray = new Label[10, 20]; //main game scene
        Label[,] nextTetrisArray = new Label[4, 6]; //UI, the field to show next tetris
        bool[,] boolArray = new bool[18, 24]; //use to check if the positions is occupied
        List<Point> cubeList = new List<Point>(); //the list to put point for current tetris temperary
        List<Point> nextCubeList = new List<Point>(); //the list to put point for next tetris temperary
        int[] typeArray = new int[] { 20, 40, 40, 40, 10, 20, 20 }; //the array to control rotation

        private Point position = new Point(4, 0); //the point indicating where the tetris is 
        private Point nextPosition = new Point(1, 4); //the generation point for UI field 
        Random randomTetris = new Random(); 

        private int currentTetrisType; 
        private int nextTetrisType;
        private int score = 0;
        private int bestScore = 0;
        private int stopLine = 19;
        private int timeInterval = 500;

        private bool canRight = true;
        private bool canLeft = true;
        private bool canMove = true;
        private bool canRotate = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //game scene
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Label label1 = new Label();
                    label1.Location = new Point(i * 40, j * 40);
                    label1.Size = new Size(39, 39);
                    label1.BackColor = Color.FromArgb(0, 0, 0);
                    labelArray[i, j] = label1;
                    this.Controls.Add(label1);
                }
            }
            //boolArray, outside the scene will be defined as occupied
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (j == 23 || i <= 3 || i >= 14)
                        boolArray[i, j] = true;
                    else
                        boolArray[i, j] = false;
                }
            }
            //UI field, including next tetris and score
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    Label label1 = new Label();
                    label1.Location = new Point(i * 40 + 400, j * 40);

                    if (0 < i && i < 5 && 1 < j && j < 8)
                    {
                        label1.Size = new Size(39, 39);
                        label1.BackColor = Color.FromArgb(0, 0, 0);
                        nextTetrisArray[i - 1, j - 2] = label1;
                    }
                    else
                    {
                        label1.Size = new Size(40, 40);
                        label1.BackColor = Color.FromArgb(255, 255, 255, 255);
                    }
                    this.Controls.Add(label1);
                }
            }
            //background
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Label label1 = new Label();
                    label1.Location = new Point(i * 40, j * 40+800);
                    label1.Size = new Size(40, 40);
                    label1.BackColor = Color.FromArgb(255, 255, 255,255);
                    this.Controls.Add(label1);
                }
            }

            currentTetrisType = randomTetris.Next(0, 6);
            createTetris(position, cubeList,currentTetrisType);
            nextTetrisType = randomTetris.Next(0, 6);
            createNextTetris(nextPosition, nextCubeList, nextTetrisType);
            timer1.Enabled = true;
        }

        //create current tetris on game field
        private void createTetris(Point tetrisPosition, List<Point> tetrisCubeList, int tetrisType)
        {
            createTetrisPoint(tetrisPosition, tetrisCubeList, tetrisType);
            canMoveOrNot();
            printTetris(tetrisCubeList);
        }

        //create next tetris on UI field
        private void createNextTetris(Point tetrisPosition, List<Point> tetrisCubeList, int tetrisType)
        {
            createTetrisPoint(tetrisPosition, tetrisCubeList, tetrisType);
            foreach (var obj in tetrisCubeList)
                nextTetrisArray[obj.X, obj.Y].BackColor = Color.FromArgb(255, 255, 255, 255);
        }
       
        private void createTetrisPoint(Point tetrisPosition, List<Point> tetrisCubeList,int tetrisType)
        {
            canRight = true;
            canLeft = true;
            canMove = true;
            canRotate = true;
            tetrisCubeList.Clear();
            Point startPoint = tetrisPosition;

            //put point into cubelist according to the tetristype
            //position is always at the buttom
            switch (tetrisType)
            {
                case 0:
                    putIntoList(4, startPoint, "up", tetrisCubeList);
                    break;
                case 10:
                    putIntoList(4, startPoint, "left", tetrisCubeList);
                    break;
                case 21:
                    startPoint.X += 1;
                    putIntoList(3, startPoint, "up", tetrisCubeList);
                    startPoint.X -= 1;
                    startPoint.Y -= 2;
                    putIntoList(1, startPoint, "up", tetrisCubeList);
                    break;
                case 11:
                    startPoint.X += 1;
                    putIntoList(3, startPoint, "left", tetrisCubeList);
                    startPoint.Y -= 1;
                    putIntoList(1, startPoint, "left", tetrisCubeList);
                    break;
                case 1:
                    putIntoList(3, startPoint, "up", tetrisCubeList);
                    startPoint.X += 1;
                    putIntoList(1, startPoint, "up", tetrisCubeList);
                    break;
                case 31:
                    startPoint.X -= 1;
                    putIntoList(1, startPoint, "right", tetrisCubeList);
                    startPoint.Y -= 1;
                    putIntoList(3, startPoint, "right", tetrisCubeList);
                    break;
                case 22:
                    putIntoList(3, startPoint, "up", tetrisCubeList);
                    startPoint.X += 1;
                    startPoint.Y -= 2;
                    putIntoList(1, startPoint, "up", tetrisCubeList);
                    break;
                case 12:
                    startPoint.X += 1;
                    putIntoList(1, startPoint, "left", tetrisCubeList);
                    startPoint.Y -= 1;
                    putIntoList(3, startPoint, "left", tetrisCubeList);
                    break;
                case 2:
                    putIntoList(1, startPoint, "up", tetrisCubeList);
                    startPoint.X += 1;
                    putIntoList(3, startPoint, "up", tetrisCubeList);
                    break;
                case 32:
                    startPoint.X -= 1;
                    putIntoList(3, startPoint, "right", tetrisCubeList);
                    startPoint.Y -= 1;
                    putIntoList(1, startPoint, "right", tetrisCubeList);
                    break;
                case 3:
                    putIntoList(3, startPoint, "up", tetrisCubeList);
                    startPoint.X += 1;
                    startPoint.Y -= 1;
                    putIntoList(1, startPoint, "up", tetrisCubeList);
                    break;
                case 33:
                    putIntoList(1, startPoint, "left", tetrisCubeList);
                    startPoint.X += 1;
                    startPoint.Y -= 1;
                    putIntoList(3, startPoint, "left", tetrisCubeList);
                    break;
                case 23:
                    startPoint.X += 1;
                    putIntoList(3, startPoint, "up", tetrisCubeList);
                    startPoint.X -= 1;
                    startPoint.Y -= 1;
                    putIntoList(1, startPoint, "up", tetrisCubeList);
                    break;
                case 13:
                    startPoint.X += 1;
                    putIntoList(3, startPoint, "left", tetrisCubeList);
                    startPoint.X -= 1;
                    startPoint.Y -= 1;
                    putIntoList(1, startPoint, "left", tetrisCubeList);
                    break;
                case 4:
                    putIntoList(2, startPoint, "up", tetrisCubeList);
                    startPoint.X += 1;
                    putIntoList(2, startPoint, "up", tetrisCubeList);
                    break;
                case 5:
                    putIntoList(2, startPoint, "up", tetrisCubeList);
                    startPoint.X += 1;
                    startPoint.Y -= 1;
                    putIntoList(2, startPoint, "up", tetrisCubeList);
                    break;
                case 15:
                    putIntoList(2, startPoint, "right", tetrisCubeList);
                    startPoint.Y -= 1;
                    putIntoList(2, startPoint, "left", tetrisCubeList);
                    break;
                case 6:
                    startPoint.X += 1;
                    putIntoList(2, startPoint, "up", tetrisCubeList);
                    startPoint.X -= 1;
                    startPoint.Y -= 1;
                    putIntoList(2, startPoint, "up", tetrisCubeList);
                    break;
                case 16:
                    putIntoList(2, startPoint, "left", tetrisCubeList);
                    startPoint.Y -= 1;
                    putIntoList(2, startPoint, "right", tetrisCubeList);
                    break;
            }
        }

        //put point into cubelist
        private void putIntoList(int tetrisLength, Point startPoint, string directionString, List<Point> tetrisCubeList)
        {
            //tetrisDirection controls which way the cube grows
            Point tetrisDirection = new Point(0, 0);
            if (directionString == "up")
                tetrisDirection.Y = -1;
            else if (directionString == "left")
                tetrisDirection.X = -1;
            else if (directionString == "right")
                tetrisDirection.X = 1;

            for (int i = 0; i < tetrisLength; i++)
            {
                tetrisCubeList.Add(startPoint);
                startPoint.X += tetrisDirection.X;
                startPoint.Y += tetrisDirection.Y;
            }
        }

        //modify the position when you rotate the tetris
        private void modifyPosition()
        {
            int movement = 0; //decide to move in which way
            List<int> doubleList = new List<int>(); //the list to record the point where there are two cubes
            cubeList=cubeList.OrderBy(p => p.X).ToList();

            foreach (var obj in cubeList)
            {
                //if there are two points on the same point, put into this list
                if (boolArray[obj.X + 4, obj.Y+3])
                {
                    //label1.Text +=obj.X+","+obj.Y+" ";
                    doubleList.Add(obj.X);
                }

                //if there is a cube on the left side/right side, then you have to move to the other side
                if (movement == 0||movement==2)
                {
                    if (boolArray[obj.X + 3, obj.Y+3])
                    {
                        if(cubeList.Exists(p => p == new Point(obj.X - 1, obj.Y)))
                            movement += 1;
                    }
                    else if (obj.X == cubeList[0].X && boolArray[obj.X + 4, obj.Y+3] == true)
                        movement += 1;
                }
                if (movement == 0||movement==1)
                {
                    if (boolArray[obj.X + 5, obj.Y+3])
                    {
                        if (cubeList.Exists(p => p == new Point(obj.X + 1, obj.Y)))
                            movement += 2;
                    }
                    else if (obj.X == cubeList[cubeList.Count-1].X && boolArray[obj.X + 4, obj.Y+3] == true)
                        movement += 2;
                }
            }

            //if the list is not empty, then the position must be modified
            if (doubleList.Count != 0)
            {
                //the distance you will need to move
                int rightDifference = cubeList[cubeList.Count - 1].X - doubleList[0] + 1;
                int leftDifference = doubleList[doubleList.Count - 1] - cubeList[0].X + 1;
                if (movement == 3) //can not go right or left
                    rotateBack();
                else if (movement == 1) //can only go right
                {
                    if (cubeList[cubeList.Count-1].X + leftDifference <= 9)
                    {
                        if (secondCheck(leftDifference))
                        {
                            position.X += leftDifference;
                            createTetrisPoint(position, cubeList, currentTetrisType);
                        }
                        else
                            rotateBack();
                    }
                    else
                        rotateBack();
                }
                else if (movement == 2) //can only go left
                {
                    if (cubeList[0].X - rightDifference >= 0)
                    {
                        if (secondCheck(-rightDifference))
                        {
                            position.X -= rightDifference;
                            createTetrisPoint(position, cubeList, currentTetrisType);
                        }
                        else
                            rotateBack();
                    }
                    else
                        rotateBack();
                }
                else if (movement == 0) //the double point is not on the edge
                {
                    if (cubeList[cubeList.Count-1].X + leftDifference <= 9)
                    {
                        if (secondCheck(leftDifference))
                        {
                            position.X += leftDifference;
                            createTetrisPoint(position, cubeList, currentTetrisType);
                        }
                    }
                    else if (cubeList[0].X - rightDifference >= 0)
                    {
                        if (secondCheck(-rightDifference))
                        {
                            position.X -= rightDifference;
                            createTetrisPoint(position, cubeList, currentTetrisType);
                        }
                    }
                    else
                        rotateBack();
                }

            }
        }

        //before modify the position, check if the new position is occupied or not
        private bool secondCheck(int difference)
        {
            bool modifyIsRight = true;
            foreach (var obj in cubeList)
            {
                if (boolArray[obj.X + difference + 4, obj.Y+3])
                {
                    modifyIsRight = false;
                    break;
                }
            }
            return modifyIsRight;
        }

        private void printTetris(List<Point> tetrisCubeList)
        {
            foreach (var obj in tetrisCubeList)
            {
                if (obj.Y < 0)
                    continue;
                else
                    labelArray[obj.X, obj.Y].BackColor = Color.FromArgb(255, 255, 255, 255);
            }
        }

        private void deleteTetris(List<Point> tetrisCubeList, Label[,] tetrisArray)
        {
            foreach (var obj in tetrisCubeList)
            {
                if (obj.Y < 0)
                    continue;
                else
                    tetrisArray[obj.X, obj.Y].BackColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void tetrisRotate()
        {
            currentTetrisType += 10;
            if (currentTetrisType >= typeArray[currentTetrisType % 10])
                currentTetrisType -= typeArray[currentTetrisType % 10];

            deleteTetris(cubeList, labelArray);
            createTetrisPoint(position, cubeList, currentTetrisType);
            modifyPosition();
            canMoveOrNot();
            printTetris(cubeList);
        }

        //if the tetris can not rotate, then turn it back
        private void rotateBack()
        {
            currentTetrisType -= 10;
            if (currentTetrisType < 0)
                currentTetrisType += typeArray[(currentTetrisType+10) % 10];
            createTetrisPoint(position,cubeList,currentTetrisType);
            canRotate = false;
        }

        //tetris will fall automatically until it bump into the buttom or other tetris
        private void tetrisFall()
        {
            if (stopLine == 0)
                gameOver();
            else if (canMove)
            {
                deleteTetris(cubeList, labelArray);
                position.Y += 1;
                createTetris(position, cubeList, currentTetrisType);
            }
            else //if it bump into the buttom or other tetris, create a new tetris
            {
                foreach (var obj in cubeList)
                    boolArray[obj.X + 4, obj.Y + 3] = true;
                deleteRow();

                position = new Point(4, 0);
                currentTetrisType = nextTetrisType;
                createTetris(position, cubeList, currentTetrisType);

                //show the next tetris
                nextTetrisType = randomTetris.Next(0, 6);
                deleteTetris(nextCubeList, nextTetrisArray);
                createNextTetris(nextPosition, nextCubeList, nextTetrisType);

                canMove = true;
                if (timer1.Interval > 20) //game speed will be faster when tetris reach the bottom
                {
                    timeInterval -= 20;
                    timer1.Interval = timeInterval;
                }
            }
        }

        private void canMoveOrNot()
        {
            foreach (var obj in cubeList)
            {
                if (boolArray[obj.X+4, obj.Y + 4])
                {
                    canMove = false;
                    stopLine = position.Y;
                }
                if (boolArray[obj.X+3, obj.Y+3])
                {
                    canLeft = false;
                }
                if (boolArray[obj.X+5, obj.Y+3])
                {
                    canRight = false;
                }
            }
        }

        //when the tetris is stop, detect to delete a row or not
        private void deleteRow()
        {
            int bonusScore = 1; //delete 1 row=1 point; 2=3 points: 3=6points; 4=10 points
            //check 4 rows
            for (int i = 3; i >=0; i--)
            {
                bool isDelete = true; //check if the whole role is occupied
                for (int j = 4; j <= 13; j++)
                {
                    if (!boolArray[j, position.Y - i+3])
                    {
                        isDelete = false;
                        break;
                    }
                }

                if (isDelete)
                {
                    //when delete a row, and then put every cube down
                    for (int k = 0; k < 10; k++)
                    {
                        for (int j = position.Y - i; j >= 0; j--)
                        {
                            if (j == 0)
                                boolArray[k + 4, j+3] = false;
                            else
                                boolArray[k + 4, j+3] = boolArray[k+4,j+2];

                            if(boolArray[k + 4, j+3])
                                labelArray[k, j].BackColor = Color.FromArgb(255, 255, 255,255);
                            else
                                labelArray[k, j].BackColor = Color.FromArgb(0, 0, 0);
                        }
                    }
                    score += bonusScore;
                    bonusScore += 1;
                }
            }
            scoreLabel.Text = "score: " + score;
        }

        private void gameOver()
        {
            gameOverLabel.Visible = true;
            bestScoreLabel.Visible = true;
            finalScoreLabel.Visible = true;
            retryButton.Visible = true;
            retryButton.Enabled = true;
            timer1.Enabled = false;

            //show score and best score
            if (score > bestScore)
            {
                bestScore = score;
                newRecordLabel.Visible = true;
            }
            bestScoreLabel.Text = "Best Score : " + bestScore;
            finalScoreLabel.Text = "Your Score : " + score;

            //delete the game field
            foreach(var obj in labelArray)
                obj.BackColor = Color.FromArgb(0, 0, 0);
            deleteTetris(nextCubeList, nextTetrisArray);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //press space to rotate tetris
            if (e.KeyCode == Keys.Space && canRotate==true)
            {
                deleteTetris(cubeList,labelArray);
                tetrisRotate();
                createTetris(position,cubeList,currentTetrisType);
            }
            //press right to move right
            else if (e.KeyCode == Keys.Right && canRight == true)
            {
                deleteTetris(cubeList,labelArray);
                position.X += 1;
                createTetris(position,cubeList,currentTetrisType);
            }
            //press left to move left
            else if (e.KeyCode == Keys.Left && canLeft == true)
            {
                deleteTetris(cubeList,labelArray);
                position.X -= 1;
                createTetris(position,cubeList,currentTetrisType);
            }
            //press move fast when you press down key, can be long pressed
            else if (e.KeyCode == Keys.Down)
            {
                timer1.Interval = 20;
            }
        }
        //change into normal speed when you leave down key
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                timer1.Interval = timeInterval;            
        }
        //tetris will move down every 0.5 second
        private void timer1_Tick(object sender, EventArgs e)
        {
            tetrisFall();
        }
        //restart the game
        private void retryButton_Click(object sender, EventArgs e)
        {
            gameOverLabel.Visible = false;
            bestScoreLabel.Visible = false;
            finalScoreLabel.Visible = false;
            newRecordLabel.Visible = false;
            retryButton.Visible = false;
            retryButton.Enabled = false;

            position = new Point(4, 0);
            score = 0;
            stopLine = 19;
            timeInterval = 500;
            timer1.Interval = timeInterval;

            canRight = true;
            canLeft = true;
            canMove = true;
            canRotate = true;

            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (j == 23 || i <= 3 || i >= 14)
                        boolArray[i, j] = true;
                    else
                        boolArray[i, j] = false;
                }
            }

            currentTetrisType = randomTetris.Next(0, 6);
            createTetris(position, cubeList, currentTetrisType);
            nextTetrisType = randomTetris.Next(0, 6);
            createNextTetris(nextPosition, nextCubeList, nextTetrisType);
            timer1.Enabled = true;
        }

        private void finalScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void newRecordLabel_Click(object sender, EventArgs e)
        {

        }
    }    
}
