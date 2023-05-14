/*
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте программу в которой создайте класс и примените к его методам атрибут Obsolete
сначала в форме, просто выводящей предупреждение, а затем в форме, препятствующей
компиляции. Продемонстрируйте работу атрибута на примере вызова данных методов.
*/

MyClass myClass = new();
myClass.Method();
myClass.MethodError();
class MyClass
{
    [Obsolete("Этот метод устарел")]
    public void Method()
    {
    
    }
    [Obsolete("Этот метод не скомпилириуется", true)]
    public void MethodError()
    {

    }
}