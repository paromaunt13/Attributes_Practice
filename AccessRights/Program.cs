/*
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте программу в которой создайте пользовательский атрибут AccessLevelAttribute,
позволяющий определить уровень доступа пользователя к системе. Сформируйте состав
сотрудников некоторой фирмы в виде набора классов, например, Manager, Programmer, Director.
При помощи атрибута AccessLevelAttribute распределите уровни доступа персонала и отобразите
на экране реакцию системы на попытку каждого сотрудника получить доступ в защищенную
секцию.
*/

Console.WriteLine("Введите ваш уровень доступа (1, 2 или 3):");
int num = int.Parse(Console.ReadLine());

Storage storage = new Storage();
storage.AccessTo(num);

public class Storage
{
    Employee[] employees = new Employee[3];
    public Storage()
    {
        employees[0] = new Manager();
        employees[1] = new Programmer();
        employees[2] = new Director();
    }
    public void AccessTo(int accessLevel)
    {
        for (int i = 0; i < accessLevel; i++)
        {
            Console.WriteLine($"Сотрудник: {employees[i].GetType().Name}");
            Type type = employees[i].GetType();
            var attributes = type.GetCustomAttributes(false);
            foreach (AccessLevelAttribute attribute in attributes)
            {
                if (attribute.AccessLevel == accessLevel) 
                    Console.WriteLine("Доступ разрешён!");
                else 
                    Console.WriteLine("Доступ запрёщен!");
            }
        }
    }
}

[AccessLevel(1)]
class Manager : Employee
{

}
[AccessLevel(2)]
class Programmer : Employee
{

}
[AccessLevel(3)]
class Director : Employee
{

}
class Employee
{

}

class AccessLevelAttribute : Attribute
{
    public int AccessLevel { get; }
    public AccessLevelAttribute(int age) => AccessLevel = age;
}