using System;

class Triangle
{
    // Захищені поля класу
    protected int a;
    protected int b;
    protected int c;
    protected int color;

    // Конструктор класу Triangle
    public Triangle(int sideA, int sideB, int sideC, int triangleColor)
    {
        a = sideA;
        b = sideB;
        c = sideC;
        color = triangleColor;
    }

    // Індексатор для доступу до полів за індексом
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                case 2: return c;
                case 3: return color;
                default:
                    throw new IndexOutOfRangeException("Неприпустимий індекс");
            }
        }
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: c = value; break;
                case 3: color = value; break;
                default:
                    throw new IndexOutOfRangeException("Неприпустимий індекс");
            }
        }
    }

    // Перевантаження операторів ++ (інкремент) та -- (декремент)
    public static Triangle operator ++(Triangle t)
    {
        t.a++;
        t.b++;
        t.c++;
        return t;
    }

    public static Triangle operator --(Triangle t)
    {
        t.a--;
        t.b--;
        t.c--;
        return t;
    }

    // Перевантаження констант true і false
    public static implicit operator bool(Triangle t)
    {
        return t.IsValidTriangle();
    }

    // Перевантаження оператору множення *
    public static Triangle operator *(Triangle t, int scalar)
    {
        t.a *= scalar;
        t.b *= scalar;
        t.c *= scalar;
        return t;
    }

    // Перевантаження перетворення в рядок (string)
    public override string ToString()
    {
        return $"Трикутник зі сторонами: {a}, {b}, {c}";
    }

    // Приватний метод для перевірки існування трикутника за довжинами сторін
    private bool IsValidTriangle()
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    // Методи для виведення довжин сторін трикутника
    public void DisplaySides()
    {
        Console.WriteLine($"Сторони трикутника: {a}, {b}, {c}");
    }

    // Метод для розрахунку периметра трикутника
    public int CalculatePerimeter()
    {
        return a + b + c;
    }

    // Метод для розрахунку площі трикутника за формулою Герона
    public double CalculateArea()
    {
        double p = CalculatePerimeter() / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Властивості
    public int SideA
    {
        get { return a; }
        set { if (value > 0) a = value; }
    }

    public int SideB
    {
        get { return b; }
        set { if (value > 0) b = value; }
    }

    public int SideC
    {
        get { return c; }
        set { if (value > 0) c = value; }
    }

    public int Color
    {
        get { return color; }
    }
}

class Program
{
    static void Main()
    {
        // Створення екземпляру класу Triangle
        Triangle triangle1 = new Triangle(3, 4, 5, 1);

        // Використання індексатора для доступу до полів
        Console.WriteLine($"a: {triangle1[0]}, b: {triangle1[1]}, c: {triangle1[2]}, color: {triangle1[3]}");

        // Інкремент
        triangle1++;
        triangle1.DisplaySides();

        // Перевірка існування трикутника
        if (triangle1)
            Console.WriteLine("Трикутник існує.");
        else
            Console.WriteLine("Трикутник не існує.");

        // Множення сторін на скаляр
        triangle1 *= 2;
        triangle1.DisplaySides();

        // Перетворення в рядок
        Console.WriteLine(triangle1.ToString());
    }
}
