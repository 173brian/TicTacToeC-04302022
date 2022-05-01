namespace project
{
    
    class TicTacToe
    {
        
        static void Main(string[] args)
        {
            bool win = false;
            string[,] board = new string[3, 3]; 
            for (int i = 0; i < board.GetLength(0) * board.GetLength(1); i++)
            {
                board[i / 3, i % 3] = (i + 1).ToString();
            }
            for(int turnNum = 0; turnNum < 9; turnNum++)
            {
                PrintBoard(board);
                char turn;
                if (turnNum % 2 == 1)
                    turn = 'y';
                else 
                    turn = 'x';
                Console.WriteLine($"{turn}\'s turn to choose a square (1-9): ");
                int place = int.Parse(Console.ReadLine());
                win = Move(turn, place, board);
                if (win)
                {
                    PrintBoard(board);
                    Console.WriteLine($"{turn} won the game!");
                    break;
                }
            }
            if (!win)
                Console.WriteLine("Stalemate!");
        }

        static bool Move(char x, int place, string[,] board)
        {
            bool win = false;
            board[(place - 1)/3, (place - 1)%3] = x.ToString();
            if(place == 5)
                win = CheckMiddle(x, board);
            else if(place % 2 == 0)
                win = CheckEdges(x, place, board);
            else
                win = CheckDiagonals(x, board);
            return win;
        }
        static void PrintBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i ++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    Console.Write(board[i,x]);
                    if (x < 2)
                        Console.Write('|');
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("-+-+-");
            }
        }

        static bool CheckEdges(char x, int place, string[,]board)
        {
            bool horizontal = CheckHorizontal(x, place, board);
            bool vertical = CheckVertical(x, place, board);
            return (horizontal || vertical);
        }

        static bool CheckMiddle(char x, string[,]board)
        {
            bool horizontal = CheckHorizontal(x, 5, board);
            bool vertical = CheckVertical(x, 5, board);
            bool diagonals = CheckDiagonals(x, board);
            return (horizontal || vertical || diagonals);
        }

        static bool CheckDiagonals(char x, string[,]board)
        {
            bool diagDown = false;
            bool diagUp = false;
            for (int i = 0; i < 3; i++)
                if (board[i, i].ToString() == x.ToString())
                    diagDown = true;
                else
                {
                    diagDown = false;
                    break;
                }
            for (int i = 0; i < 3; i++)
                if (board[(2 - i), i].ToString() == x.ToString())
                    diagUp = true;
                else
                {
                    diagUp = false;
                    break;
                }
            return (diagDown || diagUp);
        }

        static bool CheckHorizontal(char x, int place, string[,]board)
        {
            bool horizontal = false;
            for (int i = 0; i < 3; i++)
                if (board[place/3, i].ToString() == x.ToString())
                    horizontal = true;
                else
                {
                    horizontal = false;
                    break;
                }
            return horizontal;
        }

        static bool CheckVertical(char x, int place, string[,]board)
        {
            bool vertical = false;
            for (int i = 0; i < 3; i++)
                if (board[i, 1].ToString() == x.ToString())
                    vertical = true;
                else
                {
                    vertical = false;
                    break;
                }
            return vertical;
        }
    }
}