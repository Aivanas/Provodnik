using System;
using System.IO;

namespace Provodnik
{
    public class Print_dir
    {
        public static void ShowDirectory(string dir_path)
        {
            int choosed_line = 0;
            while (true)
            {
                
                
                string[] allDirectories = Directory.GetDirectories(dir_path);
                string[] allFiles = Directory.GetFiles(dir_path);
                Console.WriteLine("----------------------------------------------------------" +
                                  "-----------------------------------------------");
                Console.WriteLine("| F1 - Создать новый файл | F2 - Создать новую директорию | " +
                                  "F3 - Удалить файл | F4 - Удалить директорию |");
                Console.WriteLine("----------------------------------------------------------" +
                                  "-----------------------------------------------");
                Console.WriteLine(dir_path);
                Console.WriteLine("");
            
                foreach (string dir in allDirectories)
                {
                    if (choosed_line == Array.IndexOf(allDirectories, dir))
                    {
                        Console.WriteLine($"----> {dir}");
                    }
                    else
                    {
                        Console.WriteLine($"     {dir}");
                    }
                }

                foreach (string file in allFiles)
                {
                    if (choosed_line == (Array.IndexOf(allFiles, file) + allDirectories.Length))
                    {
                        Console.WriteLine($"----> {file}");
                    }
                    else
                    {
                        Console.WriteLine($"     {file}");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow & choosed_line > 0)
                {
                    choosed_line--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow & choosed_line < (allDirectories.Length + allFiles.Length - 1))
                {
                    choosed_line++;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (choosed_line <= allDirectories.Length)
                    {
                        Print_dir.ShowDirectory(allDirectories[choosed_line]);
                    }
                    
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;

                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.Write("Введите название файла: ");
                    string FileName = Console.ReadLine();
                    File.Create(dir_path + "\\" + FileName);
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.Write("Введите название директории: ");
                    string DirName = Console.ReadLine();
                    Directory.CreateDirectory(dir_path + "\\" + DirName);
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    int DeletingChoosedLine = 0;
                    while (true)
                    {
                        Console.WriteLine($"Вы уверены что хотите удалить файл {allFiles[choosed_line - allDirectories.Length]}?");
                        if (DeletingChoosedLine == 0)
                        {
                            Console.WriteLine("---> Нет");
                            Console.WriteLine("     Да");
                        }
                        else
                        {
                            Console.WriteLine("     Нет");
                            Console.WriteLine("---> Да");
                        }

                        ConsoleKeyInfo deleting_key = Console.ReadKey();

                        if (deleting_key.Key == ConsoleKey.UpArrow & DeletingChoosedLine > 0)
                        {
                            DeletingChoosedLine--;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.DownArrow & DeletingChoosedLine < 1)
                        {
                            DeletingChoosedLine++;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.Enter)
                        {
                            if (DeletingChoosedLine == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                File.Delete(allFiles[choosed_line - allDirectories.Length]);
                                Console.Clear();
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                        }

                    }
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    int DeletingChoosedLine = 0;
                    while (true)
                    {
                        Console.WriteLine($"Вы уверены что хотите удалить директорию {allDirectories[choosed_line]}?");
                        if (DeletingChoosedLine == 0)
                        {
                            Console.WriteLine("---> Нет");
                            Console.WriteLine("     Да");
                        }
                        else
                        {
                            Console.WriteLine("     Нет");
                            Console.WriteLine("---> Да");
                        }

                        ConsoleKeyInfo deleting_key = Console.ReadKey();

                        if (deleting_key.Key == ConsoleKey.UpArrow & DeletingChoosedLine > 0)
                        {
                            DeletingChoosedLine--;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.DownArrow & DeletingChoosedLine < 1)
                        {
                            DeletingChoosedLine++;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.Enter)
                        {
                            if (DeletingChoosedLine == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                DeleteDirectory(allDirectories[choosed_line]);
                                Directory.Delete(allDirectories[choosed_line]);
                                Console.Clear();
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                
                
                
                else
                {
                    Console.Clear();
                }
                
            }
            

        }

        public static void DeleteDirectory(string dir_path)
        {
            string[] allDirectories = Directory.GetDirectories(dir_path);
            string[] allFiles = Directory.GetFiles(dir_path);

            foreach (var file in allFiles)
            {
                File.Delete(file);
            }

            foreach (var directory in allDirectories)
            {
                DeleteDirectory(directory);
                Directory.Delete(directory);
            }
        }
    }
}