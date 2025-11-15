using System;

namespace MatricesDemo
{
  class TwoDMatrix
  {
    protected int[,] A;
    protected const int N = 3;
    public TwoDMatrix()
    {
      A = new int[N, N];
    }
    public virtual void InputFromConsole()
    {
      Console.WriteLine("Введіть елементи двовимірної матриці 3x3 (цілі числа):");
      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < N; j++)
        {
          while (true)
          {
            Console.Write($"A[{i},{j}] = ");
            string? s = Console.ReadLine();
            if (int.TryParse(s, out int val))
            {
              A[i, j] = val;
              break;
            }
            Console.WriteLine("Невірне значення. Спробуйте знову.");
          }
        }
      }
    }
    public virtual void FillRandom(int minValue = -50, int maxValue = 50)
    {
      var rnd = new Random();
      for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
          A[i, j] = rnd.Next(minValue, maxValue + 1);
    }
    public virtual int MinElement()
    {
      int min = A[0, 0];
      for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
          if (A[i, j] < min) min = A[i, j];
      return min;
    }
    public virtual void Print()
    {
      Console.WriteLine("Двовимірна матриця 3x3:");
      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < N; j++)
          Console.Write($"{A[i, j],6}");
        Console.WriteLine();
      }
    }
  }
  class ThreeDMatrix : TwoDMatrix
  {
    private int[,,] B;
    private const int X = 3, Y = 3, Z = 3;
    public ThreeDMatrix()
    {
      B = new int[X, Y, Z];
    }
    public override void InputFromConsole()
    {
      Console.WriteLine("Введіть елементи тривимірної матриці 3x3x3 (цілі числа):");
      for (int k = 0; k < Z; k++)
      {
        Console.WriteLine($"Слой {k}:");
        for (int i = 0; i < X; i++)
        {
          for (int j = 0; j < Y; j++)
          {
            while (true)
            {
              Console.Write($"B[{i},{j},{k}] = ");
              string? s = Console.ReadLine();
              if (int.TryParse(s, out int val))
              {
                B[i, j, k] = val;
                break;
              }
              Console.WriteLine("Невірне значення. Спробуйте знову.");
            }
          }
        }
      }
    }
    public override void FillRandom(int minValue = -50, int maxValue = 50)
    {
      var rnd = new Random();
      for (int k = 0; k < Z; k++)
        for (int i = 0; i < X; i++)
          for (int j = 0; j < Y; j++)
            B[i, j, k] = rnd.Next(minValue, maxValue + 1);
    }
    public override int MinElement()
    {
      int min = B[0, 0, 0];
      for (int k = 0; k < Z; k++)
        for (int i = 0; i < X; i++)
          for (int j = 0; j < Y; j++)
            if (B[i, j, k] < min) min = B[i, j, k];
      return min;
    }
    public override void Print()
    {
      Console.WriteLine("Тривимірна матриця 3x3x3 (по слоях):");
      for (int k = 0; k < Z; k++)
      {
        Console.WriteLine($"Слой {k}:");
        for (int i = 0; i < X; i++)
        {
          for (int j = 0; j < Y; j++)
            Console.Write($"{B[i, j, k],6}");
          Console.WriteLine();
        }
      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Демонстрація класів двовимірної та тривимірної матриць (3x3, 3x3x3)");
      TwoDMatrix m2 = new TwoDMatrix();
      m2.FillRandom();
      m2.Print();
      Console.WriteLine($"Мінімальний елемент двовимірної матриці: {m2.MinElement()}");
      Console.WriteLine();
      TwoDMatrix m3 = new ThreeDMatrix(); // використаємо поліморфізм
      m3.FillRandom(); // викличеться перевизначений метод
      m3.Print(); // перевизначений Print
      Console.WriteLine($"Мінімальний елемент тривимірної матриці: {m3.MinElement()}");
      Console.WriteLine();
      Console.WriteLine("Приклад вводу з клавіатури для двовимірної матриці:");
      var user2 = new TwoDMatrix();
      user2.InputFromConsole();
      user2.Print();
      Console.WriteLine($"Мінімум (користувацька матриця 2D): {user2.MinElement()}");
      Console.WriteLine();
      Console.WriteLine("Приклад вводу з клавіатури для тривимірної матриці:");
      var user3 = new ThreeDMatrix();
      user3.InputFromConsole();
      user3.Print();
      Console.WriteLine($"Мінімум (користувацька матриця 3D): {user3.MinElement()}");
    }
  }
}
