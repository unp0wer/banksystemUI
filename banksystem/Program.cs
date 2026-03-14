using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace banksystem
{

    internal class Program
    {

        static void Main(string[] args)
        {
            #region 初始化
            AdminDAL adminDAL = new AdminDAL();
            SuperDAL superDAL = new SuperDAL();
            UserDAL userDAL = new UserDAL();
            AdressDAL adressDAL = new AdressDAL();
            Console.Title = "银行管理系统";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------欢迎登录银行客户管理系统(Version 1.0.0)------");
            Console.ForegroundColor = ConsoleColor.White;
        #endregion
        #region 登录
        Login:
            Console.WriteLine("请选择登录方式： 1.普通管理员  2.超级管理员");
            int.TryParse(Console.ReadLine(), out int powerNum);
            if (!(powerNum == 1 || powerNum == 2))
            {
                Console.WriteLine("输入格式或数字错误，请正确选择");
                goto Login;
            }
            Console.Write("请输入账号：");
            string account = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(account))
            {
                Console.WriteLine("账号不能为空");
                goto Login;
            }
            Console.WriteLine("请输入密码：");
            string password = "";
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                password += keyInfo.KeyChar;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("密码不能为空");
                goto Login;
            }
            bool loginSucess;
            if (powerNum == 1)
            {

                loginSucess = adminDAL.Login(account, password);
            }
            else
            {
                loginSucess = superDAL.Login(account, password);
            }

            if (!loginSucess)
            {
                Console.WriteLine("账号或密码错误，请重新输入");
                goto Login;
            }
        #endregion
        #region 菜单
        Menu:
            Console.ForegroundColor = ConsoleColor.Red;
            if(powerNum==2)
            {
             Console.WriteLine("1.添加管理员        2.修改管理员       3.删除管理员       4.查询管理员  ");
            }
             Console.WriteLine("a.添加用户          b.修改用户         c.删除用户         d.查询用户");
             Console.WriteLine("e.添加地址          f.修改地址         g.删除地址         h.查询地址       exit.退出登录 ");

            Console.ForegroundColor = ConsoleColor.White;
            string order = Console.ReadLine();
            if(!string.IsNullOrEmpty(order)&&(order.ToCharArray()[0])>= '0'&&(order.ToCharArray()[0])<='9'&&powerNum==1)
            {
                Console.WriteLine("权限不足，无法进行管理员操作");
                goto Menu;
            }
            switch (order)
            {

                case "1":
                    Console.WriteLine("请输入要添加的管理员，格式为:id,账号,密码");
                    string[] addadmin = Console.ReadLine().Split(',');
                    if (addadmin.Length != 3 || !int.TryParse(addadmin[0], out int addadminId))
                    {
                        Console.WriteLine("输入格式错误");
                        goto Menu;
                    }
                    if (adminDAL.Find(addadminId) != null)
                    { Console.WriteLine("管理员已存在"); goto Menu; }
                    else
                    {
                        adminDAL.Add(new Admin
                        {
                            Id = addadminId,
                            account = addadmin[1],
                            password = addadmin[2]
                        });
                        Console.WriteLine($"增加后的管理员列表为\n{adminDAL}");
                        goto Menu;
                    }
                case "2":
                    Console.WriteLine("请输入要修改的管理员id");
                    if (!int.TryParse(Console.ReadLine(), out int changeId) && changeId <= 0)
                    {
                        Console.WriteLine("请输入正整数");
                    }
                    Console.WriteLine($"该用户的信息为{adminDAL.Find(changeId)}");
                    Console.WriteLine("请输入修改后的管理员信息，格式为:账号,密码");
                    string[] changeadmin = Console.ReadLine().Split(',');
                    if (changeadmin.Length != 2)
                    {
                        Console.WriteLine("输入格式错误");
                        goto Menu;
                    }
                    else
                    {
                        adminDAL.Change(new Admin
                        {
                            Id = changeId,
                            account = changeadmin[0],
                            password = changeadmin[1],
                            CreatTime = adminDAL.Find(changeId).CreatTime
                        }
                           );
                        Console.WriteLine($"修改后的管理员列表为\n{adminDAL}");
                    }
                    goto Menu;
                case "3":
                    Console.WriteLine("请输入要删除的管理员id");
                    if (!int.TryParse(Console.ReadLine(), out int deleteId) && deleteId <= 0)
                    {
                        Console.WriteLine("请输入正整数类型的参数");
                        goto Menu;
                    }
                    adminDAL.Delete(deleteId);
                    Console.WriteLine($"删除后的管理员列表为：\n{adminDAL}");
                    goto Menu;
                case "4":
                    Console.WriteLine("请输入要查询的管理员id");
                    if (!int.TryParse(Console.ReadLine(), out int findId) && findId <= 0)
                    {
                        Console.WriteLine("请输入正整数类型的参数");
                    }
                    Console.WriteLine($"管理员信息为{adminDAL.Find(findId)}");
                    goto Menu;

                case "a":
                    Console.WriteLine("请输入要添加的用户，格式为:id,账号,密码");
                    string[] addUser = Console.ReadLine().Split(',');
                    if (addUser.Length != 3 || !int.TryParse(addUser[0], out int addUserId))
                    {
                        Console.WriteLine("输入格式错误");
                        goto Menu;
                    }
                    if (adressDAL.Find(addUserId) != null)
                    { Console.WriteLine("用户已存在"); goto Menu; }
                    else
                    {
                        userDAL.Add(new User
                        {
                            Id = addUserId,
                            account = addUser[1],
                            password = addUser[2]
                        });
                        Console.WriteLine($"增加后的用户列表为\n{userDAL}");
                        goto Menu;
                    }
                case "b":
                    Console.WriteLine("请输入要修改的用户id");
                    if (!int.TryParse(Console.ReadLine(), out int changeUserId) && changeUserId <= 0)
                    {
                        Console.WriteLine("请输入正整数");
                    }
                    Console.WriteLine($"该用户的信息为{userDAL.Find(changeUserId)}");
                    Console.WriteLine("请输入修改后的用户信息，格式为:账号,密码");
                    string[] changeUser = Console.ReadLine().Split(',');
                    if (changeUser.Length != 2)
                    {
                        Console.WriteLine("输入格式错误");
                        goto Menu;
                    }
                    else
                    {
                        userDAL.Change(new User
                        {
                            Id = changeUserId,
                            account = changeUser[0],
                            password = changeUser[1],
                            CreatTime = userDAL.Find(changeUserId).CreatTime
                        }
                           );
                        Console.WriteLine($"修改后的用户列表为\n{userDAL}");

                    }
                    goto Menu;
                case "c":
                    Console.WriteLine("请输入要删除的用户id");
                    if (!int.TryParse(Console.ReadLine(), out int deleteUserId) && deleteUserId <= 0)
                    {
                        Console.WriteLine("请输入正整数类型的参数");
                        goto Menu;
                    }
                    userDAL.Delete(deleteUserId);
                    Console.WriteLine($"删除后的用户列表为：\n{userDAL}");
                    goto Menu;
                case "d":
                    Console.WriteLine("请输入要查询的用户id");
                    if (!int.TryParse(Console.ReadLine(), out int findUserId) && findUserId <= 0)
                    {
                        Console.WriteLine("请输入正整数类型的参数");
                    }
                    Console.WriteLine($"用户信息为{userDAL.Find(findUserId)}");
                    goto Menu;



                case "e":
                    Console.WriteLine("请输入要添加的地址，格式为:id,省，市，县，路，号");
                    string[] addAdress = Console.ReadLine().Split(',');
                    if (addAdress.Length != 6 || !int.TryParse(addAdress[0], out int addAdressId))
                    {
                        Console.WriteLine("输入格式错误");
                        goto Menu;
                    }
                    if (adressDAL.Find(addAdressId) != null)
                    { Console.WriteLine("地址已存在"); goto Menu; }
                    else
                    {
                        adressDAL.Add(addAdressId, new Adress
                        {
                            Provice = addAdress[1],
                            City = addAdress[2],
                            County = addAdress[3],
                            Road = addAdress[4],
                            Number = addAdress[5],
                        });
                        Console.WriteLine($"增加后的地址列表为\n{adressDAL}");
                        goto Menu;
                    }
                case "f":
                    Console.WriteLine("请输入要修改的地址id");
                    if (!int.TryParse(Console.ReadLine(), out int changeAdressId) && changeAdressId <= 0)
                    {
                        Console.WriteLine("请输入正整数");
                    }
                    Console.WriteLine($"该地址的信息为{adressDAL.Find(changeAdressId)}");
                    Console.WriteLine("请输入修改后的地址信息，格式为:省，市，县，路，号");
                    string[] changeAdress = Console.ReadLine().Split(',');
                    if (changeAdress.Length != 5)
                    {
                        Console.WriteLine("输入格式错误");
                        goto Menu;
                    }
                    else
                    {
                        adressDAL.Change(changeAdressId, new Adress
                        {
                            Provice = changeAdress[0],
                            City = changeAdress[1],
                            County = changeAdress[2],
                            Road = changeAdress[3],
                            Number = changeAdress[4],
                        }
                           );
                        Console.WriteLine($"修改后的地址列表为\n{adressDAL}");

                    }
                    goto Menu;
                case "g":
                    Console.WriteLine("请输入要删除的地址id");
                    if (!int.TryParse(Console.ReadLine(), out int deleteAdressId) && deleteAdressId <= 0)
                    {
                        Console.WriteLine("请输入正整数类型的参数");
                        goto Menu;
                    }
                    adressDAL.Delete(deleteAdressId);
                    Console.WriteLine($"删除后的地址列表为：\n{adressDAL}");
                    goto Menu;
                case "h":
                    Console.WriteLine("请输入要查询的地址id");
                    if (!int.TryParse(Console.ReadLine(), out int findAdressId) && findAdressId <= 0)
                    {
                        Console.WriteLine("请输入正整数类型的参数");
                    }
                    Console.WriteLine($"地址信息为{adressDAL.Find(findAdressId)}");
                    goto Menu;

                case "exit":
                    if (powerNum == 1)
                    { adminDAL.Logout(); }
                    else
                    {
                        superDAL.Logout();
                    }
                    Console.Clear();
                    goto Login;

                default:
                    Console.WriteLine("输入指令错误，请重新输入");
                    goto Menu;
            }
            #endregion
        }
    }
}
