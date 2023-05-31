class Universe
{

    static int[,] universe = new int[10, 10];

    static void Main()
    {
        
        // Необходимо ввести значения для начальной эволюции.
        Console.WriteLine("Введите первое поколение клеток через пробел (0 - мертвая клетка, 1 - живая клетка):");
        for (int i = 0; i < 10; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            if (input.Length != 10) // Проверка на количество значений для массива
            {
                
                Console.WriteLine($"Неверное количество значений (необходимо 10 значений). Повторите ввод. Вы продолжаете вводить с {i+1} строки");
                if (i >= 0)
                {
                    i--;
                    continue;
                }
                else
                {
                    Main();
                }
            }

            for (int j = 0; j < 10; j++) // Запуск цикла перебора многомерного массива
            {
                universe[i, j] = int.Parse(input[j]);
                if (!int.TryParse(input[j], out int value) || (value !=0 && value !=1)) // Проверка на коректность введенных данных
                {
                    
                    Console.WriteLine($"Неверные значения (0 - мертвая клетка, 1 - живая клетка). Повторите ввод {i+1} строки.");
                    if (i >= 0)
                    {
                        i--;
                        break;
                    }
                }
                universe[i, j] = value;
            }

        }
        DisplayUniverse(); // Визуальное отображение вселенной ( X = живая,0 = меортвая ) 
        Return();
        
        static void Return()
        {
            Console.WriteLine("Нажмите r для следующей генерации или любую другую клавишу, для завершения работы кода."); // Запуск генерации
            char key = Console.ReadKey().KeyChar;
            if (key == 'r' || key == 'к')
            {
                NextGeneration();
            }
        }
       

        static int CountAlive(int x,int y)
        {
            int count = 0;
            
            // Проверка соседей
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y)
                        continue;
                    // Зацикленность вселенной 
                    int X = (i + 10) % 10;
                    int Y = (j + 10) % 10;

                    if (universe[X,Y] ==1)
                        count++;
                }
            }
            return count;
        }

        static void DisplayUniverse() // Визуальное отображение
        {
            Console.WriteLine("Текущее состояние вселенной:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (universe[i, j] == 1)
                        Console.Write(" X "); // Живая
                    else
                    {
                        Console.Write(" 0 "); // Мертвая
                    }
                }
                Console.WriteLine();
            }
        }
        static void NextGeneration()
        {
            int[,] nextGeneration = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Подсчет живых соседних клеток
                    int liveCount = CountAlive(i, j);
                    // Если текущая клетка живая
                    if (universe[i,j] ==1)
                    {
                        // Живые соседи
                        if (liveCount == 2 || liveCount == 3)
                        {
                            nextGeneration[i, j] = 1; // Клетка остается жить
                        }
                        else
                        {
                            nextGeneration[i, j] = 0; // Клетка умирает
                        }
                    }
                    else // Если изначально мертва
                    {
                        nextGeneration[i, j] = 0; // Остается мертвой
                    }

                }
            }
            universe= nextGeneration; // Обновленное состояние вселенной

            DisplayUniverse();
            Return();
        }
    }
}