using System.Data.Common;

namespace Seat_Booking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema c1 = new Cinema();
            while (true)
            {
                Console.WriteLine("1. Book Seat");
                Console.WriteLine("2. Cancel Seat");
                Console.WriteLine("3. Display Seats");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option (1-4): ");

                int choice;
               
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("❌ Invalid input, please enter a number.");
                    continue;
                }
                int row, col;
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("Enter row (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out row) && row >= 1 && row <= 5)
                            {
                                row--;
                                break;
                            }  
                            Console.WriteLine("❌ Invalid row. Please enter a number between 1 and 5.");
                        }

                        while (true)
                        {
                            Console.Write("Enter column (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out col) && col >= 1 && col <= 5)
                            {
                                col--;
                                break;
                            }
                            Console.WriteLine("❌ Invalid column. Please enter a number between 1 and 5.");
                        }

                        c1.BookSeat(row, col);
                        break;
                    case 2:
                        while (true)
                        {
                            Console.Write("Enter row (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out row) && row >= 1 && row <= 5)
                            {
                                row--;
                                break;
                            }
                            Console.WriteLine("❌ Invalid row. Please enter a number between 1 and 5.");
                        }

                        while (true)
                        {
                            Console.Write("Enter column (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out col) && col >= 1 && col <= 5)
                            {
                                col--;
                                break;
                            }
                            Console.WriteLine("❌ Invalid column. Please enter a number between 1 and 5.");
                        }
                        c1.CancelSeat(row, col);
                        break;
                    case 3:
                        c1.DisplaySeats();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("❌ Please choose between 1 and 4");
                        break;
                }
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }
        }
    }
    class Cinema
    {
     
        private int _row;
        private int _column;
        private bool[,] _seats = new bool[5, 5];
        public bool this [int row,int column] { 
            get
            { return _seats[row, column]; }
            set
            { _seats[row, column] = value; }
        }
        public Cinema (int row = 5, int column = 5)
        {
            _row = row;
            _column = column;
            _seats = new bool[_row, _column];
        }
        public bool IsValidSeat(int row, int col)
        {
            return row >= 0 && row < 5 && col >= 0 && col < 5;
        }
        public void BookSeat(int row, int col)
        {
            if (!IsValidSeat(row, col))
            {
                Console.WriteLine("❌ Invalid seat position!");
                return;
            }

            if (this[row, col])
            {
                Console.WriteLine("❌ Seat already taken!");
            }
            else
            {
                this[row, col] = true;
                Console.WriteLine("✅ Seat booked successfully!");
            }
        }
        
        public void CancelSeat(int row, int col)
        {
            if (!IsValidSeat(row, col))
            {
                Console.WriteLine("❌ Invalid seat position!");
                return;
            }

            if (!this[row, col])
            {
                Console.WriteLine("❌ Seat is already empty!");
            }
            else
            {
                this[row, col] = false;
                Console.WriteLine("✅ Booking canceled successfully!");
            }
        }
        public void DisplaySeats()
        {
            for (var row = 0; row < _seats.GetLength(1); row++)
            {
                for (var col = 0; col < _seats.GetLength(0); col++)
                {
                    Console.Write(this[row, col] ? "[X]" : "[O]");
                }
                Console.WriteLine();
            }
                
        }
    }
}

