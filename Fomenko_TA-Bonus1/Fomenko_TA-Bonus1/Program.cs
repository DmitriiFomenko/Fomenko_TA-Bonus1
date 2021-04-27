using System;
using System.Collections.Generic;
using System.Linq;

namespace Fomenko_TA_Bonus1
{
    class Program
    {
        static void Main(string[] args)
        {
            string word;
            string temp;
            List<string> steps = new List<string>();
            Console.WriteLine("Примеры ввода:\r\n1>2\r\n2>.3\r\n4>\r\n5>.\r\n>.3\r\n\r\nP.s. Если алгоритм зацикливается, то выведется его последние изменение.\r\n");
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Введите действия. 0 - закончить ввод");
                    temp = Console.ReadLine();
                    if (temp.Equals("0"))
                        break;
                    if (temp.Count(x => x == '.') == 1 && !temp[temp.IndexOf('>') + 1].Equals('.'))
                    {
                        Console.WriteLine("Некорректный ввод!");
                        continue;
                    }
                    if (temp.Count(x => x == '>') != 1 || temp.Count(x => x == '.') > 1)
                        Console.WriteLine("Некорректный ввод!");
                    else
                        steps.Add(temp);
                }

                Console.WriteLine("\r\nВведите слово");
                word = Console.ReadLine();

                while (true)
                {
                    string temp_word = word;
                    foreach (string s in steps)
                    {
                        string s1 = s.Substring(0, s.IndexOf('>'));
                        if (word.Contains(s1))
                        {
                            if (s.Contains("."))
                            {
                                word = word.Remove(word.IndexOf(s1), s1.Length).Insert(word.IndexOf(s1), s.Substring(s.IndexOf('>') + 2));
                                steps.Clear();
                                break;
                            }
                            else
                            {
                                word = word.Remove(word.IndexOf(s1), s1.Length).Insert(word.IndexOf(s1), s.Substring(s.IndexOf('>') + 1));
                                break;
                            }
                        }
                    }
                    if (word.Equals(temp_word))
                        break;
                    else
                        temp_word = word;
                    Console.WriteLine(word);
                }

                Console.WriteLine("Алгоритм завершился.\r\nДля завершения введите 0, иначе введите любой символ.");
                if(Console.ReadLine().Equals("0"))
                    break;

                Console.WriteLine();
            }
        }
    }
}
/*
Примеры ввода:
1>2
2>.3
4>
5>.
>.3

P.s. Если алгоритм зацикливается, то выведется его последние изменение.

Введите действия. 0 - закончить ввод
1>2
Введите действия. 0 - закончить ввод
3>.4
Введите действия. 0 - закончить ввод
0

Введите слово
33114q
33214q
33224q
43224q
Алгоритм завершился.
Для завершения введите 0, иначе введите любой символ.
1

Введите действия. 0 - закончить ввод
123
Некорректный ввод!
Введите действия. 0 - закончить ввод
1.>3
Некорректный ввод!
Введите действия. 0 - закончить ввод
1>
Введите действия. 0 - закончить ввод
2>.2
Введите действия. 0 - закончить ввод
0

Введите слово
11111111111111111132
1111111111111111132
111111111111111132
11111111111111132
1111111111111132
111111111111132
11111111111132
1111111111132
111111111132
11111111132
1111111132
111111132
11111132
1111132
111132
11132
1132
132
32
Алгоритм завершился.
Для завершения введите 0, иначе введите любой символ.
0
 */
