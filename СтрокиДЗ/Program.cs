// See https://aka.ms/new-console-template for more information

int itemConsole;
string Text = string.Empty;
string strPath;
// Console.Title = "Домашнее задание №3";
Console.Title = "Домашнее задание №3";
Console.WriteLine("Выберите:\n" +
    "\t1. Считать текст из файла.\n" +
    "\t2. Скопировать текст в консоль.");
Console.Write("Ваш выбор: ");

do
{
    itemConsole = IsNumber(Console.ReadLine());
    if (itemConsole == 1 || itemConsole == 2) continue;
    Console.WriteLine("Выберите пункты 1 или 2");
    Console.Write("Ваш выбор: ");
} while (itemConsole < 1 || itemConsole > 2);


if (itemConsole == 1)
{
    Console.WriteLine("Укажите путь к файлу например \"D:\\учеба\\TheText.txt\" ");
    bool Flag;
    do
    {
        Console.Write("Загрузить текстовый файл: ");
       strPath = IsString(Console.ReadLine()).Trim();
        if (File.Exists(strPath))
        {
            Text = System.IO.File.ReadAllText(strPath);
            Flag = false;
        }
        else
        {
            Console.WriteLine($"Неправильно указан путь \"{strPath}\" или файл не существует!!! ");
            Flag = true;
        }
            

    } while (Flag);
}
else
{
    Console.WriteLine("Вставте текст:");
    Text = IsString(Console.ReadLine()).Trim();
}
Console.WriteLine("Выберите номер пункта чтобы:\n" +
    "\t 1.  Найти слова, содержащие максимальное количество цифр.\n" +
    "\t 2.  Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.\n" +
    "\t 3.  Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».\n" +
    "\t 4.  Вывести на экран сначала вопросительные, а затем восклицательные предложения.\n" +
    "\t 5.  Вывести на экран только предложения, не содержащие запятых.\n" +
    "\t 6.  Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву");
Console.Write("Ваш выбор: ");


do
{
    itemConsole = IsNumber(Console.ReadLine());
    if (itemConsole >= 1 & itemConsole <= 6) continue;
    Console.WriteLine("Выберите пункты 1-6");

} while (itemConsole < 1 || itemConsole > 6);

switch (itemConsole)
{
    case 1:

        MaxNumbersss(Text);
        break;

    case 2:
        LongestWord(Text);
        break;

    case 3:
        DigitToWord(Text);
        break;

    case 4:
        ShowOffers(Text);
        break;

    case 5:
        NoCommaSentence(Text);
        break;

    case 6:
        StartEndLetter(Text);
        break;
}

// проверка пустой строки, пробелов
static string IsString(string str)
{
    bool flag;
    do
    {
        flag = String.IsNullOrEmpty(str.Trim());
        if (flag)
        {
            Console.WriteLine("Ошибка ввода. Попробуйте еще раз!");
            str = Console.ReadLine();
        }

    } while (flag);
    return str;
}
// возвращает строку из цифры от 1 до 9
static string IntToString(char num)
{
    string str = Convert.ToString(num);
    switch (num)
    {
        case '1':
            str = "один";
            break;
        case '2':
            str = "два";
            break;
        case '3':
            str = "три";
            break;
        case '4':
            str = "четыре";
            break;
        case '5':
            str = "пять";
            break;
        case '6':
            str = "шесть";
            break;
        case '7':
            str = "семь";
            break;
        case '8':
            str = "восемь";
            break;
        case '9':
            str = "девять";
            break;
        case '0':
            str = "ноль";
            break;
    }
    return str;
}
// проверка при вводе числа с консоли
static int IsNumber(string str)
{
    bool flag;
    int number;
    do
    {
        flag = int.TryParse(str, out number);
        if (!flag)
        {
            Console.WriteLine("Ошибка ввода. Попробуйте еще раз!");
            str = Console.ReadLine();
        }

    } while (!flag);
    return number;
}
// Поиск слов содержащих максимальное количество цифр версия 1.1
static void MaxNumbers(string text)
{
    double max;
    double tmp = 0;
    int k = 0;
    string line = string.Empty;
    string[] Text = text.Split();//создаем строковый массив из слов текста
    Console.Write("Слова из цифр в тексте: ");

    for (int i = 0; i < Text.Length; i++)
    {
        if (double.TryParse(Text[i].Trim(), out max)) // проверяем каждый элемент это число или нет
        {
            Console.Write($"{max} ");
            if (Text[i].TrimStart('-').Replace(",", "").Length > tmp.ToString().Length)// ищем самое длинное число
            {
                tmp = max;
                k = Text[i].TrimStart('-').Replace(",", "").Length;// количество цифр без учета запятой(дробное) и знака числа
            }
        }
    }
    Console.WriteLine();
    for (int i = 0; i < Text.Length; i++)
    {
        if (double.TryParse(Text[i].Trim(), out max))
        {
            if (Text[i].TrimStart('-').Replace(",", "").Length == k)// выбираем из массива числа длинной равные к
            {
                line += Text[i] + " ";
            }
        }

    }
    Console.WriteLine($"Максимальное количество цифр в словах: {line.Trim()},");
}
//Поиск длинного слова и определить, сколько раз оно встретилось в тексте
static void LongestWord(string text)
{
    int k = 0,n=0;
    int len = 0;
    // массив из строки с удалением знаков препинания
    string[] word = text.Split('.', '?', '!', ',', ':', ';', '\"', ' ');
    string tmp = word[0];
    for (int i = 1; i < word.Length; i++)
    {                                       
        if (word[i].Length > tmp.Length) //сравнение длинны слов
        {
            tmp = word[i]; // слова наибольшей длинны
            len = tmp.Length; // определение длинны слова
        }
    }
    Console.WriteLine("*********");
    Console.Write($"Слова с наибольшим количеством символов - {len} : ");
    
    for (int j = 0; j < word.Length; j++)//запись максимальнно длинных слов без повторений
                                         // в одну строку через пробел
    {
        if (word[j].Length == len && tmp.IndexOf(word[j])==-1)
            tmp+=" "+ word[j];
    }
    
    tmp = tmp.Trim();
    
        Console.Write($"{tmp}");
        Console.WriteLine();
    string[] strWord=tmp.Split(' ');//запись в массив длинных слов без повторений
    for (int i = 0; i < strWord.Length; i++)
    {
        string[] Arr = Array.FindAll(word,x=> x==strWord[i]);//находим в массиве текста длинные слова и записываем в массив
        k=Arr.Length;//длинна массива есть количество повторений
        Console.WriteLine("****");
        Console.WriteLine($"Слово {strWord[i]} встречается в тексте {k} раз(а). ");
    }
   
   

}
//Поиск слов содержащих максимальное количество цифр версия 1.2
static void MaxNumbersss(string text)
{
    string temp = "";
    int max = 0, k;
    string[] words = text.Split();
    char[] sumb = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    Console.WriteLine("*********");
    Console.Write("Слова с цифрами в тексте: ");
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].IndexOfAny(sumb) != -1)// ищем слова в которых есть хотяба 1 цифра
        {
            k = 0;
            string tmp = words[i];
            for (int j = 0; j < words[i].Length; j++)
            {
                if (tmp.IndexOfAny(sumb, j, 1) != -1) k++; // считаем цифры в найденых словах
            }

            if (k > max) max = k; //запоминаем максимальное количество цифр

            Console.Write(words[i] + "  ");
            temp += words[i] + " ";
        }
    }
    Console.WriteLine("*********");
    Console.WriteLine($"Максимольное количество цифр в словах {max}.");
    temp = temp.Trim();
    words = temp.Split();// создаем массив из слов с цифрами
    Console.WriteLine("*********");
    Console.Write("Наибольшее количество цифр в следующих словах: ");
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].IndexOfAny(sumb) != -1)
        {
            k = 0;
            string tmp = words[i];
            for (int j = 0; j < words[i].Length; j++)
            {
                if (tmp.IndexOfAny(sumb, j, 1) != -1) k++;
            }

            if (k == max) //выбираем слова с максимальным количеством

                Console.Write(words[i] + "  ");
        }
    }
    Console.WriteLine();
}
//Заменяет цифры от 0 до 9 на слова «ноль», «один», …, «девять»
static void DigitToWord(string text)
{
    string[] word = text.Split();
    char[] sumb = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    string tmp;
    for (int i = 0; i < word.Length; i++)
    {

        if (word[i].IndexOfAny(sumb) != -1)//проверка наличия в слове цифр
        {

            tmp = word[i];
            word[i] = string.Empty;
            for (int j = 0; j < tmp.Length; j++)
            {
                word[i] += IntToString(tmp[j]) + " ";// замена цифр словами
            }
            word[i] = word[i].Trim();
        }
    }

    tmp = String.Join(" ", word);
    Console.WriteLine("*********");
    Console.WriteLine($"Новый текст:\n\t{tmp}");


}
//Выводит на экран сначала вопросительные, а затем восклицательные предложения
static void ShowOffers(string text)
{
    char x = '?';
    char y = '!';
    Console.WriteLine("*********");
    Console.WriteLine("Вопросительные предложения:");
    for (int j = 0; j < 2; j++)
    {
        int index;
        string tmp;
        string[] offers = text.Split(x);//создаем массив с разделителем х=? или х=!
        char[] symb = new char[] { y, '.' };//массив символов
        for (int i = 0; i < offers.Length; i++)
        {
            tmp = offers[i];
            index = tmp.Length - 1;//идекс последнего символа строки
            if (char.IsPunctuation(tmp[index])) continue;//если последний символ строки массива знак пунктуации пропускаем итерацию
            index = offers[i].LastIndexOfAny(symb);//от конца предложения находим первое вхождение точки
            offers[i] = offers[i].Substring(index + 2);//обрезаем строку массива получая искомое предложение
            Console.WriteLine($"{offers[i]}{x}");
        }
        x = '!';
        y = '?';
        Console.WriteLine("*********");
        Console.WriteLine("Восклицательные предложения:");
    }
    //foreach (string r in offers)
    //    Console.WriteLine($"{r.Trim()}\n");
}
//Выводит на экран только предложения, не содержащие запятых.
static void NoCommaSentence(string text)
{
    Console.WriteLine("*********");
    Console.WriteLine("Предложения не содержащие запятые:");
    string[] words = text.Split('.','!','?');
    for(int i=0; i < words.Length; i++)
    {
        if(words[i].IndexOf(',')==-1)//выводит те предложения где нет входящих запятых
            Console.WriteLine(words[i]+'.');
    }
}
//Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
static void StartEndLetter(string text)
{
    // массив из строки с удалением знаков препинания
    string[] word = text.Split('.', '?', '!', ',', ':', ';', '\"', ' ');
   
    string[] TheWords = Array.FindAll(word, x => x.Length>1 && (x[0] == x[^1]));
    Console.WriteLine("*********");
    Console.WriteLine($"Найденные слова: {String.Join(", ",TheWords)}");
}
