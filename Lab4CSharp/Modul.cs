using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть клас для використання:");
        Console.WriteLine("1. Клас Triangle");
        Console.WriteLine("2. Клас VectorUInt");

        // Зчитуємо вибір користувача
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                UseTriangleClass();
                break;
            case "2":
                UseVectorUIntClass();
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

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

//___________________________ task 2

class VectorUInt
{
    protected uint[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorUInt()
    {
        size = 1;
        IntArray = new uint[size];
        num_vec++;
    }

    public VectorUInt(uint vectorSize)
    {
        size = vectorSize;
        IntArray = new uint[size];
        num_vec++;
    }

    public VectorUInt(uint vectorSize, uint initValue)
    {
        size = vectorSize;
        IntArray = new uint[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        num_vec++;
    }

    // Деструктор
    ~VectorUInt()
    {
        Console.WriteLine("Вектор був видалений.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент {i}: ");
            IntArray[i] = Convert.ToUInt32(Console.ReadLine());
        }
    }

    public void DisplayElements()
    {
        Console.WriteLine("Елементи вектора:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"{IntArray[i]} ");
        }
        Console.WriteLine();
    }

    public void AssignElements(uint value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint CountVectors()
    {
        return num_vec;
    }

    // Властивості
    public uint Size
    {
        get { return size; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public uint this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                return IntArray[index];
            }
        }
        set
        {
            if (index < 0 || index >= size)
            {
                codeError = -1;
            }
            else
            {
                IntArray[index] = value;
            }
        }
    }

    // Перевантаження операторів
    public static VectorUInt operator ++(VectorUInt vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]++;
        }
        return vec;
    }

    public static VectorUInt operator --(VectorUInt vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]--;
        }
        return vec;
    }

    public static bool operator true(VectorUInt vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            if (vec.IntArray[i] == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorUInt vec)
    {
        if (vec.size == 0)
            return true;

        for (int i = 0; i < vec.size; i++)
        {
            if (vec.IntArray[i] == 0)
                return true;
        }
        return false;
    }

    public static bool operator !(VectorUInt vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            if (vec.IntArray[i] == 0)
                return true;
        }
        return false;
    }

    // Додаткові бінарні операції (приклад)
    public static VectorUInt operator +(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 + val2;
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання класу VectorUInt
        VectorUInt vec1 = new VectorUInt(3, 10);
        VectorUInt vec2 = new VectorUInt(4, 5);

        // Введення та вивід елементів
        vec1.InputElements();
        vec1.DisplayElements();

        // Операції з векторами
        VectorUInt sumVec = vec1 + vec2;
        sumVec.DisplayElements();

        // Перевірка умов true та false
        if (!vec1)
            Console.WriteLine("vec1 містить нульові елементи.");
        else
            Console.WriteLine("vec1 не містить нульових елементів.");

        // Підрахунок кількості створених векторів
        Console.WriteLine($"Кількість векторів: {VectorUInt.CountVectors()}");
    }
}
